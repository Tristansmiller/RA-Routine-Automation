using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using RAInterface;

namespace RA_Application
{
    public partial class MainForm : Form
    {

        #region Initialization & Class Variables
        //Opens when the play button is pressed - controls the actual playback of a file and has controls for speed/loops.
        private PlaybackForm playbackForm;
        //Opens when the settings button is pressed - has a field for setting the macro.
        private SettingsForm macroForm;
        private SchedulerForm schedulerForm;
        //The macro for start/stop recording/playback
        private List<int> macroKeys;
        private RAController raController;
        public MainForm()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            raController = new RAController();
            //init forms
            playbackForm = new PlaybackForm(raController);
            macroForm = new SettingsForm();
            schedulerForm = new SchedulerForm(raController);



            // load in the current macro setting
            try
            {
                macroKeys = new List<int>(MacroLoader.loadMacro(Directory.GetCurrentDirectory() + "/macro.config"));
            } catch(FileNotFoundException ex)
            {
                Console.WriteLine("Process is being controller by System");
                macroKeys = new List<int>(MacroLoader.loadMacro(Environment.GetCommandLineArgs()[1]));
                Console.WriteLine(ex);
            }
            RoutineListener.Start(macroKeys.ToArray());


        }
        //state that is used to change the status text at the top of the form
        private enum RecordingStatus { Recording,Waiting,NotRecording}
        RecordingStatus currStatus = RecordingStatus.NotRecording;
        private bool isFileText = true;
        private bool isDLLDirectorySet = false;
        private bool isLocked = false;//used to check whether the window is currently locked in place/on top - lock button controls this.
        private bool isCurrentlyPlayingBack = false;
        private bool isCurrentlyRecording = false;
        private bool isScrollingText = false;//used by the text scroll timer to control the bottom panel's text.
        private int scrollDelayTicker = 0;//used to control the speed the text scrolls at
        private int scrollCounter = 0;//used to control the speed the text scrolls at
        private string currFile = "";//the current file that is loaded.
        #endregion

        #region Weird stuff for borderless window
        //This stuff allows the window to be "locked" in place. No idea how it works. Copy pasted from Stack Overflow
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            if (!isLocked)
            {
                base.WndProc(ref m);
                if (m.Msg == WM_NCHITTEST)
                    m.Result = (IntPtr)(HT_CAPTION);
            }
        }
        #endregion

        #region Load Button
        //Opens the a file explorer dialog to set the current file.
        private void loadButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "RA files (*.ar)|*.ar";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string targetFile = fileDialog.FileName;
                bottomPanelText.Text = targetFile;
                currFile = targetFile;
            }

        }

        //these two functions toggle the orange image so the user can see when they are hovering the button.
        private void loadButton_MouseEnter(object sender, EventArgs e)
        {
            loadButton.ImageIndex = 1;
        }
        private void loadButton_MouseLeave(object sender, EventArgs e)
        {
            loadButton.ImageIndex = 0;
        }
        #endregion

        #region Lock Button

        //these functions facillitate setting the window on top, and changing the images of the lock button.
        //0 = unlocked, 1 = locked, 2 = unlock hover, 3 = locked hover
        private void LockButton_Click(object sender, EventArgs e)
        {
            if (LockButton.ImageIndex == 0 || LockButton.ImageIndex == 2)
            {
                LockButton.ImageIndex = 3;
                isLocked = true;
                MainForm.ActiveForm.TopMost = true;
            }
            else
            {
                LockButton.ImageIndex = 2;
                isLocked = false;
                MainForm.ActiveForm.TopMost = false;
            }
        }
        private void LockButton_MouseEnter(object sender, EventArgs e)
        {
            if(LockButton.ImageIndex == 0)
            {
                LockButton.ImageIndex = 2;
            }
            else if(LockButton.ImageIndex == 1)
            {
                LockButton.ImageIndex = 3;
            }
        }
        private void LockButton_MouseLeave(object sender, EventArgs e)
        {
            if(LockButton.ImageIndex == 2)
            {
                LockButton.ImageIndex = 0;
            }
            else if(LockButton.ImageIndex == 3)
            {
                LockButton.ImageIndex = 1;
            }
        }
        #endregion

        #region Min Button
        //minimizes the form.
        private void MinButton_Click(object sender, EventArgs e)
        {
            isLocked = false;
            LockButton.ImageIndex = 0;
            this.WindowState = FormWindowState.Minimized;
        }
        private void MinButton_MouseEnter(object sender, EventArgs e)
        {
            MinButton.ImageIndex = 1;
        }
        private void MinButton_MouseLeave(object sender, EventArgs e)
        {
            MinButton.ImageIndex = 0;
        }
        #endregion

        #region Close Button
        //Closes the form.
        private void CloseButton_Click(object sender, EventArgs e)
        {
            isLocked = false;
            RoutineListener.Stop();
            this.Close();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ImageIndex = 1;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ImageIndex = 0;
        }
        #endregion

        #region Play Button
        //Opens the playback form that facillitates playing back the current file loaded.
        private void playButton_Click(object sender, EventArgs e)
        {
            //check to see that nothing is currently playing back or recording and that there is a file loaded.
            if (!isCurrentlyPlayingBack && !isCurrentlyRecording && currFile != "")
            {
                isCurrentlyPlayingBack = true;
                playButton.ImageIndex = 1;
                //open the playback form, pass it the macro, current file, and location to open at.
                playbackForm.showForm(currFile,this.Location,macroKeys.ToArray<int>());
                //turns on the playback timer that waits for the playback to end and changes the status text
                PlaybackTimer.Enabled = true;
                bottomPanelText.Text = "Press your control macro to start/stop.";
            }
        }
        private void playButton_MouseEnter(object sender, EventArgs e)
        {
            playButton.ImageIndex = 1;
        }
        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            if (!isCurrentlyPlayingBack)
            {
                playButton.ImageIndex = 0;
            }
        }
        #endregion

        #region Record Button
        //Spins up a new thread that begins the recording process.
        private void recordButton_Click(object sender, EventArgs e)
        {
            //opens a dialog to choose the file name desired for the new recording.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RA files (*.ar)|*.ar";
            DialogResult res = sfd.ShowDialog();
            //if the dialog successfully creates a file name
            if (res == DialogResult.OK)
            {
                string targetFile = sfd.FileName;
                currFile = targetFile;
                //check to make sure nothing else is happening, otherwise - bail.
                if (!isCurrentlyPlayingBack && !isCurrentlyRecording)
                {
                    bottomPanelText.Text = "Press your control macro to start/stop.";
                    isCurrentlyRecording = true;
                    recordButton.ImageIndex = 1;
                    //spin up a new thread and give it the auxiliary record function + filepath
                    Thread recordingThread = new Thread(() => recordWrapper(targetFile));
                    recordingThread.Start();
                    //turn on status ticker
                    RecordStatusUpdater.Enabled = true;
                }
            }

        }
        //auxiliary function that performs the actual recording.
        private void recordWrapper(string filepath)
        {
            //get an int array of virtual keys for the macro
            int[] macroArr = macroKeys.ToArray<int>();
            //wait for macro press before starting recording
            currStatus = RecordingStatus.Waiting;
            raController.watchForStartSequence(macroArr);
            //begin recording, macro press will end the recording.
            currStatus = RecordingStatus.Recording;
            raController.recordActivity(filepath);
            //finished recording, reset all class variables.
            isCurrentlyRecording = false;
            currStatus = RecordingStatus.NotRecording;
            recordButton.ImageIndex = 0;
        }
        private void recordButton_MouseEnter(object sender, EventArgs e)
        {
            recordButton.ImageIndex = 1;
        }
        private void recordButton_MouseLeave(object sender, EventArgs e)
        {
            if (!isCurrentlyRecording)
            {
                recordButton.ImageIndex = 0;
            }
        }
        #endregion

        #region Settings Button
        private void Scheduler_Click(object sender, EventArgs e)
        {
            schedulerForm.showForm(this.Location);
        }
        private void Scheduler_MouseEnter(object sender, EventArgs e)
        {
            Scheduler.ImageIndex = 1;
        }
        private void Scheduler_MouseLeave(object sender, EventArgs e)
        {
            Scheduler.ImageIndex = 0;
        }
        private void SettingButton_MouseEnter(object sender, EventArgs e)
        {
            SettingButton.ImageIndex = 1;
        }

        private void SettingButton_MouseLeave(object sender, EventArgs e)
        {
            SettingButton.ImageIndex = 0;
        }
        private void SettingButton_Click(object sender, EventArgs e)
        {
            macroForm.showForm(this.Location);
            MacroSettingTimer.Enabled = true;
        }
        #endregion

        #region Timers
        //Timer for updating the status text located at the top of the form.
        private void RecordStatusUpdater_Tick(object sender, EventArgs e)
        {
            if(currStatus == RecordingStatus.NotRecording)
            {
                StatusLabel.Text = "";
                RecordStatusUpdater.Enabled = false;
            }
            else if(currStatus == RecordingStatus.Waiting && StatusLabel.Text!="Waiting...")
            {
                StatusLabel.Text = "Waiting...";
            }
            else if(currStatus == RecordingStatus.Recording && StatusLabel.Text != "Recording...")
            {
                StatusLabel.Text = "Recording...";
            }

        }
        //timer for changing class variable for playback state and changing the status text at the end of playback
        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (!playbackForm.isPlayingBack)
            {
                playButton.ImageIndex = 0;
                PlaybackTimer.Enabled = false;
                isCurrentlyPlayingBack = false;
            }
            if(playbackForm.status == PlaybackForm.PlaybackStatus.Nothing && StatusLabel.Text!="")
            {
                StatusLabel.Text = "";
            }
            else if(playbackForm.status == PlaybackForm.PlaybackStatus.Waiting && StatusLabel.Text != "Waiting...")
            {
                StatusLabel.Text = "Waiting...";
            }
            else if(playbackForm.status == PlaybackForm.PlaybackStatus.Running && StatusLabel.Text != "Playing...")
            {
                StatusLabel.Text = "Playing...";
            }

        }

        //Timer that waits for the macro form to close and then writes the new macro out to the macro.config file
        private void MacroSettingTimer_Tick(object sender, EventArgs e)
        {
            if (macroForm.hasWrittenNewMacro)
            {
                macroKeys = macroForm.keyCodes;
                while (macroKeys.Count < 4)
                {
                    macroKeys.Add(0);
                }
                int[] macroArr = macroKeys.ToArray<int>();
                StreamWriter sw = new StreamWriter("../../macro.config",false);
                sw.WriteLine(macroArr[0] + "," + macroArr[1] + "," + macroArr[2] + "," + macroArr[3]);
                sw.Close();
                MacroSettingTimer.Enabled = false;
            }
        }

        //Timer that controls scrolling the text on the bottom panel.
        private void TextScrollTimer_Tick(object sender, EventArgs e)
        {
            if (bottomPanelText.Text.Length >= 40)
            {
                scrollCounter = scrollCounter + 1;
                bottomPanelText.Text = bottomPanelText.Text.Substring(1, bottomPanelText.Text.Length - 1);
                isScrollingText = true;
            }
            else if (isScrollingText)
            {
                if (scrollDelayTicker < 4)
                {
                    scrollDelayTicker++;
                }
                else
                {
                    scrollDelayTicker = 0;
                    if (isCurrentlyRecording || isCurrentlyPlayingBack)
                    {
                        bottomPanelText.Text = "Press your control macro to start/stop.";
                    }
                    else
                    {
                        bottomPanelText.Text = currFile;
                    }
                    isScrollingText = false;
                }
            }

        }
        #endregion


    }
}

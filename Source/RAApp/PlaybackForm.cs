using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using RAInterface;

namespace RA_Application
{
    public partial class PlaybackForm : Form
    {

        #region Class Variables
        private float speed;// speed of the playback in decimal percent format i.e. .5 = 81%
        private int loops;//number of times to repeat the playback
        private string filepath;//file path for the routine file
        public enum PlaybackStatus { Nothing,Waiting,Running }
        public PlaybackStatus status;
        public bool isPlayingBack;
        //thread that facillitates the initial macro lock, and runs the interpreter
        Thread playbackThread;
        //thread that interrupts the interpreter
        Thread abortControlThread;
        //array of virtual keys for the macro that starts/stop playback/recording
        private int[] macroVKs;
        private RAController raController;
        #endregion

        #region Initialization
        public PlaybackForm(RAController rac)
        {
            raController = rac;
            InitializeComponent();
            speed = 1;
            loops = 1;
            status = PlaybackStatus.Nothing;
            this.Show();
            this.Hide();
        }
        #endregion

        public void showForm(string fp, Point location, int[] macroKeys)
        {
            //sets the location so that this form appears on top of wherever the main form is
            this.Location = location;
            macroVKs = macroKeys;
            //makes the form visible
            this.Show();
            filepath = fp;
            isPlayingBack = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            speed = float.Parse(SpeedBox.Text)/100;
            loops = int.Parse(LoopBox.Text);
            //spins up the playback thread so that the gui is free to continue while playback occurs
            playbackThread = new Thread(() => playWrapper(filepath, speed, loops));
            playbackThread.Start();
            //closes the form.
            this.Hide();           
        }
        //function for the thread that interrupts a playback sequence.
        private void abortWrapper()
        {
            //block until the macro is hit, then set flags to stop the interpreter.
            raController.interruptInterpreterSequence(macroVKs);
            //clean up
            isPlayingBack = false;
            status = PlaybackStatus.Nothing;
        }
        //function for the thread that actually performs the playback
        private void playWrapper(string filepath, float speed, int loops)
        {
            //block until the macro is pressed
            status = PlaybackStatus.Waiting;
            raController.watchForStartSequence(macroVKs);

            status = PlaybackStatus.Running;
            //spin up the thread that can interrupt the playback
            abortControlThread = new Thread(() => abortWrapper());
            abortControlThread.Start();
            //run the interpreter to read the routine file and execute the action node sequence
            raController.executeAutomatedRoutine(filepath, speed, loops);
            //clean up
            if (abortControlThread.IsAlive)
            {
                abortControlThread.Abort();
            }
            isPlayingBack = false;
            status = PlaybackStatus.Nothing;
        }
    }
}

using RAInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_Application
{
    public partial class SchedulerForm : Form
    {
        private RoutineScheduler routineScheduler;
        private string targetFile;
        public SchedulerForm(RAController rac)
        {
            InitializeComponent();
            routineScheduler = new RoutineScheduler(rac);
            targetFile = "";
            refreshScheduleTable();
            this.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void showForm(Point location)
        {
            //sets the location so that this form appears on top of wherever the main form is
            this.Location = location;
            //makes the form visible
            this.Show();
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "RA files (*.ar)|*.ar";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                targetFile = fileDialog.FileName;
                RoutineNameBox.Text = targetFile.Substring(targetFile.LastIndexOf("\\")+1);
            }
        }
        private void LoadButton_MouseEnter(object sender, EventArgs e)
        {
            LoadButton.ImageIndex = 1;
        }
        private void LoadButton_MouseLeave(object sender, EventArgs e)
        {
            LoadButton.ImageIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = DatePicker.Value;
                DateTime time = TimePicker.Value;
                DateTime executionTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                RoutineScheduler.IntervalType interval;
                interval = ((RoutineScheduler.IntervalType)IntervalDropdown.SelectedIndex+1);
                if(targetFile != "")
                {
                    if (!File.Exists(targetFile))
                    {
                        throw new FileNotFoundException();
                    }
                }
                if(DateTime.Now.Ticks > executionTime.Ticks)
                {
                    throw new InvalidTimeException();
                }
                if (!routineScheduler.scheduleTask(targetFile, executionTime, interval))
                {
                    throw new OverlappingTaskException();
                }
                this.Hide();
                refreshScheduleTable();
            } catch(FileNotFoundException ex)
            {
                ErrorText.Text = "Selected File Does Not Exist";
            } catch(InvalidTimeException ex)
            {
                ErrorText.Text = "Time must be in the future.";
            } catch(OverlappingTaskException ex)
            {
                ErrorText.Text = "A Task is scheduled for this time.";
            } catch(Exception ex)
            {
                ErrorText.Text = "Unexpected error occured.";
            }

        }

        private class InvalidTimeException : Exception
        {
        }
        private class OverlappingTaskException : Exception { }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void refreshScheduleTable()
        {
            Microsoft.Win32.TaskScheduler.Task[] tasks = routineScheduler.getSchedule();
            tabPage2.Controls.Clear();
            tasks.OrderBy(i => i.NextRunTime.Ticks).ToArray();
            Point baseLocation = new Point(8, 34);
            Point panelSize = new Point(416, 35);
            Point routineNameLocation = new Point(3, 11);
            Point runtimeLocation = new Point(114, 11);
            Point startTimeLocation = new Point(201, 11);
            Point deleteButtonLocation = new Point(363, 3);
            Panel outerPanel = new Panel();
            outerPanel.Size = new Size(426, 215);
            outerPanel.Location = baseLocation;
            outerPanel.AutoScroll = true;
            for(int j = 0;j < tasks.Length; j++)
            {
                Panel innerPanel = new Panel();
                innerPanel.Size = new Size(416, 35);
                innerPanel.Location = new Point(0, 40 * j);

                Label taskName = new Label();
                string taskDesc = tasks[j].Definition.RegistrationInfo.Description;
                taskName.Text = taskDesc.Substring(taskDesc.LastIndexOf("\\")+1);
                taskName.Location = routineNameLocation;
                taskName.ForeColor = Color.White;

                Label taskRuntimeLabel = new Label();
                taskRuntimeLabel.AutoSize = true;
                string taskRoutinePath = routineScheduler.getRoutinePathFromTask(tasks[j]);
                double taskRuntime = routineScheduler.getRoutineRuntime(taskRoutinePath);
                taskRuntimeLabel.Location = runtimeLocation;
                int minutes = (int)(taskRuntime / 60000);
                int seconds = (int)(taskRuntime % 60000)/1000;
                taskRuntimeLabel.Text = minutes + "m " + seconds + "s";
                taskRuntimeLabel.ForeColor = Color.White;

                Label taskStartTimeLabel = new Label();
                taskStartTimeLabel.AutoSize = true;
                taskStartTimeLabel.Location = startTimeLocation;
                taskStartTimeLabel.Text = tasks[j].NextRunTime.ToString();
                taskStartTimeLabel.ForeColor = Color.White;
              //  taskStartTimeLabel.Anchor = AnchorStyles.Left;

                Button deleteTaskButton = new Button();
                Microsoft.Win32.TaskScheduler.Task taskToDelete = tasks[j];
                deleteTaskButton.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        routineScheduler.deleteTask(taskToDelete);
                        refreshScheduleTable();
                    }
                );
                deleteTaskButton.Location = deleteButtonLocation;
                deleteTaskButton.Size = new Size(50, 29);
                deleteTaskButton.ForeColor = Color.White;
                deleteTaskButton.BackColor = Color.FromArgb(255, 89, 0);
                deleteTaskButton.Text = "Delete";
                deleteTaskButton.FlatStyle = FlatStyle.Flat;


                innerPanel.Controls.Add(taskName);
                innerPanel.Controls.Add(taskRuntimeLabel);
                innerPanel.Controls.Add(taskStartTimeLabel);
                innerPanel.Controls.Add(deleteTaskButton);

                outerPanel.Controls.Add(innerPanel);
            }
            tabPage2.Controls.Add(outerPanel);
        }

        private void ScheduleRefreshTimer_Tick(object sender, EventArgs e)
        {
         
        }

        private void RoutineNameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

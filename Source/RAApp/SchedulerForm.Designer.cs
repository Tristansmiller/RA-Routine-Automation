namespace RA_Application
{
    partial class SchedulerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulerForm));
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RoutineNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ScheduleNew = new System.Windows.Forms.TabPage();
            this.IntervalDropdown = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ErrorText = new System.Windows.Forms.TextBox();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.LoadButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ScheduleRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.ScheduleNew.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(111, 46);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(200, 20);
            this.DatePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(135, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Schedule A Routine";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(60, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date";
            // 
            // RoutineNameBox
            // 
            this.RoutineNameBox.Location = new System.Drawing.Point(111, 161);
            this.RoutineNameBox.Name = "RoutineNameBox";
            this.RoutineNameBox.ReadOnly = true;
            this.RoutineNameBox.Size = new System.Drawing.Size(198, 20);
            this.RoutineNameBox.TabIndex = 3;
            this.RoutineNameBox.TextChanged += new System.EventHandler(this.RoutineNameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(39, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Routine";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ScheduleNew);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(441, 263);
            this.tabControl1.TabIndex = 5;
            // 
            // ScheduleNew
            // 
            this.ScheduleNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.ScheduleNew.Controls.Add(this.IntervalDropdown);
            this.ScheduleNew.Controls.Add(this.label8);
            this.ScheduleNew.Controls.Add(this.button1);
            this.ScheduleNew.Controls.Add(this.ErrorText);
            this.ScheduleNew.Controls.Add(this.TimePicker);
            this.ScheduleNew.Controls.Add(this.label4);
            this.ScheduleNew.Controls.Add(this.button2);
            this.ScheduleNew.Controls.Add(this.LoadButton);
            this.ScheduleNew.Controls.Add(this.label1);
            this.ScheduleNew.Controls.Add(this.label3);
            this.ScheduleNew.Controls.Add(this.DatePicker);
            this.ScheduleNew.Controls.Add(this.RoutineNameBox);
            this.ScheduleNew.Controls.Add(this.label2);
            this.ScheduleNew.Location = new System.Drawing.Point(4, 22);
            this.ScheduleNew.Name = "ScheduleNew";
            this.ScheduleNew.Padding = new System.Windows.Forms.Padding(3);
            this.ScheduleNew.Size = new System.Drawing.Size(433, 237);
            this.ScheduleNew.TabIndex = 0;
            this.ScheduleNew.Text = "Create";
            // 
            // IntervalDropdown
            // 
            this.IntervalDropdown.FormattingEnabled = true;
            this.IntervalDropdown.Items.AddRange(new object[] {
            "Hourly",
            "Every Six Hours",
            "Every Twelve Hours",
            "Daily",
            "Weekly",
            "Monthly",
            "Once"});
            this.IntervalDropdown.Location = new System.Drawing.Point(111, 122);
            this.IntervalDropdown.Name = "IntervalDropdown";
            this.IntervalDropdown.Size = new System.Drawing.Size(200, 21);
            this.IntervalDropdown.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(39, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "Interval";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(89)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.button1.Location = new System.Drawing.Point(111, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorText
            // 
            this.ErrorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.ErrorText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ErrorText.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorText.ForeColor = System.Drawing.Color.Red;
            this.ErrorText.Location = new System.Drawing.Point(111, 190);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(200, 12);
            this.ErrorText.TabIndex = 23;
            // 
            // TimePicker
            // 
            this.TimePicker.CalendarForeColor = System.Drawing.Color.Transparent;
            this.TimePicker.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.TimePicker.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.TimePicker.CalendarTitleForeColor = System.Drawing.Color.Transparent;
            this.TimePicker.CalendarTrailingForeColor = System.Drawing.Color.Transparent;
            this.TimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimePicker.Location = new System.Drawing.Point(111, 83);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.Size = new System.Drawing.Size(200, 20);
            this.TimePicker.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(60, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "Time";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(89)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.button2.Location = new System.Drawing.Point(234, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.AccessibleName = "LoadButton";
            this.LoadButton.BackColor = System.Drawing.Color.Transparent;
            this.LoadButton.FlatAppearance.BorderSize = 0;
            this.LoadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.LoadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadButton.ImageIndex = 0;
            this.LoadButton.ImageList = this.LoadButtonImages;
            this.LoadButton.Location = new System.Drawing.Point(315, 148);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(48, 36);
            this.LoadButton.TabIndex = 5;
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            this.LoadButton.MouseEnter += new System.EventHandler(this.LoadButton_MouseEnter);
            this.LoadButton.MouseLeave += new System.EventHandler(this.LoadButton_MouseLeave);
            // 
            // LoadButtonImages
            // 
            this.LoadButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LoadButtonImages.ImageStream")));
            this.LoadButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.LoadButtonImages.Images.SetKeyName(0, "FolderIcon32.png");
            this.LoadButtonImages.Images.SetKeyName(1, "FolderIcon32Hover.png");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(433, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Schedule";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(209, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Next Start Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(122, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "Runtime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Routine Name";
            // 
            // ScheduleRefreshTimer
            // 
            this.ScheduleRefreshTimer.Enabled = true;
            this.ScheduleRefreshTimer.Interval = 60000;
            this.ScheduleRefreshTimer.Tick += new System.EventHandler(this.ScheduleRefreshTimer_Tick);
            // 
            // SchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(440, 260);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SchedulerForm";
            this.Text = "SchedulerForm";
            this.tabControl1.ResumeLayout(false);
            this.ScheduleNew.ResumeLayout(false);
            this.ScheduleNew.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RoutineNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ScheduleNew;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList LoadButtonImages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker TimePicker;
        private System.Windows.Forms.TextBox ErrorText;
        private System.Windows.Forms.Timer ScheduleRefreshTimer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox IntervalDropdown;
    }
}
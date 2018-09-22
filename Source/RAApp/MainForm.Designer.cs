namespace RA_Application
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.playButton = new System.Windows.Forms.Button();
            this.PlayButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.recordButton = new System.Windows.Forms.Button();
            this.RecordButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.loadButton = new System.Windows.Forms.Button();
            this.LoadButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.LockButton = new System.Windows.Forms.Button();
            this.LockButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.CloseButton = new System.Windows.Forms.Button();
            this.CloseButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.MinButton = new System.Windows.Forms.Button();
            this.MinButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.RASymbol = new System.Windows.Forms.Label();
            this.TextScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.StatusLabel = new System.Windows.Forms.Label();
            this.RecordStatusUpdater = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.PlaybackTimer = new System.Windows.Forms.Timer(this.components);
            this.Scheduler = new System.Windows.Forms.Button();
            this.SchedulerImages = new System.Windows.Forms.ImageList(this.components);
            this.MacroSettingTimer = new System.Windows.Forms.Timer(this.components);
            this.bottomPanelText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SettingsButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.SettingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.AccessibleName = "playButton";
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatAppearance.BorderSize = 0;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.ForeColor = System.Drawing.Color.Transparent;
            this.playButton.ImageIndex = 0;
            this.playButton.ImageList = this.PlayButtonImages;
            this.playButton.Location = new System.Drawing.Point(5, 23);
            this.playButton.Margin = new System.Windows.Forms.Padding(0);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(64, 40);
            this.playButton.TabIndex = 1;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseEnter += new System.EventHandler(this.playButton_MouseEnter);
            this.playButton.MouseLeave += new System.EventHandler(this.playButton_MouseLeave);
            // 
            // PlayButtonImages
            // 
            this.PlayButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PlayButtonImages.ImageStream")));
            this.PlayButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.PlayButtonImages.Images.SetKeyName(0, "PlayIcon32x32New.png");
            this.PlayButtonImages.Images.SetKeyName(1, "PlayIcon32x32NewHover.png");
            // 
            // recordButton
            // 
            this.recordButton.BackColor = System.Drawing.Color.Transparent;
            this.recordButton.FlatAppearance.BorderSize = 0;
            this.recordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordButton.ForeColor = System.Drawing.Color.Transparent;
            this.recordButton.ImageIndex = 0;
            this.recordButton.ImageList = this.RecordButtonImages;
            this.recordButton.Location = new System.Drawing.Point(72, 22);
            this.recordButton.Margin = new System.Windows.Forms.Padding(0);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(64, 41);
            this.recordButton.TabIndex = 2;
            this.recordButton.UseVisualStyleBackColor = false;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            this.recordButton.MouseEnter += new System.EventHandler(this.recordButton_MouseEnter);
            this.recordButton.MouseLeave += new System.EventHandler(this.recordButton_MouseLeave);
            // 
            // RecordButtonImages
            // 
            this.RecordButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("RecordButtonImages.ImageStream")));
            this.RecordButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.RecordButtonImages.Images.SetKeyName(0, "RecordButtonIconNew32.png");
            this.RecordButtonImages.Images.SetKeyName(1, "RecordButtonIconHoverNew32.png");
            // 
            // loadButton
            // 
            this.loadButton.AccessibleName = "Load File";
            this.loadButton.BackColor = System.Drawing.Color.Transparent;
            this.loadButton.FlatAppearance.BorderSize = 0;
            this.loadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.ForeColor = System.Drawing.Color.Transparent;
            this.loadButton.ImageIndex = 0;
            this.loadButton.ImageList = this.LoadButtonImages;
            this.loadButton.Location = new System.Drawing.Point(135, 22);
            this.loadButton.Margin = new System.Windows.Forms.Padding(0);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 42);
            this.loadButton.TabIndex = 3;
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            this.loadButton.MouseEnter += new System.EventHandler(this.loadButton_MouseEnter);
            this.loadButton.MouseLeave += new System.EventHandler(this.loadButton_MouseLeave);
            // 
            // LoadButtonImages
            // 
            this.LoadButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LoadButtonImages.ImageStream")));
            this.LoadButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.LoadButtonImages.Images.SetKeyName(0, "FolderIcon32.png");
            this.LoadButtonImages.Images.SetKeyName(1, "FolderIcon32Hover.png");
            // 
            // label3
            // 
            this.label3.AccessibleName = "bottomPanelText";
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.label3.Location = new System.Drawing.Point(136, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            // 
            // LockButton
            // 
            this.LockButton.BackColor = System.Drawing.Color.Transparent;
            this.LockButton.FlatAppearance.BorderSize = 0;
            this.LockButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.LockButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.LockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LockButton.ImageIndex = 0;
            this.LockButton.ImageList = this.LockButtonImages;
            this.LockButton.Location = new System.Drawing.Point(194, 1);
            this.LockButton.Margin = new System.Windows.Forms.Padding(0);
            this.LockButton.Name = "LockButton";
            this.LockButton.Size = new System.Drawing.Size(15, 15);
            this.LockButton.TabIndex = 10;
            this.LockButton.UseVisualStyleBackColor = false;
            this.LockButton.Click += new System.EventHandler(this.LockButton_Click);
            this.LockButton.MouseEnter += new System.EventHandler(this.LockButton_MouseEnter);
            this.LockButton.MouseLeave += new System.EventHandler(this.LockButton_MouseLeave);
            // 
            // LockButtonImages
            // 
            this.LockButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LockButtonImages.ImageStream")));
            this.LockButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.LockButtonImages.Images.SetKeyName(0, "UnlockedIconNew.png");
            this.LockButtonImages.Images.SetKeyName(1, "LockedIconNew.png");
            this.LockButtonImages.Images.SetKeyName(2, "UnlockedIconHoverNew.png");
            this.LockButtonImages.Images.SetKeyName(3, "LockedIconHoverNew.png");
            // 
            // CloseButton
            // 
            this.CloseButton.AccessibleName = "CloseButton";
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.ImageIndex = 0;
            this.CloseButton.ImageList = this.CloseButtonImages;
            this.CloseButton.Location = new System.Drawing.Point(251, -2);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(32, 20);
            this.CloseButton.TabIndex = 11;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // CloseButtonImages
            // 
            this.CloseButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("CloseButtonImages.ImageStream")));
            this.CloseButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.CloseButtonImages.Images.SetKeyName(0, "CloseIconNew.png");
            this.CloseButtonImages.Images.SetKeyName(1, "CloseIconHoverNew.png");
            // 
            // MinButton
            // 
            this.MinButton.AccessibleName = "MinButton";
            this.MinButton.BackColor = System.Drawing.Color.Transparent;
            this.MinButton.FlatAppearance.BorderSize = 0;
            this.MinButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MinButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinButton.ImageIndex = 0;
            this.MinButton.ImageList = this.MinButtonImages;
            this.MinButton.Location = new System.Drawing.Point(216, 0);
            this.MinButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(32, 19);
            this.MinButton.TabIndex = 12;
            this.MinButton.UseVisualStyleBackColor = false;
            this.MinButton.Click += new System.EventHandler(this.MinButton_Click);
            this.MinButton.MouseEnter += new System.EventHandler(this.MinButton_MouseEnter);
            this.MinButton.MouseLeave += new System.EventHandler(this.MinButton_MouseLeave);
            // 
            // MinButtonImages
            // 
            this.MinButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MinButtonImages.ImageStream")));
            this.MinButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.MinButtonImages.Images.SetKeyName(0, "MinIconNew.png");
            this.MinButtonImages.Images.SetKeyName(1, "MinIconHoverNew.png");
            // 
            // RASymbol
            // 
            this.RASymbol.AccessibleName = "RALabel";
            this.RASymbol.AutoSize = true;
            this.RASymbol.BackColor = System.Drawing.Color.Transparent;
            this.RASymbol.Font = new System.Drawing.Font("Papyrus", 9.25F);
            this.RASymbol.ForeColor = System.Drawing.Color.White;
            this.RASymbol.Location = new System.Drawing.Point(26, 0);
            this.RASymbol.Margin = new System.Windows.Forms.Padding(0);
            this.RASymbol.Name = "RASymbol";
            this.RASymbol.Size = new System.Drawing.Size(34, 21);
            this.RASymbol.TabIndex = 13;
            this.RASymbol.Text = "RA";
            // 
            // TextScrollTimer
            // 
            this.TextScrollTimer.Enabled = true;
            this.TextScrollTimer.Interval = 400;
            this.TextScrollTimer.Tick += new System.EventHandler(this.TextScrollTimer_Tick);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AccessibleName = "StatusLabel";
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(85, 3);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 12);
            this.StatusLabel.TabIndex = 15;
            // 
            // RecordStatusUpdater
            // 
            this.RecordStatusUpdater.Tick += new System.EventHandler(this.RecordStatusUpdater_Tick);
            // 
            // label4
            // 
            this.label4.AccessibleName = "RALabel";
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Papyrus", 9.25F);
            this.label4.Image = global::RA_Application.Properties.Resources.RAIcon;
            this.label4.Location = new System.Drawing.Point(32, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 21);
            this.label4.TabIndex = 16;
            // 
            // PlaybackTimer
            // 
            this.PlaybackTimer.Tick += new System.EventHandler(this.PlaybackTimer_Tick);
            // 
            // Scheduler
            // 
            this.Scheduler.AccessibleName = "Scheduler";
            this.Scheduler.BackColor = System.Drawing.Color.Transparent;
            this.Scheduler.FlatAppearance.BorderSize = 0;
            this.Scheduler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Scheduler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Scheduler.ForeColor = System.Drawing.Color.Transparent;
            this.Scheduler.ImageIndex = 0;
            this.Scheduler.ImageList = this.SchedulerImages;
            this.Scheduler.Location = new System.Drawing.Point(213, 23);
            this.Scheduler.Name = "Scheduler";
            this.Scheduler.Size = new System.Drawing.Size(67, 40);
            this.Scheduler.TabIndex = 17;
            this.Scheduler.UseVisualStyleBackColor = false;
            this.Scheduler.Click += new System.EventHandler(this.Scheduler_Click);
            this.Scheduler.MouseEnter += new System.EventHandler(this.Scheduler_MouseEnter);
            this.Scheduler.MouseLeave += new System.EventHandler(this.Scheduler_MouseLeave);
            // 
            // SchedulerImages
            // 
            this.SchedulerImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SchedulerImages.ImageStream")));
            this.SchedulerImages.TransparentColor = System.Drawing.Color.Transparent;
            this.SchedulerImages.Images.SetKeyName(0, "ScheduleIcon32.png");
            this.SchedulerImages.Images.SetKeyName(1, "ScheduleIconHover32.png");
            // 
            // MacroSettingTimer
            // 
            this.MacroSettingTimer.Tick += new System.EventHandler(this.MacroSettingTimer_Tick);
            // 
            // bottomPanelText
            // 
            this.bottomPanelText.AccessibleName = "BottomPanelText";
            this.bottomPanelText.AutoSize = true;
            this.bottomPanelText.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanelText.Font = new System.Drawing.Font("OCR A Extended", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomPanelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(89)))), ((int)(((byte)(0)))));
            this.bottomPanelText.Location = new System.Drawing.Point(5, 66);
            this.bottomPanelText.Name = "bottomPanelText";
            this.bottomPanelText.Size = new System.Drawing.Size(26, 12);
            this.bottomPanelText.TabIndex = 18;
            this.bottomPanelText.Text = "...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::RA_Application.Properties.Resources.RAIconNew;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 21);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // SettingsButtonImages
            // 
            this.SettingsButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SettingsButtonImages.ImageStream")));
            this.SettingsButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.SettingsButtonImages.Images.SetKeyName(0, "SettingsIcon15.png");
            this.SettingsButtonImages.Images.SetKeyName(1, "SettingsIconHover15.png");
            // 
            // SettingButton
            // 
            this.SettingButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingButton.FlatAppearance.BorderSize = 0;
            this.SettingButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SettingButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SettingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingButton.ImageIndex = 0;
            this.SettingButton.ImageList = this.SettingsButtonImages;
            this.SettingButton.Location = new System.Drawing.Point(166, 1);
            this.SettingButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(15, 15);
            this.SettingButton.TabIndex = 20;
            this.SettingButton.UseVisualStyleBackColor = false;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            this.SettingButton.MouseEnter += new System.EventHandler(this.SettingButton_MouseEnter);
            this.SettingButton.MouseLeave += new System.EventHandler(this.SettingButton_MouseLeave);
            // 
            // RAForm
            // 
            this.AccessibleName = "RAForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            this.BackgroundImage = global::RA_Application.Properties.Resources.Background10;
            this.ClientSize = new System.Drawing.Size(285, 80);
            this.Controls.Add(this.SettingButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bottomPanelText);
            this.Controls.Add(this.Scheduler);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.RASymbol);
            this.Controls.Add(this.MinButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.LockButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.playButton);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(73)))), ((int)(((byte)(203)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(288, 80);
            this.MinimumSize = new System.Drawing.Size(270, 80);
            this.Name = "RAForm";
            this.Text = "  ";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(34)))));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LockButton;
        public System.Windows.Forms.ImageList LockButtonImages;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ImageList CloseButtonImages;
        private System.Windows.Forms.Button MinButton;
        private System.Windows.Forms.ImageList MinButtonImages;
        private System.Windows.Forms.Label RASymbol;
        private System.Windows.Forms.Timer TextScrollTimer;
        private System.Windows.Forms.ImageList PlayButtonImages;
        private System.Windows.Forms.ImageList RecordButtonImages;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Timer RecordStatusUpdater;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer PlaybackTimer;
        private System.Windows.Forms.Button Scheduler;
        private System.Windows.Forms.Timer MacroSettingTimer;
        private System.Windows.Forms.Label bottomPanelText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList LoadButtonImages;
        private System.Windows.Forms.ImageList SettingsButtonImages;
        private System.Windows.Forms.Button SettingButton;
        private System.Windows.Forms.ImageList SchedulerImages;
    }
}


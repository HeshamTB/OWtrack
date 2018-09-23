namespace OWTrack
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
            this.label1 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Label();
            this.Wins = new System.Windows.Forms.Label();
            this.Losses = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WinBut = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.reduceLossBut = new System.Windows.Forms.Button();
            this.reduceWinBut = new System.Windows.Forms.Button();
            this.clearBut = new System.Windows.Forms.Button();
            this.srTextBox = new System.Windows.Forms.TextBox();
            this.srBut = new System.Windows.Forms.Button();
            this.srLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            this.SRCheckBx = new System.Windows.Forms.CheckBox();
            this.ExeTrackCheckBx = new System.Windows.Forms.CheckBox();
            this.ChngOWPathBtn = new System.Windows.Forms.Button();
            this.SettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Overwatch is: ";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.White;
            this.status.Location = new System.Drawing.Point(93, 36);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(35, 13);
            this.status.TabIndex = 1;
            this.status.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(20, 13);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(35, 13);
            this.Time.TabIndex = 2;
            this.Time.Text = "label2";
            // 
            // Wins
            // 
            this.Wins.AutoSize = true;
            this.Wins.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Wins.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Wins.Location = new System.Drawing.Point(162, 78);
            this.Wins.Name = "Wins";
            this.Wins.Size = new System.Drawing.Size(39, 42);
            this.Wins.TabIndex = 3;
            this.Wins.Text = "0";
            // 
            // Losses
            // 
            this.Losses.AutoSize = true;
            this.Losses.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Losses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Losses.Location = new System.Drawing.Point(231, 78);
            this.Losses.Name = "Losses";
            this.Losses.Size = new System.Drawing.Size(39, 42);
            this.Losses.TabIndex = 4;
            this.Losses.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(206, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 42);
            this.label3.TabIndex = 5;
            this.label3.Text = ":";
            // 
            // WinBut
            // 
            this.WinBut.Location = new System.Drawing.Point(161, 136);
            this.WinBut.Name = "WinBut";
            this.WinBut.Size = new System.Drawing.Size(52, 26);
            this.WinBut.TabIndex = 6;
            this.WinBut.Text = "win";
            this.WinBut.UseVisualStyleBackColor = true;
            this.WinBut.Click += new System.EventHandler(this.WinBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 26);
            this.button2.TabIndex = 6;
            this.button2.Text = "loss";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LossBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(197, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 42);
            this.label2.TabIndex = 5;
            this.label2.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // reduceLossBut
            // 
            this.reduceLossBut.Location = new System.Drawing.Point(277, 137);
            this.reduceLossBut.Name = "reduceLossBut";
            this.reduceLossBut.Size = new System.Drawing.Size(20, 24);
            this.reduceLossBut.TabIndex = 8;
            this.reduceLossBut.Text = "-";
            this.reduceLossBut.UseVisualStyleBackColor = true;
            this.reduceLossBut.Click += new System.EventHandler(this.reduceLossBut_Click);
            // 
            // reduceWinBut
            // 
            this.reduceWinBut.Location = new System.Drawing.Point(137, 137);
            this.reduceWinBut.Name = "reduceWinBut";
            this.reduceWinBut.Size = new System.Drawing.Size(20, 24);
            this.reduceWinBut.TabIndex = 9;
            this.reduceWinBut.Text = "-";
            this.reduceWinBut.UseVisualStyleBackColor = true;
            this.reduceWinBut.Click += new System.EventHandler(this.reduceWinBut_Click);
            // 
            // clearBut
            // 
            this.clearBut.Location = new System.Drawing.Point(19, 103);
            this.clearBut.Name = "clearBut";
            this.clearBut.Size = new System.Drawing.Size(75, 25);
            this.clearBut.TabIndex = 10;
            this.clearBut.Text = "Clear stats";
            this.clearBut.UseVisualStyleBackColor = true;
            this.clearBut.Click += new System.EventHandler(this.clearBut_Click);
            // 
            // srTextBox
            // 
            this.srTextBox.Location = new System.Drawing.Point(169, 168);
            this.srTextBox.Name = "srTextBox";
            this.srTextBox.Size = new System.Drawing.Size(100, 20);
            this.srTextBox.TabIndex = 11;
            this.srTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // srBut
            // 
            this.srBut.Location = new System.Drawing.Point(184, 194);
            this.srBut.Name = "srBut";
            this.srBut.Size = new System.Drawing.Size(75, 23);
            this.srBut.TabIndex = 12;
            this.srBut.Text = "Enter";
            this.srBut.UseVisualStyleBackColor = true;
            this.srBut.Click += new System.EventHandler(this.srBut_Click);
            // 
            // srLabel
            // 
            this.srLabel.AutoSize = true;
            this.srLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.srLabel.Location = new System.Drawing.Point(189, 36);
            this.srLabel.Name = "srLabel";
            this.srLabel.Size = new System.Drawing.Size(46, 24);
            this.srLabel.TabIndex = 13;
            this.srLabel.Text = "0 - 0";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Overwatch.exe";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Start - Gain/Loss";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "OWtrack";
            this.notifyIcon1.Visible = true;
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Controls.Add(this.ChngOWPathBtn);
            this.SettingsGroup.Controls.Add(this.ExeTrackCheckBx);
            this.SettingsGroup.Controls.Add(this.SRCheckBx);
            this.SettingsGroup.Controls.Add(this.clearBut);
            this.SettingsGroup.Location = new System.Drawing.Point(12, 62);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Size = new System.Drawing.Size(116, 143);
            this.SettingsGroup.TabIndex = 15;
            this.SettingsGroup.TabStop = false;
            this.SettingsGroup.Text = "Settings";
            // 
            // SRCheckBx
            // 
            this.SRCheckBx.AutoSize = true;
            this.SRCheckBx.Location = new System.Drawing.Point(11, 19);
            this.SRCheckBx.Name = "SRCheckBx";
            this.SRCheckBx.Size = new System.Drawing.Size(86, 17);
            this.SRCheckBx.TabIndex = 0;
            this.SRCheckBx.Text = "SR Tracking";
            this.SRCheckBx.UseVisualStyleBackColor = true;
            // 
            // ExeTrackCheckBx
            // 
            this.ExeTrackCheckBx.AutoSize = true;
            this.ExeTrackCheckBx.Location = new System.Drawing.Point(11, 44);
            this.ExeTrackCheckBx.Name = "ExeTrackCheckBx";
            this.ExeTrackCheckBx.Size = new System.Drawing.Size(90, 17);
            this.ExeTrackCheckBx.TabIndex = 0;
            this.ExeTrackCheckBx.Text = "OW Tracking";
            this.ExeTrackCheckBx.UseVisualStyleBackColor = true;
            // 
            // ChngOWPathBtn
            // 
            this.ChngOWPathBtn.Location = new System.Drawing.Point(19, 74);
            this.ChngOWPathBtn.Name = "ChngOWPathBtn";
            this.ChngOWPathBtn.Size = new System.Drawing.Size(75, 23);
            this.ChngOWPathBtn.TabIndex = 1;
            this.ChngOWPathBtn.Text = "OW Path";
            this.ChngOWPathBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 237);
            this.Controls.Add(this.SettingsGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.srLabel);
            this.Controls.Add(this.srBut);
            this.Controls.Add(this.srTextBox);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reduceWinBut);
            this.Controls.Add(this.reduceLossBut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Wins);
            this.Controls.Add(this.Losses);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.WinBut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OWTrack";
            this.SettingsGroup.ResumeLayout(false);
            this.SettingsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Wins;
        private System.Windows.Forms.Label Losses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button WinBut;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button reduceLossBut;
        private System.Windows.Forms.Button reduceWinBut;
        private System.Windows.Forms.Button clearBut;
        private System.Windows.Forms.TextBox srTextBox;
        private System.Windows.Forms.Button srBut;
        private System.Windows.Forms.Label srLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox SettingsGroup;
        private System.Windows.Forms.CheckBox ExeTrackCheckBx;
        private System.Windows.Forms.CheckBox SRCheckBx;
        private System.Windows.Forms.Button ChngOWPathBtn;
    }
}


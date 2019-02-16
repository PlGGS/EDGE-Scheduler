namespace EDGE_Scheduler
{
    partial class frmMain
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
            this.scrMain = new System.Windows.Forms.SplitContainer();
            this.btnCreateSchedule = new System.Windows.Forms.Button();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.txtShiftLength = new System.Windows.Forms.TextBox();
            this.lblShiftLength = new System.Windows.Forms.Label();
            this.lblTeam = new System.Windows.Forms.Label();
            this.cbxTeam = new System.Windows.Forms.ComboBox();
            this.btnReadData = new System.Windows.Forms.Button();
            this.dgvTimes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.scrMain)).BeginInit();
            this.scrMain.Panel2.SuspendLayout();
            this.scrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // scrMain
            // 
            this.scrMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrMain.Location = new System.Drawing.Point(0, 0);
            this.scrMain.Name = "scrMain";
            this.scrMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scrMain.Panel1
            // 
            this.scrMain.Panel1.BackColor = System.Drawing.Color.Silver;
            // 
            // scrMain.Panel2
            // 
            this.scrMain.Panel2.Controls.Add(this.btnCreateSchedule);
            this.scrMain.Panel2.Controls.Add(this.lblEnd);
            this.scrMain.Panel2.Controls.Add(this.dtpEnd);
            this.scrMain.Panel2.Controls.Add(this.lblStart);
            this.scrMain.Panel2.Controls.Add(this.dtpStart);
            this.scrMain.Panel2.Controls.Add(this.txtShiftLength);
            this.scrMain.Panel2.Controls.Add(this.lblShiftLength);
            this.scrMain.Panel2.Controls.Add(this.lblTeam);
            this.scrMain.Panel2.Controls.Add(this.cbxTeam);
            this.scrMain.Panel2.Controls.Add(this.btnReadData);
            this.scrMain.Panel2.Controls.Add(this.dgvTimes);
            this.scrMain.Panel2.SizeChanged += new System.EventHandler(this.scrMain_Panel2_SizeChanged);
            this.scrMain.Size = new System.Drawing.Size(1005, 725);
            this.scrMain.SplitterDistance = 500;
            this.scrMain.TabIndex = 2;
            // 
            // btnCreateSchedule
            // 
            this.btnCreateSchedule.Location = new System.Drawing.Point(173, 176);
            this.btnCreateSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateSchedule.Name = "btnCreateSchedule";
            this.btnCreateSchedule.Size = new System.Drawing.Size(172, 44);
            this.btnCreateSchedule.TabIndex = 24;
            this.btnCreateSchedule.Text = "Create Schedule";
            this.btnCreateSchedule.UseVisualStyleBackColor = true;
            this.btnCreateSchedule.Click += new System.EventHandler(this.btnCreateSchedule_Click);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(2, 128);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 21);
            this.lblEnd.TabIndex = 23;
            this.lblEnd.Text = "End";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(70, 122);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(269, 29);
            this.dtpEnd.TabIndex = 22;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(2, 89);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(42, 21);
            this.lblStart.TabIndex = 21;
            this.lblStart.Text = "Start";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(70, 83);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(269, 29);
            this.dtpStart.TabIndex = 20;
            // 
            // txtShiftLength
            // 
            this.txtShiftLength.Location = new System.Drawing.Point(302, 45);
            this.txtShiftLength.Name = "txtShiftLength";
            this.txtShiftLength.Size = new System.Drawing.Size(37, 29);
            this.txtShiftLength.TabIndex = 19;
            // 
            // lblShiftLength
            // 
            this.lblShiftLength.AutoSize = true;
            this.lblShiftLength.Location = new System.Drawing.Point(2, 48);
            this.lblShiftLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShiftLength.Name = "lblShiftLength";
            this.lblShiftLength.Size = new System.Drawing.Size(130, 21);
            this.lblShiftLength.TabIndex = 18;
            this.lblShiftLength.Text = "Shift Length (hrs)";
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(2, 10);
            this.lblTeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(46, 21);
            this.lblTeam.TabIndex = 16;
            this.lblTeam.Text = "Team";
            // 
            // cbxTeam
            // 
            this.cbxTeam.FormattingEnabled = true;
            this.cbxTeam.Items.AddRange(new object[] {
            "Both",
            "East",
            "West"});
            this.cbxTeam.Location = new System.Drawing.Point(275, 7);
            this.cbxTeam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxTeam.Name = "cbxTeam";
            this.cbxTeam.Size = new System.Drawing.Size(64, 29);
            this.cbxTeam.TabIndex = 14;
            // 
            // btnReadData
            // 
            this.btnReadData.Location = new System.Drawing.Point(1, 176);
            this.btnReadData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(172, 44);
            this.btnReadData.TabIndex = 16;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // dgvTimes
            // 
            this.dgvTimes.AllowUserToAddRows = false;
            this.dgvTimes.AllowUserToDeleteRows = false;
            this.dgvTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimes.Location = new System.Drawing.Point(345, 0);
            this.dgvTimes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTimes.Name = "dgvTimes";
            this.dgvTimes.ReadOnly = true;
            this.dgvTimes.Size = new System.Drawing.Size(660, 221);
            this.dgvTimes.TabIndex = 15;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 725);
            this.Controls.Add(this.scrMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDGE Scheduler";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.scrMain.Panel2.ResumeLayout(false);
            this.scrMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrMain)).EndInit();
            this.scrMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer scrMain;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DataGridView dgvTimes;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.TextBox txtShiftLength;
        private System.Windows.Forms.Label lblShiftLength;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.ComboBox cbxTeam;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Button btnCreateSchedule;
    }
}


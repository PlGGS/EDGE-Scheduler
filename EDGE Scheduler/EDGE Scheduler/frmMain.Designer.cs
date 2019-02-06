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
            this.lblSpreadsheetID = new System.Windows.Forms.Label();
            this.btnReadData = new System.Windows.Forms.Button();
            this.cbxTeam = new System.Windows.Forms.ComboBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.txtSpreadsheetID = new System.Windows.Forms.TextBox();
            this.lblShiftLength = new System.Windows.Forms.Label();
            this.txtShiftLength = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.dgvTimes = new System.Windows.Forms.DataGridView();
            this.pnlGroupsContainer = new System.Windows.Forms.Panel();
            this.pnlGroups = new System.Windows.Forms.Panel();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).BeginInit();
            this.pnlGroupsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSpreadsheetID
            // 
            this.lblSpreadsheetID.AutoSize = true;
            this.lblSpreadsheetID.Location = new System.Drawing.Point(4, 9);
            this.lblSpreadsheetID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpreadsheetID.Name = "lblSpreadsheetID";
            this.lblSpreadsheetID.Size = new System.Drawing.Size(115, 21);
            this.lblSpreadsheetID.TabIndex = 1;
            this.lblSpreadsheetID.Text = "Spreadsheet ID";
            // 
            // btnReadData
            // 
            this.btnReadData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadData.Location = new System.Drawing.Point(5, 677);
            this.btnReadData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(339, 44);
            this.btnReadData.TabIndex = 2;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // cbxTeam
            // 
            this.cbxTeam.FormattingEnabled = true;
            this.cbxTeam.Items.AddRange(new object[] {
            "Both",
            "East",
            "West"});
            this.cbxTeam.Location = new System.Drawing.Point(277, 43);
            this.cbxTeam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxTeam.Name = "cbxTeam";
            this.cbxTeam.Size = new System.Drawing.Size(64, 29);
            this.cbxTeam.TabIndex = 3;
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(4, 46);
            this.lblTeam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(46, 21);
            this.lblTeam.TabIndex = 4;
            this.lblTeam.Text = "Team";
            // 
            // txtSpreadsheetID
            // 
            this.txtSpreadsheetID.Location = new System.Drawing.Point(150, 6);
            this.txtSpreadsheetID.Name = "txtSpreadsheetID";
            this.txtSpreadsheetID.Size = new System.Drawing.Size(191, 29);
            this.txtSpreadsheetID.TabIndex = 5;
            this.txtSpreadsheetID.TextChanged += new System.EventHandler(this.txtSpreadsheetID_TextChanged);
            // 
            // lblShiftLength
            // 
            this.lblShiftLength.AutoSize = true;
            this.lblShiftLength.Location = new System.Drawing.Point(4, 82);
            this.lblShiftLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShiftLength.Name = "lblShiftLength";
            this.lblShiftLength.Size = new System.Drawing.Size(130, 21);
            this.lblShiftLength.TabIndex = 6;
            this.lblShiftLength.Text = "Shift Length (hrs)";
            // 
            // txtShiftLength
            // 
            this.txtShiftLength.Location = new System.Drawing.Point(304, 81);
            this.txtShiftLength.Name = "txtShiftLength";
            this.txtShiftLength.Size = new System.Drawing.Size(37, 29);
            this.txtShiftLength.TabIndex = 7;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(72, 119);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(269, 29);
            this.dtpStart.TabIndex = 8;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(4, 125);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(42, 21);
            this.lblStart.TabIndex = 9;
            this.lblStart.Text = "Start";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(72, 158);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(269, 29);
            this.dtpEnd.TabIndex = 10;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(4, 164);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(36, 21);
            this.lblEnd.TabIndex = 11;
            this.lblEnd.Text = "End";
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlOptions.BackColor = System.Drawing.SystemColors.Control;
            this.pnlOptions.Controls.Add(this.lblEnd);
            this.pnlOptions.Controls.Add(this.dtpEnd);
            this.pnlOptions.Controls.Add(this.lblStart);
            this.pnlOptions.Controls.Add(this.dtpStart);
            this.pnlOptions.Controls.Add(this.txtShiftLength);
            this.pnlOptions.Controls.Add(this.lblShiftLength);
            this.pnlOptions.Controls.Add(this.txtSpreadsheetID);
            this.pnlOptions.Controls.Add(this.lblTeam);
            this.pnlOptions.Controls.Add(this.cbxTeam);
            this.pnlOptions.Controls.Add(this.btnReadData);
            this.pnlOptions.Controls.Add(this.lblSpreadsheetID);
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(348, 726);
            this.pnlOptions.TabIndex = 1;
            // 
            // dgvTimes
            // 
            this.dgvTimes.AllowUserToAddRows = false;
            this.dgvTimes.AllowUserToDeleteRows = false;
            this.dgvTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimes.Location = new System.Drawing.Point(348, 470);
            this.dgvTimes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTimes.Name = "dgvTimes";
            this.dgvTimes.ReadOnly = true;
            this.dgvTimes.Size = new System.Drawing.Size(658, 256);
            this.dgvTimes.TabIndex = 4;
            // 
            // pnlGroupsContainer
            // 
            this.pnlGroupsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGroupsContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlGroupsContainer.Controls.Add(this.pnlGroups);
            this.pnlGroupsContainer.Location = new System.Drawing.Point(348, 0);
            this.pnlGroupsContainer.Name = "pnlGroupsContainer";
            this.pnlGroupsContainer.Size = new System.Drawing.Size(658, 470);
            this.pnlGroupsContainer.TabIndex = 5;
            // 
            // pnlGroups
            // 
            this.pnlGroups.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlGroups.Location = new System.Drawing.Point(9, 9);
            this.pnlGroups.Name = "pnlGroups";
            this.pnlGroups.Size = new System.Drawing.Size(639, 453);
            this.pnlGroups.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 725);
            this.Controls.Add(this.pnlGroupsContainer);
            this.Controls.Add(this.dgvTimes);
            this.Controls.Add(this.pnlOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EDGE Scheduler";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).EndInit();
            this.pnlGroupsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSpreadsheetID;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.ComboBox cbxTeam;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.TextBox txtSpreadsheetID;
        private System.Windows.Forms.Label lblShiftLength;
        private System.Windows.Forms.TextBox txtShiftLength;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.DataGridView dgvTimes;
        private System.Windows.Forms.Panel pnlGroupsContainer;
        private System.Windows.Forms.Panel pnlGroups;
    }
}


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
            this.dgvTimes = new System.Windows.Forms.DataGridView();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.txtSpreadsheetID = new System.Windows.Forms.TextBox();
            this.lblTeam = new System.Windows.Forms.Label();
            this.cbxTeam = new System.Windows.Forms.ComboBox();
            this.btnReadData = new System.Windows.Forms.Button();
            this.lblSpreadsheetID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.colTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).BeginInit();
            this.pnlOptions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTimes
            // 
            this.dgvTimes.AllowUserToAddRows = false;
            this.dgvTimes.AllowUserToDeleteRows = false;
            this.dgvTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTest});
            this.dgvTimes.Location = new System.Drawing.Point(0, 29);
            this.dgvTimes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTimes.Name = "dgvTimes";
            this.dgvTimes.ReadOnly = true;
            this.dgvTimes.Size = new System.Drawing.Size(845, 660);
            this.dgvTimes.TabIndex = 0;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.txtSpreadsheetID);
            this.pnlOptions.Controls.Add(this.lblTeam);
            this.pnlOptions.Controls.Add(this.cbxTeam);
            this.pnlOptions.Controls.Add(this.btnReadData);
            this.pnlOptions.Controls.Add(this.lblSpreadsheetID);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(439, 689);
            this.pnlOptions.TabIndex = 1;
            // 
            // txtSpreadsheetID
            // 
            this.txtSpreadsheetID.Location = new System.Drawing.Point(150, 6);
            this.txtSpreadsheetID.Name = "txtSpreadsheetID";
            this.txtSpreadsheetID.Size = new System.Drawing.Size(284, 29);
            this.txtSpreadsheetID.TabIndex = 5;
            this.txtSpreadsheetID.TextChanged += new System.EventHandler(this.txtSpreadsheetID_TextChanged);
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
            // cbxTeam
            // 
            this.cbxTeam.FormattingEnabled = true;
            this.cbxTeam.Location = new System.Drawing.Point(309, 43);
            this.cbxTeam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxTeam.Name = "cbxTeam";
            this.cbxTeam.Size = new System.Drawing.Size(125, 29);
            this.cbxTeam.TabIndex = 3;
            // 
            // btnReadData
            // 
            this.btnReadData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadData.Location = new System.Drawing.Point(4, 640);
            this.btnReadData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(430, 44);
            this.btnReadData.TabIndex = 2;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTimes);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(440, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 689);
            this.panel1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem,
            this.groupsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem1});
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.studentsToolStripMenuItem.Text = "File";
            // 
            // studentsToolStripMenuItem1
            // 
            this.studentsToolStripMenuItem1.Name = "studentsToolStripMenuItem1";
            this.studentsToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.studentsToolStripMenuItem1.Text = "Edit";
            // 
            // groupsToolStripMenuItem
            // 
            this.groupsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentsToolStripMenuItem2,
            this.groupsToolStripMenuItem2});
            this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
            this.groupsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.groupsToolStripMenuItem.Text = "Section";
            // 
            // studentsToolStripMenuItem2
            // 
            this.studentsToolStripMenuItem2.Name = "studentsToolStripMenuItem2";
            this.studentsToolStripMenuItem2.Size = new System.Drawing.Size(120, 22);
            this.studentsToolStripMenuItem2.Text = "Students";
            // 
            // groupsToolStripMenuItem2
            // 
            this.groupsToolStripMenuItem2.Name = "groupsToolStripMenuItem2";
            this.groupsToolStripMenuItem2.Size = new System.Drawing.Size(120, 22);
            this.groupsToolStripMenuItem2.Text = "Groups";
            // 
            // colTest
            // 
            this.colTest.HeaderText = "Test";
            this.colTest.Name = "colTest";
            this.colTest.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlOptions);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "EDGE Scheduler";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimes)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimes;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblSpreadsheetID;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.ComboBox cbxTeam;
        private System.Windows.Forms.TextBox txtSpreadsheetID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem groupsToolStripMenuItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTest;
    }
}


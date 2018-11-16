namespace KClick
{
    partial class ClubForm
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
            this.lsvAction = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvScripts = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditScript = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGetMousePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTryClick = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnFindControl = new System.Windows.Forms.Button();
            this.btnFixControl = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.cboRaidNumber = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lsvNox = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddNox = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvAction
            // 
            this.lsvAction.CheckOnClick = true;
            this.lsvAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvAction.FormattingEnabled = true;
            this.lsvAction.Items.AddRange(new object[] {
            "Club Share",
            "Club Join",
            "Daily Mission",
            "Event Mission",
            "Panel Shootout"});
            this.lsvAction.Location = new System.Drawing.Point(0, 0);
            this.lsvAction.Name = "lsvAction";
            this.lsvAction.Size = new System.Drawing.Size(108, 172);
            this.lsvAction.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(108, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 286);
            this.panel1.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvScripts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 172);
            this.panel2.TabIndex = 20;
            // 
            // lsvScripts
            // 
            this.lsvScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colDelay,
            this.colDescription});
            this.lsvScripts.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvScripts.FullRowSelect = true;
            this.lsvScripts.GridLines = true;
            this.lsvScripts.Location = new System.Drawing.Point(0, 0);
            this.lsvScripts.Name = "lsvScripts";
            this.lsvScripts.Size = new System.Drawing.Size(233, 172);
            this.lsvScripts.TabIndex = 41;
            this.lsvScripts.UseCompatibleStateImageBehavior = false;
            this.lsvScripts.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "No.";
            this.colNo.Width = 40;
            // 
            // colDelay
            // 
            this.colDelay.Text = "Delay";
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 200;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewScript,
            this.btnEditScript,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnGetMousePosition,
            this.btnTryClick});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 120);
            // 
            // btnNewScript
            // 
            this.btnNewScript.Name = "btnNewScript";
            this.btnNewScript.Size = new System.Drawing.Size(177, 22);
            this.btnNewScript.Text = "New";
            // 
            // btnEditScript
            // 
            this.btnEditScript.Name = "btnEditScript";
            this.btnEditScript.Size = new System.Drawing.Size(177, 22);
            this.btnEditScript.Text = "Edit";
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(177, 22);
            this.btnDelete.Text = "Delete";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // btnGetMousePosition
            // 
            this.btnGetMousePosition.Name = "btnGetMousePosition";
            this.btnGetMousePosition.Size = new System.Drawing.Size(177, 22);
            this.btnGetMousePosition.Text = "Get Mouse Position";
            // 
            // btnTryClick
            // 
            this.btnTryClick.Name = "btnTryClick";
            this.btnTryClick.Size = new System.Drawing.Size(177, 22);
            this.btnTryClick.Text = "Try Click";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnFindControl);
            this.panel3.Controls.Add(this.btnFixControl);
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Controls.Add(this.btnStop);
            this.panel3.Controls.Add(this.cboRaidNumber);
            this.panel3.Controls.Add(this.btnRun);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 114);
            this.panel3.TabIndex = 21;
            // 
            // btnFindControl
            // 
            this.btnFindControl.Location = new System.Drawing.Point(3, 3);
            this.btnFindControl.Name = "btnFindControl";
            this.btnFindControl.Size = new System.Drawing.Size(69, 50);
            this.btnFindControl.TabIndex = 1;
            this.btnFindControl.Text = "Take Control";
            this.btnFindControl.UseVisualStyleBackColor = true;
            // 
            // btnFixControl
            // 
            this.btnFixControl.Location = new System.Drawing.Point(78, 3);
            this.btnFixControl.Name = "btnFixControl";
            this.btnFixControl.Size = new System.Drawing.Size(69, 50);
            this.btnFixControl.TabIndex = 2;
            this.btnFixControl.Text = "Fix Size Control";
            this.btnFixControl.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(153, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 50);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Save Script";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(78, 59);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(69, 50);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop (Alt-S)";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // cboRaidNumber
            // 
            this.cboRaidNumber.FormattingEnabled = true;
            this.cboRaidNumber.Location = new System.Drawing.Point(153, 75);
            this.cboRaidNumber.Name = "cboRaidNumber";
            this.cboRaidNumber.Size = new System.Drawing.Size(69, 21);
            this.cboRaidNumber.TabIndex = 18;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(3, 59);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(69, 50);
            this.btnRun.TabIndex = 16;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Raid (Shared)";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(108, 286);
            this.panel4.TabIndex = 41;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lsvAction);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 114);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(108, 172);
            this.panel6.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(108, 114);
            this.panel5.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lsvNox);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(108, 114);
            this.panel7.TabIndex = 0;
            // 
            // lsvNox
            // 
            this.lsvNox.ContextMenuStrip = this.contextMenuStrip2;
            this.lsvNox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvNox.FormattingEnabled = true;
            this.lsvNox.Location = new System.Drawing.Point(0, 0);
            this.lsvNox.Name = "lsvNox";
            this.lsvNox.Size = new System.Drawing.Size(108, 114);
            this.lsvNox.TabIndex = 1;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNox});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(97, 26);
            // 
            // btnAddNox
            // 
            this.btnAddNox.Name = "btnAddNox";
            this.btnAddNox.Size = new System.Drawing.Size(96, 22);
            this.btnAddNox.Text = "Add";
            // 
            // ClubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 286);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.MaximizeBox = false;
            this.Name = "ClubForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lsvAction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFixControl;
        private System.Windows.Forms.Button btnFindControl;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListView lsvScripts;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnNewScript;
        private System.Windows.Forms.ToolStripMenuItem btnEditScript;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnGetMousePosition;
        private System.Windows.Forms.ToolStripMenuItem btnTryClick;
        private System.Windows.Forms.ComboBox cboRaidNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colDelay;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckedListBox lsvNox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnAddNox;
    }
}
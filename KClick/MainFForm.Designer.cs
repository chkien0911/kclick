namespace KClick
{
    partial class MainFForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnFindControl = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFixControl = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lsvScripts = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditScript = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearScripts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGetMousePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTryClick = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lsvAction = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddAction = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditAction = new System.Windows.Forms.ToolStripMenuItem();
            this.chkAdjustAuto = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 119);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.chkAdjustAuto);
            this.panel4.Controls.Add(this.btnRun);
            this.panel4.Controls.Add(this.btnStop);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(316, 52);
            this.panel4.TabIndex = 41;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 9);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(54, 36);
            this.btnRun.TabIndex = 14;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(72, 9);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(50, 36);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop (Alt-S)";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtY);
            this.panel3.Controls.Add(this.btnFindControl);
            this.panel3.Controls.Add(this.btnImport);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Controls.Add(this.btnFixControl);
            this.panel3.Controls.Add(this.txtX);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 67);
            this.panel3.TabIndex = 40;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(91, 38);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(30, 20);
            this.txtY.TabIndex = 18;
            this.txtY.Text = "0";
            // 
            // btnFindControl
            // 
            this.btnFindControl.Location = new System.Drawing.Point(12, 11);
            this.btnFindControl.Name = "btnFindControl";
            this.btnFindControl.Size = new System.Drawing.Size(54, 43);
            this.btnFindControl.TabIndex = 1;
            this.btnFindControl.Text = "Take Control";
            this.btnFindControl.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(201, 11);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(49, 43);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Load Script";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Y";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(256, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(51, 43);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Save Script";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnFixControl
            // 
            this.btnFixControl.Location = new System.Drawing.Point(127, 11);
            this.btnFixControl.Name = "btnFixControl";
            this.btnFixControl.Size = new System.Drawing.Size(58, 43);
            this.btnFixControl.TabIndex = 2;
            this.btnFixControl.Text = "Fix Size Control";
            this.btnFixControl.UseVisualStyleBackColor = true;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(91, 12);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(30, 20);
            this.txtX.TabIndex = 17;
            this.txtX.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "X";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 152);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lsvScripts);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(85, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(231, 152);
            this.panel6.TabIndex = 4;
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
            this.lsvScripts.Size = new System.Drawing.Size(231, 152);
            this.lsvScripts.TabIndex = 2;
            this.lsvScripts.UseCompatibleStateImageBehavior = false;
            this.lsvScripts.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "No.";
            this.colNo.Width = 30;
            // 
            // colDelay
            // 
            this.colDelay.Text = "Delay";
            this.colDelay.Width = 45;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 276;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewScript,
            this.btnEditScript,
            this.btnDelete,
            this.btnClearScripts,
            this.toolStripSeparator2,
            this.btnGetMousePosition,
            this.btnTryClick});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(178, 142);
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
            // btnClearScripts
            // 
            this.btnClearScripts.Name = "btnClearScripts";
            this.btnClearScripts.Size = new System.Drawing.Size(177, 22);
            this.btnClearScripts.Text = "Clear";
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
            // panel5
            // 
            this.panel5.Controls.Add(this.lsvAction);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(85, 152);
            this.panel5.TabIndex = 3;
            // 
            // lsvAction
            // 
            this.lsvAction.ContextMenuStrip = this.contextMenuStrip2;
            this.lsvAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvAction.FormattingEnabled = true;
            this.lsvAction.Location = new System.Drawing.Point(0, 0);
            this.lsvAction.Name = "lsvAction";
            this.lsvAction.Size = new System.Drawing.Size(85, 152);
            this.lsvAction.TabIndex = 1;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddAction,
            this.btnEditAction});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(97, 48);
            // 
            // btnAddAction
            // 
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(96, 22);
            this.btnAddAction.Text = "Add";
            // 
            // btnEditAction
            // 
            this.btnEditAction.Name = "btnEditAction";
            this.btnEditAction.Size = new System.Drawing.Size(96, 22);
            this.btnEditAction.Text = "Edit";
            // 
            // chkAdjustAuto
            // 
            this.chkAdjustAuto.AutoSize = true;
            this.chkAdjustAuto.Location = new System.Drawing.Point(146, 9);
            this.chkAdjustAuto.Name = "chkAdjustAuto";
            this.chkAdjustAuto.Size = new System.Drawing.Size(137, 17);
            this.chkAdjustAuto.TabIndex = 15;
            this.chkAdjustAuto.Text = "Adjusted based on X, Y";
            this.chkAdjustAuto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "(Required script geneated at X=0,Y=0)";
            // 
            // MainFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 271);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "MainFForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No App Found";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button btnFindControl;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnFixControl;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListView lsvScripts;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colDelay;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnNewScript;
        private System.Windows.Forms.ToolStripMenuItem btnEditScript;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem btnClearScripts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnGetMousePosition;
        private System.Windows.Forms.ToolStripMenuItem btnTryClick;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckedListBox lsvAction;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnAddAction;
        private System.Windows.Forms.ToolStripMenuItem btnEditAction;
        private System.Windows.Forms.CheckBox chkAdjustAuto;
        private System.Windows.Forms.Label label1;
    }
}
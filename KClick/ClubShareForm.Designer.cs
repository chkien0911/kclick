namespace KClick
{
    partial class ClubShareForm
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
            this.btnTryClick = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditScript = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClearScripts = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetMousePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvScripts = new System.Windows.Forms.ListView();
            this.colDelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFixControl = new System.Windows.Forms.Button();
            this.btnFindControl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTryClick
            // 
            this.btnTryClick.Name = "btnTryClick";
            this.btnTryClick.Size = new System.Drawing.Size(177, 22);
            this.btnTryClick.Text = "Try Click";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(177, 22);
            this.btnDelete.Text = "Delete";
            // 
            // btnEditScript
            // 
            this.btnEditScript.Name = "btnEditScript";
            this.btnEditScript.Size = new System.Drawing.Size(177, 22);
            this.btnEditScript.Text = "Edit";
            // 
            // btnNewScript
            // 
            this.btnNewScript.Name = "btnNewScript";
            this.btnNewScript.Size = new System.Drawing.Size(177, 22);
            this.btnNewScript.Text = "New";
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
            // btnClearScripts
            // 
            this.btnClearScripts.Name = "btnClearScripts";
            this.btnClearScripts.Size = new System.Drawing.Size(177, 22);
            this.btnClearScripts.Text = "Clear";
            // 
            // btnGetMousePosition
            // 
            this.btnGetMousePosition.Name = "btnGetMousePosition";
            this.btnGetMousePosition.Size = new System.Drawing.Size(177, 22);
            this.btnGetMousePosition.Text = "Get Mouse Position";
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 276;
            // 
            // colNo
            // 
            this.colNo.Text = "No.";
            this.colNo.Width = 30;
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
            this.lsvScripts.Size = new System.Drawing.Size(300, 176);
            this.lsvScripts.TabIndex = 1;
            this.lsvScripts.UseCompatibleStateImageBehavior = false;
            this.lsvScripts.View = System.Windows.Forms.View.Details;
            // 
            // colDelay
            // 
            this.colDelay.Text = "Delay";
            this.colDelay.Width = 45;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lsvScripts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 176);
            this.panel3.TabIndex = 40;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(231, 10);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(60, 35);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Load Script";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(163, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(62, 36);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Save Script";
            this.btnExport.UseVisualStyleBackColor = true;
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
            this.btnStop.Size = new System.Drawing.Size(65, 36);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop (Alt-S)";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRun);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 53);
            this.panel2.TabIndex = 38;
            // 
            // btnFixControl
            // 
            this.btnFixControl.Location = new System.Drawing.Point(187, 12);
            this.btnFixControl.Name = "btnFixControl";
            this.btnFixControl.Size = new System.Drawing.Size(62, 41);
            this.btnFixControl.TabIndex = 2;
            this.btnFixControl.Text = "Fix Size Control";
            this.btnFixControl.UseVisualStyleBackColor = true;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.txtHeight);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnFixControl);
            this.panel1.Controls.Add(this.txtY);
            this.panel1.Controls.Add(this.btnFindControl);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtX);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 67);
            this.panel1.TabIndex = 39;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(151, 37);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(30, 20);
            this.txtY.TabIndex = 18;
            this.txtY.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Y";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(151, 11);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(30, 20);
            this.txtX.TabIndex = 17;
            this.txtX.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "X";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(95, 37);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(30, 20);
            this.txtHeight.TabIndex = 22;
            this.txtHeight.Text = "400";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "H";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(95, 11);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(30, 20);
            this.txtWidth.TabIndex = 20;
            this.txtWidth.Text = "500";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "W";
            // 
            // ClubShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 296);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "ClubShareForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No App Found";
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem btnTryClick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem btnEditScript;
        private System.Windows.Forms.ToolStripMenuItem btnNewScript;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnGetMousePosition;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ListView lsvScripts;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFixControl;
        private System.Windows.Forms.Button btnFindControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader colDelay;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem btnClearScripts;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label4;
    }
}
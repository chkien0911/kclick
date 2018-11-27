namespace KClick
{
    partial class ActionForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lsvBoostTime = new System.Windows.Forms.ListView();
            this.colBoostTimeFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBoostTimeTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddTime = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditTime = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteTime = new System.Windows.Forms.ToolStripMenuItem();
            this.colBoostTimeNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(342, 142);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lsvScripts);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(342, 113);
            this.panel4.TabIndex = 4;
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
            this.lsvScripts.Size = new System.Drawing.Size(342, 113);
            this.lsvScripts.TabIndex = 3;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.txtName);
            this.panel3.Controls.Add(this.txtNo);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 29);
            this.panel3.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(61, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(249, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(316, 6);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(26, 20);
            this.txtNo.TabIndex = 2;
            this.txtNo.Text = "0";
            this.txtNo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 155);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lsvBoostTime);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(342, 115);
            this.panel6.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnLoadScript);
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 115);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(342, 40);
            this.panel5.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(274, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLoadScript
            // 
            this.btnLoadScript.Location = new System.Drawing.Point(11, 6);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(73, 29);
            this.btnLoadScript.TabIndex = 2;
            this.btnLoadScript.Text = "Load Script";
            this.btnLoadScript.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lsvBoostTime
            // 
            this.lsvBoostTime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBoostTimeNo,
            this.colBoostTimeFrom,
            this.colBoostTimeTo});
            this.lsvBoostTime.ContextMenuStrip = this.contextMenuStrip2;
            this.lsvBoostTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvBoostTime.FullRowSelect = true;
            this.lsvBoostTime.GridLines = true;
            this.lsvBoostTime.Location = new System.Drawing.Point(0, 0);
            this.lsvBoostTime.Name = "lsvBoostTime";
            this.lsvBoostTime.Size = new System.Drawing.Size(342, 115);
            this.lsvBoostTime.TabIndex = 4;
            this.lsvBoostTime.UseCompatibleStateImageBehavior = false;
            this.lsvBoostTime.View = System.Windows.Forms.View.Details;
            // 
            // colBoostTimeFrom
            // 
            this.colBoostTimeFrom.Text = "From Time";
            this.colBoostTimeFrom.Width = 150;
            // 
            // colBoostTimeTo
            // 
            this.colBoostTimeTo.Text = "To Time";
            this.colBoostTimeTo.Width = 150;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddTime,
            this.btnEditTime,
            this.btnDeleteTime});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(108, 70);
            // 
            // btnAddTime
            // 
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(107, 22);
            this.btnAddTime.Text = "Add";
            // 
            // btnEditTime
            // 
            this.btnEditTime.Name = "btnEditTime";
            this.btnEditTime.Size = new System.Drawing.Size(107, 22);
            this.btnEditTime.Text = "Edit";
            // 
            // btnDeleteTime
            // 
            this.btnDeleteTime.Name = "btnDeleteTime";
            this.btnDeleteTime.Size = new System.Drawing.Size(107, 22);
            this.btnDeleteTime.Text = "Delete";
            // 
            // colBoostTimeNo
            // 
            this.colBoostTimeNo.Text = "No";
            this.colBoostTimeNo.Width = 30;
            // 
            // ActionForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(342, 297);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "ActionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Action";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Button btnLoadScript;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
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
        private System.Windows.Forms.ListView lsvBoostTime;
        private System.Windows.Forms.ColumnHeader colBoostTimeFrom;
        private System.Windows.Forms.ColumnHeader colBoostTimeTo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnAddTime;
        private System.Windows.Forms.ToolStripMenuItem btnEditTime;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteTime;
        private System.Windows.Forms.ColumnHeader colBoostTimeNo;
    }
}
﻿namespace KClick
{
    partial class RerolForm
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
            this.btnFixControl = new System.Windows.Forms.Button();
            this.btnFindControl = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lsvScripts = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFixColor = new System.Windows.Forms.Button();
            this.btnClearScripts = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFixControl
            // 
            this.btnFixControl.Location = new System.Drawing.Point(87, 12);
            this.btnFixControl.Name = "btnFixControl";
            this.btnFixControl.Size = new System.Drawing.Size(69, 50);
            this.btnFixControl.TabIndex = 2;
            this.btnFixControl.Text = "Fix Size Control";
            this.btnFixControl.UseVisualStyleBackColor = true;
            // 
            // btnFindControl
            // 
            this.btnFindControl.Location = new System.Drawing.Point(12, 12);
            this.btnFindControl.Name = "btnFindControl";
            this.btnFindControl.Size = new System.Drawing.Size(69, 50);
            this.btnFindControl.TabIndex = 1;
            this.btnFindControl.Text = "Take Control";
            this.btnFindControl.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClearScripts);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnRun);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 89);
            this.panel2.TabIndex = 35;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 13);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(69, 50);
            this.btnRun.TabIndex = 14;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(87, 13);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(69, 50);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop (Alt-S)";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFixColor);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnFixControl);
            this.panel1.Controls.Add(this.btnFindControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 87);
            this.panel1.TabIndex = 36;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(198, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(69, 50);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Load Script";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lsvScripts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 176);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(352, 110);
            this.panel3.TabIndex = 37;
            // 
            // lsvScripts
            // 
            this.lsvScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colInfo,
            this.colDescription});
            this.lsvScripts.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvScripts.FullRowSelect = true;
            this.lsvScripts.GridLines = true;
            this.lsvScripts.Location = new System.Drawing.Point(0, 0);
            this.lsvScripts.Name = "lsvScripts";
            this.lsvScripts.Size = new System.Drawing.Size(352, 110);
            this.lsvScripts.TabIndex = 1;
            this.lsvScripts.UseCompatibleStateImageBehavior = false;
            this.lsvScripts.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "No.";
            this.colNo.Width = 30;
            // 
            // colInfo
            // 
            this.colInfo.Text = "Info";
            this.colInfo.Width = 250;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 22);
            this.btnDelete.Text = "Delete";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(198, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 50);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Save Script";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnFixColor
            // 
            this.btnFixColor.Enabled = false;
            this.btnFixColor.Location = new System.Drawing.Point(273, 12);
            this.btnFixColor.Name = "btnFixColor";
            this.btnFixColor.Size = new System.Drawing.Size(69, 50);
            this.btnFixColor.TabIndex = 4;
            this.btnFixColor.Text = "Fix Color";
            this.btnFixColor.UseVisualStyleBackColor = true;
            // 
            // btnClearScripts
            // 
            this.btnClearScripts.Location = new System.Drawing.Point(273, 13);
            this.btnClearScripts.Name = "btnClearScripts";
            this.btnClearScripts.Size = new System.Drawing.Size(69, 50);
            this.btnClearScripts.TabIndex = 16;
            this.btnClearScripts.Text = "Clear Scripts";
            this.btnClearScripts.UseVisualStyleBackColor = true;
            // 
            // RerolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(352, 286);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "RerolForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rerol";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFixControl;
        private System.Windows.Forms.Button btnFindControl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lsvScripts;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colInfo;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnFixColor;
        private System.Windows.Forms.Button btnClearScripts;
    }
}
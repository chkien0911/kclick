namespace KClick
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtProgress = new System.Windows.Forms.RichTextBox();
            this.btnGetPositionMoved = new System.Windows.Forms.Button();
            this.txtYMoved = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtXMoved = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtColorMoved = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkDrag = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoSequencial = new System.Windows.Forms.RadioButton();
            this.rdoSpeed = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGetPosition = new System.Windows.Forms.Button();
            this.lblXPos = new System.Windows.Forms.Label();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.lblYPos = new System.Windows.Forms.Label();
            this.txtYPos = new System.Windows.Forms.TextBox();
            this.lblColor1 = new System.Windows.Forms.Label();
            this.txtColor1 = new System.Windows.Forms.TextBox();
            this.lblColor2 = new System.Windows.Forms.Label();
            this.btnGetPosition2 = new System.Windows.Forms.Button();
            this.txtColor2 = new System.Windows.Forms.TextBox();
            this.txtY2 = new System.Windows.Forms.TextBox();
            this.lblX2 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdateScript = new System.Windows.Forms.Button();
            this.btnClearScripts = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.grbIgnore = new System.Windows.Forms.GroupBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.btnGetPositionIgnored1 = new System.Windows.Forms.Button();
            this.txtYIgnored1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXIgnored1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColorIgnored1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApplyDelay = new System.Windows.Forms.Button();
            this.btnFixControl = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoopTime = new System.Windows.Forms.TextBox();
            this.rdoLimit = new System.Windows.Forms.RadioButton();
            this.rdoInfinity = new System.Windows.Forms.RadioButton();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.btnFindControl = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lsvScripts = new System.Windows.Forms.ListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.chkIsStartIcon = new System.Windows.Forms.CheckBox();
            this.btnGetMousePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTryClick = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear1 = new System.Windows.Forms.Button();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.btnClearIgnored = new System.Windows.Forms.Button();
            this.btnClearMoved = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.chkRunOnce = new System.Windows.Forms.CheckBox();
            this.pnlControl.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbIgnore.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Script";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.chkRunOnce);
            this.pnlControl.Controls.Add(this.btnClearMoved);
            this.pnlControl.Controls.Add(this.chkIsStartIcon);
            this.pnlControl.Controls.Add(this.panel5);
            this.pnlControl.Controls.Add(this.btnGetPositionMoved);
            this.pnlControl.Controls.Add(this.txtYMoved);
            this.pnlControl.Controls.Add(this.label6);
            this.pnlControl.Controls.Add(this.txtXMoved);
            this.pnlControl.Controls.Add(this.label7);
            this.pnlControl.Controls.Add(this.txtColorMoved);
            this.pnlControl.Controls.Add(this.label8);
            this.pnlControl.Controls.Add(this.chkDrag);
            this.pnlControl.Controls.Add(this.panel4);
            this.pnlControl.Controls.Add(this.panel3);
            this.pnlControl.Controls.Add(this.txtDescription);
            this.pnlControl.Controls.Add(this.label5);
            this.pnlControl.Controls.Add(this.panel2);
            this.pnlControl.Controls.Add(this.grbIgnore);
            this.pnlControl.Controls.Add(this.btnApplyDelay);
            this.pnlControl.Controls.Add(this.btnFixControl);
            this.pnlControl.Controls.Add(this.panel1);
            this.pnlControl.Controls.Add(this.txtDelay);
            this.pnlControl.Controls.Add(this.lblDelay);
            this.pnlControl.Controls.Add(this.btnFindControl);
            this.pnlControl.Controls.Add(this.txtName);
            this.pnlControl.Controls.Add(this.lblName);
            this.pnlControl.Controls.Add(this.txtClass);
            this.pnlControl.Controls.Add(this.lblClass);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(444, 437);
            this.pnlControl.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtProgress);
            this.panel5.Location = new System.Drawing.Point(442, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(155, 418);
            this.panel5.TabIndex = 47;
            // 
            // txtProgress
            // 
            this.txtProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgress.Location = new System.Drawing.Point(0, 0);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(155, 418);
            this.txtProgress.TabIndex = 0;
            this.txtProgress.Text = "";
            // 
            // btnGetPositionMoved
            // 
            this.btnGetPositionMoved.Enabled = false;
            this.btnGetPositionMoved.Location = new System.Drawing.Point(155, 310);
            this.btnGetPositionMoved.Name = "btnGetPositionMoved";
            this.btnGetPositionMoved.Size = new System.Drawing.Size(56, 44);
            this.btnGetPositionMoved.TabIndex = 43;
            this.btnGetPositionMoved.Text = "Get Position";
            this.btnGetPositionMoved.UseVisualStyleBackColor = true;
            // 
            // txtYMoved
            // 
            this.txtYMoved.Enabled = false;
            this.txtYMoved.Location = new System.Drawing.Point(99, 334);
            this.txtYMoved.Name = "txtYMoved";
            this.txtYMoved.Size = new System.Drawing.Size(49, 20);
            this.txtYMoved.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Y (Optional)";
            // 
            // txtXMoved
            // 
            this.txtXMoved.Enabled = false;
            this.txtXMoved.Location = new System.Drawing.Point(99, 311);
            this.txtXMoved.Name = "txtXMoved";
            this.txtXMoved.Size = new System.Drawing.Size(49, 20);
            this.txtXMoved.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "X (Optional)";
            // 
            // txtColorMoved
            // 
            this.txtColorMoved.Enabled = false;
            this.txtColorMoved.Location = new System.Drawing.Point(99, 358);
            this.txtColorMoved.Name = "txtColorMoved";
            this.txtColorMoved.Size = new System.Drawing.Size(49, 20);
            this.txtColorMoved.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Color (Optional)";
            // 
            // chkDrag
            // 
            this.chkDrag.AutoSize = true;
            this.chkDrag.Location = new System.Drawing.Point(17, 293);
            this.chkDrag.Name = "chkDrag";
            this.chkDrag.Size = new System.Drawing.Size(49, 17);
            this.chkDrag.TabIndex = 39;
            this.chkDrag.Text = "Drag";
            this.chkDrag.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdoSequencial);
            this.panel4.Controls.Add(this.rdoSpeed);
            this.panel4.Location = new System.Drawing.Point(274, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 25);
            this.panel4.TabIndex = 38;
            // 
            // rdoSequencial
            // 
            this.rdoSequencial.AutoSize = true;
            this.rdoSequencial.Location = new System.Drawing.Point(69, 3);
            this.rdoSequencial.Name = "rdoSequencial";
            this.rdoSequencial.Size = new System.Drawing.Size(75, 17);
            this.rdoSequencial.TabIndex = 1;
            this.rdoSequencial.Text = "Sequential";
            this.rdoSequencial.UseVisualStyleBackColor = true;
            // 
            // rdoSpeed
            // 
            this.rdoSpeed.AutoSize = true;
            this.rdoSpeed.Checked = true;
            this.rdoSpeed.Location = new System.Drawing.Point(8, 3);
            this.rdoSpeed.Name = "rdoSpeed";
            this.rdoSpeed.Size = new System.Drawing.Size(56, 17);
            this.rdoSpeed.TabIndex = 0;
            this.rdoSpeed.TabStop = true;
            this.rdoSpeed.Text = "Speed";
            this.rdoSpeed.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClear2);
            this.panel3.Controls.Add(this.btnClear1);
            this.panel3.Controls.Add(this.btnGetPosition);
            this.panel3.Controls.Add(this.lblXPos);
            this.panel3.Controls.Add(this.txtXPos);
            this.panel3.Controls.Add(this.lblYPos);
            this.panel3.Controls.Add(this.txtYPos);
            this.panel3.Controls.Add(this.lblColor1);
            this.panel3.Controls.Add(this.txtColor1);
            this.panel3.Controls.Add(this.lblColor2);
            this.panel3.Controls.Add(this.btnGetPosition2);
            this.panel3.Controls.Add(this.txtColor2);
            this.panel3.Controls.Add(this.txtY2);
            this.panel3.Controls.Add(this.lblX2);
            this.panel3.Controls.Add(this.lblY2);
            this.panel3.Controls.Add(this.txtX2);
            this.panel3.Location = new System.Drawing.Point(12, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(423, 90);
            this.panel3.TabIndex = 37;
            // 
            // btnGetPosition
            // 
            this.btnGetPosition.Location = new System.Drawing.Point(144, 8);
            this.btnGetPosition.Name = "btnGetPosition";
            this.btnGetPosition.Size = new System.Drawing.Size(55, 47);
            this.btnGetPosition.TabIndex = 11;
            this.btnGetPosition.Text = "Get Position";
            this.btnGetPosition.UseVisualStyleBackColor = true;
            // 
            // lblXPos
            // 
            this.lblXPos.AutoSize = true;
            this.lblXPos.Location = new System.Drawing.Point(8, 9);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(46, 13);
            this.lblXPos.TabIndex = 9;
            this.lblXPos.Text = "X (Main)";
            // 
            // txtXPos
            // 
            this.txtXPos.Location = new System.Drawing.Point(84, 9);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.Size = new System.Drawing.Size(50, 20);
            this.txtXPos.TabIndex = 4;
            // 
            // lblYPos
            // 
            this.lblYPos.AutoSize = true;
            this.lblYPos.Location = new System.Drawing.Point(8, 35);
            this.lblYPos.Name = "lblYPos";
            this.lblYPos.Size = new System.Drawing.Size(46, 13);
            this.lblYPos.TabIndex = 11;
            this.lblYPos.Text = "Y (Main)";
            // 
            // txtYPos
            // 
            this.txtYPos.Location = new System.Drawing.Point(84, 35);
            this.txtYPos.Name = "txtYPos";
            this.txtYPos.Size = new System.Drawing.Size(50, 20);
            this.txtYPos.TabIndex = 5;
            // 
            // lblColor1
            // 
            this.lblColor1.AutoSize = true;
            this.lblColor1.Location = new System.Drawing.Point(9, 61);
            this.lblColor1.Name = "lblColor1";
            this.lblColor1.Size = new System.Drawing.Size(63, 13);
            this.lblColor1.TabIndex = 17;
            this.lblColor1.Text = "Color (Main)";
            // 
            // txtColor1
            // 
            this.txtColor1.Location = new System.Drawing.Point(84, 61);
            this.txtColor1.Name = "txtColor1";
            this.txtColor1.Size = new System.Drawing.Size(50, 20);
            this.txtColor1.TabIndex = 6;
            // 
            // lblColor2
            // 
            this.lblColor2.AutoSize = true;
            this.lblColor2.Location = new System.Drawing.Point(211, 63);
            this.lblColor2.Name = "lblColor2";
            this.lblColor2.Size = new System.Drawing.Size(88, 13);
            this.lblColor2.TabIndex = 19;
            this.lblColor2.Text = "Color 2 (Optional)";
            // 
            // btnGetPosition2
            // 
            this.btnGetPosition2.Location = new System.Drawing.Point(362, 8);
            this.btnGetPosition2.Name = "btnGetPosition2";
            this.btnGetPosition2.Size = new System.Drawing.Size(56, 47);
            this.btnGetPosition2.TabIndex = 12;
            this.btnGetPosition2.Text = "Get Position";
            this.btnGetPosition2.UseVisualStyleBackColor = true;
            // 
            // txtColor2
            // 
            this.txtColor2.Location = new System.Drawing.Point(305, 60);
            this.txtColor2.Name = "txtColor2";
            this.txtColor2.Size = new System.Drawing.Size(51, 20);
            this.txtColor2.TabIndex = 9;
            // 
            // txtY2
            // 
            this.txtY2.Location = new System.Drawing.Point(305, 34);
            this.txtY2.Name = "txtY2";
            this.txtY2.Size = new System.Drawing.Size(51, 20);
            this.txtY2.TabIndex = 8;
            // 
            // lblX2
            // 
            this.lblX2.AutoSize = true;
            this.lblX2.Location = new System.Drawing.Point(231, 11);
            this.lblX2.Name = "lblX2";
            this.lblX2.Size = new System.Drawing.Size(68, 13);
            this.lblX2.TabIndex = 21;
            this.lblX2.Text = "X2 (Optional)";
            // 
            // lblY2
            // 
            this.lblY2.AutoSize = true;
            this.lblY2.Location = new System.Drawing.Point(231, 38);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(68, 13);
            this.lblY2.TabIndex = 23;
            this.lblY2.Text = "Y2 (Optional)";
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(305, 9);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(51, 20);
            this.txtX2.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(247, 311);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(188, 43);
            this.txtDescription.TabIndex = 36;
            this.txtDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Describe your command";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClearAll);
            this.panel2.Controls.Add(this.btnUpdateScript);
            this.panel2.Controls.Add(this.btnClearScripts);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnRun);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Location = new System.Drawing.Point(9, 393);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 41);
            this.panel2.TabIndex = 34;
            // 
            // btnUpdateScript
            // 
            this.btnUpdateScript.Location = new System.Drawing.Point(57, 4);
            this.btnUpdateScript.Name = "btnUpdateScript";
            this.btnUpdateScript.Size = new System.Drawing.Size(51, 34);
            this.btnUpdateScript.TabIndex = 30;
            this.btnUpdateScript.Text = "Update Script";
            this.btnUpdateScript.UseVisualStyleBackColor = true;
            // 
            // btnClearScripts
            // 
            this.btnClearScripts.Location = new System.Drawing.Point(377, 3);
            this.btnClearScripts.Name = "btnClearScripts";
            this.btnClearScripts.Size = new System.Drawing.Size(46, 35);
            this.btnClearScripts.TabIndex = 15;
            this.btnClearScripts.Text = "Clear Scripts";
            this.btnClearScripts.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(160, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(51, 34);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(217, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(55, 34);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop (Alt-S)";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(277, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(52, 34);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "Save Script";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(332, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(44, 34);
            this.btnImport.TabIndex = 29;
            this.btnImport.Text = "Load Script";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // grbIgnore
            // 
            this.grbIgnore.Controls.Add(this.btnClearIgnored);
            this.grbIgnore.Controls.Add(this.txtNo);
            this.grbIgnore.Controls.Add(this.btnGetPositionIgnored1);
            this.grbIgnore.Controls.Add(this.txtYIgnored1);
            this.grbIgnore.Controls.Add(this.label2);
            this.grbIgnore.Controls.Add(this.txtXIgnored1);
            this.grbIgnore.Controls.Add(this.label3);
            this.grbIgnore.Controls.Add(this.txtColorIgnored1);
            this.grbIgnore.Controls.Add(this.label4);
            this.grbIgnore.Cursor = System.Windows.Forms.Cursors.Default;
            this.grbIgnore.Location = new System.Drawing.Point(13, 186);
            this.grbIgnore.Name = "grbIgnore";
            this.grbIgnore.Size = new System.Drawing.Size(422, 101);
            this.grbIgnore.TabIndex = 33;
            this.grbIgnore.TabStop = false;
            this.grbIgnore.Text = "Successful Color (If matching this click point, mouse clicking will be ignored)";
            // 
            // txtNo
            // 
            this.txtNo.Enabled = false;
            this.txtNo.Location = new System.Drawing.Point(303, 54);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(100, 20);
            this.txtNo.TabIndex = 31;
            this.txtNo.Visible = false;
            // 
            // btnGetPositionIgnored1
            // 
            this.btnGetPositionIgnored1.Location = new System.Drawing.Point(142, 19);
            this.btnGetPositionIgnored1.Name = "btnGetPositionIgnored1";
            this.btnGetPositionIgnored1.Size = new System.Drawing.Size(56, 44);
            this.btnGetPositionIgnored1.TabIndex = 27;
            this.btnGetPositionIgnored1.Text = "Get Position";
            this.btnGetPositionIgnored1.UseVisualStyleBackColor = true;
            // 
            // txtYIgnored1
            // 
            this.txtYIgnored1.Location = new System.Drawing.Point(86, 43);
            this.txtYIgnored1.Name = "txtYIgnored1";
            this.txtYIgnored1.Size = new System.Drawing.Size(49, 20);
            this.txtYIgnored1.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Y (Optional)";
            // 
            // txtXIgnored1
            // 
            this.txtXIgnored1.Location = new System.Drawing.Point(86, 20);
            this.txtXIgnored1.Name = "txtXIgnored1";
            this.txtXIgnored1.Size = new System.Drawing.Size(49, 20);
            this.txtXIgnored1.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "X (Optional)";
            // 
            // txtColorIgnored1
            // 
            this.txtColorIgnored1.Location = new System.Drawing.Point(86, 67);
            this.txtColorIgnored1.Name = "txtColorIgnored1";
            this.txtColorIgnored1.Size = new System.Drawing.Size(49, 20);
            this.txtColorIgnored1.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Color (Optional)";
            // 
            // btnApplyDelay
            // 
            this.btnApplyDelay.Location = new System.Drawing.Point(157, 65);
            this.btnApplyDelay.Name = "btnApplyDelay";
            this.btnApplyDelay.Size = new System.Drawing.Size(54, 23);
            this.btnApplyDelay.TabIndex = 32;
            this.btnApplyDelay.Text = "Apply";
            this.btnApplyDelay.UseVisualStyleBackColor = true;
            // 
            // btnFixControl
            // 
            this.btnFixControl.Location = new System.Drawing.Point(213, 11);
            this.btnFixControl.Name = "btnFixControl";
            this.btnFixControl.Size = new System.Drawing.Size(55, 42);
            this.btnFixControl.TabIndex = 31;
            this.btnFixControl.Text = "Fix Size Control";
            this.btnFixControl.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtLoopTime);
            this.panel1.Controls.Add(this.rdoLimit);
            this.panel1.Controls.Add(this.rdoInfinity);
            this.panel1.Location = new System.Drawing.Point(274, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 43);
            this.panel1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "time(s)";
            // 
            // txtLoopTime
            // 
            this.txtLoopTime.Enabled = false;
            this.txtLoopTime.Location = new System.Drawing.Point(78, 21);
            this.txtLoopTime.Name = "txtLoopTime";
            this.txtLoopTime.Size = new System.Drawing.Size(41, 20);
            this.txtLoopTime.TabIndex = 2;
            this.txtLoopTime.Text = "1";
            // 
            // rdoLimit
            // 
            this.rdoLimit.AutoSize = true;
            this.rdoLimit.Location = new System.Drawing.Point(69, 3);
            this.rdoLimit.Name = "rdoLimit";
            this.rdoLimit.Size = new System.Drawing.Size(46, 17);
            this.rdoLimit.TabIndex = 1;
            this.rdoLimit.Text = "Limit";
            this.rdoLimit.UseVisualStyleBackColor = true;
            // 
            // rdoInfinity
            // 
            this.rdoInfinity.AutoSize = true;
            this.rdoInfinity.Checked = true;
            this.rdoInfinity.Location = new System.Drawing.Point(8, 3);
            this.rdoInfinity.Name = "rdoInfinity";
            this.rdoInfinity.Size = new System.Drawing.Size(55, 17);
            this.rdoInfinity.TabIndex = 0;
            this.rdoInfinity.TabStop = true;
            this.rdoInfinity.Text = "Infinity";
            this.rdoInfinity.UseVisualStyleBackColor = true;
            // 
            // txtDelay
            // 
            this.txtDelay.Location = new System.Drawing.Point(96, 67);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(50, 20);
            this.txtDelay.TabIndex = 3;
            this.txtDelay.Text = "100";
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(16, 68);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(34, 13);
            this.lblDelay.TabIndex = 13;
            this.lblDelay.Text = "Delay";
            // 
            // btnFindControl
            // 
            this.btnFindControl.Location = new System.Drawing.Point(155, 11);
            this.btnFindControl.Name = "btnFindControl";
            this.btnFindControl.Size = new System.Drawing.Size(55, 42);
            this.btnFindControl.TabIndex = 10;
            this.btnFindControl.Text = "Take Control";
            this.btnFindControl.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(96, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(50, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(17, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(96, 12);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(50, 20);
            this.txtClass.TabIndex = 1;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(18, 15);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(32, 13);
            this.lblClass.TabIndex = 3;
            this.lblClass.Text = "Class";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.lsvScripts);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 437);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(444, 224);
            this.pnlGrid.TabIndex = 2;
            // 
            // lsvScripts
            // 
            this.lsvScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colDelay,
            this.colInfo,
            this.colDescription});
            this.lsvScripts.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvScripts.FullRowSelect = true;
            this.lsvScripts.GridLines = true;
            this.lsvScripts.Location = new System.Drawing.Point(0, 0);
            this.lsvScripts.Name = "lsvScripts";
            this.lsvScripts.Size = new System.Drawing.Size(444, 224);
            this.lsvScripts.TabIndex = 0;
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
            this.btnDelete,
            this.btnGetMousePosition,
            this.btnTryClick});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 70);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(138, 22);
            this.btnDelete.Text = "Delete";
            // 
            // chkIsStartIcon
            // 
            this.chkIsStartIcon.AutoSize = true;
            this.chkIsStartIcon.Location = new System.Drawing.Point(246, 357);
            this.chkIsStartIcon.Name = "chkIsStartIcon";
            this.chkIsStartIcon.Size = new System.Drawing.Size(83, 17);
            this.chkIsStartIcon.TabIndex = 32;
            this.chkIsStartIcon.Text = "Is Start Icon";
            this.chkIsStartIcon.UseVisualStyleBackColor = true;
            // 
            // btnGetMousePosition
            // 
            this.btnGetMousePosition.Name = "btnGetMousePosition";
            this.btnGetMousePosition.Size = new System.Drawing.Size(138, 22);
            this.btnGetMousePosition.Text = "Get Position";
            // 
            // btnTryClick
            // 
            this.btnTryClick.Name = "btnTryClick";
            this.btnTryClick.Size = new System.Drawing.Size(138, 22);
            this.btnTryClick.Text = "Try Click";
            // 
            // btnClear1
            // 
            this.btnClear1.Location = new System.Drawing.Point(144, 60);
            this.btnClear1.Name = "btnClear1";
            this.btnClear1.Size = new System.Drawing.Size(54, 21);
            this.btnClear1.TabIndex = 32;
            this.btnClear1.Text = "Clear";
            this.btnClear1.UseVisualStyleBackColor = true;
            // 
            // btnClear2
            // 
            this.btnClear2.Location = new System.Drawing.Point(362, 59);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(54, 21);
            this.btnClear2.TabIndex = 33;
            this.btnClear2.Text = "Clear";
            this.btnClear2.UseVisualStyleBackColor = true;
            // 
            // btnClearIgnored
            // 
            this.btnClearIgnored.Location = new System.Drawing.Point(142, 66);
            this.btnClearIgnored.Name = "btnClearIgnored";
            this.btnClearIgnored.Size = new System.Drawing.Size(54, 21);
            this.btnClearIgnored.TabIndex = 33;
            this.btnClearIgnored.Text = "Clear";
            this.btnClearIgnored.UseVisualStyleBackColor = true;
            // 
            // btnClearMoved
            // 
            this.btnClearMoved.Location = new System.Drawing.Point(157, 357);
            this.btnClearMoved.Name = "btnClearMoved";
            this.btnClearMoved.Size = new System.Drawing.Size(54, 21);
            this.btnClearMoved.TabIndex = 34;
            this.btnClearMoved.Text = "Clear";
            this.btnClearMoved.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(112, 4);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(40, 34);
            this.btnClearAll.TabIndex = 31;
            this.btnClearAll.Text = "Clear";
            this.btnClearAll.UseVisualStyleBackColor = true;
            // 
            // chkRunOnce
            // 
            this.chkRunOnce.AutoSize = true;
            this.chkRunOnce.Location = new System.Drawing.Point(333, 357);
            this.chkRunOnce.Name = "chkRunOnce";
            this.chkRunOnce.Size = new System.Drawing.Size(73, 17);
            this.chkRunOnce.TabIndex = 48;
            this.chkRunOnce.Text = "Run once";
            this.chkRunOnce.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnStop;
            this.ClientSize = new System.Drawing.Size(444, 661);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlControl);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KClick";
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.grbIgnore.ResumeLayout(false);
            this.grbIgnore.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ListView lsvScripts;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.Button btnFindControl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtYPos;
        private System.Windows.Forms.Label lblYPos;
        private System.Windows.Forms.TextBox txtXPos;
        private System.Windows.Forms.Label lblXPos;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.ColumnHeader colDelay;
        private System.Windows.Forms.Button btnClearScripts;
        private System.Windows.Forms.Button btnGetPosition;
        private System.Windows.Forms.TextBox txtColor1;
        private System.Windows.Forms.Label lblColor1;
        private System.Windows.Forms.TextBox txtColor2;
        private System.Windows.Forms.Label lblColor2;
        private System.Windows.Forms.TextBox txtY2;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.Label lblX2;
        private System.Windows.Forms.Button btnGetPosition2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ColumnHeader colInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoInfinity;
        private System.Windows.Forms.RadioButton rdoLimit;
        private System.Windows.Forms.TextBox txtLoopTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFixControl;
        private System.Windows.Forms.Button btnApplyDelay;
        private System.Windows.Forms.GroupBox grbIgnore;
        private System.Windows.Forms.Button btnGetPositionIgnored1;
        private System.Windows.Forms.TextBox txtYIgnored1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXIgnored1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColorIgnored1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdoSequencial;
        private System.Windows.Forms.RadioButton rdoSpeed;
        private System.Windows.Forms.CheckBox chkDrag;
        private System.Windows.Forms.Button btnUpdateScript;
        private System.Windows.Forms.Button btnGetPositionMoved;
        private System.Windows.Forms.TextBox txtYMoved;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtXMoved;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtColorMoved;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RichTextBox txtProgress;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.CheckBox chkIsStartIcon;
        private System.Windows.Forms.ToolStripMenuItem btnGetMousePosition;
        private System.Windows.Forms.ToolStripMenuItem btnTryClick;
        private System.Windows.Forms.Button btnClear1;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Button btnClearIgnored;
        private System.Windows.Forms.Button btnClearMoved;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.CheckBox chkRunOnce;
    }
}


namespace KClick
{
    partial class MouseHookKeyForm
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
            this.lblXPos = new System.Windows.Forms.Label();
            this.txtXPos = new System.Windows.Forms.TextBox();
            this.lblYPos = new System.Windows.Forms.Label();
            this.txtYPos = new System.Windows.Forms.TextBox();
            this.lblColor1 = new System.Windows.Forms.Label();
            this.txtColor1 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblXPos
            // 
            this.lblXPos.AutoSize = true;
            this.lblXPos.Location = new System.Drawing.Point(15, 12);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(14, 13);
            this.lblXPos.TabIndex = 21;
            this.lblXPos.Text = "X";
            // 
            // txtXPos
            // 
            this.txtXPos.Location = new System.Drawing.Point(91, 12);
            this.txtXPos.Name = "txtXPos";
            this.txtXPos.Size = new System.Drawing.Size(94, 20);
            this.txtXPos.TabIndex = 18;
            // 
            // lblYPos
            // 
            this.lblYPos.AutoSize = true;
            this.lblYPos.Location = new System.Drawing.Point(15, 38);
            this.lblYPos.Name = "lblYPos";
            this.lblYPos.Size = new System.Drawing.Size(14, 13);
            this.lblYPos.TabIndex = 22;
            this.lblYPos.Text = "Y";
            // 
            // txtYPos
            // 
            this.txtYPos.Location = new System.Drawing.Point(91, 38);
            this.txtYPos.Name = "txtYPos";
            this.txtYPos.Size = new System.Drawing.Size(94, 20);
            this.txtYPos.TabIndex = 19;
            // 
            // lblColor1
            // 
            this.lblColor1.AutoSize = true;
            this.lblColor1.Location = new System.Drawing.Point(16, 64);
            this.lblColor1.Name = "lblColor1";
            this.lblColor1.Size = new System.Drawing.Size(31, 13);
            this.lblColor1.TabIndex = 23;
            this.lblColor1.Text = "Color";
            // 
            // txtColor1
            // 
            this.txtColor1.Location = new System.Drawing.Point(91, 64);
            this.txtColor1.Name = "txtColor1";
            this.txtColor1.Size = new System.Drawing.Size(94, 20);
            this.txtColor1.TabIndex = 20;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(191, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(49, 72);
            this.btnStart.TabIndex = 24;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(246, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 72);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // MouseHookKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 90);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblXPos);
            this.Controls.Add(this.txtXPos);
            this.Controls.Add(this.lblYPos);
            this.Controls.Add(this.txtYPos);
            this.Controls.Add(this.lblColor1);
            this.Controls.Add(this.txtColor1);
            this.MaximizeBox = false;
            this.Name = "MouseHookKeyForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouse Hook Key";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblXPos;
        private System.Windows.Forms.TextBox txtXPos;
        private System.Windows.Forms.Label lblYPos;
        private System.Windows.Forms.TextBox txtYPos;
        private System.Windows.Forms.Label lblColor1;
        private System.Windows.Forms.TextBox txtColor1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
    }
}
namespace Helpdesk
{
    partial class resetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(resetPassword));
            this.usernameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usernameOK = new System.Windows.Forms.Button();
            this.usernameCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(12, 83);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(416, 20);
            this.usernameText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter the user\'s username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // usernameOK
            // 
            this.usernameOK.Location = new System.Drawing.Point(328, 13);
            this.usernameOK.Name = "usernameOK";
            this.usernameOK.Size = new System.Drawing.Size(99, 26);
            this.usernameOK.TabIndex = 2;
            this.usernameOK.Text = "OK";
            this.usernameOK.UseVisualStyleBackColor = true;
            this.usernameOK.Click += new System.EventHandler(this.usernameOK_Click);
            // 
            // usernameCancel
            // 
            this.usernameCancel.Location = new System.Drawing.Point(328, 45);
            this.usernameCancel.Name = "usernameCancel";
            this.usernameCancel.Size = new System.Drawing.Size(99, 26);
            this.usernameCancel.TabIndex = 3;
            this.usernameCancel.Text = "Cancel";
            this.usernameCancel.UseVisualStyleBackColor = true;
            this.usernameCancel.Click += new System.EventHandler(this.usernameCancel_Click);
            // 
            // resetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 115);
            this.Controls.Add(this.usernameCancel);
            this.Controls.Add(this.usernameOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "resetPassword";
            this.Text = "Reset Password";
            this.Load += new System.EventHandler(this.resetPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button usernameOK;
        private System.Windows.Forms.Button usernameCancel;
    }
}
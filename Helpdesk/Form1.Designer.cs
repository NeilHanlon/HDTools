namespace Helpdesk
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ResetPassword = new System.Windows.Forms.Button();
            this.CheckPassExpire = new System.Windows.Forms.Button();
            this.CheckPassLastSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ResetPassword
            // 
            this.ResetPassword.Location = new System.Drawing.Point(36, 57);
            this.ResetPassword.Name = "ResetPassword";
            this.ResetPassword.Size = new System.Drawing.Size(97, 61);
            this.ResetPassword.TabIndex = 0;
            this.ResetPassword.Text = "Reset Password";
            this.ResetPassword.UseVisualStyleBackColor = true;
            this.ResetPassword.Click += new System.EventHandler(this.button1_Click);
            // 
            // CheckPassExpire
            // 
            this.CheckPassExpire.Location = new System.Drawing.Point(139, 57);
            this.CheckPassExpire.Name = "CheckPassExpire";
            this.CheckPassExpire.Size = new System.Drawing.Size(97, 61);
            this.CheckPassExpire.TabIndex = 1;
            this.CheckPassExpire.Text = "Check Password Expiration";
            this.CheckPassExpire.UseVisualStyleBackColor = true;
            this.CheckPassExpire.Click += new System.EventHandler(this.button2_Click);
            // 
            // CheckPassLastSet
            // 
            this.CheckPassLastSet.Location = new System.Drawing.Point(36, 124);
            this.CheckPassLastSet.Name = "CheckPassLastSet";
            this.CheckPassLastSet.Size = new System.Drawing.Size(97, 61);
            this.CheckPassLastSet.TabIndex = 2;
            this.CheckPassLastSet.Text = "Check Password Last Set";
            this.CheckPassLastSet.UseVisualStyleBackColor = true;
            this.CheckPassLastSet.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Version 1.1.0.4";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckPassLastSet);
            this.Controls.Add(this.CheckPassExpire);
            this.Controls.Add(this.ResetPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Helpdesk Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResetPassword;
        private System.Windows.Forms.Button CheckPassExpire;
        private System.Windows.Forms.Button CheckPassLastSet;
        private System.Windows.Forms.Label label1;
    }
}


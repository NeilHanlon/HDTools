namespace Helpdesk
{
    partial class InfoWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoWindow));
            this.infowindowCancel = new System.Windows.Forms.Button();
            this.infowindowOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.message = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // infowindowCancel
            // 
            this.infowindowCancel.Location = new System.Drawing.Point(349, 85);
            this.infowindowCancel.Name = "infowindowCancel";
            this.infowindowCancel.Size = new System.Drawing.Size(99, 26);
            this.infowindowCancel.TabIndex = 5;
            this.infowindowCancel.Text = "Cancel";
            this.infowindowCancel.UseVisualStyleBackColor = true;
            this.infowindowCancel.Click += new System.EventHandler(this.infowindowCancel_Click);
            // 
            // infowindowOK
            // 
            this.infowindowOK.Location = new System.Drawing.Point(244, 85);
            this.infowindowOK.Name = "infowindowOK";
            this.infowindowOK.Size = new System.Drawing.Size(99, 26);
            this.infowindowOK.TabIndex = 4;
            this.infowindowOK.Text = "OK";
            this.infowindowOK.UseVisualStyleBackColor = true;
            this.infowindowOK.Click += new System.EventHandler(this.usernameOK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(-2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 47);
            this.panel1.TabIndex = 6;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(13, 29);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(0, 13);
            this.message.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 8;
            // 
            // InfoWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 123);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.message);
            this.Controls.Add(this.infowindowCancel);
            this.Controls.Add(this.infowindowOK);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoWindow";
            this.Text = "Information";
            this.Load += new System.EventHandler(this.InfoWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button infowindowCancel;
        private System.Windows.Forms.Button infowindowOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Label label1;
    }
}
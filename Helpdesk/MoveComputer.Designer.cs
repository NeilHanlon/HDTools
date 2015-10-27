namespace Helpdesk
{
    partial class MoveComputer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveComputer));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.computer_name = new System.Windows.Forms.TextBox();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.move_fix_button = new System.Windows.Forms.Button();
            this.move_back_after_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(517, 218);
            this.textBox1.TabIndex = 100;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // computer_name
            // 
            this.computer_name.Location = new System.Drawing.Point(101, 248);
            this.computer_name.Name = "computer_name";
            this.computer_name.Size = new System.Drawing.Size(420, 20);
            this.computer_name.TabIndex = 0;
            this.computer_name.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // move_fix_button
            // 
            this.move_fix_button.Location = new System.Drawing.Point(12, 288);
            this.move_fix_button.Name = "move_fix_button";
            this.move_fix_button.Size = new System.Drawing.Size(253, 78);
            this.move_fix_button.TabIndex = 101;
            this.move_fix_button.Text = "Move to OU for fix";
            this.move_fix_button.UseVisualStyleBackColor = true;
            this.move_fix_button.Click += new System.EventHandler(this.move_fix_button_Click);
            // 
            // move_back_after_button
            // 
            this.move_back_after_button.Location = new System.Drawing.Point(276, 288);
            this.move_back_after_button.Name = "move_back_after_button";
            this.move_back_after_button.Size = new System.Drawing.Size(253, 78);
            this.move_back_after_button.TabIndex = 102;
            this.move_back_after_button.Text = "Move back AFTER fix";
            this.move_back_after_button.UseVisualStyleBackColor = true;
            this.move_back_after_button.Click += new System.EventHandler(this.move_back_after_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Computer Name";
            // 
            // MoveComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 378);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.move_back_after_button);
            this.Controls.Add(this.move_fix_button);
            this.Controls.Add(this.computer_name);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoveComputer";
            this.Text = "Move Computer (EDUROAM Fix)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox computer_name;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Button move_fix_button;
        private System.Windows.Forms.Button move_back_after_button;
        private System.Windows.Forms.Label label1;
    }
}
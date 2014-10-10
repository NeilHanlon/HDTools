using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpdesk
{
    public partial class CheckAccount : Form
    {
        public resetPassword resetPass = new resetPassword();
        public InfoWindow infoWindow = new InfoWindow();
        /**
         * 1 = check password expire
         * 2 = check last set
         **/
        public static int status_code;
        public int status
        {
            get { return status_code; }
            set { status_code = value; }
        }
        public CheckAccount()
        {
            InitializeComponent();
        }

        private void usernameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            usernameText.Focus();
            
            if (status_code == 1)
            {
                String message = resetPass.checkPasswordExpire(usernameText.Text);
                try
                {
                    infoWindow.updateInfo(message, "OK", "OK");
                    infoWindow.info_OK.Hide();
                    infoWindow.Show();
                }
                catch
                {
                    InfoWindow infoWindow = new InfoWindow();
                    infoWindow.Hide();
                    infoWindow.updateInfo(message, "OK", "OK");
                    infoWindow.info_OK.Hide();
                    infoWindow.Show();
                }
                this.usernameText.Text = "";
                usernameText.Focus();
                return;
            }
            if(status_code == 2)
            {
                String message = resetPass.getPassExpire(usernameText.Text);
                try
                {
                    infoWindow.updateInfo(message, "OK", "OK");
                    infoWindow.info_OK.Hide();
                    infoWindow.Show();
                }
                catch
                {
                    InfoWindow infoWindow = new InfoWindow();
                    infoWindow.Hide();
                    infoWindow.updateInfo(message, "OK", "OK");
                    infoWindow.info_OK.Hide();
                    infoWindow.Show();
                }
                this.usernameText.Text = "";
                usernameText.Focus();
                return;
            }
            this.usernameText.Text = "";
            usernameText.Focus();
        }

        private void usernameCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.usernameText.Text = "";
            usernameText.Focus();
        }

        private void CheckAccount_Load(object sender, EventArgs e)
        {
            this.usernameText.Focus();
        }
    }
}

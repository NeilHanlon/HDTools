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
    public partial class InfoWindow : Form
    {
        /**
         * 0 = nothing
         * 1 = showing expiration info
         * 2 = asking if you want to reset
         * 3 = confirming Wentworth ID Number
         * 4 = password has been reset
         * 10 = general information.
         **/
        public static int status_code = 0;
        public int status { 
            get { return status_code; }
            set { status_code = value; }
        }
        public resetPassword passForm = new resetPassword();
        public InfoWindow()
        {
            InitializeComponent();
        }

        public Label messageLabel { get { return message; } }
        public Button info_OK { get { return infowindowOK; } }
        public Button info_Cancel { get { return infowindowCancel; } }
        public void updateInfo(String newMessage, String OKButtonText = "OK", String CancelButtonText = "Cancel")
        {
            message.Text = newMessage;
            infowindowCancel.Text = CancelButtonText;
            infowindowOK.Text = OKButtonText;
        }
        private void usernameOK_Click(object sender, EventArgs e)
        {
            if(status_code == 1)
            {
                Console.WriteLine(status_code);
                this.updateInfo("Would you like to reset the password for " + passForm.FullName + "?","Yes","No");
                status_code = 2;
                return;
            }
            if(status_code == 2)
            {
                Console.WriteLine(status_code);
                this.updateInfo("Please confirm that the Wentworth ID Number for " + passForm.FullName +
                    " is " + passForm.EmployeeID + ".", "Yes", "No");
                this.label1.Text = "THIS WILL RESET THE PASSWORD.";
                status_code = 3;
                return;
            }
            if(status_code == 3)
            {
                Console.WriteLine(status_code);
                if(passForm.doResetPassword(passForm.DistinguishedName))
                {
                    status_code = 4;
                    this.updateInfo("Password Successfully Changed for " + passForm.FullName + ".", "OK", "OK");
                    infowindowOK.Hide();
                    return;
                }
                else
                {
                    this.updateInfo("An unknown error occured.", "OK", "OK");
                    infowindowOK.Hide();
                    status_code = -1; //fail!
                    return;
                }
                
            }
            if(status_code == -50)
            {
                this.Hide();
            }
        }
        private void infowindowCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InfoWindow_Load(object sender, EventArgs e)
        {

        }
    }
}

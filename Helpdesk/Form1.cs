using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;

namespace Helpdesk
{
    public partial class Form1 : Form
    {
        resetPassword resetPasswordForm = new resetPassword();
        private CheckAccount checkAccount = new CheckAccount();
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Reset Password
            try
            {
                resetPasswordForm.Show();
            } catch
            {
                resetPasswordForm = new resetPassword();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                checkAccount.status = 1;
                checkAccount.Show();
            }
            catch
            {
                CheckAccount checkAccount = new CheckAccount();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                checkAccount.status = 2;
                checkAccount.Show();
            }
            catch
            {
                CheckAccount checkAccount = new CheckAccount();
            }
        }
    }
}

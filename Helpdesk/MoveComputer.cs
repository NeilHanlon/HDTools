using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;

namespace Helpdesk
{
    public partial class MoveComputer : Form
    {
        public MoveComputer()
        {
            InitializeComponent();
            computer_name.Focus();
        }

        public static int status_code;
        public int status
        {
            get { return status_code; }
            set { status_code = value; }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void move_fix_button_Click(object sender, EventArgs e)
        {
            // This moves the computer from Campus Computers to the OU without EDUROAM GPO applied to fix connection
            String pc_name = computer_name.Text;
            if (String.IsNullOrEmpty(pc_name))
            {
                InfoWindow error = new InfoWindow();
                error.updateInfo("Invalid or empty computer name provided.", "OK", "OK");
                error.status = -50;
                error.info_OK.Hide();
                error.Show();
            }
            else
            {
                try
                {
                    DirectoryEntry theObjectToMove = new DirectoryEntry("LDAP://CN="+pc_name+",OU=Campus Computers,OU=WIT Computers,DC=wit,DC=private");
                    DirectoryEntry theNewParent = new DirectoryEntry("LDAP://OU=eduroamfix,OU=Campus Computers,OU=WIT Computers,dc=wit,dc=private");
                    theObjectToMove.MoveTo(theNewParent);
                    InfoWindow success = new InfoWindow();
                    success.updateInfo("Object " + pc_name + " moved to the eduroamfix OU.\nPlease wait a minute and then proceed with the fix.");
                    success.info_OK.Hide();
                    success.Show();
                }
                catch
                {
                    InfoWindow error = new InfoWindow();
                    error.updateInfo("Something went wrong. Try again, and if this message still appears, contact Neil Hanlon.\nOften, this can mean that the user is already in the OU!\nCheck that you're pressing the right button!", "OK", "OK");
                    error.status = -50;
                    error.info_OK.Hide();
                    error.Show();
                }
            }
         
        }

        private void move_back_after_button_Click(object sender, EventArgs e)
        {
            // This moves the computer from eduroamfix to the Campus Computer OU
            String pc_name = computer_name.Text;
            if (String.IsNullOrEmpty(pc_name))
            {
                InfoWindow error = new InfoWindow();
                error.updateInfo("Invalid or empty computer name provided.", "OK", "OK");
                error.status = -50;
                error.info_OK.Hide();
                error.Show();
            }
            else
            {
                try
                {
                    DirectoryEntry theObjectToMove = new DirectoryEntry("LDAP://local-dc1.wit.private/CN=" + pc_name + ",OU=eduroamfix,OU=Campus Computers,OU=WIT Computers,DC=wit,DC=private");
                    DirectoryEntry theNewParent = new DirectoryEntry("LDAP://local-dc1.wit.private/OU=Campus Computers,OU=WIT Computers,dc=wit,dc=private");
                    theObjectToMove.MoveTo(theNewParent);
                    InfoWindow success = new InfoWindow();
                    success.updateInfo("Object " + pc_name + " moved back to the Campus Computers OU.\nPlease wait a minute and check the user's connection.", "OK", "OK");
                    success.status = -50;
                    success.info_OK.Hide();
                    success.Show();
                }
                catch
                {
                    InfoWindow error = new InfoWindow();
                    error.updateInfo("Something went wrong. Try again, and if this message still appears, contact Neil Hanlon.\nOften, this can mean that the user is already in the OU!\nCheck that you're pressing the right button!", "OK", "OK");
                    error.status = -50;
                    error.info_OK.Hide();
                    error.Show();
                }
            }
        }


    }
}

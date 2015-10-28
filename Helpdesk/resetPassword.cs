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
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Helpdesk
{
    public partial class resetPassword : Form
    {
        static String userDN = "";
        static String name = "";
        static String employeeID;
        static String uName = "";
        public String FullName { get { return name; } }
        public String EmployeeID { get { return employeeID; } }
        public String DistinguishedName { get { return userDN; } }
        public String username { get { return uName; } }

        PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
        UserPrincipal user = null;
        public resetPassword()
        {
            InitializeComponent();
        }

        public void SetFocus()
        {
            this.usernameText.Focus();
        }

        public resetPassword passResetForm { get { return this; } }
        private void resetPassword_Load(object sender, EventArgs e)
        {
            this.usernameText.Clear();
            this.AcceptButton = this.usernameOK;
        }
        public string GetUserDn(string identity)
        {
            var userName = identity;
            var domain = new PrincipalContext(ContextType.Domain);
            var user = UserPrincipal.FindByIdentity(domain, userName);
            return user != null ? user.DistinguishedName : null;
        }

        public String getPassExpire(string username)
        {
            DateTime PasswordLastSet = DateTime.Now;
            String fullName = null;

            userDN = GetUserDn(username);
            try
            {
                user = UserPrincipal.FindByIdentity(ctx, userDN);

                if (user != null)
                {
                    PasswordLastSet = (DateTime)user.LastPasswordSet;
                    fullName = user.Name;
                }
                return "Password for " + fullName + " was last set on " + PasswordLastSet.ToString() + ".";
            }
            catch 
            {
                throw new InvalidUserException("User not found in directory");
            }
        }

        private void usernameOK_Click(object sender, EventArgs e)
        {
            this.Hide();

            try
            {
                userDN = GetUserDn(usernameText.Text);

                String message = checkPasswordExpire(usernameText.Text);

                InfoWindow showExpireInfo = new InfoWindow();
                showExpireInfo.status = 1;
                showExpireInfo.Text = "Password Expiration for " + usernameText.Text;
                showExpireInfo.messageLabel.Text = message;
                showExpireInfo.Show();
                uName = this.usernameText.Text;
                this.usernameText.Clear();
            }
            catch (InvalidUserException ex)
            {
                InfoWindow exception = new InfoWindow();
                exception.status = -50;
                exception.updateInfo("Something went wrong. The error thrown by the application was: " + ex.Message + "\nPlease try again", "OK", "OK");
                exception.info_OK.Hide();
                exception.Show();
            }

            this.usernameText.Clear();
        }

        public Boolean doResetPassword(string userDN)
        {
            try
            {
                string password = "WIT1$";
                password += employeeID.Substring(3);
                DirectoryEntry uEntry = new DirectoryEntry("LDAP://local-dc1.wit.private/" + userDN);
                uEntry.Invoke("SetPassword", new object[] { password });
                uEntry.Properties["LockOutTime"].Value = 0; //unlock account
                uEntry.Properties["pwdLastSet"].Value = 0; //user must change password
                uEntry.CommitChanges();
                uEntry.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public String checkPasswordExpire(String userName)
        {
            DateTime PasswordLastSet = DateTime.Now;
            Boolean PasswordNeverExpires = false;

            userDN = GetUserDn(userName);
            try
            {
                user = UserPrincipal.FindByIdentity(ctx, userDN);

                if (user != null)
                {
                    PasswordLastSet = (DateTime)user.LastPasswordSet;
                    PasswordNeverExpires = user.PasswordNeverExpires;
                    name = user.Name.ToString();
                    employeeID = user.EmployeeId.ToString();
                }

                if (PasswordNeverExpires == true)
                {
                    return "Password for " + name + " never expires.";
                }
                else
                {
                    if (PasswordLastSet == null)
                    {
                        return "Password for " + name + " has never been set.";
                    }
                    else
                    {
                        DateTime passExpires = PasswordLastSet.AddDays(180);
                        Console.WriteLine(passExpires);
                        Console.WriteLine(PasswordLastSet);
                        if (passExpires < DateTime.Now)
                        {
                            return "Password for " + name + " expired on " + passExpires + ".";
                        }
                        else
                        {
                            return "Password for " + name + " is not expired and expires on " + passExpires.ToString();
                        }
                    }
                }
            }
            catch
            {
                throw new InvalidUserException("User not found in directory.");
            }
        }

        private void usernameCancel_Click(object sender, EventArgs e)
        {
            usernameText.Clear();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

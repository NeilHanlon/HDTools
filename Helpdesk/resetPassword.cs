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
        public resetPassword()
        {
            InitializeComponent();
        }

        public resetPassword passResetForm { get { return this; } }
        private void resetPassword_Load(object sender, EventArgs e)
        {

        }

        public String getPassExpire(string username)
        {
            DateTime PasswordLastSet = DateTime.Now;
            String fullName = "";
            using (PowerShell ps = PowerShell.Create())
            {

                String properties = "PasswordLastSet";
                ps.AddScript("Get-ADUser " + username + " -Properties " + properties);

                Collection<PSObject> result = ps.Invoke();

                foreach (PSObject outputItem in result)
                {
                    if (outputItem != null)
                    {
                        PasswordLastSet = (DateTime)outputItem.Properties["PasswordLastSet"].Value;
                        fullName = outputItem.Properties["Name"].Value.ToString();
                    }
                }
                Console.WriteLine(PasswordLastSet);
                Console.WriteLine(fullName);
                return "Password for " + fullName + " was last set on " + PasswordLastSet.ToString() + ".";
            }
        }

        private void usernameOK_Click(object sender, EventArgs e)
        {
            this.Hide();
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
        public string GetUserDn(string identity)
        {
            var userName = identity;
            using (var rootEntry = new DirectoryEntry("LDAP://local-dc1.wit.private/DC=wit,DC=private"))
            {
                using (var directorySearcher = new DirectorySearcher(rootEntry, String.Format("(sAMAccountName={0})", userName)))
                {
                    var searchResult = directorySearcher.FindOne();
                    if (searchResult != null)
                    {
                        using (var userEntry = searchResult.GetDirectoryEntry())
                        {
                            return (string)userEntry.Properties["distinguishedName"].Value;
                        }
                    }
                }
            }
            return null;
        }
        public Boolean doResetPassword(string userDN)
        {
            try
            {
                string password = "WIT1$";
                password += employeeID.Substring(3);
                //Console.WriteLine(password);
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
            using (PowerShell ps = PowerShell.Create())
            {
                DateTime PasswordLastSet = DateTime.Now;
                Boolean PasswordExpired = false;
                Boolean PasswordNeverExpires = false;

                String properties = "PasswordLastSet,PasswordExpired,PasswordNeverExpires,EmployeeID";
                ps.AddScript("Get-ADUser " + userName + " -Properties " + properties);

                Collection<PSObject> result = ps.Invoke();

                foreach (PSObject outputItem in result)
                {
                    if (outputItem != null)
                    {
                        PasswordLastSet = (DateTime)outputItem.Properties["PasswordLastSet"].Value;
                        PasswordExpired = (outputItem.Properties["PasswordExpired"].Value.ToString() == "False") ? false : true;
                        PasswordNeverExpires = (outputItem.Properties["PasswordNeverExpires"].Value.ToString() == "False") ? false : true;
                        name = outputItem.Properties["Name"].Value.ToString();
                        employeeID = outputItem.Properties["EmployeeID"].Value.ToString();
                    }
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
                        if (passExpires > DateTime.Now && PasswordExpired)
                        {
                            return "Password for " + name + " has expired.";
                        }
                        else
                        {
                            return "Password for " + name + " is not expired and expires on " + passExpires.ToString();
                        }
                    }
                }
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

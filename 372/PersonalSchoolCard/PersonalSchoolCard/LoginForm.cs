using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Core;
using PersonalSchoolCard.Data;

namespace PersonalShcoolCard
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        string schoolYear = Classes.SchoolYearDA.GetCurrentSchoolYear();
        private void LoginButt_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text != "admin" && textBoxPassword.Text != "admin")
                try
                {
                    if (Classes.TeacherDA.HasClass(Classes.TeacherDA.SearchTeacher(textBoxUserName.Text, textBoxPassword.Text).TeacherID, Classes.SchoolYearDA.GetCurrentSchoolYear()))
                    {
                        Classes.SignClass.LogIn(textBoxUserName.Text, textBoxPassword.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не ви е назначен клас.");
                        textBoxUserName.Clear();
                        textBoxPassword.Clear();
                        textBoxUserName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    if (ex is EntityException)
                    {
                        MessageBox.Show("Няма свързана база от данни.");
                        textBoxUserName.Clear();
                        textBoxPassword.Clear();
                        textBoxUserName.Focus();
                    }
                    if (ex is InvalidOperationException)
                    {
                        MessageBox.Show("Невалидно потребителско име или парола.");
                        textBoxUserName.Clear();
                        textBoxPassword.Clear();
                        textBoxUserName.Focus();
                    }
                }
            else
            {
                Classes.SignClass.LogIn(textBoxUserName.Text, textBoxPassword.Text);
                this.Close();
            }
        }
        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginButt_Click(sender, e);
            }
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginButt_Click(sender, e);
            }
        }

        private void UserNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginButt_Click(sender, e);
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

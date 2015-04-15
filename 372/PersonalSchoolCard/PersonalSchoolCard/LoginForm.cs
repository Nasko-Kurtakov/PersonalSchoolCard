using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalSchoolCard.Data;

namespace PersonalShcoolCard
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginButt_Click(object sender, EventArgs e)
        {
            try
            {
                Classes.SignClass.LogIn(textBoxUserName.Text, textBoxPassword.Text);
                this.Close();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Няма свързана база от данни.");
                textBoxUserName.Clear();
                textBoxPassword.Clear();
                textBoxUserName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невалидно потребителско име или парола.");
                textBoxUserName.Clear();
                textBoxPassword.Clear();
                textBoxUserName.Focus();
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

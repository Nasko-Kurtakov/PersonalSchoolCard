﻿using System;
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
            bool UserValidation = false;
            int teacherID = 0;

            if (UserNameBox.Text == "admin" && PasswordBox.Text == "admin")
            {
                AdminForm af = new AdminForm();

                UserValidation = true;

                af.Show();
            }

            if (!UserValidation)
            {
                string teacherUName = " ";
                var context = new PersonalSchoolCardEntities();
                var teacherUserName = context.Teachers
                    .Select(teacher => teacher.UserName)
                    .ToList()
                    ;
                var teacherPassword = context.Teachers
                    .Select(teacher => teacher.Password)
                    .ToList()
                    ;
                for (int iii = 0; iii < teacherUserName.Count; iii++ )
                {
                    if(UserNameBox.Text == teacherUserName[iii] && PasswordBox.Text == teacherPassword[iii])
                    {
                        teacherUName = teacherUserName[iii];
                        break;
                    }
                }

                teacherID = context.Teachers
                    .Where(teacher => teacher.UserName == teacherUName)
                    .Select(teacher => teacher.TeacherID)
                    .FirstOrDefault()
                    ;



                    if (teacherID != 0)
                    {
                        TeacherForm tf = new TeacherForm(teacherID);
                        tf.Show();
                    }
                    else
                    {
                        MessageBox.Show("Your username/password is incorrect .. ");

                        UserNameBox.Text = " ";
                        PasswordBox.Text = " ";

                        UserNameBox.Focus();
                    }

            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}

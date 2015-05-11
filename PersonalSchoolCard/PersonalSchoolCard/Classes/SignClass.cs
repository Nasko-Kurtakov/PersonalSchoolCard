namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Linq;
    using PersonalSchoolCard.Data;
    public class SignClass
    {
        //this class is used for loging in and out users
        public static void LogIn(string userName, string password)
        {
            if (userName == "admin" && password == "admin")
            {

                var newAdminForm = new AdminForm();
                newAdminForm.Show();

            }
            else
            {
                using (var context = new PersonalSchoolCardEntities())
                {
                    int loggedTeacherID = context.Teachers
                                            .Where(teacher => teacher.UserName == userName && teacher.Password == password)
                                            .Select(teacher => teacher.TeacherID)
                                            .First();
                    var newTeacherForm = new TeacherForm(loggedTeacherID);
                    newTeacherForm.Show();
                }
            }
        }
        public static void LogOut(Form form)
        {
            var myLoginForm = new LoginForm();
            myLoginForm.Show();
            form.Hide();
            form.Dispose();
        }
    }
}

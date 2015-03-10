namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Linq;
    using PersonalSchoolCard.Data;
    public class LogInClass
    {
        public static void LogIn(string userName,string password)
        {
            if (userName=="admin" && password=="admin")
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
    }
}

namespace PersonalShcoolCard.Classes.TeacherFormClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    public class OnLogin
    {
        public static string GetTeacherName(int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var teacher = context.Teachers
                    .Where(t => t.TeacherID == teacherID)
                    .Select(t => t).FirstOrDefault();

                return teacher.GetFullName();
            }
        }
    }
}

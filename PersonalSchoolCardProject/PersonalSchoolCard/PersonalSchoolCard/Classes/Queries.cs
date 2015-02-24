using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalSchoolCard.Data;

namespace PersonalShcoolCard.Classes
{
    class Queries
    {


        public static string GetTeacherName(int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var teacherNames = context.Teachers
                    .Where(teacher => teacher.TeacherID == teacherID)
                    .Select(teacher => new
                    {
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName
                    })
                    .FirstOrDefault()
                    ;

                return teacherNames.FirstName + " "
                    + teacherNames.LastName
                    ;
            }
        }

    }
}

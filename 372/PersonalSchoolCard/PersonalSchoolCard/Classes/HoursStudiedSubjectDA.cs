namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    using System.Windows.Forms;
    public class HoursStudiedSubjectDA
    {
        public static void SaveHoursStudiedSubject(DataGridView gridViewSubjects, DataGridView gridViewHoursStudied, int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                for (int i = 0; i < gridViewSubjects.Rows.Count; i++)
                {
                    if (gridViewHoursStudied.Rows[i].Cells[0].Value != null)
                    {
                        var subjectID = SubjectDA.GetSubjectID(gridViewSubjects.Rows[i].Cells[0].Value.ToString());
                        var subjectTypeID = SubjectDA.GetSubjectTypeID(gridViewSubjects.Columns[2].Name.ToString().Substring(0, 2));
                        var profileID = ProfileDA.GetProfileIDByClassName(TeacherDA.GetClassNameByTeacherID(teacherID,SchoolYearDA.GetCurrentSchoolYear()));
                        var classID = TeacherDA.GetClassIDByTeacherID(teacherID);
                        var hoursStudiedSubject = new HoursStudiedSubject
                        {
                            ClassID = classID,
                            ProfileID = profileID,
                            SubjectID = subjectID,
                            SubjectTypeID = subjectTypeID,
                            HoursStudied = int.Parse(gridViewHoursStudied.Rows[i].Cells[0].Value.ToString())
                        };
                        context.HoursStudiedSubjects.Add(hoursStudiedSubject);
                        
                    }
                }
                context.SaveChanges();
            }
        }
    }
}

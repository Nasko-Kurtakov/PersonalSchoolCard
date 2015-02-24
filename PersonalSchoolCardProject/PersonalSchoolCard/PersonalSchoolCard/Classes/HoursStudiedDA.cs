namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    using System.Windows.Forms;
    public class HoursStudiedDA
    {
        public static void SaveHoursStudied(DataGridView gridView,int teacherID)
        {
            for (int i = 0; i < gridView.Rows.Count-1; i++)
            {
                var newHourStudied = new HoursStudiedSubject
                {
                    ClassID = SchoolClassDA.GetClassIDByTeacherID(teacherID),
                    SubjectID = SubjectDA.GetSubjectID(gridView.Rows[i].Cells[0].ToString()),
                    //SubjectTypeID = SubjectDA.GetSubjectTypeID()

                };
            }
        }
    }
}

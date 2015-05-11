namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class AbsencesDA
    {
        public static void SaveAbsences(DataGridView gridView, long studentID, int teacherID)
        {
            using (var contex = new PersonalSchoolCardEntities())
            {
                var classID = SchoolClassDA.GetSchoolClassByTeacherID(teacherID).ClassID;

                for (int i = 0; i < gridView.Rows.Count; i++)
                {
                    if (gridView.Rows[i].Cells[1].Value != null)
                    {
                        var absenceTypeName = gridView.Rows[i].Cells[0].Value.ToString();
                        var absenceTypeID = AbsencesTypeDA.GetAbsenceIDTypeByName(absenceTypeName);
                        var termID = TermDA.GetTermIDByName(gridView.Columns[1].HeaderText.ToString());
                        var absences = gridView.Rows[i].Cells[1].Value.ToString();

                        var newAbsencesEntity = new Absence
                        {
                            StudentID = studentID,
                            ClassID = classID,
                            TermID = termID,
                            TypeAbsenceID = absenceTypeID,
                            AbsencesNumber = absences
                        };
                        contex.Absences.Add(newAbsencesEntity);
                    }
                    if (gridView.Rows[i].Cells[2].Value != null)
                    {
                        var absenceTypeName = gridView.Rows[i].Cells[0].Value.ToString();
                        var absenceTypeID = AbsencesTypeDA.GetAbsenceIDTypeByName(absenceTypeName);
                        var termID = TermDA.GetTermIDByName(gridView.Columns[2].HeaderText.ToString());
                        var absences = gridView.Rows[i].Cells[2].Value.ToString();

                        var newAbsencesEntity = new Absence
                        {
                            StudentID = studentID,
                            ClassID = classID,
                            TermID = termID,
                            TypeAbsenceID = absenceTypeID,
                            AbsencesNumber = absences
                        };
                        contex.Absences.Add(newAbsencesEntity);
                    }
                }
                contex.SaveChanges();
            }
        }
    }
}

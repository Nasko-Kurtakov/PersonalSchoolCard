namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    using System.Windows.Forms;
    public class HoursStudiedSubjectDA
    {
        public static void SaveHoursStudiedSubject(DataGridView gridViewHoursStudied, int teacherID,string subjectType)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var subjectTypeID = SubjectDA.GetSubjectTypeID(subjectType);
                for (int i = 0; i < gridViewHoursStudied.Rows.Count; i++)
                {
                    if (gridViewHoursStudied.Rows[i].Cells[1].Value != null)
                    {
                        var subjectID = SubjectDA.GetSubjectID(gridViewHoursStudied.Rows[i].Cells[0].Value.ToString());                                                
                        var classID = 22/*SchoolClassDA.GetSchoolClassByTeacherID(teacherID).ClassID*/;
                        var hoursStudiedSubject = new HoursStudiedSubject
                        {
                            ClassID = classID,
                            SubjectID = subjectID,
                            SubjectTypeID = subjectTypeID,
                            HoursStudied = int.Parse(gridViewHoursStudied.Rows[i].Cells[1].Value.ToString())
                        };
                        context.HoursStudiedSubjects.Add(hoursStudiedSubject);
                    }
                    else
                    {
                        throw new NullReferenceException("Не са въведени данни.");
                    }
                }
                context.SaveChanges();
            }
        }
        public static string GetHoursStudiedOnSubject(int teacherID, string subjectName, string subjectType)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var studiedYears = SchoolYearDA.GetAllStudiedYears();
                studiedYears.Reverse();
                var schoolClass = SchoolClassDA.GetSchoolClassByTeacherID(teacherID);
                var schoolClassChar = schoolClass.ClassChar;
                var schoolClassNumber = schoolClass.ClassNumber;
                var subjectId = SubjectDA.GetSubjectID(subjectName);
                var subjectTypeId = SubjectDA.GetSubjectTypeID(subjectType);
                int hoursStudiedTotal = 0;
                for (int i = 0; i < studiedYears.Count; i++)
                {
                    string year = studiedYears[i];
                    string className = string.Format("{0} {1}", schoolClassNumber - i, schoolClassChar);
                    var schoolClassID = context.SchoolClasses
                                            .Where(entity => entity.SchoolYear.SchoolYearName == year && entity.ClassName == className)
                                            .Select(entity => entity.ClassID)
                                            .First();

                    var hoursStudied = context.HoursStudiedSubjects
                                    .Where(entity => entity.ClassID == schoolClassID && entity.SubjectID == subjectId && entity.SubjectTypeID == subjectTypeId)
                                    .Select(entity => entity.HoursStudied)
                                    .FirstOrDefault();
                    hoursStudiedTotal += hoursStudied;
                }
                if (hoursStudiedTotal.ToString()=="0")
                {
                    return "-";
                }
                else
                {
                    return hoursStudiedTotal.ToString();
                }
            }
        }
    }
}

namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class MarkDA
    {
        public static string GetMarkWithWords(string rowValue)
        {
            string markAsWord = "";
            switch (rowValue)
            {
                case "2": markAsWord = "Слаб"; break;
                case "3": markAsWord = "Среден"; break;
                case "4": markAsWord = "Добър"; break;
                case "5": markAsWord = "Много добър"; break;
                case "6": markAsWord = "Отличен"; break;
                default: markAsWord = "Грешни входни данни"; break;
            }
            return markAsWord;
        }
        public static void SaveMark(DataGridView gridView, int teacherID, long studentID, byte termID, bool isForExtraSubjects = false)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var classID = SchoolClassDA.GetClassIDByTeacherID(teacherID);
                if (!isForExtraSubjects)
                {
                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        if (gridView.Rows[i].Cells[2].Value != null)
                        {
                            var subjectName = gridView.Rows[i].Cells[0].Value.ToString();
                            var subjectID = context.Subjects
                                            .Where(subject => subject.SubjectName == subjectName)
                                            .Select(subject => subject.SubjectID)
                                            .FirstOrDefault();
                            var subjectTypeID = SubjectDA.GetSubjectTypeID(gridView.Columns[2].Name.ToString().Substring(0, 2));
                            var mark = new Mark
                            {
                                StudentID = studentID,
                                SubjectID = subjectID,
                                SubjectTypeID = subjectTypeID,
                                TermID = termID,
                                ClassID = classID,
                                Grade = byte.Parse(gridView.Rows[i].Cells[2].Value.ToString())
                            };
                            context.Marks.Add(mark);
                        }
                        if (gridView.Rows[i].Cells[4].Value != null)
                        {
                            var subjectName = gridView.Rows[i].Cells[0].Value.ToString();
                            var subjectID = context.Subjects
                                            .Where(subject => subject.SubjectName == subjectName)
                                            .Select(subject => subject.SubjectID)
                                            .FirstOrDefault();
                            var subjectTypeID = SubjectDA.GetSubjectTypeID(gridView.Columns[4].Name.ToString().Substring(0, 3));
                            var mark = new Mark
                            {
                                StudentID = studentID,
                                SubjectID = subjectID,
                                SubjectTypeID = subjectTypeID,
                                TermID = termID,
                                ClassID = classID,
                                Grade = byte.Parse(gridView.Rows[i].Cells[2].Value.ToString())
                            };
                            context.Marks.Add(mark);
                        }
                        if (gridView.Rows[i].Cells[2].Value == null)
                        {
                            continue;
                        }
                        if (gridView.Rows[i].Cells[4].Value == null)
                        {
                            continue;
                        }
                    }
                    context.SaveChanges();
                }
                if (isForExtraSubjects)
                {
                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        if (gridView.Rows[i].Cells[2].Value != null)
                        {
                            var subjectName = gridView.Rows[i].Cells[0].Value.ToString();
                            var subjectID = context.Subjects
                                            .Where(subject => subject.SubjectName == subjectName)
                                            .Select(subject => subject.SubjectID)
                                            .FirstOrDefault();
                            var subjectTypeID = SubjectDA.GetSubjectTypeID(gridView.Columns[2].Name.ToString().Substring(0, 3));
                            var mark = new Mark
                            {
                                StudentID = studentID,
                                SubjectID = subjectID,
                                SubjectTypeID = subjectTypeID,
                                TermID = termID,
                                ClassID = classID,
                                Grade = byte.Parse(gridView.Rows[i].Cells[2].Value.ToString())
                            };
                            context.Marks.Add(mark);
                        }
                        if (gridView.Rows[i].Cells[2].Value == null)
                        {
                            continue;
                        }
                    }
                    context.SaveChanges();
                }
            }

        }
        public static byte? GetMark(long studentID, string subjectName, int subjectTypeID, byte termID, int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var subjectID = SubjectDA.GetSubjectID(subjectName);
                var classID = SchoolClassDA.GetClassIDByTeacherID(teacherID);
                var mark = context.Marks
                            .Where(subject => subject.StudentID == studentID && subject.SubjectID == subjectID
                                    && subject.ClassID == classID && subject.SubjectTypeID == subjectTypeID && subject.TermID == termID)
                                    .Select(grade => grade.Grade)
                                    .FirstOrDefault();
                return mark;
            }
        }
        public static byte? GetFinalMarkForSchoolYear(long studentID, int subjectID, string subjectTypeName, string schoolYear)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var classID = context.StudentsSchoolYears
                                    .Where(student => student.StudentID == studentID)
                                    .Where(year => year.SchoolYear.SchoolYearName == schoolYear)
                                    .Select(schoolClass => schoolClass.ClassID)
                                    .FirstOrDefault();
                var subjectTypeID = context.SubjectTypes
                                    .Where(type => type.SubjectTypeName == subjectTypeName)
                                    .Select(type => type.SubjectTypeID)
                                    .FirstOrDefault();

                var mark = context.Marks
                                .Where(student => student.StudentID == studentID)
                                .Where(schoolClass => schoolClass.ClassID == classID)
                                .Where(term => term.TermID == 3)
                                .Where(type => type.SubjectTypeID == subjectTypeID)
                                .Where(subject => subject.SubjectID == subjectID)
                                .Select(grade => grade.Grade)
                                .FirstOrDefault();
                return mark;
            }
        }
    }
}

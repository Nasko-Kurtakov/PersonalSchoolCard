namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class MarkDA
    {
        public static string GetMarkWithWords(string value)
        {

            var valueAsFloat = float.Parse(value);
            if (valueAsFloat >= 2.0 && valueAsFloat <= 2.49)
            {
                return "Слаб";
            }
            else
                if (valueAsFloat >= 2.50 && valueAsFloat <= 3.49)
                {
                    return "Среден";
                }
                else if (valueAsFloat >= 3.50 && valueAsFloat <= 4.49)
                {
                    return "Добър";
                }
                else if (valueAsFloat >= 4.50 && valueAsFloat <= 5.49)
                {
                    return "Мн. добър";
                }
                else if (valueAsFloat >= 5.50 && valueAsFloat <= 6.00)
                {
                    return "Отличен";
                }
                else
                {
                    return "Грешни входни данни";
                }
        }
        public static void SaveMark(DataGridView gridView, int teacherID, long studentID, byte termID, bool isForExtraSubjects = false)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var classID = SchoolClassDA.GetSchoolClassByTeacherID(teacherID).ClassID;
                if (!isForExtraSubjects)
                {
                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        if (gridView.Rows[i].Cells[2].Value.ToString() != "")
                        {
                            var subjectName = gridView.Rows[i].Cells[0].Value.ToString();
                            var subjectID = SubjectDA.GetSubjectID(subjectName);
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
                        if (gridView.Rows[i].Cells[4].Value.ToString() != "")
                        {
                            var subjectName = gridView.Rows[i].Cells[0].Value.ToString();
                            var subjectID = SubjectDA.GetSubjectID(subjectName);
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
                        if (gridView.Rows[i].Cells[2].Value.ToString() == "")
                        {
                            continue;
                        }
                        if (gridView.Rows[i].Cells[4].Value.ToString() == "")
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
                        if (gridView.Rows[i].Cells[2].Value.ToString() != "")
                        {
                            var subjectName = gridView.Rows[i].Cells[0].Value.ToString();
                            var subjectID = SubjectDA.GetSubjectID(subjectName);
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
                        if (gridView.Rows[i].Cells[2].Value.ToString() == "")
                        {
                            continue;
                        }
                    }
                    context.SaveChanges();
                }
            }
        }
        public static byte? GetFinalMarkForSchoolYear(long studentID, int subjectID, string subjectTypeName, string schoolYear)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                int classID = SchoolClassDA.GetClassIDByStudent(studentID, schoolYear);
                byte subjectTypeID = SubjectDA.GetSubjectTypeID(subjectTypeName);
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

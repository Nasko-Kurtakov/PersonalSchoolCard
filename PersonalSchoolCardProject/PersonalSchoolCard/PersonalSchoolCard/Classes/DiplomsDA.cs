namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    using System.Windows.Forms;
    public class DiplomsDA
    {
        public static void SaveMarkExam(long studentID, string subjectName, string mark)
        {
            using (var contex = new PersonalSchoolCardEntities())
            {
                var subjectID = SubjectDA.GetSubjectID(subjectName);
                var markAsFloat = float.Parse(mark);
                var ExamMark = new Diplom
                {
                    StudentID = studentID,
                    SubjectID = subjectID,
                    SubjectTypeID = 5,
                    Mark = markAsFloat
                };
                contex.Diploms.Add(ExamMark);
                contex.SaveChanges();
            }
        }
        public static void SaveMarkFinal(DataGridView gridView, long studentID, string subjectTypeName, int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                if (subjectTypeName == "ЗП")
                {
                    var subjectTypeID = SubjectDA.GetSubjectTypeID(subjectTypeName);
                    var profileSubjects = Classes.SubjectDA.GetProfileSubjects(studentID, teacherID);

                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        if (gridView.Rows[i].Cells[gridView.Columns.Count - 3].Value != null)
                        {
                            var subjectID = SubjectDA.GetSubjectID(gridView.Rows[i].Cells[0].Value.ToString());
                            var mark = float.Parse(gridView.Rows[i].Cells[gridView.Columns.Count - 3].Value.ToString());
                            foreach (var subject in profileSubjects)
                            {
                                if (subject.SubjectID == subjectID)
                                {
                                    var subjectTypePrfessionalID = SubjectDA.GetSubjectTypeID("ЗПП");
                                    var finalMarkProfessional = new Diplom
                                    {
                                        StudentID = studentID,
                                        SubjectID = subjectID,
                                        SubjectTypeID = subjectTypePrfessionalID,
                                        Mark = mark
                                    };
                                    context.Diploms.Add(finalMarkProfessional);
                                }
                            }
                            var finalMark = new Diplom
                            {
                                StudentID = studentID,
                                SubjectID = subjectID,
                                SubjectTypeID = subjectTypeID,
                                Mark = mark
                            };
                            context.Diploms.Add(finalMark);
                        }

                    }
                }
                if (subjectTypeName == "ЗИП")
                {
                    var subjectTypeID = SubjectDA.GetSubjectTypeID(subjectTypeName);

                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        var subjectID = SubjectDA.GetSubjectID(gridView.Rows[i].Cells[0].Value.ToString());
                        if (gridView.Rows[i].Cells[gridView.Columns.Count - 1].Value != null)
                        {
                            var mark = float.Parse(gridView.Rows[i].Cells[gridView.Columns.Count - 1].Value.ToString());
                            var finalMark = new Diplom
                            {
                                StudentID = studentID,
                                SubjectID = subjectID,
                                SubjectTypeID = subjectTypeID,
                                Mark = mark
                            };
                            context.Diploms.Add(finalMark);
                        }

                    }
                }
                if (subjectTypeName == "СИП")
                {
                    var subjectTypeID = SubjectDA.GetSubjectTypeID(subjectTypeName);

                    for (int i = 0; i < gridView.Rows.Count; i++)
                    {
                        var subjectID = SubjectDA.GetSubjectID(gridView.Rows[i].Cells[0].Value.ToString());
                        if (gridView.Rows[i].Cells[gridView.Columns.Count - 1].Value != null)
                        {
                            var mark = float.Parse(gridView.Rows[i].Cells[gridView.Columns.Count - 1].Value.ToString());
                            var finalMark = new Diplom
                            {
                                StudentID = studentID,
                                SubjectID = subjectID,
                                SubjectTypeID = subjectTypeID,
                                Mark = mark
                            };
                            context.Diploms.Add(finalMark);
                        }
                    }
                }
                context.SaveChanges();
            }
        }
        public static List<Diplom> GetAllDiplomMarks(long studentID,string subjectType)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                var diplomEntities = context.Diploms
                                        .Where(entity => entity.StudentID == studentID && entity.SubjectType.SubjectTypeName == subjectType)
                                        .Select(entity => entity)
                                        .ToList();
                return diplomEntities;
            }
        }
        public static string GetMarkOnSubject(long studentID,string subjectName,string subjectType)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                
                var mark = context.Diploms
                                        .Where(entity => entity.StudentID == studentID && entity.Subject.SubjectName==subjectName &&  entity.SubjectType.SubjectTypeName == subjectType)
                                        .Select(entity => entity.Mark).First();
                return mark.ToString("f2");
            }
        }
        public static double CalculateAverageMark(long studentID, string subjectType)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var marksList = context.Diploms
                                   .Where(subject => subject.SubjectType.SubjectTypeName == subjectType)
                                   .Select(mark => mark.Mark);
                double averageMark = marksList.Average();
                averageMark = Math.Round(averageMark, 2);
                return averageMark;
            }
        }
        public static double CalculateDiplomMark(long studentID)
        {
            var averageMarkFromMandatorySubjects = CalculateAverageMark(studentID, "ЗП");
            var averageMarkFromExams = CalculateAverageMark(studentID, "ДЗИ");
            var averageMarkFromChosenSubjects = CalculateAverageMark(studentID, "ЗИП");
            var averageMarkFromProfesionalSubjects = CalculateAverageMark(studentID, "ЗПП");
            var professionalChosenSubjects = ((averageMarkFromChosenSubjects + averageMarkFromProfesionalSubjects) / 2);
            professionalChosenSubjects = Math.Round(professionalChosenSubjects, 2);
            var diplomMark = (averageMarkFromMandatorySubjects + averageMarkFromExams + professionalChosenSubjects) / 3;
            diplomMark = Math.Round(diplomMark, 2);
            return diplomMark;
        }
    }
}

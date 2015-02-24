namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard;
    using PersonalSchoolCard.Data;
    using System.Windows.Forms;
    public class SubjectDA
    {
        public static void AddSubjectTypes(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {
                        for (int col = 0; col < gridView.Rows[rows].Cells.Count; col++)
                        {
                            string input = gridView.Rows[rows].Cells[col].Value.ToString();
                            if (input != null && input != "" && input != " ")
                            {
                                var subjectType = new SubjectType
                                {
                                    SubjectTypeName = input
                                };
                                context.SubjectTypes.Add(subjectType);
                            }
                            else if (input == null || input == "" || input == " ")
                            {
                                throw new ArgumentNullException();
                            }
                        }
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void AddSubjects(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {

                try
                {
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {

                        string input = gridView.Rows[rows].Cells[0].Value.ToString();
                        if (input != null && input != "" && input != " ")
                        {
                            var subject = new Subject
                            {
                                SubjectName = input
                            };
                            context.Subjects.Add(subject);
                        }
                        else if (input == null || input == "" || input == " ")
                        {
                            throw new ArgumentNullException("Невалидни входни параметри");
                        }

                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        public static List<string> GetAllSubjectTypesName()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var subjectTypes = context.SubjectTypes
                                   .Select(subjectType => subjectType.SubjectTypeName)
                                   .ToList();
                return subjectTypes;
            }
        }
        public static List<Subject> GetAllSubjects()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var subjectTypes = context.Subjects
                                   .Select(subject => subject)
                                   .ToList();
                return subjectTypes;
            }
        }
        public static byte GetSubjectTypeID(string columnName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var subjectTypeID = context.SubjectTypes
                                    .Where(subjectType => subjectType.SubjectTypeName == columnName)
                                    .Select(subjectType => subjectType.SubjectTypeID)
                                    .FirstOrDefault();
                return subjectTypeID;
            }
        }
        public static int GetSubjectID(string subjectName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var subjectID = context.Subjects
                                    .Where(subject => subject.SubjectName == subjectName)
                                    .Select(subjectType => subjectType.SubjectID)
                                    .FirstOrDefault();
                return subjectID;
            }
        }
        
    }
}


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
        public static byte GetSubjectTypeID(string name)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var subjectTypeID = context.SubjectTypes
                                    .Where(subjectType => subjectType.SubjectTypeName == name)
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
        public static List<Subject> GetProfileSubjects(long studentID, int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var profileID = TeacherDA.GetClassProfileIDByTeacher(teacherID, SchoolYearDA.GetCurrentSchoolYear());
                var profile = context.Profiles
                                            .Where(prof => prof.ProfileID == profileID)
                                            .Select(prof => prof).FirstOrDefault();

                var profileSubjectList = context.Subjects.ToList()
                                         .Where(psb => psb.Profiles.Contains(profile)).ToList();

                return profileSubjectList;
            }
        }
        public static List<Subject> GetForeignLanguage(long studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var languages = context.Subjects
                         .Where(subject => subject.SubjectName.Substring(subject.SubjectName.Length - 4, 4) == "език")
                         .Select(subject => subject)
                         .ToList();
                var subjectTypeID = GetSubjectTypeID("ЗП");
                var subjectIDDiplom = context.Diploms
                                        .Where(student => student.StudentID == studentID && student.SubjectTypeID == subjectTypeID)
                                        .Select(subject => subject.SubjectID)
                                        .ToList();
                var studiedForeignLanguages = new List<Subject>();
                for (int i = 0; i < subjectIDDiplom.Count; i++)
                    for (int k = 0; k < languages.Count; k++)
                    {
                        if (languages[k].SubjectID == subjectIDDiplom[i])
                        {
                            studiedForeignLanguages.Add(languages[k]);
                        }
                    }
                return studiedForeignLanguages;
            }
        }
        public static string GetSubjectName(int subjectID)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                var subjectName = context.Subjects
                                    .Where(subject => subject.SubjectID == subjectID)
                                    .Select(subject => subject.SubjectName)
                                    .First();
                return subjectName;
            }
        }
    }
}


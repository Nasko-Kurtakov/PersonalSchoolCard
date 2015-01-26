namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class AddTeachersPanel
    {
        public static void AddTeachers(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {

                try
                {
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {

                        string firstName = gridView.Rows[rows].Cells[0].Value.ToString();
                        string lastName = gridView.Rows[rows].Cells[1].Value.ToString();
                        string taughtSubject = gridView.Rows[rows].Cells[2].Value.ToString();
                        if (firstName != null && firstName != "" && firstName != " ")
                        {
                            if (lastName != null && lastName != "" && lastName != " ")
                            {
                                if (taughtSubject != null && taughtSubject != "" && taughtSubject != " ")
                                {
                                    var thaughtSubjectID = context.Subjects
                                                           .Where(subject => subject.SubjectName == taughtSubject)
                                                           .Select(subject => subject.SubjectID)
                                                           .First();
                                    var teacher = new Teacher
                                    {
                                        FirstName = firstName,
                                        LastName = lastName,
                                        TaughtSubjectID = thaughtSubjectID
                                    };
                                    context.Teachers.Add(teacher);

                                }
                            }
                            else if (firstName == null || firstName == "" || firstName == " ")
                            {
                                throw new ArgumentNullException("Невалидни входни параметри");
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

        public static void ShowSubjectsInCombobox<T>(DataGridViewComboBoxColumn column, T dataSource)
        {
            column.DataSource = dataSource;
        }

        public static List<string> GetAllTeachersNames()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var teachersList = context.Teachers
                                          .Select(teacher => teacher).ToList();

                    var teachersNamesList = new List<string>();
                    foreach (var teacher in teachersList)
                    {
                        teachersNamesList.Add(teacher.GetFullName());
                    }
                    return teachersNamesList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
    }
}

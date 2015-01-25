namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    class AddTeachersPanel
    {
        public static void AddTeachers(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCEntities())
            {

                try
                {
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {
                        for (int col = 0; col < gridView.Rows[rows].Cells.Count; col++)
                        {
                            string firstName = gridView.Rows[rows].Cells[1].Value.ToString();
                            string lastName = gridView.Rows[rows].Cells[2].Value.ToString();
                            string thaughtSubject = gridView.Rows[rows].Cells[3].Value.ToString();
                            if (firstName != null && firstName != "" && firstName != " ")
                            {
                                if (lastName != null && lastName != "" && lastName != " ")
                                {
                                    if (thaughtSubject != null && thaughtSubject != "" && thaughtSubject != " ")
                                    {
                                        var thaughtSubjectID = context.Subjects
                                                               .Where(subject => subject.SubjectName == thaughtSubject)
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

        public static DataGridViewComboBoxColumn ShowSubjectsInCombobox<T>(T dataSource)
        {
            DataGridViewComboBoxColumn subjectsColumn  = new DataGridViewComboBoxColumn()
            {
                HeaderText = "Предмети",
                DataSource = dataSource,
                Name = "TaughtSubjects"
            };
            return subjectsColumn;
        }
    }
}

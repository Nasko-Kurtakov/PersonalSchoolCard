namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class TeacherDA
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
                        string userName = gridView.Rows[rows].Cells[2].Value.ToString();
                        string password = gridView.Rows[rows].Cells[3].Value.ToString();
                        if (firstName != null && firstName != "" && firstName != " ")
                        {
                            if (lastName != null && lastName != "" && lastName != " ")
                            {
                                if (userName != null && userName != "" && userName != " ")
                                {
                                    if (userName != null && userName != "" && userName != " ")
                                    {
                                        
                                        var teacher = new Teacher
                                        {
                                            FirstName = firstName,
                                            LastName = lastName,
                                            UserName = userName,
                                            Password= password
                                             
                                        };
                                        context.Teachers.Add(teacher);
                                    }
                                }
                            }
                        }

                        else if (firstName == null || firstName == "" || firstName == " " 
                                || lastName == null || lastName == ""|| lastName== " " ||
                                    userName == null || userName == "" || userName==" " ||
                                    password == null || password=="" || password==" ")

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
                        teachersNamesList.Add(teacher.FullName);
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
        public static Teacher GetTeacher(int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var teacher = context.Teachers
                    .Where(t => t.TeacherID == teacherID)
                    .Select(t => t).FirstOrDefault();

                return teacher;
            }
        }        
        public static void EditTeacherInfo(int teacherID,string firstName,string lastName,string userName,string password)
        {
            using(var context =  new PersonalSchoolCardEntities())
            {
                var selectedTeacher = context.Teachers
                                .Where(teacher => teacher.TeacherID == teacherID)
                                .Select(teacher => teacher)
                                .FirstOrDefault();
                selectedTeacher.FirstName = firstName;
                selectedTeacher.LastName = lastName;
                selectedTeacher.UserName = userName;
                selectedTeacher.Password = password;
                context.SaveChanges();
            }
        }
    }
}

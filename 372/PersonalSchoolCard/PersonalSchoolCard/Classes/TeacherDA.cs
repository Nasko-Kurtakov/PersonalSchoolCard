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
                                            Password = password

                                        };
                                        context.Teachers.Add(teacher);
                                    }
                                }
                            }
                        }

                        else if (firstName == null || firstName == "" || firstName == " "
                                || lastName == null || lastName == "" || lastName == " " ||
                                    userName == null || userName == "" || userName == " " ||
                                    password == null || password == "" || password == " ")
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
                var teachersList = context.Teachers
                                      .Select(teacher => teacher).ToList();

                var teachersnameslist = new List<string>();
                foreach (var teacher in teachersList)
                {
                    teachersnameslist.Add(teacher.FullName);
                }
                return teachersnameslist;
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
        public static Teacher SearchTeacher(string username, string password)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var searchedTeacher = context.Teachers
                                .Where(teacher => teacher.UserName == username && teacher.Password == password)
                                .Select(teacher => teacher)
                                .First();
                return searchedTeacher;
            }
        }
        public static void EditTeacherInfo(int teacherID, string firstName, string lastName, string userName, string password)
        {
            using (var context = new PersonalSchoolCardEntities())
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
        public static List<Teacher> GetAllTeachers()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var teachersList = context.Teachers
                                      .Select(teacher => teacher)
                                      .ToList();
                return teachersList;
            }
        }
        public static bool HasClass(int teacherID, string schoolYear)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var searchedTeacherID = context.SchoolClasses
                                .Where(schoolClass => schoolClass.TeacherID == teacherID && schoolClass.SchoolYear.SchoolYearName == schoolYear)
                                .Select(schoolClass => schoolClass)
                                .FirstOrDefault();
                if(searchedTeacherID!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

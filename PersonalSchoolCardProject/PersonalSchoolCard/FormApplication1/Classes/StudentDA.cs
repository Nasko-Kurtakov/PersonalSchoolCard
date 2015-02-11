namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    using System.Data.OleDb;
    using System.Data;
    public class StudentDA
    {
        public static List<string> GetStudentsInClasses(ComboBox selectedClass)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var className = selectedClass.SelectedItem.ToString();
                    var studentsList = context.StudentsSchoolYears
                                        .Where(schoolClass => schoolClass.SchoolClass.ClassName == className)
                                        .Select(student => student.Student.FirstName + " " + student.Student.SecondName
                                         + " " + student.Student.LastName)
                                        .ToList();
                    return studentsList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
        public static void AddStudent(DataGridView gridView, ComboBox selectedClass)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    string currentSchoolYear = Classes.SchoolYearDA.GetCurrentSchoolYear();
                    var currentSchoolYearId = context.SchoolYears
                                        .Where(schoolYear => schoolYear.SchoolYearName == currentSchoolYear)
                                        .Select(schoolYear => schoolYear.SchoolYearID)
                                        .First();
                    var classId = context.SchoolClasses
                                    .Where(schoolClass => schoolClass.ClassName == selectedClass.SelectedItem.ToString() && schoolClass.SchoolYearID == currentSchoolYearId)
                                    .Select(schoolClass => schoolClass.ClassID)
                                    .First();
                    var profileId = context.SchoolClasses
                                    .Where(schoolClass => schoolClass.ClassName == selectedClass.SelectedItem.ToString() && schoolClass.SchoolYearID == currentSchoolYearId)
                                    .Select(schoolClass => schoolClass.ProfileID)
                                    .First();




                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {
                        string firstName = gridView.Rows[rows].Cells[0].Value.ToString();
                        string secondName = gridView.Rows[rows].Cells[1].Value.ToString();
                        string lastName = gridView.Rows[rows].Cells[2].Value.ToString();
                        try
                        {

                            var newStudent = new Student
                            {
                                FirstName = firstName,
                                SecondName = secondName,
                                LastName = lastName,
                                ProfileID = (int)profileId
                            };
                            context.Students.Add(newStudent);
                            context.SaveChanges();
                            var newStudentsSchoolYear = new StudentsSchoolYear
                            {
                                SchoolYearID = currentSchoolYearId,
                                StudentID = newStudent.StudentID,
                                ClassID = classId
                            };
                            context.StudentsSchoolYears.Add(newStudentsSchoolYear);
                        }
                        catch
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
        public static DataTable AddStudentToDatagridFromExcel(string path)
        {
            try
            {
                string pathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Mode=ReadWrite;Extended Properties=Excel 8.0;";
                OleDbConnection conn = new OleDbConnection(pathConn);
                conn.Open();
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + "Sheet1" + "$]", conn);

                DataTable dt = new DataTable();
                myDataAdapter.Fill(dt);
                dt.Columns[0].ColumnName = "NewStudentFirstName";
                dt.Columns[1].ColumnName = "NewStudentSecondName";
                dt.Columns[2].ColumnName = "NewStudentLastName";

                return dt;

            }
            catch (Exception)
            {
                MessageBox.Show("Грешка! Въведете правилно име на листа от файла с имената!");
                return null;
            }
        }
        public static List<string> GetClassesForThisSchoolYear()
        {
            string currentSchoolYear = Classes.SchoolYearDA.GetCurrentSchoolYear();
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var schoolClassesNamesList = context.SchoolClasses
                                                  .Where(schoolClasses => schoolClasses.SchoolYear.SchoolYearName == currentSchoolYear)
                                                  .Select(schoolClasses => schoolClasses.ClassName)
                                                  .ToList();
                    return schoolClassesNamesList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }

            }

        }

        public static List<Student> GetStudentByTeacher(int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var currentSchoolYear = SchoolYearDA.GetCurrentSchoolYear();
                var studentsList = context.StudentsSchoolYears
                                    .Where(student => student.SchoolClass.TeacherID == teacherID && student.SchoolClass.SchoolYear.SchoolYearName == currentSchoolYear)
                                    .Select(student => student.Student)
                                    .ToList();
                return studentsList;
            }
        }
        public static long GetStudentID(int teacherID, string firstName, string secondName, string lastName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var studentID = context.StudentsSchoolYears
                      .Where(student => student.Student.FirstName == firstName
                          && student.Student.SecondName == secondName
                          && student.Student.LastName == lastName
                           && student.SchoolClass.TeacherID == teacherID)
                           .Select(student => student.StudentID)
                           .FirstOrDefault();
                return studentID;
            }
        }

        public static Student SelectStudent(long studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var student = context.Students
                                .Where(stu => stu.StudentID == studentID)
                                .Select(stu => stu)
                                .First();
                return student;
            }
        }
        public static void UpdateStudentInfo(long studentID,Student studentToUpdate)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                var selectedStudent = context.Students
                                .Where(stu => stu.StudentID == studentID)
                                .Select(stu => stu)
                                .First();
                
                selectedStudent.FirstName = studentToUpdate.FirstName;
                selectedStudent.SecondName = studentToUpdate.SecondName;
                selectedStudent.LastName = studentToUpdate.LastName;
                selectedStudent.PersonalNumber = studentToUpdate.PersonalNumber;
                selectedStudent.PersonalCardNumber = studentToUpdate.PersonalCardNumber;
                selectedStudent.Phone = studentToUpdate.Phone;
                selectedStudent.SettlementID = studentToUpdate.SettlementID;
                selectedStudent.Address = studentToUpdate.Address;
                selectedStudent.DateOfBirth = studentToUpdate.DateOfBirth;
                selectedStudent.EnrollmentYear = studentToUpdate.EnrollmentYear;
                context.SaveChanges();
            }
        }
    }
}

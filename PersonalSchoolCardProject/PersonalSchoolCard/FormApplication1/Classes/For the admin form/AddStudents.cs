namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    using System.Data.OleDb;
    using System.Data;
    //using Microsoft.Office.Interop.Excel;
    public class AddStudents
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
                    string currentSchoolYear = Classes.SchoolYearsPanel.GetCurrentSchoolYear();
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
                                ProfileID = profileId
                                
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
        public static DataTable  AddStudentToDatagridFromExcel(string path)
        {
            try
            {
                string pathConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Mode=ReadWrite;Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                OleDbConnection conn = new OleDbConnection(pathConn);
                conn.Open();
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter("Select * from [" + "Sheet1" + "$]", conn);
                
                DataTable dt = new DataTable();
                myDataAdapter.Fill(dt);

                return dt;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Грешка! Въведете правилно име на листа от файла с имената!");
                return null;
            }
        }
    }
}

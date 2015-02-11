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


        public static string GetStudentsName(int studentID)
        {
            try
            {
                using (var context = new PersonalSchoolCardEntities())
                {
                    var sn = context.Students
                        .Where(student => student.StudentID == studentID)
                        .Select(student => new
                        {
                            FirstName = student.FirstName,
                            SecondName = student.SecondName,
                            LastName = student.LastName
                        })
                        .FirstOrDefault()
                        ;

                    var nameS
                        = sn.FirstName + " " + sn.SecondName + " " + sn.LastName;

                    return nameS;
                }
            }
            catch
            {
                return null;
            }
        }

        public static string GetStudentArea(int studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                //to be redone
                //var AreaName = (from s in context.Students
                //                join set in context.Settlements
                //                on s.SettlementID equals set.SettlementID
                //                join ar in context.Areas
                //                on set.AreaID equals ar.AreaID
                //                where s.StudentID == studentID
                //                select ar.AreaName)
                //                .FirstOrDefault();

                //return AreaName;
                return null;
            }
        }

        public static string GetStudentsSettlement(int studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var StudentSettlement = context.Students
                     .Where(student => student.StudentID == studentID)
                    .Join(context.Settlements,
                    o => o.SettlementID, od => od.SettlementID,
                    (o, od) => new
                    {
                        Settlement = od.SettlementName
                    })
                    .FirstOrDefault()
                    ;

                return StudentSettlement.Settlement;
            }
        }

        public static string GetStudentMunicipality(int studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                //to be redone
                //var StudentMunicipality = (from s in context.Students
                //                           join set in context.Settlements
                //                           on s.SettlementID equals set.SettlementID
                //                           join mu in context.Manicipalities
                //                           on set.ManicipalityID equals mu.ManicipalityID
                //                           where s.StudentID == studentID
                //                           select mu.ManicipalityName)
                //                           .FirstOrDefault();

                //return StudentMunicipality;
                return null;
            }
        }

        public static string GetStudentSchoolName()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var SchoolName = (from s in context.Schools
                                  select s.SchoolName)
                                  .FirstOrDefault()
                                  ;

                return SchoolName;
            }
        }

        

        public static string GetStudentCardID(int studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {

                var StudentCardID = context.Students
                    .Where(student => student.StudentID == studentID)
                    .Select(student => student.PersonalCardNumber)
                    .FirstOrDefault()
                    ;

                return StudentCardID;

            }
        }

        public static string GetStudentCitizenship()
        {
            //using ( var context = new PersonalSchoolCardEntities())
            //{
            //  code
            //  code
            //  code
            //  return code;
            //}

            return "българско";

        }

        public static string GetStudentGenderAssist(int studentID)
        {
            using ( var context = new PersonalSchoolCardEntities())
            {
                string familyName = context.Students
                    .Where(stu => stu.StudentID == studentID)
                    .Select(stu => stu.LastName)
                    .FirstOrDefault()
                    ;

                int charCount = 0;
                
                foreach(char c in familyName)
                {
                    charCount++;
                }

                char genderAssist = familyName[charCount - 1];

                if (genderAssist == 'а')
                {
                    return "на";
                }
                else
                    return "н";
            }
        }

        public static DateTime GetStudentDateOfBirth(int studentID)
        {
            try
            {
                using (var context = new PersonalSchoolCardEntities())
                {
                    var StudentBirthDate = context.Students
                        .Where(student => student.StudentID == studentID)
                        .Select(student => student.DateOfBirth)
                        .First();
                    if (StudentBirthDate != null)
                    {
                        return (DateTime)StudentBirthDate;
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return DateTime.Now;
            }
        }

        public static string GetStudentCurrentAddress(int studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var CurrentAddress = (from s in context.Students
                                      where s.StudentID == studentID
                                      select s.Address)
                                      .FirstOrDefault()
                                      ;

                return CurrentAddress;
            }
        }

        public static string GetStudentMobilePhone(int studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var StudentMobilePhone = context.Students
                    .Where(student => student.StudentID == studentID)
                    .Select(student => student.Phone)
                    .FirstOrDefault()
                    ;

                return StudentMobilePhone;
            }
        }

        public static int? GetStudentEnrollmentYear(int studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var StudentEnrollmentYear = context.Students
                    .Where(student => student.StudentID == studentID)
                    .Select(student => student.EnrollmentYear)
                    .FirstOrDefault()
                    ;

                return StudentEnrollmentYear;
            }
        }
    }
}

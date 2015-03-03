namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;

    public class SchoolClassDA
    {
        public static List<SchoolClassInfo> GetSchoolClassesForSchoolYear(string schoolYear)
        {
            using (var contex = new PersonalSchoolCardEntities())
            {
                try
                {
                    var currentSchoolClasses = contex.SchoolClasses
                                                .Where(schoolClasses => schoolClasses.SchoolYear.SchoolYearName == schoolYear)
                                               .Select(schoolClasses => schoolClasses)
                                               .ToList();
                    currentSchoolClasses = currentSchoolClasses.OrderBy(schoolClass => schoolClass.ClassNumber).ToList();
                    var currentSchoolClassesInfoList = new List<SchoolClassInfo>();

                    foreach (var schoolClass in currentSchoolClasses)
                    {
                        var currentSchoolClassesInfo = new SchoolClassInfo
                     {
                         ClassName = schoolClass.ClassName,
                         SchoolYear = schoolClass.SchoolYear.SchoolYearName,
                         ProfileID = (int)schoolClass.ProfileID,
                         TeacherName = schoolClass.Teacher.FullName
                     };
                        currentSchoolClassesInfoList.Add(currentSchoolClassesInfo);
                    }
                    return currentSchoolClassesInfoList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
        public static List<SchoolClassInfo> VisualizeChanges(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var schoolClassesList = new List<SchoolClassInfo>();
                    for (int rows = 0; rows < gridView.Rows.Count; rows++)
                    {

                        string className = gridView.Rows[rows].Cells[0].Value.ToString();
                        string schoolYear = gridView.Rows[rows].Cells[1].Value.ToString();
                        string teacherName = gridView.Rows[rows].Cells[3].Value.ToString();
                        int profileID = int.Parse(gridView.Rows[rows].Cells[2].Value.ToString());
                        string newClassName = (int.Parse(className.Substring(0, 2))+1).ToString();
                        if (newClassName!="13")
                        {
                                    var schoolClass = new SchoolClassInfo
                                    {
                                        ClassName = GetNextClassName(className),
                                        SchoolYear = SchoolYearDA.GetNextSchoolYear(schoolYear),
                                        ProfileID = profileID,
                                        TeacherName = teacherName
                                    };
                                    schoolClassesList.Add(schoolClass);
                        }
                    }
                    return schoolClassesList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }        
        private static string GetNextClassName(string className)
        {
            if (className.Length < 4 && className != "12")
            {
                string newClassNumber = (int.Parse(className.Substring(0, 1)) + 1).ToString();
                string classChar = className.Substring(2, 1);
                return string.Format("{0} {1}", newClassNumber, classChar);
            }
            else
            {
                string newClassName = (int.Parse(className.Substring(0, 2)) + 1).ToString();
                string classChar = className.Substring(3, 1);
                return string.Format("{0} {1}", newClassName, classChar);
            }
        }
        public static void SaveUpdatedSchoolClasses(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var schoolClassesList = new List<SchoolClassInfo>();
                    for (int rows = 0; rows < gridView.Rows.Count; rows++)
                    {

                        string className = gridView.Rows[rows].Cells[0].Value.ToString();
                        string schoolYearToBeSaved = gridView.Rows[rows].Cells[1].Value.ToString();
                        string teacherName = gridView.Rows[rows].Cells[3].Value.ToString();
                        int profileID = int.Parse(gridView.Rows[rows].Cells[2].Value.ToString());

                        var schoolYearID = context.SchoolYears
                                           .Where(schoolYear => schoolYear.SchoolYearName == schoolYearToBeSaved)
                                           .Select(schoolYear => schoolYear.SchoolYearID)
                                           .First();
                        var teacherNameID = context.Teachers
                                            .Where(teacher => (teacher.FirstName + " " + teacher.LastName) == teacherName)
                                            .Select(teacher => teacher.TeacherID)
                                            .First();
                        if (schoolYearID != 0)
                        {
                            if (teacherNameID != 0)
                            {
                                var newSchoolClass = new SchoolClass
                                {
                                    ClassName = className,
                                    SchoolYearID = schoolYearID,
                                    TeacherID = teacherNameID,
                                    ProfileID = profileID
                                };
                                context.SchoolClasses.Add(newSchoolClass);
                            }
                            else
                            {
                                throw new Exception("Учителят, който се опитвате да запишете не съществува.");
                            }
                        }
                        else
                        {
                            throw new Exception("Учебната година, в която се опитвате да запишете не е създадена.");
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
        public static void SaveNewSchoolClasses(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    string nextSchoolYear = string.Format("{0}/{1}", DateTime.Now.Year, DateTime.Now.Year + 1);
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {
                        string className = gridView.Rows[rows].Cells[0].Value.ToString();
                        string profileName = gridView.Rows[rows].Cells[1].Value.ToString();
                        string teacherName = gridView.Rows[rows].Cells[2].Value.ToString();

                        var profileID = context.Profiles
                                        .Where(profile => profile.ProfileName == profileName)
                                        .Select(profile => profile.ProfileID)
                                        .First();
                        var teacherID = context.Teachers
                                        .Where(teacher => (teacher.FirstName + " " + teacher.LastName) == teacherName)
                                        .Select(teacher => teacher.TeacherID)
                                        .First();

                        var schoolYearID = context.SchoolYears
                                           .Where(schoolYear => schoolYear.SchoolYearName == nextSchoolYear)
                                           .Select(schoolYear => schoolYear.SchoolYearID)
                                           .First();
                        if(schoolYearID==0)
                        {                            
                            throw new Exception(string.Format("Моля първо веведете учебна година {0}", nextSchoolYear));
                        }

                        var newSchoolClass = new SchoolClass
                        {
                            ClassName = className,
                            ProfileID = profileID,
                            TeacherID = teacherID,
                            SchoolYearID = schoolYearID
                        };
                        context.SchoolClasses.Add(newSchoolClass);
                    }
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
        public static int GetClassID (string className)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                var currentSchoolYearID = SchoolYearDA.GetCurrentSchoolYearID();
                var classID = context.SchoolClasses
                                    .Where(schoolClass => schoolClass.ClassName == className && schoolClass.SchoolYearID == currentSchoolYearID)
                                    .Select(schoolClass => schoolClass.ClassID)
                                    .First();
                return classID;
            }
        }
        public static int GetClassIDByStudent(long studentID, string schoolYear)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var classID = context.StudentsSchoolYears
                                        .Where(student => student.StudentID == studentID)
                                        .Where(year => year.SchoolYear.SchoolYearName == schoolYear)
                                        .Select(schoolClass => schoolClass.ClassID)
                                        .FirstOrDefault();
                return classID;
            }
        }
    }
}

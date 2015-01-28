namespace PersonalSchoolCardTestProject.DataAccessClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolCardDatabase;
    using System.Collections;

    public class StudentsAccess
    {
        public static List<string> GetAllStudents()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var studentsList = context.Students
                                   .Select(student => student.FirstName)
                                   .ToList();
                return studentsList;
            }
        }
        public static List<Student> GetStudentsByEnrollmentYear(int enrollmentYear)
        {
            try
            {
                using (var context = new PersonalSchoolCardEntities())
                {
                    var studentsList = context.Students
                                       .Where(student => student.EnrollmentYear == enrollmentYear)
                                       .ToList();
                    if (studentsList != null)
                    {
                        return studentsList;
                    }
                    else
                    {
                        throw new Exception("No students found or input year not correct!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption: {0}", ex.Message);
                return null;
            }
        }

        public static List<Student> GetStudentsByProfile(string profileName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                int searchedProfileID = context.Profiles
                                        .Where(profile => profile.ProfileName == profileName)
                                        .FirstOrDefault().ProfileID;


                var studentByProfile = context.Students
                                        .Where(student => student.ProfileID.Equals(searchedProfileID) == true)
                                        .ToList();
                return studentByProfile;
            }

        }
    }
}

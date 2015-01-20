namespace PersonalSchoolCardTestProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SchoolCardDatabase;
    public class Program
    {
        static void Main()
        {
            //sets encoding of console to cyrilic
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //Tests for the Students table from PersonalSchoolCardDatabase           

            #region //returns all students in the database
            Console.WriteLine("Returns all students in the database.");
            var listOfStudents = DataAccessClasses.StudentsAccess.GetAllStudents();
            foreach (var student in listOfStudents)
            {
                Console.WriteLine(student.ToString());
            }
            #endregion
            #region//return students by enrollment year
            Console.WriteLine();
            Console.WriteLine("Return students by enrollment year");
            var listOfStudentsByEnrollmentYear = DataAccessClasses.StudentsAccess.GetStudentsByEnrollmentYear(2010);
            foreach (var students in listOfStudentsByEnrollmentYear)
            {
                Console.WriteLine(students.ToString());
            }
            var listOfStudentsByEnrollmentYearExeptionTest = DataAccessClasses.StudentsAccess.GetStudentsByEnrollmentYear(2015);
            foreach (var students in listOfStudentsByEnrollmentYearExeptionTest)
            {
                Console.WriteLine(students.ToString());
            }
            #endregion

            #region//return students by profile
            Console.WriteLine();
            Console.WriteLine("Returns students searched by profile name");
            var studentsByProfile = DataAccessClasses.StudentsAccess.GetStudentsByProfile("Информационни технологии, Математика, Английски");
            foreach (var student in studentsByProfile)
            {
                Console.WriteLine(student.ToString());
            }
            #endregion
            //Tests for the Teachers Tabele form PersonalSchoolCardDatabase
            Console.WriteLine();
            #region//returns all teachers
            Console.WriteLine("Names of all teachers");
            var allTeachersList = DataAccessClasses.TeachersAccess.GetAllTearchers();
            foreach (var teacher in allTeachersList)
            {
                Console.WriteLine(teacher.ToString());
            }
            #endregion
            Console.WriteLine();
            #region//returns  teachers by taught subject
            Console.WriteLine("Names of all teachers teaching the searched subject");
            var teachersByTaughtSubject = DataAccessClasses.TeachersAccess.GetTeachersByThaughtSubject("Математика");
            foreach (var teacher in teachersByTaughtSubject)
            {
                Console.WriteLine(teacher.ToString());
            }
            #endregion
        }
    }
}

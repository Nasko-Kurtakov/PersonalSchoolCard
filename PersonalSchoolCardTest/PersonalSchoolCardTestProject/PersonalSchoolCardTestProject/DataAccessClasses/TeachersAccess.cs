namespace PersonalSchoolCardTestProject.DataAccessClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SchoolCardDatabase;

    public class TeachersAccess
    {
        public static List<Teacher> GetAllTearchers()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var allTeachers = context.Teachers
                                  .Select(teacher => teacher)
                                  .ToList();
                return allTeachers;
            }
        }
        public static List<Teacher> GetTeachersByThaughtSubject(string subjectName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var taughtSubjectID = context.Subjects
                                        .Where(subject => subject.SubjectName == subjectName)
                                        .FirstOrDefault().SubjectID;

                var teacherByTaughtSubject = context.Teachers
                                             .Where(teacher => teacher.TaughtSubjectID == taughtSubjectID)
                                             .ToList();
                return teacherByTaughtSubject;  
            }

        }
    }
}

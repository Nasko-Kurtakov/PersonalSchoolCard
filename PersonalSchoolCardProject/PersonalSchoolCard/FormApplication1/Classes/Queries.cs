using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalSchoolCard.Data;

namespace PersonalShcoolCard.Classes
{
    class Queries
    {
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

        public static string GetStudentID(int studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var StudentID = context.Students
                    .Where(student => student.StudentID == studentID)
                    .Select(student => student.PersonalNumber)
                    .FirstOrDefault()
                    ;

                return StudentID;
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

        public static string GetStudentGenderAssist()
        {
            //using ( var context = new PersonalSchoolCardEntities())
            //{
            //  code
            //  code
            //  code
            //  return code;
            //}

            return "н";
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

        public static string GetTeacherName(int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var teacherNames = context.Teachers
                    .Where(teacher => teacher.TeacherID == teacherID)
                    .Select(teacher => new
                    {
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName
                    })
                    .FirstOrDefault()
                    ;

                return teacherNames.FirstName + " "
                    + teacherNames.LastName
                    ;
            }
        }

    }
}

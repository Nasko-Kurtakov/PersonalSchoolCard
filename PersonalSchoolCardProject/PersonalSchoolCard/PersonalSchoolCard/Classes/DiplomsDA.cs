namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    public class DiplomsDA
    {
        public static void SaveMarkExam(long studentID,string subjectName,string mark)
        {
            using (var contex = new PersonalSchoolCardEntities())
            {
                var subjectID = SubjectDA.GetSubjectID(subjectName);
                var markAsFloat = float.Parse(mark);
                var ExamMark = new Diplom
                {
                    StudentID = studentID,
                    SubjectID = subjectID,
                    SubjectTypeID = 5,
                    Mark = markAsFloat
                };
                contex.Diploms.Add(ExamMark);
                contex.SaveChanges();
            }
        }
    }
}

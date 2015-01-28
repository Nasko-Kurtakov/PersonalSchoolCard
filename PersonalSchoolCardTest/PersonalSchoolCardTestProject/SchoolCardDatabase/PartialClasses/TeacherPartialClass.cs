﻿namespace SchoolCardDatabase
{
    using System;
    using System.Linq;
    public partial class Teacher
    {

        public override string ToString()
        {
            using(var contex = new PersonalSchoolCardEntities())
            {
                //var subjechtsNames = contex
            }
            return string.Format("Name: {0} {1} Subject: {2}", this.FirstName,this.LastName,TeacherSubjectName(this.TaughtSubjectID));
        }
        private string TeacherSubjectName(int thaughtSubjectId)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
        string thaughtSubjectName = context.Subjects
                                .Where(subject => subject.SubjectID == thaughtSubjectId)
                                .FirstOrDefault().SubjectName;
                return thaughtSubjectName;
            }
        }
    }
}

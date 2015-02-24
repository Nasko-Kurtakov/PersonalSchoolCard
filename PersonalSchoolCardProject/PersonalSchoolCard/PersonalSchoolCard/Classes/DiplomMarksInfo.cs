namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    public class DiplomMarksInfo
    {
        public string Subject { get; set; }
        public byte? MandatorySubjectFirstYear { get; set; }
        public byte? ChosenSubjectFirstYear { get; set; }
        public byte? MandatorySubjectSecondYear { get; set; }
        public byte? ChosenSubjectSecondYear { get; set; }
        public byte? MandatorySubjectThirdYear { get; set; }
        public byte? ChosenSubjectThirdYear { get; set; }
        public byte? MandatorySubjectFourthYear { get; set; }
        public byte? ChosenSubjectFourthYear { get; set; }

        public static List<DiplomMarksInfo> GetAllMarksForDiplom(long studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var allSubjects = SubjectDA.GetAllSubjects();
                var DiplomMarksList = new List<DiplomMarksInfo>();
                var studeiedYears = SchoolYearDA.GetAllStudiedYears();

                for (int i = 0; i < allSubjects.Count; i++)
                {
                    var markMandatoryFirstYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "ЗП", studeiedYears[0]);
                    var markChosenFirstYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "ЗИП", studeiedYears[0]);
                    var markMandatorySecondYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "ЗП", studeiedYears[1]);
                    var markChosenSecondYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "ЗИП", studeiedYears[1]);
                    var markMandatoryThirdYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "ЗП", studeiedYears[2]);
                    var markChosenThirdYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "ЗИП", studeiedYears[2]);
                    var markMandatoryFourthYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "ЗП", studeiedYears[3]);
                    var markChosenFourthYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "ЗИП", studeiedYears[3]);
                    
                    var marksForSubject = new DiplomMarksInfo
                    {
                         Subject = allSubjects[i].SubjectName,
                         MandatorySubjectFirstYear = markMandatoryFirstYear,
                         MandatorySubjectSecondYear= markMandatorySecondYear,
                         MandatorySubjectThirdYear = markMandatoryThirdYear,
                         MandatorySubjectFourthYear = markMandatoryFourthYear,
                         ChosenSubjectFirstYear = markChosenFirstYear,
                         ChosenSubjectSecondYear = markChosenSecondYear,
                         ChosenSubjectThirdYear = markChosenThirdYear,
                         ChosenSubjectFourthYear = markChosenFourthYear
                    };
                    DiplomMarksList.Add(marksForSubject);
                }
                return DiplomMarksList;
            }

        }
    }
}


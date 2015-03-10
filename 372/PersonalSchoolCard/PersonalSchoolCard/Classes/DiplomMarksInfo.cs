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
        public byte? ExtraSubjectFirstYear { get; set; }
        public byte? ExtraSubjectSecondYear { get; set; }
        public byte? ExtraSubjectThirdYear { get; set; }
        public byte? ExtraSubjectFourthYear { get; set; }
        public double? AverageMarkMandatorySubject { get; set; }
        public double? AverageMarkChosenSubject { get; set; }
        public double? AverageMarkExtraSubject { get; set; }

        public static List<DiplomMarksInfo> GetAllMarksForDiplomRegularSubjects(long studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var allSubjects = SubjectDA.GetAllSubjects();
                var diplomMarksList = new List<DiplomMarksInfo>();
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

                    var averageMarkMandatorySubject = CalculateAverageMark(markMandatoryFirstYear, markMandatorySecondYear, markMandatoryThirdYear, markMandatoryFourthYear);
                    var averageMarkChosenSubject = CalculateAverageMark(markChosenFirstYear, markChosenSecondYear, markChosenThirdYear, markChosenFourthYear);
                    var marksForSubject = new DiplomMarksInfo
                    {
                        Subject = allSubjects[i].SubjectName,
                        MandatorySubjectFirstYear = markMandatoryFirstYear,
                        MandatorySubjectSecondYear = markMandatorySecondYear,
                        MandatorySubjectThirdYear = markMandatoryThirdYear,
                        MandatorySubjectFourthYear = markMandatoryFourthYear,
                        ChosenSubjectFirstYear = markChosenFirstYear,
                        ChosenSubjectSecondYear = markChosenSecondYear,
                        ChosenSubjectThirdYear = markChosenThirdYear,
                        ChosenSubjectFourthYear = markChosenFourthYear,
                        AverageMarkMandatorySubject = averageMarkMandatorySubject,
                        AverageMarkChosenSubject = averageMarkChosenSubject
                    };
                    diplomMarksList.Add(marksForSubject);
                }
                return diplomMarksList;
            }

        }
        public static List<DiplomMarksInfo> GetAllMarksExtraSubjects(long studentID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var allSubjects = SubjectDA.GetAllSubjects();
                var diplomMarksList = new List<DiplomMarksInfo>();
                var studeiedYears = SchoolYearDA.GetAllStudiedYears();

                for (int i = 0; i < allSubjects.Count; i++)
                {
                    var markExtraSubjectFirstYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "СИП", studeiedYears[0]);
                    var markExtraSubjectSecondYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "СИП", studeiedYears[1]);
                    var markExtraSubjectThirdYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "СИП", studeiedYears[2]);
                    var markExtraSubjectFourthYear = MarkDA.GetFinalMarkForSchoolYear(studentID, allSubjects[i].SubjectID, "СИП", studeiedYears[3]);
                    var averageMarkExtraSubject = CalculateAverageMark(markExtraSubjectFirstYear, markExtraSubjectSecondYear, markExtraSubjectThirdYear, markExtraSubjectFourthYear);

                    var marksForSubject = new DiplomMarksInfo
                    {
                        Subject = allSubjects[i].SubjectName,
                        ExtraSubjectFirstYear = markExtraSubjectFirstYear,
                        ExtraSubjectSecondYear = markExtraSubjectSecondYear,
                        ExtraSubjectThirdYear = markExtraSubjectThirdYear,
                        ExtraSubjectFourthYear = markExtraSubjectFourthYear,
                        AverageMarkExtraSubject = averageMarkExtraSubject
                    };
                    diplomMarksList.Add(marksForSubject);
                }
                return diplomMarksList;
            }
        }
        private static double? CalculateAverageMark(params byte?[] marks)
        {
            double sum =0.00;
            int numberOfMarks = 0;
            
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] != null)
                {
                    sum += double.Parse(marks[i].ToString());
                    numberOfMarks++;
                }
            }
            
            if (!double.IsNaN(sum / numberOfMarks))
            {
                var markAsString = (sum / numberOfMarks).ToString("0.00");
                var mark = double.Parse(markAsString);
                mark = Math.Round(mark, 2);
                return mark;
            }else
            {
                return null;
            }
            
        }
    }
}



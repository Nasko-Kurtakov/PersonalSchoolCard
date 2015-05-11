namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class SchoolYearDA
    {
        public static void AddSchooYear(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {
                        var schoolYear = gridView.Rows[rows].Cells[0].Value.ToString();

                        if (schoolYear.Length == 9)
                        {
                            var newSchoolYear = new SchoolYear
                            {
                                SchoolYearName = schoolYear
                            };
                            context.SchoolYears.Add(newSchoolYear);
                        }
                        else
                        {
                            throw new Exception("Неправилно въведени данни.");
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
        public static void AddNextSchoolYearOnly()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {

                    var schoolYear = string.Format("{0}/{1}", DateTime.Now.Year, DateTime.Now.Year + 1);
                    var newSchoolYear = new SchoolYear
                    {
                        SchoolYearName = schoolYear
                    };
                    context.SchoolYears.Add(newSchoolYear);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public static List<string> GetAllSchoolYears()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var schoolYearsList = context.SchoolYears
                                          .OrderBy(schoolYear => schoolYear.SchoolYearName)
                                          .Select(schoolYear => schoolYear.SchoolYearName)
                                          .ToList();
                    return schoolYearsList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
        public static string GetCurrentSchoolYear()
        {
            if (DateTime.Now.Month < 9)
            {
                return string.Format("{0}/{1}", DateTime.Now.Year - 1, DateTime.Now.Year);
            }
            else
            {
                return string.Format("{0}/{1}", DateTime.Now.Year, DateTime.Now.Year + 1);
            }
        }
        public static int GetCurrentSchoolYearID()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var currentSchooYear = GetCurrentSchoolYear();
                var currentSchoolYearID = context.SchoolYears
                    .Where(schoolYear => schoolYear.SchoolYearName == currentSchooYear)
                    .Select(schoolYear => schoolYear.SchoolYearID)
                    .First();
                return currentSchoolYearID;
            }
        }
        public static List<string> GetAllStudiedYears()
        {
            int finalYear;
            var years = new List<string>();
            if (DateTime.Now.Month < 9)
            {
               finalYear = DateTime.Now.Year;
            }
            else
            {
               finalYear = DateTime.Now.Year + 1;
            }
            years.Add(string.Format("{0}/{1}", finalYear - 4, finalYear - 3));
            years.Add(string.Format("{0}/{1}", finalYear - 3, finalYear - 2));
            years.Add(string.Format("{0}/{1}", finalYear - 2, finalYear - 1));
            years.Add(string.Format("{0}/{1}", finalYear - 1, finalYear));
            return years;
        }
        public static string GetNextSchoolYear(string currentSchoolYear = "")
        {
            if (currentSchoolYear == "")
            {
                currentSchoolYear = GetCurrentSchoolYear();
            }
            string shoolYearFirstHalf = currentSchoolYear.Substring(0, 4);
            int shoolYearFirstHalfAsInt = int.Parse(shoolYearFirstHalf) + 1;
            string schoolYearSecondHalf = currentSchoolYear.Substring(5, 4);
            int schoolYearSecondHalfAsInt = int.Parse(schoolYearSecondHalf) + 1;
            string schoolYearChanged = string.Format("{0}/{1}", shoolYearFirstHalfAsInt, schoolYearSecondHalfAsInt);
            return schoolYearChanged;
        }
        public static int GetSchoolYearID(string schoolYearName)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                var schoolYearId = context.SchoolYears
                                    .Where(schoolYear => schoolYear.SchoolYearName == schoolYearName)
                                    .Select(schoolYear => schoolYear.SchoolYearID)
                                    .First();
                return schoolYearId;
            }
        }
    }
}
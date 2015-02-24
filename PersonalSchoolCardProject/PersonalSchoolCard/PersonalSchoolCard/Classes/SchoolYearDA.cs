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
        public static List<string> GetAllStudiedYears()
        {
            var years = new List<string>();
            years.Add(string.Format("{0}/{1}", DateTime.Now.Year - 4, DateTime.Now.Year - 3));
            years.Add(string.Format("{0}/{1}", DateTime.Now.Year - 3, DateTime.Now.Year - 2));
            years.Add(string.Format("{0}/{1}", DateTime.Now.Year - 2, DateTime.Now.Year - 1));
            years.Add(string.Format("{0}/{1}", DateTime.Now.Year - 1, DateTime.Now.Year));
            return years;
        }
    }
}
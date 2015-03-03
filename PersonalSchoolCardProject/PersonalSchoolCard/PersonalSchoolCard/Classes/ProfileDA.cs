namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class ProfileDA
    {
        public static void AddProfile(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {
                        string input = gridView.Rows[rows].Cells[0].Value.ToString();
                        if (input != null && input != "" && input != " ")
                        {
                            var profile = new Profile
                            {
                                ProfileName = input
                            };
                            context.Profiles.Add(profile);
                        }
                        else if (input == null || input == "" || input == " ")
                        {
                            throw new ArgumentNullException("Невалидни входни параметри");
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
        public static List<string> GetAllProfiles()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var profilesList = context.Profiles
                                          .Select(profile => profile.ProfileName).ToList();
                    return profilesList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
        public static Profile GetProfileOfStudent(int? profileID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {

                var profile = context.Profiles
                                .Where(p => p.ProfileID == profileID)
                                .Select(p => p)
                                .FirstOrDefault();
                return profile;
            }
        }
        public static string GetProfileByTeacher(int teacherID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var profileID = TeacherDA.GetClassProfileIDByTeacher(teacherID, SchoolYearDA.GetCurrentSchoolYear());
                var profileName = context.Profiles
                                .Where(profile => profile.ProfileID == profileID)
                                .Select(profile => profile.ProfileName)
                                .First();
                return profileName;
            }
        }
        public static int? GetProfileIDByClassName(string className)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                var currentSchoolYearID = SchoolYearDA.GetCurrentSchoolYearID();
                var profileID = context.SchoolClasses
                                    .Where(schoolClass => schoolClass.ClassName == className && schoolClass.SchoolYearID == currentSchoolYearID)
                                    .Select(schoolClass => schoolClass.ProfileID)
                                    .First();
                return profileID;
            }
        }
    }
}

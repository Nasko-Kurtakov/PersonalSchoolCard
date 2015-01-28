namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;

    public class SchoolInfoPanel
    {
        public static string GetSchoolName()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var schoolName = context.Schools
                                     .Select(school => school.SchoolName)
                                     .FirstOrDefault();
                    return schoolName;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void UpdateSchoolName(TextBox schoolNameTextBox)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var input = schoolNameTextBox.Text;
                    if(context.Schools.Select(school=>school).FirstOrDefault()!=null)
                    {
                        context.Schools.Select(school => school).FirstOrDefault().SchoolName = input;
                    }
                    else if (context.Schools.Select(school => school).FirstOrDefault() == null)
                    {
                        var school = new School
                        {
                            SchoolName = input
                        };
                        context.Schools.Add(school);
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void UpdatePrincipalFirstName(TextBox principalFirstName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var input = principalFirstName.Text;
                    if (input != null)
                    {
                        context.Principals.Select(principal => principal).FirstOrDefault().FirstName = input;
                        context.SaveChanges();
                    }
                    else if (input == "" || input==null || input == " ")
                    {
                        throw new Exception("Грешни входни данни");
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void UpdatePrincipalSecondName(TextBox principalSecondName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var input = principalSecondName.Text;
                    if (input != null)
                    {
                        context.Principals.Select(principal => principal).FirstOrDefault().SecondName = input;
                        context.SaveChanges();
                    }
                    else if (input == "" || input == null || input == " ")
                    {
                        throw new Exception("Грешни входни данни");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void UpdatePrincipalLastName(TextBox principalLastName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var input = principalLastName.Text;
                    if (input != null)
                    {
                        context.Principals.Select(principal => principal).FirstOrDefault().LastName = input;
                        context.SaveChanges();
                    }
                    else if (input == "" || input == null || input == " ")
                    {
                        throw new Exception("Грешни входни данни");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static string GetPrincipalFirstName()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var principalFirstName = context.Principals
                                     .Select(principal => principal.FirstName)
                                     .FirstOrDefault();
                    return principalFirstName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static string GetPrincipalSecondName()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var principalSecondName = context.Principals
                                     .Select(principal => principal.SecondName)
                                     .FirstOrDefault();
                    return principalSecondName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static string GetPrincipalLastName()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var principalLastName = context.Principals
                                     .Select(principal => principal.LastName)
                                     .FirstOrDefault();
                    return principalLastName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
    }
}

namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;

    public class SchoolInfo
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

        public static void UpdatePrincipalNames(TextBox principalFirstName, TextBox principalSecondName, TextBox principalLastName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var firstName = principalFirstName.Text;
                    var secondName = principalSecondName.Text;
                    var lastName = principalLastName.Text;
                    if (firstName != null && firstName!="" &&firstName!=" " )
                    {
                        if (secondName != null && secondName != "" && secondName != " ")
                        {
                            if (lastName != null && lastName != "" && lastName != " ")
                            {
                                context.Principals.Select(principal => principal).ToList().Last().FirstName = firstName;
                                context.Principals.Select(principal => principal).ToList().Last().SecondName = secondName;
                                context.Principals.Select(principal => principal).ToList().Last().LastName = lastName;
                                context.SaveChanges();
                            }
                        }
                    }
                    else
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
                                     .ToList()
                                     .Last();
                    return principalFirstName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static Principal GetPrincipalName()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var principalSecondName = context.Principals
                                     .Select(principal => principal)
                                     .ToList()
                                     .Last();
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
                                     .ToList()
                                     .Last();
                    return principalLastName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
        public static void NewPrincipal(TextBox firstName, TextBox secondName, TextBox lastName)
        {
            using (var contex = new PersonalSchoolCardEntities())
            {
                try
                {
                    var principal = new Principal
                    {
                        FirstName = firstName.Text,
                        SecondName = secondName.Text,
                        LastName = lastName.Text
                    };
                    contex.Principals.Add(principal);
                    contex.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public static void ChangeSchoolCity(ComboBox cityName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var cityID = context.Settlements
                                .Where(settlement => settlement.SettlementName == cityName.SelectedItem.ToString())
                                .Select(settlement => settlement.SettlementID)
                                .First();

                    context.Schools.First().SettlementID = cityID;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

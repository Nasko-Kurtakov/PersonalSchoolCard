namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;

    public class SchoolInfoDA
    {
        public static School GetSchool()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var schoolName = context.Schools
                                     .Select(school => school)
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

        public static void UpdateSchoolName(string schoolNameTextBox)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    
                    if(context.Schools.Select(school=>school).FirstOrDefault()!=null)
                    {
                        context.Schools.Select(school => school).FirstOrDefault().SchoolName = schoolNameTextBox;
                    }
                    else if (context.Schools.Select(school => school).FirstOrDefault() == null)
                    {
                        var school = new School
                        {
                            SchoolName = schoolNameTextBox
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

        public static void UpdatePrincipalNames(string principalFirstName, string principalSecondName, string principalLastName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    if (principalFirstName != null && principalFirstName != "" && principalFirstName != " ")
                    {
                        if (principalSecondName != null && principalSecondName != "" && principalSecondName != " ")
                        {
                            if (principalLastName != null && principalLastName != "" && principalLastName != " ")
                            {
                                context.Principals.Select(principal => principal).ToList().Last().FirstName = principalFirstName;
                                context.Principals.Select(principal => principal).ToList().Last().SecondName = principalSecondName;
                                context.Principals.Select(principal => principal).ToList().Last().LastName = principalLastName;
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
        public static void NewPrincipal(string firstName, string secondName, string lastName)
        {
            using (var contex = new PersonalSchoolCardEntities())
            {
                try
                {
                    var principal = new Principal
                    {
                        FirstName = firstName,
                        SecondName = secondName,
                        LastName = lastName
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
        public static void ChangeSchoolCity(int settlementID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                
                    context.Schools.First().SettlementID = settlementID;
                    context.SaveChanges();
            }
        }
    }
}

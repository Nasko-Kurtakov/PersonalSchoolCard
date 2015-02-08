namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;

    public class Principals
    {
        public static void NewPrincipal(TextBox firstName, TextBox secondName, TextBox lastName)
        {
            using(var contex = new PersonalSchoolCardEntities())
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

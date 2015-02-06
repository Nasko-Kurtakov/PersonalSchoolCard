namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class ManageAccountsPanel
    {
        public static void AddAccount(ComboBox comboBox,TextBox username,TextBox password)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    
                    string chosenUserName = username.Text.ToLower();
                    string chosenPasswod = password.Text.ToLower();
                    string teacherName = comboBox.Text;
                    var userNamesList = context.Teachers
                                       .Select(teacher => teacher.UserName)
                                       .ToList();
                    bool isFreeUsername= true;
                    foreach (var userName in userNamesList)
                    {
                        if (userName == chosenUserName)
                        {
                            isFreeUsername = false;
                            break;
                        }
                    }
                    if(isFreeUsername)
                    {
                        context.Teachers
                                    .AsEnumerable()
                                    .Where(teacher => teacher.GetFullName() == teacherName)
                                    .Select(teacher => teacher)
                                    .First().UserName = chosenUserName;
                        context.Teachers
                                    .AsEnumerable()
                                    .Where(teacher => teacher.GetFullName() == teacherName)
                                    .Select(teacher => teacher)
                                    .First().Password = chosenPasswod;
                        context.SaveChanges(); 
                    }
                    else
                    {
                        MessageBox.Show("Потребителското име е заето");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class TermDA
    {
        public static void AddTerms(DataGridView gridView)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {

                        string input = gridView.Rows[rows].Cells[0].Value.ToString();
                        if (input != null && input != "" && input != " ")
                        {
                            var term = new Term
                            {
                                 TermName = input
                            };
                            context.Terms.Add(term);
                        }
                        else if (input == null || input == "" || input == " ")
                        {
                            throw new ArgumentNullException("Невалидни входни параметри");
                        }
                    }
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public static List<string> GetTerms()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var termsList = context.Terms
                                    .Select(term => term.TermName)
                                    .ToList();
                    if (termsList != null)
                    {
                        return termsList;
                    }
                    else
                    {
                        throw new Exception("Няма въведени видове отсъствия");
                    }
                }
                catch (Exception ex)
                {
                    return new List<string> { ex.Message };
                }
            }
        }
        public static byte GetTermIDByName(string termName)
        {
            using(var context =  new PersonalSchoolCardEntities())
            {
                var termID = context.Terms
                                .Where(term => term.TermName == termName)
                                .Select(term => term.TermID)
                                .FirstOrDefault();
                return termID;
            }
        }
    }
}

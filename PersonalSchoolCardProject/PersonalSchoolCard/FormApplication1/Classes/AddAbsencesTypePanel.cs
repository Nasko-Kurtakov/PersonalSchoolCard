namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class AddAbsencesTypePanel
    {
        public static void AddAbsencesType(DataGridView gridView)
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
                            var absenceType = new TypeAbsence
                            {
                                TypeAbsenceName = input
                            };
                            context.TypeAbsences.Add(absenceType);
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

        public static List<string> GetAbsencesTypes()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var absencesTypesList = context.TypeAbsences
                                            .Select(type => type.TypeAbsenceName)
                                            .ToList();
                    if (absencesTypesList != null)
                    {
                        return absencesTypesList;
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
    }
}

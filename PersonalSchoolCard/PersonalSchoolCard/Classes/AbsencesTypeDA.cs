namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    public class AbsencesTypeDA
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
        public static List<TypeAbsence> GetAbsencesTypes()
        {
            using (var context = new PersonalSchoolCardEntities())
            {

                var absencesTypesList = context.TypeAbsences
                                        .Select(type => type)
                                        .ToList();

                return absencesTypesList;
            }

        }
        public static byte GetAbsenceIDTypeByName(string absenceTypeName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var absenceTypeID = context.TypeAbsences
                                        .Where(absenceType => absenceType.TypeAbsenceName == absenceTypeName)
                                        .Select(absenceType => absenceType.TypeAbsenceID)
                                        .FirstOrDefault();
                return absenceTypeID;
            }
        }
    }
}

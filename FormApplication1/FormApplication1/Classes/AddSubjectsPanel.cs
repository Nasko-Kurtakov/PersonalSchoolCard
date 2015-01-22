namespace PersonalShcoolCard.Classes
{
    using System;    
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard;
    using PersonalSchoolCard.Data;
    using System.Windows.Forms;
    public class AddSubjectsPanel
    {
        public static void AddSubjectTypes(DataGridView gridView)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    for (int rows = 0; rows < gridView.Rows.Count - 1; rows++)
                    {
                        for (int col = 0; col < gridView.Rows[rows].Cells.Count; col++)
                        {
                            string input = gridView.Rows[0].Cells[0].Value.ToString();
                            if (input != null && input != "" && input!=" ")
                            {
                                var subjectType = new SubjectType
                                {
                                    SubjectTypeName = input
                                };
                                context.SubjectTypes.Add(subjectType);
                            }
                            else
                            {
                                throw new ArgumentNullException();
                            }
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

        public static List<SubjectType> GetAllSubjectTypes()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var subjectTypes = context.SubjectTypes
                                   .Select(subjectType => subjectType)
                                   .ToList();
                return subjectTypes;
            }
        }
    }
}


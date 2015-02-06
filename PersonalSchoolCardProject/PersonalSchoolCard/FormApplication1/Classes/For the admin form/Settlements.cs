namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    using System.Windows.Forms;
    public class Settlements
    {
        public static void AddSettlement(TextBox cityName, ComboBox manicipality, ComboBox area, bool isManicipality = false, bool isArea = false)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    if (cityName.Text != "" && cityName.Text != null && cityName.Text != " ")
                    {
                        if (isManicipality && isArea)
                        {
                            var newSettlement = new Settlement();
                            newSettlement.SettlementName = cityName.Text;
                            context.Settlements.Add(newSettlement);
                            context.SaveChanges();

                            var newSettlementID = context.Settlements
                                                  .Where(settlement => settlement.SettlementName == cityName.Text)
                                                  .Select(settlement => settlement.SettlementID)
                                                  .First();

                            newSettlement.AreaID = newSettlement.SettlementID;
                            newSettlement.ManicipalityID = newSettlement.SettlementID;
                            context.SaveChanges();
                        }
                        if (isManicipality)
                        {
                            var newSettlement = new Settlement();
                            newSettlement.SettlementName = cityName.Text;

                            context.Settlements.Add(newSettlement);
                            context.SaveChanges();

                            var newSettlementID = context.Settlements
                                                  .Where(settlement => settlement.SettlementName == cityName.Text)
                                                  .Select(settlement => settlement.SettlementID)
                                                  .First();
                            var areaID = context.Settlements
                                         .Where(settlement => settlement.SettlementName == area.SelectedText)
                                         .Select(settlement => settlement.SettlementID)
                                         .First();

                            newSettlement.AreaID = areaID;
                            newSettlement.ManicipalityID = newSettlement.SettlementID;
                            context.SaveChanges();
                        }

                        if(!isManicipality && !isArea)
                        {
                            var newSettlement = new Settlement();
                            newSettlement.SettlementName = cityName.Text;

                            context.Settlements.Add(newSettlement);
                            context.SaveChanges();

                            var areaID = context.Settlements
                                         .Where(settlement => settlement.SettlementName == area.SelectedItem)
                                         .Select(settlement => settlement.SettlementID)
                                         .First();

                            var manicipalityID = context.Settlements
                                               .Where(settlement => settlement.SettlementName == manicipality.SelectedItem)
                                               .Select(settlement => settlement.SettlementID)
                                               .First();

                            newSettlement.AreaID = areaID;
                            newSettlement.ManicipalityID = manicipalityID;
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        throw new Exception("Грашни входни данни.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static List<string> GetAreas()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var areas = context.Settlements
                                .Where(settlement => settlement.SettlementID == settlement.AreaID)
                                .Select(settlement => settlement.SettlementName)
                                .ToList();
                    return areas;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static List<string> GetMinicipalities()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var minicipalities = context.Settlements
                                .Where(settlement => settlement.SettlementID == settlement.ManicipalityID)
                                .Select(settlement => settlement.SettlementName)
                                .ToList();
                    return minicipalities;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static List<string> GetVillages()
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var cities = context.Settlements
                                    .Select(setlement => setlement.SettlementName)
                                    .ToList();
                    return cities;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
    }
}

namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    using System.Windows.Forms;
    public class SettlementDA
    {

        public static void ModifySettlement(int settlementID, int manicipalityID, int areaID)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var settlement = context.Settlements
                   .Where(st => st.SettlementID == settlementID).FirstOrDefault();
                settlement.ManicipalityID = manicipalityID;
                settlement.AreaID = areaID;
                context.SaveChanges();
            }
        }
        public static int GetSettlementID(string settlementName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var settlement = context.Settlements
                    .Where(st => st.SettlementName == settlementName).FirstOrDefault();
                return settlement.SettlementID;

            }
        }
        public static int CreateSettlement(string newSettlementName)
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                var settlement = new Settlement
                {
                    SettlementName = newSettlementName,

                };
                context.Settlements.Add(settlement);
                context.SaveChanges();
                return settlement.SettlementID;
            }

        }
        public static void AddSettlement(string cityName, int manicipalityID, int areaID, bool isManicipality = false, bool isArea = false)
        {
            using (var context = new PersonalSchoolCardEntities())
            {

                if (cityName != "" && cityName != null && cityName != " ")
                {
                    if (isManicipality && isArea)
                    {
                        var settlementID = CreateSettlement(cityName);

                        ModifySettlement(settlementID, settlementID, settlementID);
                    }
                    if (isManicipality == true && isArea == false)
                    {
                        var settlementID = CreateSettlement(cityName);

                        ModifySettlement(settlementID, settlementID, areaID);
                    }

                    if (!isManicipality && !isArea)
                    {
                        var settlementID = CreateSettlement(cityName);

                        ModifySettlement(settlementID, manicipalityID, areaID);
                    }
                }
            }
        }

        public static List<Settlement> GetAreas()
        {
            using (var context = new PersonalSchoolCardEntities())
            {

                var areas = context.Settlements
                            .Where(settlement => settlement.SettlementID == settlement.AreaID)
                            .ToList();
                return areas;

            }
        }
        public static List<Settlement> GetMinicipalities()
        {
            using (var context = new PersonalSchoolCardEntities())
            {

                var minicipalities = context.Settlements
                            .Where(settlement => settlement.SettlementID == settlement.ManicipalityID)
                            .ToList();
                return minicipalities;
            }
        }
        public static List<Settlement> GetVillages()
        {
            using (var context = new PersonalSchoolCardEntities())
            {
                try
                {
                    var cities = context.Settlements
                                    .Select(setlement => setlement)
                                    .ToList();
                    return cities;
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

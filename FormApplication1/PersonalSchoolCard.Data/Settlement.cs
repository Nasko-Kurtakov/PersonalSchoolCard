//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonalSchoolCard.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Settlement
    {
        public Settlement()
        {
            this.Students = new HashSet<Student>();
        }
    
        public int SettlementID { get; set; }
        public string SettlemnetName { get; set; }
        public int ManicipalityID { get; set; }
        public int AreaID { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual Manicipality Manicipality { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

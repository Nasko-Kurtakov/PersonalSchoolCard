//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonalSchoolCardEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Manicipality
    {
        public Manicipality()
        {
            this.Settlements = new HashSet<Settlement>();
        }
    
        public int ManicipalityID { get; set; }
        public string ManicipalityName { get; set; }
    
        public virtual ICollection<Settlement> Settlements { get; set; }
    }
}

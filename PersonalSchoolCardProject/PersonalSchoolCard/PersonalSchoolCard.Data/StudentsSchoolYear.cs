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
    
    public partial class StudentsSchoolYear
    {
        public int SchoolYearID { get; set; }
        public long StudentID { get; set; }
        public int ClassID { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public virtual Student Student { get; set; }
    }
}

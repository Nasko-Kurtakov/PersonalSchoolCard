//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoursStudedSubject
    {
        public int ClassID { get; set; }
        public int ProfileID { get; set; }
        public int SubjectID { get; set; }
        public byte SubjectTypeID { get; set; }
        public string HoursStudied { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual SubjectType SubjectType { get; set; }
    }
}

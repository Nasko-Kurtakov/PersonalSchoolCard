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
    
    public partial class Subject
    {
        public Subject()
        {
            this.Diploms = new HashSet<Diplom>();
            this.HoursStudedSubjects = new HashSet<HoursStudedSubject>();
            this.Marks = new HashSet<Mark>();
            this.Teachers = new HashSet<Teacher>();
            this.Profiles = new HashSet<Profile>();
        }
    
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    
        public virtual ICollection<Diplom> Diploms { get; set; }
        public virtual ICollection<HoursStudedSubject> HoursStudedSubjects { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}

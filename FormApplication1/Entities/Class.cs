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
    
    public partial class Class
    {
        public Class()
        {
            this.Absences = new HashSet<Absence>();
            this.HoursStudedSubjects = new HashSet<HoursStudedSubject>();
            this.Marks = new HashSet<Mark>();
            this.StudentsSchoolYears = new HashSet<StudentsSchoolYear>();
        }
    
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public Nullable<int> SchoolYearID { get; set; }
        public Nullable<int> ProfileID { get; set; }
        public int TeacherID { get; set; }
    
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<HoursStudedSubject> HoursStudedSubjects { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<StudentsSchoolYear> StudentsSchoolYears { get; set; }
    }
}

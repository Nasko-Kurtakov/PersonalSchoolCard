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
    
    public partial class Student
    {
        public Student()
        {
            this.Absences = new HashSet<Absence>();
            this.Diploms = new HashSet<Diplom>();
            this.Marks = new HashSet<Mark>();
            this.StudentsSchoolYears = new HashSet<StudentsSchoolYear>();
        }
    
        public long StudentID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string PersonalCardNumber { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> SettlementID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Nullable<int> EnrollmentYear { get; set; }
        public Nullable<int> ProfileID { get; set; }
        public Nullable<float> MarkFromDiplom { get; set; }
    
        public virtual ICollection<Absence> Absences { get; set; }
        public virtual ICollection<Diplom> Diploms { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Settlement Settlement { get; set; }
        public virtual ICollection<StudentsSchoolYear> StudentsSchoolYears { get; set; }
    }
}

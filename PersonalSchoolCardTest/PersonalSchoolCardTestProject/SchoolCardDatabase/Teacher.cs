//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolCardDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        public Teacher()
        {
            this.Classes = new HashSet<Class>();
        }
    
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public int TaughtSubjectID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual ICollection<Class> Classes { get; set; }
        public virtual Subject Subject { get; set; }
    }
}

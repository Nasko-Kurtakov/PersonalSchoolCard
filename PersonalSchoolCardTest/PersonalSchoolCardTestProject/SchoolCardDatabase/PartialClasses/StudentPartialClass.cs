using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCardDatabase
{
    public partial class Student
    {
        public override string ToString()
        {
            return string.Format("Name: {0} Second Name: {1} Last Name: {2} PersonalID: {3}", this.FirstName, this.SecondName, this.LastName, this.PersonalNumber);
        }
    }
}

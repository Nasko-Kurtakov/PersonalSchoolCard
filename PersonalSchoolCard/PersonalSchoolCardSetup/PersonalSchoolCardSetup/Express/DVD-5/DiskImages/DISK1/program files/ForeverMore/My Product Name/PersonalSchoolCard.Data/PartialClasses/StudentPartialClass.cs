namespace PersonalSchoolCard.Data
{
    using System;
    public partial class Student
    {
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", this.FirstName, this.SecondName, this.LastName);
            }
        }
    }
}

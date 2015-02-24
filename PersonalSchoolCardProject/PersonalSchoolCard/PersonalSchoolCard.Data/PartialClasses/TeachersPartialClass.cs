namespace PersonalSchoolCard.Data
{
    using System;
    public partial class Teacher
    {
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        //public string GetFullName()
        //{
        //    return string.Format("{0} {1}", this.FirstName, this.LastName);
        //}
    }
}

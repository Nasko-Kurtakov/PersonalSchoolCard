namespace PersonalSchoolCard.Data
{
    using System;
    public partial class SchoolClass
    {
        public int ClassNumber
        {
            get
            {
                if (this.ClassName.Length < 4)
                {
                    return int.Parse(this.ClassName.Substring(0, 1));
                }
                else
                {
                    return int.Parse(this.ClassName.Substring(0, 2));
                }
            }
        }
    }
}

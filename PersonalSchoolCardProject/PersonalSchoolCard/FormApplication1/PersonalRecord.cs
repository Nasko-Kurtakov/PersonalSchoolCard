using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalShcoolCard
{
    public partial class PersonalRecord : Form
    {
        public PersonalRecord()
        {
            InitializeComponent();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Success sc = new Success();
            sc.Show();
        }

        private void PersonalRecord_Load(object sender, EventArgs e)
        {
            label1StudentName.Text = Classes.Queries.GetStudentsName(2);
            label1AreaName.Text = Classes.Queries.GetStudentArea(2);
            label1Citizenship.Text = Classes.Queries.GetStudentCitizenship();
           
            label1CurrentAddress1.Text = Classes.Queries.GetStudentCurrentAddress(2);
            label1CurrentAddress2.Text = " "; //need to be fixed, check it
            label1AreaName.Text = Classes.Queries.GetStudentArea(2);
            
            label1DateOfBirth.Text = Classes.Queries.GetStudentDateOfBirth(2).ToShortDateString();
            label1EnrollmentYear.Text = Classes.Queries.GetStudentEnrollmentYear(2).ToString();
            label1GenderAssist.Text = Classes.Queries.GetStudentGenderAssist(); //need to be fixed, check it
            
            label1TownName.Text = Classes.Queries.GetStudentsSettlement(2);
            label1HomeTown.Text = Classes.Queries.GetStudentsSettlement(2); //need to be fixed, check it
            
            label1MunicipalityName.Text = Classes.Queries.GetStudentMunicipality(2);
            label1HomeMunicipality.Text = Classes.Queries.GetStudentMunicipality(2); //need to be fixed, check it

            label1DistrictName.Text = Classes.Queries.GetStudentMunicipality(2); //need to be fixed, check it 
            label1HomeDistrict.Text = Classes.Queries.GetStudentMunicipality(2); //need to be fixed, check it

            label1ID.Text = Classes.Queries.GetStudentID(2);
            label1LNCH.Text = Classes.Queries.GetStudentCardID(2);

            //school name
            label1SchoolName.Text = Classes.Queries.GetStudentSchoolName(); //need to be fixed, check it
        }

    }
}

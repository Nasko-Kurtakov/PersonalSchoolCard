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
            int studentID = 1;

            label1StudentName.Text = Classes.Queries.GetStudentsName(studentID);
            label1AreaName.Text = Classes.Queries.GetStudentArea(studentID);
            label1Citizenship.Text = Classes.Queries.GetStudentCitizenship();

            label1CurrentAddress1.Text = Classes.Queries.GetStudentCurrentAddress(studentID);
            label1CurrentAddress2.Text = " "; //need to be fixed, check it
            label1AreaName.Text = Classes.Queries.GetStudentArea(studentID);

            label1DateOfBirth.Text = Classes.Queries.GetStudentDateOfBirth(studentID).ToShortDateString();
            label1EnrollmentYear.Text = Classes.Queries.GetStudentEnrollmentYear(studentID).ToString();
            label1GenderAssist.Text = Classes.Queries.GetStudentGenderAssist(); //need to be fixed, check it

            label1TownName.Text = Classes.Queries.GetStudentsSettlement(studentID);
            label1HomeTown.Text = Classes.Queries.GetStudentsSettlement(studentID); //need to be fixed, check it

            label1MunicipalityName.Text = Classes.Queries.GetStudentMunicipality(studentID);
            label1HomeMunicipality.Text = Classes.Queries.GetStudentMunicipality(studentID); //need to be fixed, check it

            label1DistrictName.Text = Classes.Queries.GetStudentMunicipality(studentID); //need to be fixed, check it 
            label1HomeDistrict.Text = Classes.Queries.GetStudentMunicipality(studentID); //need to be fixed, check it

            label1ID.Text = Classes.Queries.GetStudentID(studentID);
            label1LNCH.Text = Classes.Queries.GetStudentCardID(studentID);

            //school name
            label1SchoolName.Text = Classes.Queries.GetStudentSchoolName(); //need to be fixed, check it
        }

    }
}

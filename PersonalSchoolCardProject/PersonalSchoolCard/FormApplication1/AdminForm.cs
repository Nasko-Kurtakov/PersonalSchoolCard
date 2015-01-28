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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            panelAddTeachers.Parent = panelParent;
            panelAddTeachers.Dock = DockStyle.Fill;
            panelAddSubjects.Parent = panelParent;
            panelAddSubjects.Dock = DockStyle.Fill;
            panelStartPanel.Parent = panelParent;
            panelAddAbsencesType.Parent = panelParent;
            panelAddAbsencesType.Dock = DockStyle.Fill;
            panelMenageTerms.Parent = panelParent;
            panelMenageTerms.Dock = DockStyle.Fill;
            panelMenageAccounts.Parent = panelParent;
            panelMenageAccounts.Dock = DockStyle.Fill;
            panelAddProfiles.Parent = panelParent;
            panelAddProfiles.Dock = DockStyle.Fill;
            panelSchoolInfo.Parent = panelParent;
            panelSchoolInfo.Dock = DockStyle.Fill;


            var schoolNameChanged = false;
            var firstNameChanged = false;
            var secondNameChanged = false;
            var lastNameChanged = false;
        }


        private void buttonAddSubjectTypes_Click(object sender, EventArgs e)
        {
            Classes.AddSubjectsPanel.AddSubjectTypes(dataGridViewSubjectTypes);

            //refreshes the subject types column and updates it if there are changes
            var subjectsTypes = Classes.AddSubjectsPanel.GetAllSubjectTypesName();
            var subjectTypesColumn = Classes.AddSubjectsPanel.AddSubjectsTypeColumn(subjectsTypes);
            dataGridViewSubjects.Columns.Remove(subjectTypesColumn.Name);
            dataGridViewSubjects.Columns.Add(subjectTypesColumn);
            dataGridViewSubjects.Refresh();
        }

        private void buttonAddSubjects_Click(object sender, EventArgs e)
        {
            DataGridViewColumn subjectType = new DataGridViewColumn();
            var comboBoxSubjects = new DataGridViewComboBoxColumn();
            Classes.AddSubjectsPanel.AddSubjects(dataGridViewSubjects);

        }

        private void buttonAddSubjectsAndTypes_Click(object sender, EventArgs e)
        {

            //shows the subject types currently in the database
            listBoxAlreadyAddedSubjectTypes.DataSource = Classes.AddSubjectsPanel.GetAllSubjectTypesName();
            listBoxAlreadyAddedSubjects.DataSource = Classes.AddSubjectsPanel.GetAllSubjectsNames();
            var subjectsTypes = Classes.AddSubjectsPanel.GetAllSubjectTypesName();
            //creates and load the column showing types of subjects in the add subjects data grid view
            //using the method in classes-> Add Subjects Panel -> AddSubjectsTypeColumn
            var subjectTypesColumn = Classes.AddSubjectsPanel.AddSubjectsTypeColumn(subjectsTypes);
            dataGridViewSubjects.Columns.Add(subjectTypesColumn);
            //dataGridViewSubjects.Refresh();

            panelAddSubjects.Visible = true;
            panelStartPanel.Visible = false;
            panelAddSubjects.BringToFront();
        }

        private void buttonOpenAddTeachersPanel_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedTeachers.DataSource = Classes.AddTeachersPanel.GetAllTeachersNames();
            Classes.AddTeachersPanel.ShowSubjectsInCombobox(TaughtSubject, Classes.AddSubjectsPanel.GetAllSubjectsNames());
            //dataGridViewAddTeacher.Refresh();
            panelAddTeachers.Visible = true;
            panelAddTeachers.BringToFront();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.AddTeachersPanel.AddTeachers(dataGridViewAddTeacher);
        }

        private void buttonAddAbsencesType_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedAbsencesTypes.DataSource = Classes.AddAbsencesTypePanel.GetAbsencesTypes();
            panelAddAbsencesType.Visible = true;
            panelAddAbsencesType.BringToFront();
        }

        private void buttonAddAbsencesTypes_Click(object sender, EventArgs e)
        {
            Classes.AddAbsencesTypePanel.AddAbsencesType(dataGridViewAddAbsenceType);
        }

        private void buttonTermManagement_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedTerms.DataSource = Classes.AddTermsPanel.GetTerms();
            panelMenageTerms.Visible = true;
            panelMenageTerms.BringToFront();
        }

        private void buttonAddTerms_Click(object sender, EventArgs e)
        {
            Classes.AddTermsPanel.AddTerms(dataGridViewAddTerms);
        }

        private void buttonMenageAccounts_Click(object sender, EventArgs e)
        {

            comboBoxTeacherName.DataSource = Classes.AddTeachersPanel.GetAllTeachersNames();

            textBoxPassword.PasswordChar = '*';
            comboBoxTeacherName.ResetText();
            panelMenageAccounts.Visible = true;
            panelMenageAccounts.BringToFront();
        }

        private void buttonCreateAccaount_Click(object sender, EventArgs e)
        {
            Classes.ManageAccountsPanel.AddAccount(comboBoxTeacherName, textBoxUsername, textBoxPassword);
        }

        private void buttonAddSettlements_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateProfile_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedProfiles.DataSource = Classes.AddProfilesPanel.GetAllProfiles();

            panelAddProfiles.Visible = true;
            panelAddProfiles.BringToFront();
        }

        private void buttonAddProfile_Click(object sender, EventArgs e)
        {
            Classes.AddProfilesPanel.AddProfile(dataGridViewAddProfile);
        }

        private void buttonEditSchoolInfo_Click(object sender, EventArgs e)
        {

            textBoxSchoolName.Text = Classes.SchoolInfoPanel.GetSchoolName();
            textBoxPrincipalFirstName.Text = Classes.SchoolInfoPanel.GetPrincipalFirstName();
            textBoxPrincipalSecondName.Text = Classes.SchoolInfoPanel.GetPrincipalSecondName();
            textBoxPrincipalLastName.Text = Classes.SchoolInfoPanel.GetPrincipalLastName();

            panelSchoolInfo.Visible = true;
            panelSchoolInfo.BringToFront();
        }

        private void textBoxSchoolName_TextChanged(object sender, EventArgs e)
        {
            //schoolNameChanged = true;
            buttonUpdateInfo.Enabled = true;
        }

        private void textBoxPrincipalFirstName_TextChanged(object sender, EventArgs e)
        {
            //firstNameChanged = true;
            buttonUpdateInfo.Enabled = true;
        }

        private void textBoxPrincipalSecondName_TextChanged(object sender, EventArgs e)
        {
            //secondNameChanged = true;
            buttonUpdateInfo.Enabled = true;
        }

        private void textBoxPrincipalLastName_TextChanged(object sender, EventArgs e)
        {
            //lastNameChanged = true;
            buttonUpdateInfo.Enabled = true;
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            
        }
    }
}

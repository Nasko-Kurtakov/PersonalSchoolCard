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
            panelStartPanel.Parent = panelParent;
            panelStartPanel.Dock = DockStyle.Fill;
            panelAddTeachers.Parent = panelParent;
            panelAddTeachers.Dock = DockStyle.Fill;
            panelAddSubjects.Parent = panelParent;
            panelAddSubjects.Dock = DockStyle.Fill;
            panelStartPanel.Parent = panelParent;
            panelAddAbsencesType.Parent = panelParent;
            panelAddAbsencesType.Dock = DockStyle.Fill;
            panelMenageTerms.Parent = panelParent;
            panelMenageTerms.Dock = DockStyle.Fill;
            panelAddProfiles.Parent = panelParent;
            panelAddProfiles.Dock = DockStyle.Fill;
            panelSchoolInfo.Parent = panelParent;
            panelSchoolInfo.Dock = DockStyle.Fill;
            AddNewSchoolClass.Parent = panelParent;
            AddNewSchoolClass.Dock = DockStyle.Fill;
            panelAddSchoolYears.Parent = panelParent;
            panelAddSchoolYears.Dock = DockStyle.Fill;
            panelSettlements.Parent = panelParent;
            panelSettlements.Dock = DockStyle.Fill;
        }

        #region//subjects and subject types methods
        private void buttonAddSubjectTypes_Click(object sender, EventArgs e)
        {
            Classes.AddSubjectsPanel.AddSubjectTypes(dataGridViewSubjectTypes);

            //refreshes the subject types column and updates it if there are changes
            var subjectsTypes = Classes.AddSubjectsPanel.GetAllSubjectTypesName();
            var subjectTypesColumn = Classes.AddSubjectsPanel.AddSubjectsTypeColumn(subjectsTypes);
            dataGridViewSubjects.Columns.Remove(subjectTypesColumn.Name);
            dataGridViewSubjects.Columns.Add(subjectTypesColumn);
            dataGridViewSubjects.Refresh();
            listBoxAlreadyAddedSubjectTypes.DataSource = Classes.AddSubjectsPanel.GetAllSubjectTypesName();
            listBoxAlreadyAddedSubjectTypes.Refresh();
        } //done

        private void buttonAddSubjects_Click(object sender, EventArgs e)
        {
            DataGridViewColumn subjectType = new DataGridViewColumn();
            var comboBoxSubjects = new DataGridViewComboBoxColumn();
            Classes.AddSubjectsPanel.AddSubjects(dataGridViewSubjects);
            listBoxAlreadyAddedSubjects.DataSource = Classes.AddSubjectsPanel.GetAllSubjectsNames();
            listBoxAlreadyAddedSubjects.Refresh();

        } //done

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
        } //done
        #endregion

        #region//adding teachers methods
        private void buttonOpenAddTeachersPanel_Click(object sender, EventArgs e)
        {

            listBoxAlreadyAddedTeachers.DataSource = Classes.AddTeachersPanel.GetAllTeachersNames();

            panelAddTeachers.Visible = true;
            panelAddTeachers.BringToFront();

        } //done

        private void buttonAddTeachers_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedTeachers.DataSource = Classes.AddTeachersPanel.GetAllTeachersNames();
            listBoxAlreadyAddedTeachers.Refresh();
            Classes.AddTeachersPanel.AddTeachers(dataGridViewAddTeacher);
        } //done
        #endregion

        #region//adding absences types
        private void buttonAddAbsencesType_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedAbsencesTypes.DataSource = Classes.AddAbsencesTypePanel.GetAbsencesTypes();
            panelAddAbsencesType.Visible = true;
            panelAddAbsencesType.BringToFront();
        } //done

        private void buttonAddAbsencesTypes_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedAbsencesTypes.DataSource = Classes.AddAbsencesTypePanel.GetAbsencesTypes();
            listBoxAlreadyAddedAbsencesTypes.Refresh();
            Classes.AddAbsencesTypePanel.AddAbsencesType(dataGridViewAddAbsenceType);
        } //done
        #endregion

        #region //meneging terms methods
        private void buttonTermManagement_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedTerms.DataSource = Classes.AddTermsPanel.GetTerms();
            panelMenageTerms.Visible = true;
            panelMenageTerms.BringToFront();
        } //done

        private void buttonAddTerms_Click(object sender, EventArgs e)
        {
            Classes.AddTermsPanel.AddTerms(dataGridViewAddTerms);
            listBoxAlreadyAddedTerms.DataSource = Classes.AddTermsPanel.GetTerms();
            listBoxAlreadyAddedTerms.Refresh();
        } //done
        #endregion

        #region //meneging classes
        private void buttonMenageClasses_Click(object sender, EventArgs e)
        {
            //comboBoxSchoolYears.DataSource = ////TODO

            dataGridViewShowCurrentClasses.DataSource = Classes.ManageSchoolClassesPanel.GetCurrentSchoolClasses("2013/2014");
            NewSchoolClassProfile.DataSource = Classes.AddProfilesPanel.GetAllProfiles();
            NewSchoolClassTeacher.DataSource = Classes.AddTeachersPanel.GetAllTeachersNames();
            AddNewSchoolClass.Visible = true;
            AddNewSchoolClass.BringToFront();
        } //done 
        private void buttonWarning_Click_1(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
            buttonAccept.Visible = true;
        }
        private void buttonShowChanges_Click_1(object sender, EventArgs e)
        {
            dataGridViewShowChanges.DataSource = Classes.ManageSchoolClassesPanel.VisualizeChanges(dataGridViewShowCurrentClasses);
        }
        private void buttonAccept_Click_1(object sender, EventArgs e)
        {
            Classes.ManageSchoolClassesPanel.SaveUpdatedSchoolClasses(dataGridViewShowChanges);
            labelWarning.Visible = false;
            buttonAccept.Visible = false;
        }
        private void buttonAddNewSchoolClasses_Click(object sender, EventArgs e)
        {
            Classes.ManageSchoolClassesPanel.SaveNewSchoolClasses(dataGridViewAddNewSchoolClasses);
        }
        #endregion

        #region //adding settlements
        private void buttonAddSettlements_Click(object sender, EventArgs e)
        {
            comboBoxChooseArea.DataSource = Classes.Settlements.GetAreas();
            comboBoxChooseManicipality.DataSource = Classes.Settlements.GetMinicipalities();
            panelSettlements.Visible = true;
            panelSettlements.BringToFront();
        }
        private void buttonAddNewSettlement_Click(object sender, EventArgs e)
        {
            if (checkBoxIsManicipality.Checked && checkBoxIsArea.Checked)
            {
                Classes.Settlements.AddSettlement(textBoxCityName, comboBoxChooseManicipality, comboBoxChooseArea, true, true);
            }
            else
                if (checkBoxIsManicipality.Checked)
                {
                    Classes.Settlements.AddSettlement(textBoxCityName, comboBoxChooseManicipality, comboBoxChooseArea, true, false);
                }
                else
                {
                    Classes.Settlements.AddSettlement(textBoxCityName, comboBoxChooseManicipality, comboBoxChooseArea);
                }


        }
        private void checkBoxIsManicipality_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsManicipality.Checked == true)
            {
                comboBoxChooseManicipality.Enabled = false;
            }
            else
            {
                comboBoxChooseManicipality.Enabled = true;
            }
        }
        private void checkBoxIsArea_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsArea.Checked == true)
            {
                comboBoxChooseArea.Enabled = false;
                checkBoxIsManicipality.Checked = true;
            }
            else
            {
                comboBoxChooseArea.Enabled = true;
            }
        }
        #endregion

        #region //creating profiles
        private void buttonCreateProfile_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedProfiles.DataSource = Classes.AddProfilesPanel.GetAllProfiles();

            panelAddProfiles.Visible = true;
            panelAddProfiles.BringToFront();
        }//done

        private void buttonAddProfile_Click(object sender, EventArgs e)
        {
            Classes.AddProfilesPanel.AddProfile(dataGridViewAddProfile);
            listBoxAlreadyAddedProfiles.DataSource = Classes.AddProfilesPanel.GetAllProfiles();
            listBoxAlreadyAddedProfiles.Refresh();
        }//done
        #endregion

        #region//Editing school info and principals info
        private void buttonEditSchoolInfo_Click(object sender, EventArgs e)
        {

            textBoxSchoolName.Text = Classes.SchoolInfoPanel.GetSchoolName();
            textBoxPrincipalFirstName.Text = Classes.SchoolInfoPanel.GetPrincipalFirstName();
            textBoxPrincipalSecondName.Text = Classes.SchoolInfoPanel.GetPrincipalSecondName();
            textBoxPrincipalLastName.Text = Classes.SchoolInfoPanel.GetPrincipalLastName();
            comboBoxSchoolCity.DataSource = Classes.Settlements.GetVillages();
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
        #endregion

        #region//adding new school years
        private void buttonAddSchoolYear_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedSchoolYears.DataSource = Classes.SchoolYearsPanel.GetAllSchoolYears();
            panelAddSchoolYears.Visible = true;
            panelAddSchoolYears.BringToFront();
        }

        private void buttonAddNextOnly_MouseEnter(object sender, EventArgs e)
        {
            var toolTip = new ToolTip();
            toolTip.SetToolTip(this.buttonAddNextOnly, "Добавя само следващата\n учебна година без да и нужно въвеждането ѝ.");

        }

        private void buttonNewSchoolYear_Click(object sender, EventArgs e)
        {
            Classes.SchoolYearsPanel.AddSchooYear(dataGridViewSchoolYears);
            listBoxAlreadyAddedSchoolYears.DataSource = Classes.SchoolYearsPanel.GetAllSchoolYears();
            listBoxAlreadyAddedSchoolYears.Refresh();
        }

        private void buttonAddNextOnly_Click(object sender, EventArgs e)
        {
            Classes.SchoolYearsPanel.AddNextSchoolYearOnly();
            listBoxAlreadyAddedSchoolYears.DataSource = Classes.SchoolYearsPanel.GetAllSchoolYears();
            listBoxAlreadyAddedSchoolYears.Refresh();
            buttonAddNextOnly.Enabled = false;
        }
        #endregion
    }
}

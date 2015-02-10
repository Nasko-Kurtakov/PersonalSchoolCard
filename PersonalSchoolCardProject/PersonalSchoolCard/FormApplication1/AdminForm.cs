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
            panelManageTerms.Parent = panelParent;
            panelManageTerms.Dock = DockStyle.Fill;
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
            panelAddNewPrincipal.Parent = panelParent;
            panelAddNewPrincipal.Dock = DockStyle.Fill;
            panelAddStudent.Parent = panelParent;
            panelAddStudent.Dock = DockStyle.Fill;
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            labelcurrentSchoolYear.Text += Classes.SchoolYear.GetCurrentSchoolYear();
            labelSchowCurrentSchoolYear.Text += Classes.SchoolYear.GetCurrentSchoolYear();
            labelSchoolYear.Text += Classes.SchoolYear.GetCurrentSchoolYear();
        }

        #region//subjects and subject types methods
        private void buttonAddSubjectTypes_Click(object sender, EventArgs e)
        {
            Classes.AddSubject.AddSubjectTypes(dataGridViewSubjectTypes);

            //refreshes the subject types column and updates it if there are changes
            var subjectsTypes = Classes.AddSubject.GetAllSubjectTypesName();
            dataGridViewSubjects.Refresh();
            listBoxAlreadyAddedSubjectTypes.DataSource = Classes.AddSubject.GetAllSubjectTypesName();
            listBoxAlreadyAddedSubjectTypes.Refresh();
        } //done

        private void buttonAddSubjects_Click(object sender, EventArgs e)
        {
            DataGridViewColumn subjectType = new DataGridViewColumn();
            var comboBoxSubjects = new DataGridViewComboBoxColumn();
            Classes.AddSubject.AddSubjects(dataGridViewSubjects);
            listBoxAlreadyAddedSubjects.DataSource = Classes.AddSubject.GetAllSubjectsNames();
            listBoxAlreadyAddedSubjects.Refresh();

        } //done

        private void buttonAddSubjectsAndTypes_Click(object sender, EventArgs e)
        {

            //shows the subject types currently in the database
            listBoxAlreadyAddedSubjectTypes.DataSource = Classes.AddSubject.GetAllSubjectTypesName();
            listBoxAlreadyAddedSubjects.DataSource = Classes.AddSubject.GetAllSubjectsNames();
            var subjectsTypes = Classes.AddSubject.GetAllSubjectTypesName();

            panelAddSubjects.Visible = true;
            panelStartPanel.Visible = false;
            panelAddSubjects.BringToFront();
        } //done
        #endregion

        #region//adding teachers methods
        private void buttonOpenAddTeachersPanel_Click(object sender, EventArgs e)
        {

            listBoxAlreadyAddedTeachers.DataSource = Classes.AddTeacher.GetAllTeachersNames();

            panelAddTeachers.Visible = true;
            panelAddTeachers.BringToFront();

        } //done

        private void buttonAddTeachers_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedTeachers.DataSource = Classes.AddTeacher.GetAllTeachersNames();
            listBoxAlreadyAddedTeachers.Refresh();
            Classes.AddTeacher.AddTeachers(dataGridViewAddTeacher);
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

        #region //managing terms methods
        private void buttonTermManagement_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedTerms.DataSource = Classes.AddTerm.GetTerms();
            panelManageTerms.Visible = true;
            panelManageTerms.BringToFront();
        } //done

        private void buttonAddTerms_Click(object sender, EventArgs e)
        {
            Classes.AddTerm.AddTerms(dataGridViewAddTerms);
            listBoxAlreadyAddedTerms.DataSource = Classes.AddTerm.GetTerms();
            listBoxAlreadyAddedTerms.Refresh();
        } //done
        #endregion

        #region //managing classes
        private void buttonMenageClasses_Click(object sender, EventArgs e)
        {


            dataGridViewShowCurrentClasses.DataSource = Classes.SchoolClass.GetCurrentSchoolClasses("2013/2014");
            NewSchoolClassProfile.DataSource = Classes.Profile.GetAllProfiles();
            NewSchoolClassTeacher.DataSource = Classes.AddTeacher.GetAllTeachersNames();
            AddNewSchoolClass.Visible = true;
            AddNewSchoolClass.BringToFront();
        }
        private void buttonWarning_Click_1(object sender, EventArgs e)
        {
            labelWarning.Visible = true;
            buttonAccept.Visible = true;
        }
        private void buttonShowChanges_Click_1(object sender, EventArgs e)
        {
            dataGridViewShowChanges.DataSource = Classes.SchoolClass.VisualizeChanges(dataGridViewShowCurrentClasses);
        }
        private void buttonAccept_Click_1(object sender, EventArgs e)
        {
            Classes.SchoolClass.SaveUpdatedSchoolClasses(dataGridViewShowChanges);
            labelWarning.Visible = false;
            buttonAccept.Visible = false;
            labelUpdatedScholClassesDone.Visible = true;
            timerManageSchoolClasses.Start();
        }
        private void buttonAddNewSchoolClasses_Click(object sender, EventArgs e)
        {
            Classes.SchoolClass.SaveNewSchoolClasses(dataGridViewAddNewSchoolClasses);
            labelAddedNewSchoolClassesDone.Visible = true;
            timerManageSchoolClasses.Start();
        }
        private void timerManageSchoolClasses_Tick(object sender, EventArgs e)
        {
            labelAddedNewSchoolClassesDone.Visible = false;
            labelUpdatedScholClassesDone.Visible = false;
            timerManageSchoolClasses.Stop();
        }
        #endregion

        #region //adding settlements
        private void buttonAddSettlements_Click(object sender, EventArgs e)
        {
            comboBoxChooseArea.DataSource = Classes.Settlement.GetAreas();
            comboBoxChooseManicipality.DataSource = Classes.Settlement.GetMinicipalities();
            panelSettlements.Visible = true;
            panelSettlements.BringToFront();
        }
        private void buttonAddNewSettlement_Click(object sender, EventArgs e)
        {
            if (checkBoxIsManicipality.Checked && checkBoxIsArea.Checked)
            {
                Classes.Settlement.AddSettlement(textBoxCityName.Text, int.Parse(comboBoxChooseManicipality.SelectedValue.ToString()), int.Parse(comboBoxChooseArea.SelectedValue.ToString()), true, true);
            }
            else
                if (checkBoxIsManicipality.Checked)
                {
                    Classes.Settlement.AddSettlement(textBoxCityName.Text, int.Parse(comboBoxChooseManicipality.SelectedValue.ToString()), int.Parse(comboBoxChooseArea.SelectedValue.ToString()), true, false);
                }
                else
                {
                    Classes.Settlement.AddSettlement(textBoxCityName.Text, int.Parse(comboBoxChooseManicipality.SelectedValue.ToString()), int.Parse(comboBoxChooseArea.SelectedValue.ToString()));
                }
            comboBoxChooseArea.DataSource = Classes.Settlement.GetAreas();
            comboBoxChooseManicipality.DataSource = Classes.Settlement.GetMinicipalities();
            comboBoxChooseArea.Refresh();
            comboBoxChooseManicipality.Refresh();
            textBoxCityName.Clear();
            labelAddCityDone.Visible = true;
            timerAddCityDone.Start();
        }
        private void timerAddCityDone_Tick(object sender, EventArgs e)
        {
            labelAddCityDone.Visible = false;
            timerAddCityDone.Stop();
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
            listBoxAlreadyAddedProfiles.DataSource = Classes.Profile.GetAllProfiles();

            panelAddProfiles.Visible = true;
            panelAddProfiles.BringToFront();
        }//done

        private void buttonAddProfile_Click(object sender, EventArgs e)
        {
            Classes.Profile.AddProfile(dataGridViewAddProfile);
            listBoxAlreadyAddedProfiles.DataSource = Classes.Profile.GetAllProfiles();
            listBoxAlreadyAddedProfiles.Refresh();
        }//done
        #endregion

        #region//Editing school info and principals info
        private void buttonEditSchoolInfo_Click(object sender, EventArgs e)
        {

            textBoxSchoolName.Text = Classes.SchoolInfo.GetSchoolName();
            textBoxPrincipalFirstName.Text = Classes.SchoolInfo.GetPrincipalName().FirstName;
            textBoxPrincipalSecondName.Text = Classes.SchoolInfo.GetPrincipalName().SecondName;
            textBoxPrincipalLastName.Text = Classes.SchoolInfo.GetPrincipalName().LastName;
            comboBoxSchoolCity.DataSource = Classes.Settlement.GetVillages();
            panelSchoolInfo.Visible = true;
            panelSchoolInfo.BringToFront();
        }

        private void buttonAddNewPrincipal_Click(object sender, EventArgs e)
        {
            panelAddNewPrincipal.Visible = true;
            panelAddNewPrincipal.BringToFront();
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            Classes.SchoolInfo.UpdatePrincipalNames(textBoxPrincipalFirstName, textBoxPrincipalSecondName, textBoxPrincipalLastName);
            labelSchoolInfoChangesDone.Visible = true;
            timerChangesDone.Start();
        }
        private void buttonChangeSchoolName_Click(object sender, EventArgs e)
        {
            Classes.SchoolInfo.UpdateSchoolName(textBoxSchoolName);
            labelSchoolInfoChangesDone.Visible = true;
            timerChangesDone.Start();
        }
        private void buttonAddPrincipal_Click(object sender, EventArgs e)
        {
            Classes.SchoolInfo.NewPrincipal(textBoxNewPrincipalFirstName, textBoxNewPrincipalSecondName, textBoxNewPrincipalLastName);
            textBoxNewPrincipalFirstName.Clear();
            textBoxNewPrincipalSecondName.Clear();
            textBoxNewPrincipalLastName.Clear();
            labelAddedPrincipalDone.Visible = true;
            timerAddedNewPrincipal.Start();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            textBoxPrincipalFirstName.Text = Classes.SchoolInfo.GetPrincipalName().FirstName;
            textBoxPrincipalSecondName.Text = Classes.SchoolInfo.GetPrincipalName().SecondName;
            textBoxPrincipalLastName.Text = Classes.SchoolInfo.GetPrincipalName().LastName;
            panelAddNewPrincipal.Visible = false;
            panelSchoolInfo.BringToFront();
        }
        private void timerAddedNewPrincipal_Tick(object sender, EventArgs e)
        {
            labelAddedPrincipalDone.Visible = false;
            timerAddedNewPrincipal.Stop();
        }
        private void buttonChangeCity_Click(object sender, EventArgs e)
        {
            Classes.SchoolInfo.ChangeSchoolCity(comboBoxSchoolCity);
        }
        private void timerChangesDone_Tick(object sender, EventArgs e)
        {
            labelSchoolInfoChangesDone.Visible = false;
            timerChangesDone.Stop();
        }
        
        #endregion

        #region//adding new school years
        private void buttonAddSchoolYear_Click(object sender, EventArgs e)
        {
            listBoxAlreadyAddedSchoolYears.DataSource = Classes.SchoolYear.GetAllSchoolYears();
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
            Classes.SchoolYear.AddSchooYear(dataGridViewSchoolYears);
            listBoxAlreadyAddedSchoolYears.DataSource = Classes.SchoolYear.GetAllSchoolYears();
            listBoxAlreadyAddedSchoolYears.Refresh();
            labelAddedSchoolYearDone.Visible = true;
            timerAddSchoolYear.Start();
        }
        private void timerAddSchoolYear_Tick(object sender, EventArgs e)
        {
            labelAddedSchoolYearDone.Visible = false;
            timerAddSchoolYear.Stop();
        }

        private void buttonAddNextOnly_Click(object sender, EventArgs e)
        {
            Classes.SchoolYear.AddNextSchoolYearOnly();
            listBoxAlreadyAddedSchoolYears.DataSource = Classes.SchoolYear.GetAllSchoolYears();
            listBoxAlreadyAddedSchoolYears.Refresh();
            buttonAddNextOnly.Enabled = false;
            labelAddedSchoolYearDone.Visible = true;
            timerAddSchoolYear.Start();
        }
        #endregion

        #region//add students to school classes
        private void buttonAddStudents_Click(object sender, EventArgs e)
        {
            panelAddStudent.Visible = true;
            panelAddStudent.BringToFront();
        }
        private void comboBoxClassesForCurrentSchoolYear_Click(object sender, EventArgs e)
        {
            comboBoxClassesForCurrentSchoolYear.DataSource = Classes.Student.GetClassesForThisSchoolYear();
        }

        private void comboBoxClassesForCurrentSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAlreadyAddedStudents.DataSource = Classes.Student.GetStudentsInClasses(comboBoxClassesForCurrentSchoolYear);
        }
        private void buttonAddNewStudents_Click(object sender, EventArgs e)
        {
            Classes.Student.AddStudent(dataGridViewAddStudents, comboBoxClassesForCurrentSchoolYear);
            labelAddedNewStudents.Visible = true;
            timerAddedStudentsDone.Start();
        }

        private void timerAddedStudentsDone_Tick(object sender, EventArgs e)
        {
            labelAddedNewStudents.Visible = false;
            timerAddedStudentsDone.Stop();
        }

        private void buttonAddStudentsFromExcel_Click(object sender, EventArgs e)
        {
            if (openFileDialogLoadFromExcel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataGridViewAddStudents.AutoGenerateColumns = false;
                string path = openFileDialogLoadFromExcel.FileName;
                dataGridViewAddStudents.DataSource = Classes.Student.AddStudentToDatagridFromExcel(path);
            }
        }
        #endregion

        

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

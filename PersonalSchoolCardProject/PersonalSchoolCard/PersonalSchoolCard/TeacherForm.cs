namespace PersonalShcoolCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using PersonalSchoolCard.Data;
    using System.Data.Entity.Infrastructure;
    public partial class TeacherForm : Form
    {
        int teacherID;
        string path = null;
        long studentID;
        Student studentInfoToBeSaved = new Student();
        string schoolYear = Classes.SchoolYearDA.GetCurrentSchoolYear();
        string teacherName;
        string comboBoxSettlementNameInitialText = "Град/Село";
        //List<Subject> subjectsStudiedThisYear = new List<Subject>();

        public TeacherForm(int teacherID)
        {
            InitializeComponent();
            this.Size = new Size(SystemInformation.VirtualScreen.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.teacherID = teacherID;
            panelWelcome.Parent = panelParent;
            panelWelcome.Dock = DockStyle.Fill;
            panelEditStudentsInfo.Parent = panelParent;
            panelEditStudentsInfo.Dock = DockStyle.Fill;
            panelAddAbsences.Parent = panelParent;
            panelAddAbsences.Dock = DockStyle.Fill;
            panelEditTeacherInfo.Parent = panelParent;
            panelEditTeacherInfo.Dock = DockStyle.Fill;
            tabControlMarks.Parent = panelParent;
            tabControlMarks.Dock = DockStyle.Fill;
            tabControlMarksExtraSubjects.Parent = panelParent;
            tabControlMarksExtraSubjects.Dock = DockStyle.Fill;
            tabControlDiplom.Parent = panelParent;
            tabControlDiplom.Dock = DockStyle.Fill;
            panelMarksExam.Parent = panelParent;
            panelMarksExam.Dock = DockStyle.Fill;
            panelMarksSummary.Parent = panelParent;
            panelMarksSummary.Dock = DockStyle.Fill;
            comboBoxSettlementName.Text = comboBoxSettlementNameInitialText;
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            teacherName = Classes.TeacherDA.GetTeacher(teacherID).FullName;
            this.Text = teacherName;
            string className = Classes.SchoolClassDA.GetClassNameByTeacherID(teacherID, schoolYear);
            labelHi.Text += teacherName + ".";
            panelWelcome.BringToFront();
            labelTeacherName.Text += teacherName;
            labelClassName.Text += className + " клас";
            labelCurrentSchoolYear.Text += schoolYear + " година";
            ShowSchoolYears();
        }
        private void TeacherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void TeacherForm_Resize(object sender, EventArgs e)
        {
            panelEditStudentsInfo.Dock = DockStyle.Fill;
            panelEditStudentsInfo.Refresh();
        }


        #region//editing students info methods
        private void buttonEditStudentsInfo_Click(object sender, EventArgs e)
        {
            dataGridViewStudents.AutoGenerateColumns = false;
            dataGridViewStudents.DataSource = Classes.StudentDA.GetStudentByTeacher(teacherID);
            panelEditStudentsInfo.Visible = true;
            panelEditStudentsInfo.BringToFront();
        }
        private void dataGridViewStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            ClearTextFields();
            string studentFirstName = dataGridViewStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
            string studentSecondName = dataGridViewStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
            string studentLastName = dataGridViewStudents.Rows[e.RowIndex].Cells[2].Value.ToString();

            studentID = Classes.StudentDA.GetStudentID(teacherID, studentFirstName, studentSecondName, studentLastName);
            FillTextFields();

            buttonSaveChanges.Enabled = true;

        }
        private void buttonLoadPortrait_Click(object sender, EventArgs e)
        {
            if (openFileDialogLoadPortrait.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialogLoadPortrait.FileName;
                pictureBoxPortrait.Image = Image.FromFile(path);
                labelPictureNotSelected.Visible = false;
            }
            else
            {
                labelPictureNotSelected.Visible = true;
            }

        }
        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {

            var studentInfoToBeSaved = new Student
            {
                FirstName = textBoxFirstName.Text,
                SecondName = textBoxSecondName.Text,
                LastName = textBoxLastName.Text,
                PersonalNumber = textBoxPersonalNumber.Text,
                PersonalCardNumber = textBoxPersonalCardNumber.Text,
                DateOfBirth = Convert.ToDateTime(textBoxDateOfBirth.Text),
                Address = textBoxAddress.Text,
                Phone = textBoxMobilePhone.Text,
                EnrollmentYear = int.Parse(textBoxEnrollmentYear.Text),
                SettlementID = int.Parse(comboBoxSettlementName.SelectedValue.ToString()),
            };
            Classes.StudentDA.UpdateStudentInfo(studentID, studentInfoToBeSaved);
            Classes.PictureDA.SetPortraitPath(studentID, path);
        }
        private void comboBoxSettlementName_Click(object sender, EventArgs e)
        {
            comboBoxSettlementName.DataSource = Classes.SettlementDA.GetVillages();
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelWelcome.Visible = true;
            panelWelcome.BringToFront();
        }
        private void ClearTextFields()
        {
            textBoxFirstName.Clear();
            textBoxSecondName.Clear();
            textBoxLastName.Clear();
            textBoxEnrollmentYear.Clear();
            textBoxPersonalNumber.Clear();
            textBoxPersonalCardNumber.Clear();
            textBoxDateOfBirth.Clear();
            textBoxMobilePhone.Clear();
            textBoxAddress.Clear();
            comboBoxSettlementName.Text = comboBoxSettlementNameInitialText;
        }
        private void FillTextFields()
        {
            var student = Classes.StudentDA.SelectStudent(studentID);
            textBoxFirstName.Text = student.FirstName;
            textBoxSecondName.Text = student.SecondName;
            textBoxLastName.Text = student.LastName;
            if (student.PersonalNumber != null)
            {
                textBoxPersonalNumber.Text = student.PersonalNumber;
            }
            if (student.PersonalCardNumber != null)
            {
                textBoxPersonalCardNumber.Text = student.PersonalCardNumber;
            }
            if (student.DateOfBirth != null)
            {
                textBoxDateOfBirth.Text = student.DateOfBirth.Value.Date.ToShortDateString();
            }
            if (student.Address != null)
            {
                textBoxAddress.Text = student.Address;
            }
            if (student.Phone != null)
            {
                textBoxMobilePhone.Text = student.Phone;
            }
            if (student.EnrollmentYear != null)
            {
                textBoxEnrollmentYear.Text = student.EnrollmentYear.ToString();
            }
            if (student.SettlementID != null)
            {
                comboBoxSettlementName.DataSource = Classes.SettlementDA.GetVillages();
                comboBoxSettlementName.SelectedValue = student.SettlementID;
            }
            var portraitPath = Classes.PictureDA.GetPortraitPath(studentID);
            if (portraitPath != null && portraitPath != "")
            {
                pictureBoxPortrait.Image = Image.FromFile(portraitPath);
                labelPictureNotSelected.Visible = false;
            }
            else
            {
                pictureBoxPortrait.Image = null;
                labelPictureNotSelected.Visible = true;
            }
        }
        #endregion

        #region//adding marks for mandtatory subjects (ЗП, ЗИП)
        private void buttonAddMarksFirstTerm_Click(object sender, EventArgs e)
        {
            checkedListBoxSubjects.DataSource = Classes.SubjectDA.GetAllSubjects();
            checkedListBoxSubjects.DisplayMember = "SubjectName";
            tabControlMarks.Visible = true;
            tabControlMarks.BringToFront();
        }
        private void dataGridViewMarksFirstTerm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetMarkWithWords(dataGridViewMarksFirstTerm, e.ColumnIndex, e.RowIndex);
        }
        private void buttonSaveMarksFirstTerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMarksFirstTerm.Rows.Count != 0)
                {
                    Classes.MarkDA.SaveMark(dataGridViewMarksFirstTerm, teacherID, long.Parse(comboBoxStudentsNames.SelectedValue.ToString()), 1);
                    ChangesMadeSuccessfully(labelSuccessFirstTerm, timerSuccess);
                }
                else
                {
                    throw new InvalidProgramException();
                }
            }
            catch (InvalidProgramException)
            {
                MessageBox.Show("Не сте избрали учебни предмети");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не сте въвели данни");
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Данните, които искате да запишете са вече въведени");
            }

        }
        private void comboBoxStudentsNamesFirstTerm_MouseEnter(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNames);
            comboBoxStudentsNames.MouseEnter -= comboBoxStudentsNamesFirstTerm_MouseEnter;
        }
        private void buttonSaveMarksSecondTerm_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewMarksSecondTerm, teacherID, long.Parse(comboBoxStudentsNames.SelectedValue.ToString()), 2);
            ChangesMadeSuccessfully(labelSuccessSecondTerm, timerSuccess);
        }
        private void dataGridViewMarksSecondTerm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetMarkWithWords(dataGridViewMarksSecondTerm, e.ColumnIndex, e.RowIndex);
        }
        private void buttonSaveMarksYear_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewMarksYear, teacherID, long.Parse(comboBoxStudentsNames.SelectedValue.ToString()), 3);
            ChangesMadeSuccessfully(labelSuccessYear, timerSuccess);
        }
        private void dataGridViewMarksYear_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetMarkWithWords(dataGridViewMarksYear, e.ColumnIndex, e.RowIndex);
        }
        private void tabControlMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMarks.SelectedTab == tabControlMarks.TabPages[1])
            {
                comboBoxStudentsNames.Parent = panelMarksFirstTerm;
                comboBoxStudentsNames.BringToFront();
            }
            if (tabControlMarks.SelectedTab == tabControlMarks.TabPages[2])
            {
                comboBoxStudentsNames.Parent = panelMarksSecondTerm;
                comboBoxStudentsNames.BringToFront();
            }
            if (tabControlMarks.SelectedTab == tabControlMarks.TabPages[3])
            {
                comboBoxStudentsNames.Parent = panelMarksYear;
                comboBoxStudentsNames.BringToFront();
            }
        }
        private void checkedListBoxSubjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedSubjectName = checkedListBoxSubjects.SelectedItem.ToString();
            ParseSubjectsToDataGridView(dataGridViewMarksFirstTerm, e, selectedSubjectName);
            ParseSubjectsToDataGridView(dataGridViewMarksSecondTerm, e, selectedSubjectName);
            ParseSubjectsToDataGridView(dataGridViewMarksYear, e, selectedSubjectName);

        }
        #endregion

        #region//adding extra subjects marks
        private void checkedListBoxExtraSubjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedSubjectName = checkedListBoxExtraSubjects.SelectedItem.ToString();
            ParseSubjectsToDataGridView(dataGridViewExtraSubjectsFirstTerm, e, selectedSubjectName);
            ParseSubjectsToDataGridView(dataGridViewExtraSubjectsSecondTerm, e, selectedSubjectName);
            ParseSubjectsToDataGridView(dataGridViewExtraSubjectsYear, e, selectedSubjectName);
        }
        private void buttonSaveMarksExtraSubjectsFirstTerm_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewExtraSubjectsFirstTerm, teacherID, long.Parse(comboBoxStudentsNamesExtraSubjects.SelectedValue.ToString()), 1, true);
            ChangesMadeSuccessfully(labelSaveSuccessExtraSubjectsMarks, timerSaveSuccessExtraSubjects);
        }
        private void buttonSaveMarksExtraSubjectsSecondTerm_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewExtraSubjectsFirstTerm, teacherID, long.Parse(comboBoxStudentsNamesExtraSubjects.SelectedValue.ToString()), 2, true);
            ChangesMadeSuccessfully(labelSaveSuccessExtraSubjectsMarks, timerSaveSuccessExtraSubjects);
        }
        private void buttonSaveMarksExtraSubjectsYear_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewExtraSubjectsFirstTerm, teacherID, long.Parse(comboBoxStudentsNamesExtraSubjects.SelectedValue.ToString()), 3, true);
            ChangesMadeSuccessfully(labelSaveSuccessExtraSubjectsMarks, timerSaveSuccessExtraSubjects);
        }
        private void buttonAddMarksExtraSubjects_Click(object sender, EventArgs e)
        {
            checkedListBoxExtraSubjects.DataSource = Classes.SubjectDA.GetAllSubjects();
            checkedListBoxExtraSubjects.DisplayMember = "SubjectName";
            tabControlMarksExtraSubjects.Visible = true;
            tabControlMarksExtraSubjects.BringToFront();
        }
        private void dataGridViewExtraSubjectsFirstTerm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetMarkWithWords(dataGridViewExtraSubjectsFirstTerm, e.ColumnIndex, e.RowIndex);
        }
        private void dataGridViewExtraSubjectsSecondTerm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetMarkWithWords(dataGridViewExtraSubjectsSecondTerm, e.ColumnIndex, e.RowIndex);
        }
        private void dataGridViewExtraSubjectsYear_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GetMarkWithWords(dataGridViewExtraSubjectsYear, e.ColumnIndex, e.RowIndex);
        }
        private void comboBoxStudentsNamesExtraSubjects_MouseEnter(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNamesExtraSubjects);
            comboBoxStudentsNamesExtraSubjects.MouseEnter -= comboBoxStudentsNamesExtraSubjects_MouseEnter;
        }
        private void timerSaveSuccessExtraSubjects_Tick(object sender, EventArgs e)
        {
            labelSaveSuccessExtraSubjectsMarks.Visible = false;
            timerSaveSuccessExtraSubjects.Stop();
        }
        private void tabControlMarksExtraSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMarksExtraSubjects.SelectedTab == tabControlMarksExtraSubjects.TabPages[1])
            {
                comboBoxStudentsNamesExtraSubjects.Parent = panelExtraSubjectsFirstTerm;
                comboBoxStudentsNamesExtraSubjects.BringToFront();
            }
            if (tabControlMarksExtraSubjects.SelectedTab == tabControlMarksExtraSubjects.TabPages[2])
            {
                comboBoxStudentsNamesExtraSubjects.Parent = panelExtraSubjectsSecondTerm;
                comboBoxStudentsNamesExtraSubjects.BringToFront();
            }
            if (tabControlMarksExtraSubjects.SelectedTab == tabControlMarksExtraSubjects.TabPages[3])
            {
                comboBoxStudentsNamesExtraSubjects.Parent = panelExtraSubjectsYearTerm;
                comboBoxStudentsNamesExtraSubjects.BringToFront();
            }
        }
        #endregion

        #region//saving absences
        private void buttonAddAbseces_Click(object sender, EventArgs e)
        {
            dataGridViewAbsences.AutoGenerateColumns = false;
            dataGridViewAbsences.DataSource = Classes.AbsencesTypeDA.GetAbsencesTypes();
            panelAddAbsences.Visible = true;
            panelAddAbsences.BringToFront();
        }
        private void comboBoxStudentsNamesAbsences_MouseEnter(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNamesAbsences);
            comboBoxStudentsNamesAbsences.MouseEnter -= comboBoxStudentsNamesAbsences_MouseEnter;
            buttonSaveAbsences.Enabled = true;
        }
        private void buttonSaveAbsences_Click(object sender, EventArgs e)
        {
            try
            {
                Classes.AbsencesDA.SaveAbsences(dataGridViewAbsences, long.Parse(comboBoxStudentsNamesAbsences.SelectedValue.ToString()), teacherID);
                ChangesMadeSuccessfully(labelAbsecesSaveSusseccful, timerAbcensesSaveSuccessful);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не сте избрали ученик.");
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Данните, които искате да запишете са вече въведени");
            }

        }
        #endregion

        #region//edit teacher info
        private void buttonEditTeacherInfo_Click(object sender, EventArgs e)
        {
            var teacher = Classes.TeacherDA.GetTeacher(teacherID);
            textBoxTeacherFirstName.Text = teacher.FirstName;
            textBoxTeacherLastName.Text = teacher.LastName;
            textBoxUserName.Text = teacher.UserName;
            textBoxPassword.Text = teacher.Password;
            panelEditTeacherInfo.Visible = true;
            panelEditTeacherInfo.BringToFront();
        }
        private void textBoxTeacherFirstName_TextChanged(object sender, EventArgs e)
        {
            buttonSaveChangesTeacherInfo.Enabled = true;
        }

        private void textBoxTeacherLastName_TextChanged(object sender, EventArgs e)
        {
            buttonSaveChangesTeacherInfo.Enabled = true;
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            buttonSaveChangesTeacherInfo.Enabled = true;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            buttonSaveChangesTeacherInfo.Enabled = true;
        }

        private void buttonSaveChangesTeacherInfo_Click(object sender, EventArgs e)
        {
            Classes.TeacherDA.EditTeacherInfo(teacherID, textBoxTeacherFirstName.Text, textBoxTeacherLastName.Text, textBoxUserName.Text, textBoxPassword.Text);
            labelChangesMade.Visible = true;
            timerTeacherChanges.Start();
        }

        private void timerTeacherChanges_Tick(object sender, EventArgs e)
        {
            labelChangesMade.Visible = false;
            timerTeacherChanges.Stop();
        }

        private void textBoxPassword_MouseEnter(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '\0';
        }

        private void textBoxPassword_MouseLeave(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
        }
        #endregion

        #region//reusable methods
        private void GetMarkWithWords(DataGridView gridView, int colIndex, int rowIndex)
        {
            if (colIndex == 2 || colIndex == 4)
            {
                string mark = gridView.Rows[rowIndex].Cells[colIndex].Value.ToString();
                gridView.Rows[rowIndex].Cells[colIndex - 1].Value = Classes.MarkDA.GetMarkWithWords(mark);
            }
        }
        private void ParseStudentsToComboBox(ComboBox comboBox)
        {
            string text = comboBox.Text;
            comboBox.DataSource = Classes.StudentDA.GetStudentByTeacher(teacherID);
            comboBox.Text = text;
        }
        private void ChangesMadeSuccessfully(Label infoLabel, Timer timer)
        {
            infoLabel.Visible = true;
            infoLabel.BringToFront();
            timer.Start();
        }
        private void ParseSubjectsToDataGridView(DataGridView gridView, ItemCheckEventArgs e, string selectedSubjectName)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                gridView.Rows.Add();
                gridView.Rows[gridView.Rows.Count - 1].Cells[0].Value = selectedSubjectName;
                gridView.Refresh();
            }
            else
            {
                for (int i = 0; i <= gridView.Rows.Count; i++)
                {
                    if (gridView.Rows[i].Cells[0].Value.ToString() == selectedSubjectName)
                    {
                        gridView.Rows.RemoveAt(i);
                        break;
                    }
                }

            }
        }
        private void timerSuccess_Tick(object sender, EventArgs e)
        {
            labelSuccessYear.Visible = false;
            timerSuccess.Stop();
        }
        #endregion

        #region//adding marks for the end of 12 grade exams
        private void buttonAddMarksFromExams_Click(object sender, EventArgs e)
        {
            if (Classes.SchoolClassDA.GetClassNumberByTeacherID(teacherID) != 12)
            {
                labelExamWarning.Visible = true;
                buttonSaveExamMarks.Enabled = false;
            }
            panelMarksExam.Visible = true;
            panelMarksExam.BringToFront();
        }

        private void buttonSaveExamMarks_Click(object sender, EventArgs e)
        {
            try
            {

                studentID = long.Parse(comboBoxStudentsNamesExam.SelectedValue.ToString());
                string markFirstExam;
                string secondSubject;
                string secondExamMark;
                string thirdSubject;
                string thirdMark;
                if (textBoxFirstExamMark.Text != null && textBoxFirstExamMark.Text != "")
                {
                    markFirstExam = textBoxFirstExamMark.Text;
                }
                else
                {
                    throw new FormatException(string.Format("Не сте въвели оценка по {0}.", textBoxFirstExam.Text));
                }
                if (comboBoxSecondExam.SelectedItem != null)
                {
                    secondSubject = comboBoxSecondExam.SelectedItem.ToString();
                    if (textBoxSecondExamMark.Text != null && textBoxSecondExamMark.Text != "")
                    {

                        secondExamMark = textBoxSecondExamMark.Text;
                    }
                    else
                    {
                        throw new FormatException("Не сте въвели оценка по вторият предмет.");
                    }
                }
                else
                {
                    throw new FormatException(string.Format("Не стe избрали втори предмет."));
                }
                if (comboBoxThirdExam.SelectedItem != null)
                {
                    thirdSubject = comboBoxThirdExam.SelectedItem.ToString();
                    if (textBoxSecondExamMark.Text != null)
                    {
                        thirdMark = textBoxThirdExamMark.Text;
                    }
                    else
                    {
                        throw new FormatException(string.Format("Не стe избрали трети предмет."));
                    }
                    Classes.DiplomsDA.SaveMarkExam(studentID, thirdSubject, thirdMark);
                }

                Classes.DiplomsDA.SaveMarkExam(studentID, textBoxFirstExam.Text, markFirstExam);
                Classes.DiplomsDA.SaveMarkExam(studentID, secondSubject, secondExamMark);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Не сте избрали ученик");
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Вече има въведени оценки на този ученик");
            }
        }

        private void comboBoxStudentsNamesExam_Click(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNamesExam);
            comboBoxStudentsNamesExam.Click -= comboBoxStudentsNamesExam_Click;
        }
        #endregion

        #region//showing the complete diplom with marks
        private void comboBoxStudentsNamesDiplom_Click(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNamesDiplom);
            comboBoxStudentsNamesDiplom.Click -= comboBoxStudentsNamesDiplom_Click;
        }
        private void clearDiplomFields()
        {
            labelStudentName.Text = "";
            labelPersonalNumber.Text = "";
            labelGenderAssist.Text = "";
            labelHomeTown.Text = "";
            labelManicipality.Text = "";
            labelArea.Text = "";
            labelPersonalCardNumber.Text = "";
            labelGraduationYear.Text = "";
            labelSchoolName.Text = "";
            labelProfileName.Text = "";
            labelStudiedYears.Text = "";
            labelSchoolCityName.Text = "";
            labelSchoolManicipality.Text = "";
            labelSchoolArea.Text = "";
            pictureBoxStudentPortrait.Image = null;
            labelPictureNotAvailable.Visible = true;
        }
        private void buttonShowDiplom_Click(object sender, EventArgs e)
        {
            tabControlDiplom.Visible = true;
            tabControlDiplom.BringToFront();
        }
        private void ShowDiplomInfo()
        {
            var student = Classes.StudentDA.SelectStudent(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()));
            var school = Classes.SchoolInfoDA.GetSchool();
            var studentSettlementInfo = Classes.SettlementDA.GetStudentSettlement(student.SettlementID);
            var schoolSettlementInfo = Classes.SettlementDA.GetStudentSettlement(school.SettlementID);
            var profile = Classes.ProfileDA.GetProfileOfStudent(student.ProfileID);
            if (student.FullName != null)
            {
                labelStudentName.Text = student.FullName;
            }
            else
            {
                labelStudentName.Text = "-";
            }
            if (student.PersonalNumber != null)
            {
                labelPersonalNumber.Text = student.PersonalNumber;
            }
            else
            {
                labelPersonalNumber.Text = "-";
            }
            if (student.PersonalCardNumber != null)
            {
                labelPersonalCardNumber.Text = student.PersonalCardNumber;
            }
            else
            {
                labelPersonalCardNumber.Text = "-";
            }
            if (student.PersonalNumber != null)
            {
                labelGenderAssist.Text = Classes.StudentDA.GenderAssist(student.PersonalNumber);
            }
            else
            {
                labelGenderAssist.Text = "-";
            }
            if (studentSettlementInfo.SettlementName != null)
            {
                labelHomeTown.Text = studentSettlementInfo.SettlementName;
            }
            else
            {
                labelHomeTown.Text = "-";
            }
            if (studentSettlementInfo.Settlement2.SettlementName != null)
            {
                labelArea.Text = studentSettlementInfo.Settlement2.SettlementName;
            }
            else
            {
                labelArea.Text = "-";
            }
            if (profile.ProfileName != null)
            {
                labelProfileName.Text = profile.ProfileName;
            }
            else
            {
                labelProfileName.Text = "-";
            }
            if (student.EnrollmentYear != null)
            {
                labelStudiedYears.Text = (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(student.EnrollmentYear.ToString())).ToString();
            }
            else
            {
                labelStudiedYears.Text = "-";
            }
            labelGraduationYear.Text = DateTime.Now.Year.ToString();
            if (school.SchoolName != null)
            {
                labelSchoolName.Text = school.SchoolName;
            }
            else
            {
                labelSchoolName.Text = "-";
            }
            if (schoolSettlementInfo.SettlementName != null)
            {
                labelSchoolCityName.Text = schoolSettlementInfo.SettlementName;
            }
            else
            {
                labelSchoolCityName.Text = "-";
            }
            if (schoolSettlementInfo.Settlement1.SettlementName != null)
            {
                labelSchoolManicipality.Text = schoolSettlementInfo.Settlement1.SettlementName;
            }
            else
            {
                labelSchoolManicipality.Text = "-";
            }
            if (schoolSettlementInfo.Settlement2.SettlementName != null)
            {
                labelSchoolArea.Text = schoolSettlementInfo.Settlement2.SettlementName;
            }
            else
            {
                labelSchoolArea.Text = "-";
            }
            var portraitPath = Classes.PictureDA.GetPortraitPath(student.StudentID);
            if (portraitPath != null && portraitPath != "")
            {
                pictureBoxStudentPortrait.Image = Image.FromFile(portraitPath);
                labelPictureNotAvailable.Visible = false;
            }
            else
            {
                pictureBoxStudentPortrait.Image = null;
                labelPictureNotAvailable.Visible = true;
            }
        }
        private void comboBoxStudentsNamesDiplom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            clearDiplomFields();
            ShowDiplomInfo();
        }
        #endregion

        #region//show marks from all school years and calculate diplom marks
        private void buttonShowDiplomReady_Click(object sender, EventArgs e)
        {
            
            dataGridViewDiplom.AutoGenerateColumns = false;
            panelMarksSummary.Visible = true;
            panelMarksSummary.BringToFront();
        }
        private void ShowSchoolYears()
        {
            textBoxCurrentSchoolYear.Text = string.Format("{0}/{1} {2}", DateTime.Now.Year - 1, DateTime.Now.Year, textBoxCurrentSchoolYear.Text);
            textBoxThirdYear.Text = string.Format("{0}/{1} {2}", DateTime.Now.Year - 2, DateTime.Now.Year - 1, textBoxThirdYear.Text);
            textBoxSecondYear.Text = string.Format("{0}/{1} {2}", DateTime.Now.Year - 3, DateTime.Now.Year - 2, textBoxSecondYear.Text);
            textBoxFirstYear.Text = string.Format("{0}/{1} {2}", DateTime.Now.Year - 4, DateTime.Now.Year - 3, textBoxFirstYear.Text);

        }
        #endregion

        private void comboBoxStudentsNamesDiplomMarks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridViewDiplom.DataSource = Classes.DiplomMarksInfo.GetAllMarksForDiplom(long.Parse(comboBoxStudentsNamesDiplomMarks.SelectedValue.ToString()));
        }

        private void comboBoxStudentsNamesDiplomMarks_Click(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNamesDiplomMarks);
            comboBoxStudentsNamesDiplomMarks.Click -= comboBoxStudentsNamesDiplomMarks_Click;
        }

    }
}
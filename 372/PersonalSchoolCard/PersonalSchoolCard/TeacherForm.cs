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
    using System.Drawing.Printing;
    public partial class TeacherForm : Form
    {
        int teacherID;
        string path = null;
        long studentID;
        string schoolYear = Classes.SchoolYearDA.GetCurrentSchoolYear();
        string teacherName;
        string comboBoxSettlementNameInitialText = "Град/Село";

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
            tabControlMarksSummary.Parent = panelParent;
            tabControlMarksSummary.Dock = DockStyle.Fill;
            comboBoxSettlementName.Text = comboBoxSettlementNameInitialText;
            printDocument.DefaultPageSettings.Color = false;
        }
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            teacherName = Classes.TeacherDA.GetTeacher(teacherID).FullName;
            this.Text = teacherName;
            string className = Classes.TeacherDA.GetClassNameByTeacherID(teacherID, schoolYear);
            string classNumber = className.Substring(0, 2);
            string classChar = className.Substring(3, 1);
            labelHi.Text += teacherName + "!";
            labelSchooYear.Text += schoolYear + " година";
            labelSchoolClassName.Text += string.Format("{0} \'{1}\' клас", classNumber, classChar);
            labelProfile.Text += Classes.ProfileDA.GetProfileByTeacher(teacherID);
            panelWelcome.BringToFront();
            labelTeacherName.Text += teacherName;
            labelClassName.Text += string.Format("{0} \'{1}\' клас", classNumber, classChar);
            labelCurrentSchoolYear.Text += schoolYear + " година";
            ShowSchoolYears(textBoxFirstYear, textBoxSecondYear, textBoxThirdYear, textBoxFourthYear);
            ShowSchoolYears(textBoxFirstYearExtraSubject, textBoxSecondYearExtraSubject, textBoxThirdYearExtraSubject, textBoxFourthYearExtraSubject);
        }
        private void TeacherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

            var studentInfoToBeSaved = new Student();
            if (textBoxFirstName.Text != null && textBoxFirstName.Text != "")
            {
                studentInfoToBeSaved.FirstName = textBoxFirstName.Text;
            }
            if (textBoxSecondName.Text != null && textBoxSecondName.Text != "")
            {
                studentInfoToBeSaved.SecondName = textBoxSecondName.Text;
            }
            if (textBoxLastName.Text != null && textBoxLastName.Text != "")
            {
                studentInfoToBeSaved.LastName = textBoxLastName.Text;
            }
            if (textBoxPersonalNumber.Text != null && textBoxPersonalNumber.Text != "")
            {
                studentInfoToBeSaved.PersonalNumber = textBoxPersonalNumber.Text;
            }
            if (textBoxPersonalCardNumber.Text != null && textBoxPersonalCardNumber.Text != "")
            {
                studentInfoToBeSaved.PersonalCardNumber = textBoxPersonalCardNumber.Text;
            }
            if (textBoxMobilePhone.Text != null && textBoxMobilePhone.Text != "")
            {
                studentInfoToBeSaved.Phone = textBoxMobilePhone.Text;
            }
            if (textBoxAddress.Text != null && textBoxAddress.Text != "")
            {
                studentInfoToBeSaved.Address = textBoxAddress.Text;
            }
            if (textBoxEnrollmentYear.Text != null && textBoxEnrollmentYear.Text != "")
            {
                studentInfoToBeSaved.EnrollmentYear = int.Parse(textBoxEnrollmentYear.Text);
            }
            if (textBoxLastName.Text != null && textBoxLastName.Text != "")
            {
                studentInfoToBeSaved.LastName = textBoxLastName.Text;
            }
            if (comboBoxSettlementName.SelectedValue != null)
            {
                studentInfoToBeSaved.SettlementID = int.Parse(comboBoxSettlementName.SelectedValue.ToString());
            }
            if (textBoxDateOfBirth.Text != null && textBoxDateOfBirth.Text != "")
            {
                studentInfoToBeSaved.DateOfBirth = Convert.ToDateTime(textBoxDateOfBirth.Text);
            }

            Classes.StudentDA.UpdateStudentInfo(studentID, studentInfoToBeSaved);
            Classes.PictureDA.SetPortraitPath(studentID, path);
        }
        private void comboBoxSettlementName_Click(object sender, EventArgs e)
        {
            comboBoxSettlementName.DataSource = Classes.SettlementDA.GetVillages();
            comboBoxSettlementName.Click -= comboBoxSettlementName_Click;
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
            checkedListBoxSubjects.ValueMember = "SubjectName";
            tabControlMarks.Visible = true;
            tabControlMarks.BringToFront();
        }
        private void dataGridViewMarksFirstTerm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MarksWithWords(dataGridViewMarksFirstTerm);
        }
        private void buttonSaveMarksFirstTerm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewMarksFirstTerm.Rows.Count != 0)
                {
                    Classes.MarkDA.SaveMark(dataGridViewMarksFirstTerm, teacherID, long.Parse(comboBoxStudentsNames.SelectedValue.ToString()), 1);
                    ChangesMadeSuccessfully(labelSuccessFirstTerm, timerSuccessSaveMarks);
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
            ChangesMadeSuccessfully(labelSuccessSecondTerm, timerSuccessSaveMarks);
        }
        private void dataGridViewMarksSecondTerm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MarksWithWords(dataGridViewMarksSecondTerm);
        }
        private void buttonSaveMarksYear_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewMarksYear, teacherID, long.Parse(comboBoxStudentsNames.SelectedValue.ToString()), 3);
            ChangesMadeSuccessfully(labelSuccessSaveMarks, timerSuccessSaveMarks);
        }
        private void dataGridViewMarksYear_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MarksWithWords(dataGridViewMarksYear);
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
            var selectedSubjectName = checkedListBoxSubjects.SelectedValue.ToString();
            ParseSubjectsToDataGridView(dataGridViewMarksFirstTerm, e, selectedSubjectName);
            ParseSubjectsToDataGridView(dataGridViewMarksSecondTerm, e, selectedSubjectName);
            ParseSubjectsToDataGridView(dataGridViewMarksYear, e, selectedSubjectName);

        }
        private void timerSuccess_Tick(object sender, EventArgs e)
        {
            labelSuccessSaveMarks.Visible = false;
            labelSuccessSecondTerm.Visible = false;
            labelSuccessFirstTerm.Visible = false;
            timerSuccessSaveMarks.Stop();
        }
        #endregion

        #region//adding extra subjects marks(СИП)
        private void checkedListBoxExtraSubjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var selectedSubjectName = checkedListBoxExtraSubjects.SelectedValue.ToString();
            ParseSubjectsToDataGridView(dataGridViewExtraSubjectsFirstTerm, e, selectedSubjectName);
            ParseSubjectsToDataGridView(dataGridViewExtraSubjectsSecondTerm, e, selectedSubjectName);
            ParseSubjectsToDataGridView(dataGridViewExtraSubjectsYear, e, selectedSubjectName);
        }
        private void buttonSaveMarksExtraSubjectsFirstTerm_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewExtraSubjectsFirstTerm, teacherID, long.Parse(comboBoxStudentsNamesExtraSubjects.SelectedValue.ToString()), 1, true);
            ChangesMadeSuccessfully(labelSaveSuccessExtraSubjectsMarksFirstTerm, timerSaveSuccessExtraSubjects);
        }
        private void buttonSaveMarksExtraSubjectsSecondTerm_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewExtraSubjectsFirstTerm, teacherID, long.Parse(comboBoxStudentsNamesExtraSubjects.SelectedValue.ToString()), 2, true);
            ChangesMadeSuccessfully(labelSaveSuccessExtraSubjectsMarksSecondTerm, timerSaveSuccessExtraSubjects);
        }
        private void buttonSaveMarksExtraSubjectsYear_Click(object sender, EventArgs e)
        {
            Classes.MarkDA.SaveMark(dataGridViewExtraSubjectsFirstTerm, teacherID, long.Parse(comboBoxStudentsNamesExtraSubjects.SelectedValue.ToString()), 3, true);
            ChangesMadeSuccessfully(labelSaveSuccessExtraSubjectsMarksYear, timerSaveSuccessExtraSubjects);
        }
        private void buttonAddMarksExtraSubjects_Click(object sender, EventArgs e)
        {
            checkedListBoxExtraSubjects.DataSource = Classes.SubjectDA.GetAllSubjects();
            checkedListBoxExtraSubjects.DisplayMember = "SubjectName";
            checkedListBoxExtraSubjects.ValueMember = "SubjectName";
            tabControlMarksExtraSubjects.Visible = true;
            tabControlMarksExtraSubjects.BringToFront();
        }
        private void dataGridViewExtraSubjectsFirstTerm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MarksWithWords(dataGridViewExtraSubjectsFirstTerm);
        }
        private void dataGridViewExtraSubjectsSecondTerm_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MarksWithWords(dataGridViewExtraSubjectsSecondTerm);
        }
        private void dataGridViewExtraSubjectsYear_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MarksWithWords(dataGridViewExtraSubjectsYear);
        }
        private void comboBoxStudentsNamesExtraSubjects_MouseEnter(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNamesExtraSubjects);
            comboBoxStudentsNamesExtraSubjects.MouseEnter -= comboBoxStudentsNamesExtraSubjects_MouseEnter;
        }
        private void timerSaveSuccessExtraSubjects_Tick(object sender, EventArgs e)
        {
            labelSaveSuccessExtraSubjectsMarksYear.Visible = false;
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
        private void comboBoxStudentsNamesAbsences_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridViewAbsences.Rows[0].Cells[1].Value = "";
            dataGridViewAbsences.Rows[0].Cells[2].Value = "";
            dataGridViewAbsences.Rows[1].Cells[1].Value = "";
            dataGridViewAbsences.Rows[1].Cells[2].Value = "";
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
        private void MarksWithWords(DataGridView gridView)
        {
            for (int i = 0; i < gridView.Rows.Count; i++)
                for (int k = 0; k < gridView.Columns.Count; k++)
                {
                    double n;
                    if (gridView.Rows[i].Cells[k].Value != null)
                    {
                        bool isMark = double.TryParse(gridView.Rows[i].Cells[k].Value.ToString(), out n);
                        if (isMark)
                        {
                            string mark = string.Format("{0:00}", gridView.Rows[i].Cells[k].Value.ToString());
                            gridView.Rows[i].Cells[k - 1].Value = Classes.MarkDA.GetMarkWithWords(mark);
                        }
                    }
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

        private void ShowSchoolYears(TextBox firstYear, TextBox secondYear, TextBox thirdYear, TextBox fourthYear)
        {
            firstYear.Text = string.Format("{0}/{1} {2}", DateTime.Now.Year - 4, DateTime.Now.Year - 3, firstYear.Text);
            secondYear.Text = string.Format("{0}/{1} {2}", DateTime.Now.Year - 3, DateTime.Now.Year - 2, secondYear.Text);
            thirdYear.Text = string.Format("{0}/{1} {2}", DateTime.Now.Year - 2, DateTime.Now.Year - 1, thirdYear.Text);
            fourthYear.Text = string.Format("{0}/{1} {2}", DateTime.Now.Year - 1, DateTime.Now.Year, fourthYear.Text);
        }
        private bool WarningMessageBox(string message, string caption = "", bool buttonsNeeded = false)
        {
            DialogResult result;
            if (buttonsNeeded == true)
            {
                var buttons = MessageBoxButtons.OKCancel;
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                result = MessageBox.Show(message, caption);
            }
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ClearLabel(Label label)
        {
            label.Text = "";
        }
        #endregion

        #region//adding marks for the end of 12 grade exams
        private void buttonAddMarksFromExams_Click(object sender, EventArgs e)
        {
            if (Classes.TeacherDA.GetClassNumberByTeacherID(teacherID) != 12)
            {
                labelExamWarning.Visible = true;
                buttonSaveExamMarks.Enabled = false;
            }
            panelMarksExam.Visible = true;
            panelMarksExam.BringToFront();
        }
        private void comboBoxStudentsNamesExam_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBoxFirstExamMark.Text = "";
            textBoxSecondExamMark.Text = "";
            textBoxThirdExamMark.Text = "";
            comboBoxSecondExam.Items.Insert(0, "Изберете предмет");
            comboBoxSecondExam.SelectedIndex = 0;
            comboBoxThirdExam.Items.Insert(0, "Изберете предмет");
            comboBoxThirdExam.SelectedIndex = 0;
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
            if (studentSettlementInfo.Settlement1.SettlementName != null)
            {
                labelManicipality.Text = studentSettlementInfo.Settlement1.SettlementName;
            }
            else
            {
                labelManicipality.Text = "-";
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
            if (student.MarkFromDiplom != null)
            {
                labelDiplomMark.Text = string.Format("{0:0.00}", double.Parse(student.MarkFromDiplom.ToString()));
                labelDiplomMarkWithWords.Text = Classes.MarkDA.GetMarkWithWords(labelDiplomMark.Text);
            }
            else
            {
                labelDiplomMark.Text = "-";
                labelDiplomMarkWithWords.Text = "-";
            }
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
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("Снимката не е намерена на този адрес " + ex.Message);
            }

        }
        private void comboBoxStudentsNamesDiplom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var foreignLanguagesLabels = new List<Label>();
            foreignLanguagesLabels.Add(labelFirstForeignLanguage);
            foreignLanguagesLabels.Add(labelSecondForeignLanguage);
            foreignLanguagesLabels.Add(labelThirdForeignLanguage);
            var foreignLanguages = Classes.SubjectDA.GetForeignLanguage(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()));
            for (int i = 0; i < foreignLanguages.Count; i++)
            {
                foreignLanguagesLabels[i].Text = foreignLanguages[i].SubjectName;
            }
            clearDiplomFields();
            ShowDiplomInfo();
            ShowDiplomMarks();
            tabPageInfo.Focus();
        }
        private void ShowDiplomMarks()
        {
            labelBulgarianLanguageMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelBulgarianLanguage.Text, "ЗП");
            labelBulgarianLanguageMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelBulgarianLanguageMark.Text);
            if (labelFirstForeignLanguage.Text != "-")
            {
                labelFirstForeignLanguageMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelFirstForeignLanguage.Text, "ЗП");
                labelFirstForeignLanguageMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelFirstForeignLanguageMark.Text);
            }
            if (labelSecondForeignLanguage.Text != "-")
            {
                labelSecondForeignLanguageMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelSecondForeignLanguage.Text, "ЗП");
                labelSecondForeignLanguageMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelSecondForeignLanguageMark.Text);
            }
            if (labelThirdForeignLanguage.Text != "-")
            {
                labelThirdForeignLanguageMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelThirdForeignLanguage.Text, "ЗП");
                labelThirdForeignLanguageMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelThirdForeignLanguageMark.Text);
            }
            labelMathsMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelMaths.Text, "ЗП");
            labelMathsMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelMathsMark.Text);
            labelInformaticsMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelInformatics.Text, "ЗП");
            labelInformaticsMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelInformaticsMark.Text);
            labelInformationTechMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelInformationTech.Text, "ЗП");
            labelInformationTechMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelInformationTechMark.Text);
            labelHistoryMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelHistory.Text, "ЗП");
            labelHistoryMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelHistoryMark.Text);
            labelGeographyMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelGeography.Text, "ЗП");
            labelGeographyMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelGeographyMark.Text);
            labelPsychologyAndLogicMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelPsychologyAndLogic.Text, "ЗП");
            labelPsychologyAndLogicMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelPsychologyAndLogicMark.Text);
            labelEticsAndRightMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelEticsAndRight.Text, "ЗП");
            labelEticsAndRightMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelEticsAndRightMark.Text);
            labelPhilosophyMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelPhilosophy.Text, "ЗП");
            labelPhilosophyMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelPhilosophyMark.Text);
            labelWPSubjectMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelWPSubject.Text, "ЗП");
            labelWPSubjectMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelWPSubjectMark.Text);
            labelBiologyMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelBiology.Text, "ЗП");
            labelBiologyMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelBiologyMark.Text);
            labelPhysicsMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelPhysics.Text, "ЗП");
            labelPhysicsMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelPhysicsMark.Text);
            labelChemistryMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelChemistry.Text, "ЗП");
            labelChemistryMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelChemistryMark.Text);
            labelMusicMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelMusic.Text, "ЗП");
            labelMusicMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelMusicMark.Text);
            labelArtMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelArt.Text, "ЗП");
            labelArtMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelArtMark.Text);
            labelSportsMark.Text = Classes.DiplomsDA.GetMarkOnSubject(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), labelSports.Text, "ЗП");
            labelSportsMarkWords.Text = Classes.MarkDA.GetMarkWithWords(labelSportsMark.Text);
            //extra subjects(СИП)
            ClearLabel(labelFirstExtraSubject);
            ClearLabel(labelSecondExtraSubject);
            ClearLabel(labelThirdExtraSubject);
            ClearLabel(labelFourthExtraSubject);
            ClearLabel(labelFourthExtraSubject);
            ClearLabel(labelFirstExtraSubjectMark);
            ClearLabel(labelSecondExtraSubjectMark);
            ClearLabel(labelThirdExtraSubjectMark);
            ClearLabel(labelFourthExtraSubjectMark);
            ClearLabel(labelFifthExtraSubjectMark);
            ClearLabel(labelSecondExtraSubjectMarkWords);
            ClearLabel(labelThirdExtraSubjectMarkWords);
            ClearLabel(labelFourthExtraSubjectMarkWords);
            ClearLabel(labelFifthExtraSubjectMarkWords);
            var studiedExtraSubjects = Classes.DiplomsDA.GetAllDiplomMarks(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), "СИП");
            var studiedExtraSubjectsNamesLabels = new List<Label> { labelFirstExtraSubject, labelSecondExtraSubject, labelThirdExtraSubject, labelFourthExtraSubject, labelFourthExtraSubject };
            var studiedExtraSubjectsMarks = new List<Label> { labelFirstExtraSubjectMark, labelSecondExtraSubjectMark, labelThirdExtraSubjectMark, labelFourthExtraSubjectMark, labelFifthExtraSubjectMark };
            var studeiedExtraSubjectsMarksWords = new List<Label> { labelFirstExtraSubjectMarkWords, labelSecondExtraSubjectMarkWords, labelThirdExtraSubjectMarkWords, labelFourthExtraSubjectMarkWords, labelFifthExtraSubjectMarkWords };
            for (int i = 0; i < studiedExtraSubjects.Count; i++)
            {

                studiedExtraSubjectsNamesLabels[i].Text = Classes.SubjectDA.GetSubjectName(studiedExtraSubjects[i].SubjectID);
                studiedExtraSubjectsMarks[i].Text = studiedExtraSubjects[i].Mark.ToString("f2");
                studeiedExtraSubjectsMarksWords[i].Text = Classes.MarkDA.GetMarkWithWords(studiedExtraSubjectsMarks[i].Text);
            }
            //professional subjects
            ClearLabel(labelFirstChosenSubject);
            ClearLabel(labelSecondChosenSubject);
            ClearLabel(labelThirdChosenSubject);
            ClearLabel(labelFirstChosenSubjectMark);
            ClearLabel(labelSecondChosenSubjectMark);
            ClearLabel(labelThirdChosenSubjectMark);
            ClearLabel(labelFirstChosenSubjectMarkWords);
            ClearLabel(labelSecondChosenSubjectMarkWords);
            ClearLabel(labelThirdChosenSubjectMarkWords);
            var professionalSubjects = Classes.DiplomsDA.GetAllDiplomMarks(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), "ЗПП");
            var professionalSubjectsNames = new List<Label> { labelFirstChosenSubject, labelSecondChosenSubject, labelThirdChosenSubject };
            var professionalSubjectsMarks = new List<Label> { labelFirstChosenSubjectMark, labelSecondChosenSubjectMark, labelThirdChosenSubjectMark };
            var professionalSubjectsMarksWords = new List<Label> { labelFirstChosenSubjectMarkWords, labelSecondChosenSubjectMarkWords, labelThirdChosenSubjectMarkWords };
            for (int i = 0; i < professionalSubjects.Count; i++)
            {
                professionalSubjectsNames[i].Text = Classes.SubjectDA.GetSubjectName(professionalSubjects[i].SubjectID);
                professionalSubjectsMarks[i].Text = professionalSubjects[i].Mark.ToString("f2");
                professionalSubjectsMarksWords[i].Text = Classes.MarkDA.GetMarkWithWords(professionalSubjectsMarks[i].Text);
            }
            //exam subjects and marks
            ClearLabel(labelFirstExam);
            ClearLabel(labelFirstExamMark);
            ClearLabel(labelFirstExamMarkWords);
            ClearLabel(labelSecondExam);
            ClearLabel(labelSecondExamMark);
            ClearLabel(labelSecondExamMarkWords);
            ClearLabel(labelThirdExam);
            ClearLabel(labelThirdExamMark);
            ClearLabel(labelThirdExamMarkWords);
            var examSubjects = Classes.DiplomsDA.GetAllDiplomMarks(long.Parse(comboBoxStudentsNamesDiplom.SelectedValue.ToString()), "ДЗИ");
            var examSubjectsNames = new List<Label> { labelFirstExam, labelSecondExam, labelThirdExam };
            var examSubjectsMarks = new List<Label> { labelFirstExamMark, labelSecondExamMark, labelThirdExamMark };
            var examSubjectsMarksWords = new List<Label> { labelFirstExamMarkWords, labelSecondExamMarkWords, labelThirdExamMarkWords };
            for (int i = 0; i < examSubjects.Count; i++)
            {
                examSubjectsNames[i].Text = Classes.SubjectDA.GetSubjectName(examSubjects[i].SubjectID);
                examSubjectsMarks[i].Text = examSubjects[i].Mark.ToString("f2");
                examSubjectsMarksWords[i].Text = Classes.MarkDA.GetMarkWithWords(examSubjectsMarks[i].Text);
            }
        }
        #endregion

        #region//show marks from all school years and calculate diplom marks
        private void buttonShowDiplomReady_Click(object sender, EventArgs e)
        {
            dataGridViewDiplom.AutoGenerateColumns = false;
            dataGridViewDiplomExtraSubjects.AutoGenerateColumns = false;
            tabControlMarksSummary.Visible = true;
            tabControlMarksSummary.BringToFront();
        }
        private void buttonSaveMaksFinalExtraSubjects_Click(object sender, EventArgs e)
        {
            Classes.DiplomsDA.SaveMarkFinal(dataGridViewDiplomExtraSubjects, long.Parse(comboBoxStudentsNamesExtraSubjectsMarks.SelectedValue.ToString()), "СИП", teacherID);
            textBoxAverageExtraSubjects.Clear();
            textBoxAverageExtraSubjects.Text = Classes.DiplomsDA.CalculateAverageMark(long.Parse(comboBoxStudentsNamesExtraSubjectsMarks.SelectedValue.ToString()), "СИП").ToString();
        }
        private void buttonSaveDiplomMarks_Click(object sender, EventArgs e)
        {
            textBoxAverageMandatorySubjects.Clear();
            textBoxAverageChosenSubjects.Clear();
            textBoxAverageExams.Clear();

            var isAcceped = WarningMessageBox("Ще запишете окончателните оценки по предметите за дипломата както и общия успех на ученика за дипломата. \nПриемате ли?", "Внимание", true);
            if (isAcceped == true)
            {
                Classes.DiplomsDA.SaveMarkFinal(dataGridViewDiplom, long.Parse(comboBoxStudentsNamesDiplomMarks.SelectedValue.ToString()), "ЗП", teacherID);
                Classes.DiplomsDA.SaveMarkFinal(dataGridViewDiplom, long.Parse(comboBoxStudentsNamesDiplomMarks.SelectedValue.ToString()), "ЗИП", teacherID);
                textBoxAverageMandatorySubjects.Text = Classes.DiplomsDA.CalculateAverageMark(long.Parse(comboBoxStudentsNamesDiplomMarks.SelectedValue.ToString()), "ЗП").ToString();
                textBoxAverageChosenSubjects.Text = Classes.DiplomsDA.CalculateAverageMark(long.Parse(comboBoxStudentsNamesDiplomMarks.SelectedValue.ToString()), "ЗИП").ToString();
                textBoxAverageExams.Text = Classes.DiplomsDA.CalculateAverageMark(long.Parse(comboBoxStudentsNamesDiplomMarks.SelectedValue.ToString()), "ДЗИ").ToString("f2");
                Classes.StudentDA.SaveMarkForDiplom(long.Parse(comboBoxStudentsNamesDiplomMarks.SelectedValue.ToString()));
            }
            ChangesMadeSuccessfully(labelDiplomMarksSaveSuccessful, timerDiplomMarksSaved);
        }
        private void comboBoxStudentsNamesDiplomMarks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            panelMarksMandatoryAndChosenSubjectsSummary.Focus();
            dataGridViewDiplom.DataSource = Classes.DiplomMarksInfo.GetAllMarksForDiplomRegularSubjects(long.Parse(comboBoxStudentsNamesDiplomMarks.SelectedValue.ToString()));
            MarksWithWords(dataGridViewDiplom);
        }
        private void comboBoxStudentsNamesExtraSubjectsMarks_Click(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNamesExtraSubjectsMarks);
            comboBoxStudentsNamesExtraSubjectsMarks.Click -= comboBoxStudentsNamesExtraSubjectsMarks_Click;
        }
        private void comboBoxStudentsNamesExtraSubjectsMarks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            panelMarksExtraSubjectsSummary.Focus();
            dataGridViewDiplomExtraSubjects.DataSource = Classes.DiplomMarksInfo.GetAllMarksExtraSubjects(long.Parse(comboBoxStudentsNamesExtraSubjectsMarks.SelectedValue.ToString()));
            MarksWithWords(dataGridViewDiplomExtraSubjects);
        }
        private void comboBoxStudentsNamesDiplomMarks_Click(object sender, EventArgs e)
        {
            ParseStudentsToComboBox(comboBoxStudentsNamesDiplomMarks);
            comboBoxStudentsNamesDiplomMarks.Click -= comboBoxStudentsNamesDiplomMarks_Click;
        }
        private void timerDiplomMarksSaved_Tick(object sender, EventArgs e)
        {
            labelDiplomMarksSaveSuccessful.Visible = false;
            timerDiplomMarksSaved.Stop();
        }
        #endregion

        #region //Print
        //печат на формата като графичен файл
        Bitmap memoryImage;
        public void GetPrintArea(TabPage tbcontrl)
        {
            memoryImage = new Bitmap(tbcontrl.Width, tbcontrl.Height);
            tbcontrl.DrawToBitmap(memoryImage, new Rectangle(0, 0, tbcontrl.Width, tbcontrl.Height));
        }
        public void Print(TabPage tbcontrl)
        {
            //tabControlDiplom = tbcontrl;
            GetPrintArea(tbcontrl);
            printPreviewDialog.Document = printDocument;
        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            tabPageInfo.VerticalScroll.Value = tabPageInfo.VerticalScroll.Maximum;
            for (int i = 0; i < tabControlDiplom.TabPages.Count; i++)
            {
                tabControlDiplom.SelectedIndex = i;
                Print(tabControlDiplom.TabPages[i]);
                printPreviewDialog.ShowDialog();
                //printDocument.Print();
            }
            tabControlDiplom.SelectedIndex = 0;
            //Print(tabPageInfo);
            //Print(tabPageMandatoryMarks);
            //Print(tabPageExtraMarks);

            
        }
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            // e.Graphics.DrawImage(memoryImage, (pagearea.Width / 2) - (this.panelMandatorySubjectsMarks.Width / 2), this.panelMandatorySubjectsMarks.Location.Y);

            e.Graphics.DrawImage(memoryImage, (pagearea.Width / 2) - (tabControlDiplom.Width / 2), tabControlDiplom.Location.Y - 29);
            // - 29 is set so it cuts the combobox for selecting students for better vizualisation
        }
        #endregion


    }
}
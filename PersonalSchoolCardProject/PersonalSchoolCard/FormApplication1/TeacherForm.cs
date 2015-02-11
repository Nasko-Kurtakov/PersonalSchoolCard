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

namespace PersonalShcoolCard
{
    public partial class TeacherForm : Form
    {
        private int teacherID;
        string path=null;
        long studentID;
        Student studentInfoToBeSaved = new Student();
        //string textBoxFirstNameInitialText = "Име";
        //string textBoxSecondNameInitialText = "Презиме";
        //string textBoxLastNameInitialText = "Фамилия";
        //string textBoxEnrollmentYearInitialText = "Година на приемане";
        //string textBoxPersonalNumberInitialText = "ЕГН";
        //string textBoxPersonalCardNumberInitialText = "Попълнете номер на лична карта";
        //string textBoxDateOfBirthInitialText = "ДД/ММ/ГГГГ";
        //string textBoxMobilePhoneInitialText = "Попълнете телефон";
        //string textBoxAddressInitialText = "Попълнете подробен адрес";
        string comboBoxSettlementNameInitialText = "Град/Село";
        public TeacherForm(int teacherID)
        {
            InitializeComponent();

            this.teacherID = teacherID;
            panelEditStudentsInfo.Parent = panelParent;
            panelEditStudentsInfo.Dock = DockStyle.Fill;
            panelWelcome.Parent = panelParent;
            panelWelcome.Dock = DockStyle.Fill;

            //textBoxFirstName.Text = textBoxFirstNameInitialText;
            //textBoxSecondName.Text = textBoxSecondNameInitialText;
            //textBoxLastName.Text = textBoxLastNameInitialText;
            //textBoxEnrollmentYear.Text = textBoxEnrollmentYearInitialText;
            //textBoxPersonalNumber.Text = textBoxPersonalNumberInitialText;
            //textBoxPersonalCardNumber.Text = textBoxPersonalCardNumberInitialText;
            //textBoxDateOfBirth.Text = textBoxDateOfBirthInitialText;
            //textBoxMobilePhone.Text = textBoxMobilePhoneInitialText;
            //textBoxAddress.Text = textBoxAddressInitialText;

            comboBoxSettlementName.Text = comboBoxSettlementNameInitialText;

        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            labelHi.Text += Classes.TeacherFormClasses.OnLogin.GetTeacherName(teacherID) + ".";
            panelWelcome.BringToFront();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TeacherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonEditStudentsInfo_Click(object sender, EventArgs e)
        {
            dataGridViewStudents.AutoGenerateColumns = false;
            dataGridViewStudents.DataSource = Classes.StudentDA.GetStudentByTeacher(teacherID);
            panelEditStudentsInfo.Visible = true;
            panelEditStudentsInfo.BringToFront();
        }

        private void TeacherForm_Resize(object sender, EventArgs e)
        {
            panelEditStudentsInfo.Dock = DockStyle.Fill;
            panelEditStudentsInfo.Refresh();
        }

        private void dataGridViewStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string studentFirstName = dataGridViewStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
            string studentSecondName = dataGridViewStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
            string studentLastName = dataGridViewStudents.Rows[e.RowIndex].Cells[2].Value.ToString();

            studentID = Classes.StudentDA.GetStudentID(teacherID, studentFirstName, studentSecondName, studentLastName);
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
            if (portraitPath != null && portraitPath!="")
            {
                pictureBoxPortrait.Image = Image.FromFile(portraitPath);
                labelPictureNotSelected.Visible = false;
            }
            else
            {
                pictureBoxPortrait.Image = null;
                labelPictureNotSelected.Visible = true;
            }
            buttonSaveChanges.Enabled = true;

        }

        private void buttonLoadPortrait_Click(object sender, EventArgs e)
        {
            if (openFileDialogLoadPortrait.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialogLoadPortrait.FileName;
            }
            pictureBoxPortrait.Image = Image.FromFile(path);
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

        

        //private void textBoxFirstName_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (textBoxFirstName.TextLength <= 50 && textBoxFirstName.Text != textBoxFirstNameInitialText)
        //        {
        //            studentInfoToBeSaved.FirstName = textBoxFirstName.Text;
        //        }
        //        else if (textBoxFirstName.TextLength > 50)
        //        {
        //            throw new Exception("Грешно име.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void textBoxSecondName_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (textBoxSecondName.TextLength <= 50 && textBoxSecondName.Text != textBoxSecondNameInitialText)
        //        {
        //            studentInfoToBeSaved.SecondName = textBoxSecondName.Text;
        //        }
        //        else if (textBoxSecondName.TextLength > 50)
        //        {
        //            throw new Exception("Грешно презиме.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void textBoxLastName_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (textBoxLastName.TextLength <= 50 && textBoxLastName.Text != textBoxLastNameInitialText)
        //        {
        //            studentInfoToBeSaved.LastName = textBoxLastName.Text;
        //        }
        //        else if (textBoxLastName.TextLength > 50)
        //        {
        //            throw new Exception("Грешна фамилия.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void textBoxPersonalNumber_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBoxPersonalNumber.TextLength <= 10 && textBoxPersonalNumber.Text != textBoxPersonalNumberInitialText)
            //    {
            //        studentInfoToBeSaved.PersonalNumber = textBoxPersonalNumber.Text;
            //    }
            //    else if (textBoxPersonalNumber.TextLength > 10)
            //    {
            //        throw new Exception("Грешно ЕГН.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void textBoxPersonalCardNumber_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBoxPersonalCardNumber.TextLength <= 10 && textBoxPersonalCardNumber.Text != textBoxPersonalCardNumberInitialText)
            //    {
            //        studentInfoToBeSaved.PersonalCardNumber = textBoxPersonalCardNumber.Text;
            //    }
            //    else if (textBoxPersonalCardNumber.TextLength > 10)
            //    {
            //        throw new Exception("Грешен номер на лична карта.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        //private void textBoxDateOfBirth_Leave(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var dateOfBirth = Convert.ToDateTime(textBoxDateOfBirth.Text);
        //        if (DateTime.TryParse("07/27/2012", out dateOfBirth) && textBoxPersonalCardNumber.Text != textBoxPersonalCardNumberInitialText)
        //        {
        //            studentInfoToBeSaved.DateOfBirth = dateOfBirth;
        //        }
        //        else 
        //        {
        //            throw new Exception("Грешен формат на въведената дата.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void textBoxMobilePhone_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBoxMobilePhone.TextLength <= 20 && textBoxMobilePhone.Text != textBoxPersonalCardNumberInitialText)
            //    {
            //        studentInfoToBeSaved.Phone = textBoxMobilePhone.Text;
            //    }
            //    else if (textBoxMobilePhone.TextLength > 20)
            //    {
            //        throw new Exception("Грешен формат на телефонен номер.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void textBoxEnrollmentYear_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBoxEnrollmentYear.Text != textBoxEnrollmentYearInitialText)
            //    {
            //        studentInfoToBeSaved.EnrollmentYear =int.Parse(textBoxEnrollmentYear.Text);
            //    }
            //    else 
            //    {
            //        throw new Exception("Грешна година на приемане.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (textBoxAddress.TextLength <= 100 && textBoxAddress.Text != textBoxAddressInitialText)
            //    {
            //        studentInfoToBeSaved.Address = textBoxAddress.Text;
            //    }
            //    else if (textBoxAddress.TextLength > 100)
            //    {
            //        throw new Exception("Прекалено дълъг текст за адрес. (Трябва да е под 100 символа)");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void comboBoxSettlementName_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (comboBoxSettlementName.Text != comboBoxSettlementNameInitialText)
            //    {
            //        studentInfoToBeSaved.SettlementID = int.Parse(comboBoxSettlementName.SelectedValue.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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
    }
}

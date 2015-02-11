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
        string path;
        public TeacherForm(int teacherID)
        {
            InitializeComponent();

            this.teacherID = teacherID;
            
            panelEditStudentsInfo.Parent = panelParent;
            panelEditStudentsInfo.Dock = DockStyle.Fill;

            panelShowStudents.Parent = panelParent;
            panelShowStudents.Dock = DockStyle.Fill;

            panelStudentInfo.Parent = panelParent;
            panelStudentInfo.Dock = DockStyle.Fill;
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            labelHi.Text += Classes.TeacherFormClasses.OnLogin.GetTeacherName(teacherID)+ ".";
            panelParent.BringToFront();
            
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
            if(e.RowIndex == -1)
            {
                return;
            }
            string studentFirstName = dataGridViewStudents.Rows[e.RowIndex].Cells[0].Value.ToString();
            string studentSecondName = dataGridViewStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
            string studentLastName = dataGridViewStudents.Rows[e.RowIndex].Cells[2].Value.ToString();

            var studentID = Classes.StudentDA.GetStudentID(teacherID, studentFirstName, studentSecondName, studentLastName);
            var student = Classes.StudentDA.SelectStudent(studentID);
            textBoxFirstName.Text = student.FirstName;
            textBoxSecondName.Text = student.SecondName;
            textBoxLastName.Text = student.LastName;
            if(student.PersonalNumber!=null)
            {
                textBoxPersonalNumber.Text = student.PersonalNumber;
            }
            if(student.PersonalCardNumber!=null)
            {
                textBoxPersonalCardNumber.Text = student.PersonalCardNumber;
            }
            if(student.DateOfBirth!=null)
            {
                textBoxDateOfBirth.Text = student.DateOfBirth.Value.Date.ToShortDateString();
            }
            if(student.Address!=null)
            {
                textBoxAddress.Text = student.Address;
            }
            if(student.Phone!=null)
            {
                textBoxMobilePhone.Text = student.Phone;
            }
            if(student.EnrollmentYear!=null)
            {
                textBoxEnrollmentYear.Text = student.EnrollmentYear.ToString();
            }
            if(student.SettlementID!=null)
            {
                comboBoxSettlementName.DataSource = Classes.SettlementDA.GetVillages();
                comboBoxSettlementName.SelectedValue = student.SettlementID;
            }
            pictureBoxPortrait.Image = Image.FromFile("@" + student.Picture.PicturePath);
        }

        private void buttonLoadPortrait_Click(object sender, EventArgs e)
        {
            if (openFileDialogLoadPortrait.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialogLoadPortrait.FileName;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridViewShowStudents.AutoGenerateColumns = false;
            dataGridViewShowStudents.DataSource = Classes.StudentDA.GetStudentByTeacher(teacherID);

            panelShowStudents.Visible = true;
            panelShowStudents.BringToFront();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelStudentInfo.Visible = true;
            panelStudentInfo.BringToFront();
        }
    }
}

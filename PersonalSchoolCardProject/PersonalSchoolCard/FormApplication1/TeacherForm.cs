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

        public TeacherForm(int teacherID)
        {
            InitializeComponent();

            this.teacherID = teacherID;

            panelEditStudentsInfo.Parent = panelParent;
            panelEditStudentsInfo.Dock = DockStyle.Fill;
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
            dataGridViewStudents.DataSource = Classes.Student.GetStudentByTeacher(teacherID);
            panelEditStudentsInfo.Visible = true;
            panelEditStudentsInfo.BringToFront();
        }

        private void TeacherForm_Resize(object sender, EventArgs e)
        {
            panelEditStudentsInfo.Dock = DockStyle.Fill;
            panelEditStudentsInfo.Refresh();
        }
    }
}

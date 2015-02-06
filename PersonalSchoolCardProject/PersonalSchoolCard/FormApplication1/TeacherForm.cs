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
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            string TeacherName = Classes.Queries.GetTeacherName(teacherID);
            label1.Text = "Здравейте" + " , " + TeacherName;
            panel1Parent.BringToFront();
            panelSlideOne.Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

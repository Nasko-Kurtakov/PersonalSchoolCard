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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelAddSubjects.BringToFront();
            panelAddSubjects.Visible = true;

        }

        private void buttonAddSubjectTypes_Click(object sender, EventArgs e)
        {
            Classes.AddSubjectsPanel.AddSubjectTypes(dataGridViewSubjectTypes);
        }

        private void buttonAddSubjects_Click(object sender, EventArgs e)
        {
            DataGridViewColumn subjectType = new DataGridViewColumn();
            var comboBoxSubjects = new  DataGridViewComboBoxColumn();
        }
    }
}

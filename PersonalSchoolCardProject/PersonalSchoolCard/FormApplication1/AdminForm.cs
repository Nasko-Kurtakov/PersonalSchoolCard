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
            dataGridViewSubjects.Refresh();
            panelAddSubjects.BringToFront();

            panelAddSubjects.Visible = true;
            panelAddTeachers.Visible = false;
        }

        private void buttonOpenAddTeachersPanel_Click(object sender, EventArgs e)
        {






            panelAddSubjects.Visible = false;
            panelAddTeachers.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonalRecord pr = new PersonalRecord();
            pr.Show();
        }
    }
}

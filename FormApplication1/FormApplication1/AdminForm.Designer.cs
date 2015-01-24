namespace PersonalShcoolCard
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonAddSchoolYear = new System.Windows.Forms.Button();
            this.buttonMenageAccounts = new System.Windows.Forms.Button();
            this.buttonTermManagement = new System.Windows.Forms.Button();
            this.buttonAddSettlements = new System.Windows.Forms.Button();
            this.buttonAddAbsencesType = new System.Windows.Forms.Button();
            this.buttonEditSchoolInfo = new System.Windows.Forms.Button();
            this.buttonAddSubjectsAndTypes = new System.Windows.Forms.Button();
            this.buttonCreateProfile = new System.Windows.Forms.Button();
            this.panelAddSubjects = new System.Windows.Forms.Panel();
            this.listBoxAlreadyAddedSubjects = new System.Windows.Forms.ListBox();
            this.listBoxAlreadyAddedSubjectTypes = new System.Windows.Forms.ListBox();
            this.buttonAddSubjects = new System.Windows.Forms.Button();
            this.buttonAddSubjectTypes = new System.Windows.Forms.Button();
            this.dataGridViewSubjects = new System.Windows.Forms.DataGridView();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOfSubject = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewSubjectTypes = new System.Windows.Forms.DataGridView();
            this.SubjectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAddTeachers = new System.Windows.Forms.Panel();
            this.buttonOpenAddTeachersPanel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelAddSubjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjectTypes)).BeginInit();
            this.panelAddTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpenAddTeachersPanel);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddSchoolYear);
            this.splitContainer1.Panel1.Controls.Add(this.buttonMenageAccounts);
            this.splitContainer1.Panel1.Controls.Add(this.buttonTermManagement);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddSettlements);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddAbsencesType);
            this.splitContainer1.Panel1.Controls.Add(this.buttonEditSchoolInfo);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddSubjectsAndTypes);
            this.splitContainer1.Panel1.Controls.Add(this.buttonCreateProfile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelAddSubjects);
            this.splitContainer1.Size = new System.Drawing.Size(759, 494);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonAddSchoolYear
            // 
            this.buttonAddSchoolYear.Location = new System.Drawing.Point(57, 159);
            this.buttonAddSchoolYear.Name = "buttonAddSchoolYear";
            this.buttonAddSchoolYear.Size = new System.Drawing.Size(143, 39);
            this.buttonAddSchoolYear.TabIndex = 7;
            this.buttonAddSchoolYear.Text = "Добавяне на нова учебна година";
            this.buttonAddSchoolYear.UseVisualStyleBackColor = true;
            // 
            // buttonMenageAccounts
            // 
            this.buttonMenageAccounts.Location = new System.Drawing.Point(57, 339);
            this.buttonMenageAccounts.Name = "buttonMenageAccounts";
            this.buttonMenageAccounts.Size = new System.Drawing.Size(143, 39);
            this.buttonMenageAccounts.TabIndex = 6;
            this.buttonMenageAccounts.Text = "Управление на акаунтите";
            this.buttonMenageAccounts.UseVisualStyleBackColor = true;
            // 
            // buttonTermManagement
            // 
            this.buttonTermManagement.Location = new System.Drawing.Point(57, 294);
            this.buttonTermManagement.Name = "buttonTermManagement";
            this.buttonTermManagement.Size = new System.Drawing.Size(143, 39);
            this.buttonTermManagement.TabIndex = 5;
            this.buttonTermManagement.Text = "Управление на сроковете";
            this.buttonTermManagement.UseVisualStyleBackColor = true;
            // 
            // buttonAddSettlements
            // 
            this.buttonAddSettlements.Location = new System.Drawing.Point(57, 249);
            this.buttonAddSettlements.Name = "buttonAddSettlements";
            this.buttonAddSettlements.Size = new System.Drawing.Size(143, 39);
            this.buttonAddSettlements.TabIndex = 4;
            this.buttonAddSettlements.Text = "Добавяне на населени места";
            this.buttonAddSettlements.UseVisualStyleBackColor = true;
            // 
            // buttonAddAbsencesType
            // 
            this.buttonAddAbsencesType.Location = new System.Drawing.Point(57, 204);
            this.buttonAddAbsencesType.Name = "buttonAddAbsencesType";
            this.buttonAddAbsencesType.Size = new System.Drawing.Size(143, 39);
            this.buttonAddAbsencesType.TabIndex = 3;
            this.buttonAddAbsencesType.Text = "Добавяне на тип отсъствия";
            this.buttonAddAbsencesType.UseVisualStyleBackColor = true;
            // 
            // buttonEditSchoolInfo
            // 
            this.buttonEditSchoolInfo.Location = new System.Drawing.Point(57, 434);
            this.buttonEditSchoolInfo.Name = "buttonEditSchoolInfo";
            this.buttonEditSchoolInfo.Size = new System.Drawing.Size(143, 48);
            this.buttonEditSchoolInfo.TabIndex = 2;
            this.buttonEditSchoolInfo.Text = "Редактиране на информацията за училището";
            this.buttonEditSchoolInfo.UseVisualStyleBackColor = true;
            // 
            // buttonAddSubjectsAndTypes
            // 
            this.buttonAddSubjectsAndTypes.Location = new System.Drawing.Point(57, 69);
            this.buttonAddSubjectsAndTypes.Name = "buttonAddSubjectsAndTypes";
            this.buttonAddSubjectsAndTypes.Size = new System.Drawing.Size(143, 39);
            this.buttonAddSubjectsAndTypes.TabIndex = 1;
            this.buttonAddSubjectsAndTypes.Text = "Добавяне на предмети";
            this.buttonAddSubjectsAndTypes.UseVisualStyleBackColor = true;
            this.buttonAddSubjectsAndTypes.Click += new System.EventHandler(this.buttonAddSubjectsAndTypes_Click);
            // 
            // buttonCreateProfile
            // 
            this.buttonCreateProfile.Location = new System.Drawing.Point(57, 24);
            this.buttonCreateProfile.Name = "buttonCreateProfile";
            this.buttonCreateProfile.Size = new System.Drawing.Size(143, 39);
            this.buttonCreateProfile.TabIndex = 0;
            this.buttonCreateProfile.Text = "Създаване на профил";
            this.buttonCreateProfile.UseVisualStyleBackColor = true;
            // 
            // panelAddSubjects
            // 
            this.panelAddSubjects.Controls.Add(this.panelAddTeachers);
            this.panelAddSubjects.Controls.Add(this.listBoxAlreadyAddedSubjects);
            this.panelAddSubjects.Controls.Add(this.listBoxAlreadyAddedSubjectTypes);
            this.panelAddSubjects.Controls.Add(this.buttonAddSubjects);
            this.panelAddSubjects.Controls.Add(this.buttonAddSubjectTypes);
            this.panelAddSubjects.Controls.Add(this.dataGridViewSubjects);
            this.panelAddSubjects.Controls.Add(this.dataGridViewSubjectTypes);
            this.panelAddSubjects.Controls.Add(this.label1);
            this.panelAddSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAddSubjects.Location = new System.Drawing.Point(0, 0);
            this.panelAddSubjects.Name = "panelAddSubjects";
            this.panelAddSubjects.Size = new System.Drawing.Size(502, 494);
            this.panelAddSubjects.TabIndex = 0;
            // 
            // listBoxAlreadyAddedSubjects
            // 
            this.listBoxAlreadyAddedSubjects.FormattingEnabled = true;
            this.listBoxAlreadyAddedSubjects.Location = new System.Drawing.Point(338, 228);
            this.listBoxAlreadyAddedSubjects.Name = "listBoxAlreadyAddedSubjects";
            this.listBoxAlreadyAddedSubjects.Size = new System.Drawing.Size(152, 186);
            this.listBoxAlreadyAddedSubjects.TabIndex = 6;
            // 
            // listBoxAlreadyAddedSubjectTypes
            // 
            this.listBoxAlreadyAddedSubjectTypes.FormattingEnabled = true;
            this.listBoxAlreadyAddedSubjectTypes.Location = new System.Drawing.Point(383, 65);
            this.listBoxAlreadyAddedSubjectTypes.Name = "listBoxAlreadyAddedSubjectTypes";
            this.listBoxAlreadyAddedSubjectTypes.Size = new System.Drawing.Size(68, 95);
            this.listBoxAlreadyAddedSubjectTypes.TabIndex = 5;
            // 
            // buttonAddSubjects
            // 
            this.buttonAddSubjects.Location = new System.Drawing.Point(27, 432);
            this.buttonAddSubjects.Name = "buttonAddSubjects";
            this.buttonAddSubjects.Size = new System.Drawing.Size(183, 29);
            this.buttonAddSubjects.TabIndex = 4;
            this.buttonAddSubjects.Text = "Добави предмети";
            this.buttonAddSubjects.UseVisualStyleBackColor = true;
            this.buttonAddSubjects.Click += new System.EventHandler(this.buttonAddSubjects_Click);
            // 
            // buttonAddSubjectTypes
            // 
            this.buttonAddSubjectTypes.Location = new System.Drawing.Point(27, 179);
            this.buttonAddSubjectTypes.Name = "buttonAddSubjectTypes";
            this.buttonAddSubjectTypes.Size = new System.Drawing.Size(183, 29);
            this.buttonAddSubjectTypes.TabIndex = 3;
            this.buttonAddSubjectTypes.Text = "Добави видове предмети";
            this.buttonAddSubjectTypes.UseVisualStyleBackColor = true;
            this.buttonAddSubjectTypes.Click += new System.EventHandler(this.buttonAddSubjectTypes_Click);
            // 
            // dataGridViewSubjects
            // 
            this.dataGridViewSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectName,
            this.TypeOfSubject});
            this.dataGridViewSubjects.Location = new System.Drawing.Point(27, 228);
            this.dataGridViewSubjects.Name = "dataGridViewSubjects";
            this.dataGridViewSubjects.Size = new System.Drawing.Size(291, 182);
            this.dataGridViewSubjects.TabIndex = 2;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectName.HeaderText = "Име на предмета";
            this.SubjectName.Name = "SubjectName";
            // 
            // TypeOfSubject
            // 
            this.TypeOfSubject.HeaderText = "Вид предмет";
            this.TypeOfSubject.Name = "TypeOfSubject";
            this.TypeOfSubject.Visible = false;
            this.TypeOfSubject.Width = 75;
            // 
            // dataGridViewSubjectTypes
            // 
            this.dataGridViewSubjectTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubjectTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectType});
            this.dataGridViewSubjectTypes.Location = new System.Drawing.Point(30, 67);
            this.dataGridViewSubjectTypes.Name = "dataGridViewSubjectTypes";
            this.dataGridViewSubjectTypes.Size = new System.Drawing.Size(288, 93);
            this.dataGridViewSubjectTypes.TabIndex = 1;
            // 
            // SubjectType
            // 
            this.SubjectType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectType.HeaderText = "Видове предмети";
            this.SubjectType.Name = "SubjectType";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавяне на предмети";
            // 
            // panelAddTeachers
            // 
            this.panelAddTeachers.Controls.Add(this.dataGridView1);
            this.panelAddTeachers.Controls.Add(this.listBox1);
            this.panelAddTeachers.Controls.Add(this.label2);
            this.panelAddTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAddTeachers.Location = new System.Drawing.Point(0, 0);
            this.panelAddTeachers.Name = "panelAddTeachers";
            this.panelAddTeachers.Size = new System.Drawing.Size(502, 494);
            this.panelAddTeachers.TabIndex = 7;
            // 
            // buttonOpenAddTeachersPanel
            // 
            this.buttonOpenAddTeachersPanel.Location = new System.Drawing.Point(57, 114);
            this.buttonOpenAddTeachersPanel.Name = "buttonOpenAddTeachersPanel";
            this.buttonOpenAddTeachersPanel.Size = new System.Drawing.Size(143, 39);
            this.buttonOpenAddTeachersPanel.TabIndex = 8;
            this.buttonOpenAddTeachersPanel.Text = "Добавяне на учители";
            this.buttonOpenAddTeachersPanel.UseVisualStyleBackColor = true;
            this.buttonOpenAddTeachersPanel.Click += new System.EventHandler(this.buttonOpenAddTeachersPanel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName});
            this.dataGridView1.Location = new System.Drawing.Point(73, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(366, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 20F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Добавяне на учители\r\n";
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FirstName.HeaderText = "Име";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastName.HeaderText = "Фамилия";
            this.LastName.Name = "LastName";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(73, 249);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(366, 173);
            this.listBox1.TabIndex = 2;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 494);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelAddSubjects.ResumeLayout(false);
            this.panelAddSubjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjectTypes)).EndInit();
            this.panelAddTeachers.ResumeLayout(false);
            this.panelAddTeachers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonAddSchoolYear;
        private System.Windows.Forms.Button buttonMenageAccounts;
        private System.Windows.Forms.Button buttonTermManagement;
        private System.Windows.Forms.Button buttonAddSettlements;
        private System.Windows.Forms.Button buttonAddAbsencesType;
        private System.Windows.Forms.Button buttonEditSchoolInfo;
        private System.Windows.Forms.Button buttonAddSubjectsAndTypes;
        private System.Windows.Forms.Button buttonCreateProfile;
        private System.Windows.Forms.Panel panelAddSubjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSubjectTypes;
        private System.Windows.Forms.DataGridView dataGridViewSubjects;
        private System.Windows.Forms.Button buttonAddSubjects;
        private System.Windows.Forms.Button buttonAddSubjectTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewComboBoxColumn TypeOfSubject;
        private System.Windows.Forms.ListBox listBoxAlreadyAddedSubjectTypes;
        private System.Windows.Forms.ListBox listBoxAlreadyAddedSubjects;
        private System.Windows.Forms.Button buttonOpenAddTeachersPanel;
        private System.Windows.Forms.Panel panelAddTeachers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.ListBox listBox1;
    }
}
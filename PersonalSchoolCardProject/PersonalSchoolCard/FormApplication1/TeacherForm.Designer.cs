namespace PersonalShcoolCard
{
    partial class TeacherForm
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
            this.buttonEditStudentsInfo = new System.Windows.Forms.Button();
            this.panelParent = new System.Windows.Forms.Panel();
            this.panelEditStudentsInfo = new System.Windows.Forms.Panel();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.StudentFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelParent.SuspendLayout();
            this.panelEditStudentsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel1.Controls.Add(this.buttonEditStudentsInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.panelParent);
            this.splitContainer1.Size = new System.Drawing.Size(893, 533);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonEditStudentsInfo
            // 
            this.buttonEditStudentsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditStudentsInfo.Location = new System.Drawing.Point(40, 23);
            this.buttonEditStudentsInfo.Name = "buttonEditStudentsInfo";
            this.buttonEditStudentsInfo.Size = new System.Drawing.Size(173, 63);
            this.buttonEditStudentsInfo.TabIndex = 2;
            this.buttonEditStudentsInfo.Text = "Редактиране на информация за ученици";
            this.buttonEditStudentsInfo.UseVisualStyleBackColor = true;
            this.buttonEditStudentsInfo.Click += new System.EventHandler(this.buttonEditStudentsInfo_Click);
            // 
            // panelParent
            // 
            this.panelParent.Controls.Add(this.panelEditStudentsInfo);
            this.panelParent.Controls.Add(this.label2);
            this.panelParent.Controls.Add(this.labelHi);
            this.panelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParent.Location = new System.Drawing.Point(0, 0);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(619, 533);
            this.panelParent.TabIndex = 0;
            // 
            // panelEditStudentsInfo
            // 
            this.panelEditStudentsInfo.Controls.Add(this.dataGridViewStudents);
            this.panelEditStudentsInfo.Controls.Add(this.label1);
            this.panelEditStudentsInfo.Location = new System.Drawing.Point(0, 0);
            this.panelEditStudentsInfo.Name = "panelEditStudentsInfo";
            this.panelEditStudentsInfo.Size = new System.Drawing.Size(619, 533);
            this.panelEditStudentsInfo.TabIndex = 6;
            this.panelEditStudentsInfo.Visible = false;
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentFirstName,
            this.SecondName,
            this.LastName});
            this.dataGridViewStudents.Location = new System.Drawing.Point(64, 95);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.Size = new System.Drawing.Size(481, 283);
            this.dataGridViewStudents.TabIndex = 1;
            // 
            // StudentFirstName
            // 
            this.StudentFirstName.DataPropertyName = "FirstName";
            this.StudentFirstName.HeaderText = "Име";
            this.StudentFirstName.Name = "StudentFirstName";
            this.StudentFirstName.Width = 150;
            // 
            // SecondName
            // 
            this.SecondName.DataPropertyName = "SecondName";
            this.SecondName.HeaderText = "Презиме";
            this.SecondName.Name = "SecondName";
            this.SecondName.Width = 150;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Фамилия";
            this.LastName.Name = "LastName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Редактиране на информацията за учениците";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Изберете действие от левия панел!\r\n";
            // 
            // labelHi
            // 
            this.labelHi.AutoSize = true;
            this.labelHi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHi.Location = new System.Drawing.Point(177, 211);
            this.labelHi.Name = "labelHi";
            this.labelHi.Size = new System.Drawing.Size(108, 20);
            this.labelHi.TabIndex = 4;
            this.labelHi.Text = "Здравейте,";
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 533);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeacherForm_FormClosing);
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.Resize += new System.EventHandler(this.TeacherForm_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelParent.ResumeLayout(false);
            this.panelParent.PerformLayout();
            this.panelEditStudentsInfo.ResumeLayout(false);
            this.panelEditStudentsInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelParent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHi;
        private System.Windows.Forms.Button buttonEditStudentsInfo;
        private System.Windows.Forms.Panel panelEditStudentsInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
    }
}
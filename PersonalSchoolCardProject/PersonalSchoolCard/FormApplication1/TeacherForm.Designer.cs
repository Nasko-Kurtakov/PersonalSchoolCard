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
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.panelEditStudentsInfo = new System.Windows.Forms.Panel();
            this.labelPictureNotSelected = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.buttonLoadPortrait = new System.Windows.Forms.Button();
            this.pictureBoxPortrait = new System.Windows.Forms.PictureBox();
            this.comboBoxSettlementName = new System.Windows.Forms.ComboBox();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.StudentFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelHi = new System.Windows.Forms.Label();
            this.openFileDialogLoadPortrait = new System.Windows.Forms.OpenFileDialog();
            this.textBoxPersonalCardNumber = new PersonalShcoolCard.Classes.WaterMark();
            this.textBoxDateOfBirth = new PersonalShcoolCard.Classes.WaterMark();
            this.textBoxMobilePhone = new PersonalShcoolCard.Classes.WaterMark();
            this.textBoxEnrollmentYear = new PersonalShcoolCard.Classes.WaterMark();
            this.textBoxAddress = new PersonalShcoolCard.Classes.WaterMark();
            this.textBoxPersonalNumber = new PersonalShcoolCard.Classes.WaterMark();
            this.textBoxLastName = new PersonalShcoolCard.Classes.WaterMark();
            this.textBoxSecondName = new PersonalShcoolCard.Classes.WaterMark();
            this.textBoxFirstName = new PersonalShcoolCard.Classes.WaterMark();
            this.panelParent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelWelcome.SuspendLayout();
            this.panelEditStudentsInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.panelParent.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1336, 640);
            this.splitContainer1.SplitterDistance = 303;
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
            // panelWelcome
            // 
            this.panelWelcome.Controls.Add(this.panelEditStudentsInfo);
            this.panelWelcome.Controls.Add(this.label2);
            this.panelWelcome.Controls.Add(this.labelHi);
            this.panelWelcome.Location = new System.Drawing.Point(3, 0);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(1029, 340);
            this.panelWelcome.TabIndex = 0;
            // 
            // panelEditStudentsInfo
            // 
            this.panelEditStudentsInfo.Controls.Add(this.textBoxPersonalCardNumber);
            this.panelEditStudentsInfo.Controls.Add(this.textBoxDateOfBirth);
            this.panelEditStudentsInfo.Controls.Add(this.textBoxMobilePhone);
            this.panelEditStudentsInfo.Controls.Add(this.textBoxEnrollmentYear);
            this.panelEditStudentsInfo.Controls.Add(this.textBoxAddress);
            this.panelEditStudentsInfo.Controls.Add(this.textBoxPersonalNumber);
            this.panelEditStudentsInfo.Controls.Add(this.textBoxLastName);
            this.panelEditStudentsInfo.Controls.Add(this.textBoxSecondName);
            this.panelEditStudentsInfo.Controls.Add(this.textBoxFirstName);
            this.panelEditStudentsInfo.Controls.Add(this.labelPictureNotSelected);
            this.panelEditStudentsInfo.Controls.Add(this.label13);
            this.panelEditStudentsInfo.Controls.Add(this.label12);
            this.panelEditStudentsInfo.Controls.Add(this.label11);
            this.panelEditStudentsInfo.Controls.Add(this.label10);
            this.panelEditStudentsInfo.Controls.Add(this.label9);
            this.panelEditStudentsInfo.Controls.Add(this.label8);
            this.panelEditStudentsInfo.Controls.Add(this.label7);
            this.panelEditStudentsInfo.Controls.Add(this.label6);
            this.panelEditStudentsInfo.Controls.Add(this.label5);
            this.panelEditStudentsInfo.Controls.Add(this.label4);
            this.panelEditStudentsInfo.Controls.Add(this.label3);
            this.panelEditStudentsInfo.Controls.Add(this.buttonBack);
            this.panelEditStudentsInfo.Controls.Add(this.buttonSaveChanges);
            this.panelEditStudentsInfo.Controls.Add(this.buttonLoadPortrait);
            this.panelEditStudentsInfo.Controls.Add(this.pictureBoxPortrait);
            this.panelEditStudentsInfo.Controls.Add(this.comboBoxSettlementName);
            this.panelEditStudentsInfo.Controls.Add(this.dataGridViewStudents);
            this.panelEditStudentsInfo.Controls.Add(this.label1);
            this.panelEditStudentsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelEditStudentsInfo.Location = new System.Drawing.Point(3, 3);
            this.panelEditStudentsInfo.Name = "panelEditStudentsInfo";
            this.panelEditStudentsInfo.Size = new System.Drawing.Size(1026, 640);
            this.panelEditStudentsInfo.TabIndex = 6;
            this.panelEditStudentsInfo.Visible = false;
            // 
            // labelPictureNotSelected
            // 
            this.labelPictureNotSelected.AutoSize = true;
            this.labelPictureNotSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPictureNotSelected.Location = new System.Drawing.Point(57, 507);
            this.labelPictureNotSelected.Name = "labelPictureNotSelected";
            this.labelPictureNotSelected.Size = new System.Drawing.Size(158, 17);
            this.labelPictureNotSelected.TabIndex = 27;
            this.labelPictureNotSelected.Text = "Не е намерена снимка";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 387);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 17);
            this.label13.TabIndex = 26;
            this.label13.Text = "Изберете снимка";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(771, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(182, 17);
            this.label12.TabIndex = 25;
            this.label12.Text = "Единен граждански номер";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(771, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "Номер на лична карта";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(771, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Дата на раждане";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(771, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Телефонен номер";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(540, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Местоживеене";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(540, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Адрес";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(537, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Година на приемане";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(540, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(540, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Презиме";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(540, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Име";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(540, 546);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(129, 49);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Enabled = false;
            this.buttonSaveChanges.Location = new System.Drawing.Point(798, 546);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(129, 49);
            this.buttonSaveChanges.TabIndex = 14;
            this.buttonSaveChanges.Text = "Запиши редакцията";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // buttonLoadPortrait
            // 
            this.buttonLoadPortrait.Location = new System.Drawing.Point(290, 491);
            this.buttonLoadPortrait.Name = "buttonLoadPortrait";
            this.buttonLoadPortrait.Size = new System.Drawing.Size(109, 49);
            this.buttonLoadPortrait.TabIndex = 13;
            this.buttonLoadPortrait.Text = "Качи снимка";
            this.buttonLoadPortrait.UseVisualStyleBackColor = true;
            this.buttonLoadPortrait.Click += new System.EventHandler(this.buttonLoadPortrait_Click);
            // 
            // pictureBoxPortrait
            // 
            this.pictureBoxPortrait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPortrait.Location = new System.Drawing.Point(44, 417);
            this.pictureBoxPortrait.Name = "pictureBoxPortrait";
            this.pictureBoxPortrait.Size = new System.Drawing.Size(181, 199);
            this.pictureBoxPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPortrait.TabIndex = 12;
            this.pictureBoxPortrait.TabStop = false;
            // 
            // comboBoxSettlementName
            // 
            this.comboBoxSettlementName.DisplayMember = "SettlementName";
            this.comboBoxSettlementName.FormattingEnabled = true;
            this.comboBoxSettlementName.Location = new System.Drawing.Point(540, 438);
            this.comboBoxSettlementName.Name = "comboBoxSettlementName";
            this.comboBoxSettlementName.Size = new System.Drawing.Size(193, 24);
            this.comboBoxSettlementName.TabIndex = 8;
            this.comboBoxSettlementName.ValueMember = "SettlementID";
            this.comboBoxSettlementName.SelectedValueChanged += new System.EventHandler(this.comboBoxSettlementName_SelectedValueChanged);
            this.comboBoxSettlementName.Click += new System.EventHandler(this.comboBoxSettlementName_Click);
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentFirstName,
            this.SecondName,
            this.LastName});
            this.dataGridViewStudents.Location = new System.Drawing.Point(15, 72);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.Size = new System.Drawing.Size(469, 283);
            this.dataGridViewStudents.TabIndex = 1;
            this.dataGridViewStudents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellDoubleClick);
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
            this.label1.Location = new System.Drawing.Point(228, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Редактиране на информацията за учениците";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Изберете действие от левия панел!\r\n";
            // 
            // labelHi
            // 
            this.labelHi.AutoSize = true;
            this.labelHi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHi.Location = new System.Drawing.Point(408, 225);
            this.labelHi.Name = "labelHi";
            this.labelHi.Size = new System.Drawing.Size(108, 20);
            this.labelHi.TabIndex = 4;
            this.labelHi.Text = "Здравейте,";
            // 
            // openFileDialogLoadPortrait
            // 
            this.openFileDialogLoadPortrait.FileName = "openFileDialog1";
            // 
            // textBoxPersonalCardNumber
            // 
            this.textBoxPersonalCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxPersonalCardNumber.Location = new System.Drawing.Point(775, 152);
            this.textBoxPersonalCardNumber.Multiline = true;
            this.textBoxPersonalCardNumber.Name = "textBoxPersonalCardNumber";
            this.textBoxPersonalCardNumber.Size = new System.Drawing.Size(153, 23);
            this.textBoxPersonalCardNumber.TabIndex = 36;
            this.textBoxPersonalCardNumber.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxPersonalCardNumber.WaterMarkText = "ЛНЧ";
            // 
            // textBoxDateOfBirth
            // 
            this.textBoxDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxDateOfBirth.Location = new System.Drawing.Point(775, 222);
            this.textBoxDateOfBirth.Multiline = true;
            this.textBoxDateOfBirth.Name = "textBoxDateOfBirth";
            this.textBoxDateOfBirth.Size = new System.Drawing.Size(153, 23);
            this.textBoxDateOfBirth.TabIndex = 35;
            this.textBoxDateOfBirth.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxDateOfBirth.WaterMarkText = "ДД/ММ/ГГГГ";
            // 
            // textBoxMobilePhone
            // 
            this.textBoxMobilePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxMobilePhone.Location = new System.Drawing.Point(774, 292);
            this.textBoxMobilePhone.Multiline = true;
            this.textBoxMobilePhone.Name = "textBoxMobilePhone";
            this.textBoxMobilePhone.Size = new System.Drawing.Size(153, 23);
            this.textBoxMobilePhone.TabIndex = 34;
            this.textBoxMobilePhone.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxMobilePhone.WaterMarkText = "Номер";
            // 
            // textBoxEnrollmentYear
            // 
            this.textBoxEnrollmentYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxEnrollmentYear.Location = new System.Drawing.Point(540, 292);
            this.textBoxEnrollmentYear.Multiline = true;
            this.textBoxEnrollmentYear.Name = "textBoxEnrollmentYear";
            this.textBoxEnrollmentYear.Size = new System.Drawing.Size(153, 23);
            this.textBoxEnrollmentYear.TabIndex = 33;
            this.textBoxEnrollmentYear.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxEnrollmentYear.WaterMarkText = "Година на приемане";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxAddress.Location = new System.Drawing.Point(540, 370);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(388, 23);
            this.textBoxAddress.TabIndex = 32;
            this.textBoxAddress.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxAddress.WaterMarkText = "Адрес";
            // 
            // textBoxPersonalNumber
            // 
            this.textBoxPersonalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxPersonalNumber.Location = new System.Drawing.Point(774, 84);
            this.textBoxPersonalNumber.Multiline = true;
            this.textBoxPersonalNumber.Name = "textBoxPersonalNumber";
            this.textBoxPersonalNumber.Size = new System.Drawing.Size(153, 23);
            this.textBoxPersonalNumber.TabIndex = 31;
            this.textBoxPersonalNumber.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxPersonalNumber.WaterMarkText = "ЕГН";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxLastName.Location = new System.Drawing.Point(540, 222);
            this.textBoxLastName.Multiline = true;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(153, 23);
            this.textBoxLastName.TabIndex = 30;
            this.textBoxLastName.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxLastName.WaterMarkText = "Фамилия";
            // 
            // textBoxSecondName
            // 
            this.textBoxSecondName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxSecondName.Location = new System.Drawing.Point(540, 152);
            this.textBoxSecondName.Multiline = true;
            this.textBoxSecondName.Name = "textBoxSecondName";
            this.textBoxSecondName.Size = new System.Drawing.Size(153, 23);
            this.textBoxSecondName.TabIndex = 29;
            this.textBoxSecondName.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxSecondName.WaterMarkText = "Презиме";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxFirstName.Location = new System.Drawing.Point(540, 84);
            this.textBoxFirstName.Multiline = true;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(153, 23);
            this.textBoxFirstName.TabIndex = 28;
            this.textBoxFirstName.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBoxFirstName.WaterMarkText = "Име";
            // 
            // panelParent
            // 
            this.panelParent.Controls.Add(this.panelWelcome);
            this.panelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParent.Location = new System.Drawing.Point(0, 0);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(1029, 640);
            this.panelParent.TabIndex = 6;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 640);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeacherForm_FormClosing);
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.Resize += new System.EventHandler(this.TeacherForm_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelWelcome.ResumeLayout(false);
            this.panelWelcome.PerformLayout();
            this.panelEditStudentsInfo.ResumeLayout(false);
            this.panelEditStudentsInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.panelParent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelHi;
        private System.Windows.Forms.Button buttonEditStudentsInfo;
        private System.Windows.Forms.Panel panelEditStudentsInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.Button buttonLoadPortrait;
        private System.Windows.Forms.PictureBox pictureBoxPortrait;
        private System.Windows.Forms.ComboBox comboBoxSettlementName;
        private System.Windows.Forms.Label labelPictureNotSelected;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadPortrait;
        private Classes.WaterMark textBoxPersonalCardNumber;
        private Classes.WaterMark textBoxDateOfBirth;
        private Classes.WaterMark textBoxMobilePhone;
        private Classes.WaterMark textBoxEnrollmentYear;
        private Classes.WaterMark textBoxAddress;
        private Classes.WaterMark textBoxPersonalNumber;
        private Classes.WaterMark textBoxLastName;
        private Classes.WaterMark textBoxSecondName;
        private Classes.WaterMark textBoxFirstName;
        private System.Windows.Forms.Panel panelParent;
    }
}
namespace _1._3._30
{
    partial class FormCreateDatabase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataStudent = new System.Windows.Forms.DataGridView();
            this.FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kurs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fillRandomButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // dataStudent
            // 
            this.dataStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FIO,
            this.Year,
            this.MedB,
            this.Kurs,
            this.Group});
            this.dataStudent.Location = new System.Drawing.Point(94, 44);
            this.dataStudent.Name = "dataStudent";
            this.dataStudent.RowTemplate.Height = 28;
            this.dataStudent.Size = new System.Drawing.Size(1142, 555);
            this.dataStudent.TabIndex = 0;
            // 
            // FIO
            // 
            this.FIO.HeaderText = "ФИО";
            this.FIO.Name = "FIO";
            // 
            // Year
            // 
            this.Year.HeaderText = "Год рождения";
            this.Year.Name = "Year";
            // 
            // MedB
            // 
            this.MedB.HeaderText = "Средние оценки за семестры";
            this.MedB.Name = "MedB";
            // 
            // Kurs
            // 
            this.Kurs.HeaderText = "Курс";
            this.Kurs.Name = "Kurs";
            // 
            // Group
            // 
            this.Group.HeaderText = "Группа";
            this.Group.Name = "Group";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(1259, 46);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(118, 200);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Создать базу данных";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fillRandomButton
            // 
            this.fillRandomButton.Location = new System.Drawing.Point(1263, 271);
            this.fillRandomButton.Name = "fillRandomButton";
            this.fillRandomButton.Size = new System.Drawing.Size(113, 122);
            this.fillRandomButton.TabIndex = 3;
            this.fillRandomButton.Text = "Заполнить случайно";
            this.fillRandomButton.UseVisualStyleBackColor = true;
            this.fillRandomButton.Click += new System.EventHandler(this.fillRandomButton_Click);
            // 
            // FormCreateDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 669);
            this.Controls.Add(this.fillRandomButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.dataStudent);
            this.Name = "FormCreateDatabase";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormCreateDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataStudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kurs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button fillRandomButton;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLibrary1;
using LogicLibrary1.ForSudent;

namespace _1._3._30
{
    public partial class FormCreateDatabase : Form
    {
        public FormCreateDatabase()
        {
            InitializeComponent();
        }

        private void FormCreateDatabase_Load(object sender, EventArgs e)
        {
            DataGridViewUtils.InitGridForArr(dataStudent, 40, false, true, true, true, false);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            List<Student> students = DataGridViewUtils.GridToStudents(dataStudent);
            ClassFile a = new ClassFile("stud.dat");
            a.SaveStudent(students, "students.dat");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassFile obj = new ClassFile("students.dat");
            List<Student> std = obj.ReadStudent();
            DataGridViewUtils.StudentToGrid(std, dataStudent);
        }

        private void fillRandomButton_Click(object sender, EventArgs e)
        {
            int n = dataStudent.RowCount;
            WorkWithStudents2 obj = new WorkWithStudents2();
            DataGridViewUtils.StudentToGrid(obj.GetRamdom(n), dataStudent);
        }
    }
}

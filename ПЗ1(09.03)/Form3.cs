using System;
using System.Windows.Forms;

namespace ПЗ1_09._03_
{
    public partial class Form3 : Form
    {
        private Student selectedStudent;
        private Student originalStudent;

        public Student Student { get; private set; }

        public Form3()
        {
            InitializeComponent();
            button1.Click += ButtonAddEditStudent_Click;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
        }
        public Form3(Student student) : this()
        {
            originalStudent = student;

            // Populate the text boxes with the original student's data
            textBox1.Text = originalStudent.Surname;
            textBox2.Text = originalStudent.Grade.ToString();
        }

        private void ButtonAddEditStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox2.Text, out int grade))
            {
                ShowErrorMessage("Please enter valid data.");
                return;
            }

            if (originalStudent == null)
            {
                // Adding a new student
                Student = new Student
                {
                    Surname = textBox1.Text,
                    Grade = grade
                };
            }
            else
            {
                // Editing an existing student
                originalStudent.Surname = textBox1.Text;
                originalStudent.Grade = grade;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
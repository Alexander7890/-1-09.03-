using System;
using System.Windows.Forms;

namespace ПЗ1_09._03_
{
    public partial class Form3 : Form
    {
        private void Form3_Load(object sender, EventArgs e)
        {
        }
        public Student Student { get; private set; }

        public Form3()
        {
            InitializeComponent();
            button1.Click += ButtonAddStudent_Click;
        }

        private void ButtonAddStudent_Click(object sender, EventArgs e)
        {
            // Створення нового студента
            Student = new Student
            {
                Surname = textBox1.Text,
                Grade = Convert.ToInt32(textBox2.Text)
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

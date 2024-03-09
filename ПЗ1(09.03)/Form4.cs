using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ПЗ1_09._03_
{
    public partial class Form4 : Form
    {
        private Group groupToEdit;
        private Student studentToEdit;

        public Form4(Group group)
        {
            InitializeComponent();
            groupToEdit = group;
            InitializeGroupControls();
        }

        public Form4(Student student)
        {
            InitializeComponent();
            studentToEdit = student;
            InitializeStudentControls();
        }

        private void InitializeGroupControls()
        {
            // Populate controls with existing group data
            textBox1.Text = groupToEdit.Name;
            textBox2.Text = groupToEdit.Specialty;
        }

        private void InitializeStudentControls()
        {
            // Populate controls with existing student data
            textBox1.Text = studentToEdit.Surname;
            textBox2.Text = studentToEdit.Grade.ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate input before saving changes
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (groupToEdit != null)
                {
                    // Update existing group
                    groupToEdit.Name = textBox1.Text;
                    groupToEdit.Specialty = textBox2.Text;
                }
                else if (studentToEdit != null)
                {
                    // Update existing student
                    studentToEdit.Surname = textBox1.Text;
                    if (int.TryParse(textBox2.Text, out int grade))
                    {
                        studentToEdit.Grade = grade;
                    }
                    else
                    {
                        MessageBox.Show("Invalid grade. Please enter a valid numeric grade.");
                        return;
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a non-empty name.");
            }
        }
    }
}

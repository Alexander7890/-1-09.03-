using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ПЗ1_09._03_
{
    public partial class Form1 : Form
    {
        private List<Group> groups = new List<Group>();

        public Form1()
        {
            InitializeComponent();
            button1.Click += buttonAddGroup_Click;
            button2.Click += buttonAddStudent_Click;
            button3.Click += buttonEditGroup_Click;
            button4.Click += buttonEditStudent_Click;
            button9.Click += Output_of_information_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DisplayGroups()
        {
            listBox1.Items.Clear();
            foreach (var group in groups)
            {
                listBox1.Items.Add($"{group.Name} {group.Specialty} [{group.DisplayStudents()}]");
            }
        }

        private void DisplayStudents(Group group)
        {
            listBox1.Items.Clear();
            foreach (var student in group.Students)
            {
                listBox1.Items.Add($"{student.Surname} ({student.Grade})");
            }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                groups.Add(form2.Group);
                DisplayGroups();
            }
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var selectedGroup = groups[listBox1.SelectedIndex];
                Form3 form3 = new Form3();

                if (form3.ShowDialog() == DialogResult.OK)
                {
                    var student = form3.Student;
                    selectedGroup.AddStudent(student);
                    DisplayGroups();
                }
            }
        }

        private void Output_of_information_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var selectedGroup = groups[listBox1.SelectedIndex];
                UpdateInformationLabel(selectedGroup);
            }
            else
            {
                label1.Text = "Оберіть групу";
                label2.Text = "Немає інформації";
            }
        }

        private void UpdateInformationLabel(Group selectedGroup)
        {
            label1.Text = $"Група: {selectedGroup.Name}, Спеціальність: {selectedGroup.Specialty}";
            StringBuilder studentsInfo = new StringBuilder();
            foreach (var student in selectedGroup.Students)
            {
                studentsInfo.AppendLine($"{student.Surname} ({student.Grade})");
            }
            label2.Text = studentsInfo.ToString();
        }

        private void buttonEditGroup_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var selectedGroup = groups[listBox1.SelectedIndex];
                Form2 form2 = new Form2(selectedGroup);

                if (form2.ShowDialog() == DialogResult.OK)
                {
                    DisplayGroups();
                }
            }
        }

        private void buttonEditStudent_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var selectedGroup = groups[listBox1.SelectedIndex];
                EditStudent(selectedGroup);
            }
        }

        private void EditStudent(Group selectedGroup)
        {
            if (selectedGroup.Students.Count > 0)
            {
                if (int.TryParse(textBox1.Text, out int studentIndex) && studentIndex >= 0 && studentIndex < selectedGroup.Students.Count)
                {
                    var selectedStudent = selectedGroup.Students[studentIndex];
                    Form3 form3 = new Form3(selectedStudent);

                    if (form3.ShowDialog() == DialogResult.OK)
                    {
                        DisplayGroups();
                    }
                }
            }
        }
    }
}
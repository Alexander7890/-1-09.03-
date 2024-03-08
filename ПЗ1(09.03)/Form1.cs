using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ПЗ1_09._03_
{
    public partial class Form1 : Form
    {
        private List<Group> groups = new List<Group>();

        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(buttonAddGroup_Click);
            button2.Click += new EventHandler(buttonAddStudent_Click);
            button3.Click += new EventHandler(button2_1_Click);
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
            // Відображення груп на формі
            listBox1.Items.Clear();
            foreach (var group in groups)
            {
                listBox1.Items.Add($"{group.Name} {group.Specialty} [{group.DisplayStudents()}]");
            }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            // Додавання групи
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                groups.Add(form2.Group);
                DisplayGroups();
            }
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Оновлення інформації при виборі групи
            if (listBox1.SelectedIndex != -1)
            {
                var selectedGroup = groups[listBox1.SelectedIndex];
                label1.Text = $"{selectedGroup.Name} {selectedGroup.Specialty}";
            }
        }

        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            // Додавання студента до вибраної групи
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
        private void button2_1_Click(object sender, EventArgs e)
        {
            // Open Form3 for adding a student
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
    }
}

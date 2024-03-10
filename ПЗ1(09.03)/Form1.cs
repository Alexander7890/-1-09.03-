﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
            button5.Click += buttonMoveStudent_Click;
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
        private void buttonMoveStudent_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                var selectedGroupIndex = listBox1.SelectedIndex;

                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    var studentSurname = textBox2.Text.Trim();

                    // Отримати групу та студента за прізвищем
                    var selectedGroup = groups[selectedGroupIndex];
                    var selectedStudent = selectedGroup.FindStudentBySurname(studentSurname);

                    if (selectedStudent != null)
                    {
                        // Визначити групу для переміщення
                        if (int.TryParse(textBox3.Text, out int newGroupIndex) && newGroupIndex >= 0 && newGroupIndex < groups.Count)
                        {
                            // Переміщення студента зі старої групи в нову
                            var newGroup = groups[newGroupIndex];
                            newGroup.AddStudent(selectedStudent);
                            selectedGroup.RemoveStudent(selectedStudent);

                            // Оновити відображення груп
                            DisplayGroups();
                        }
                        else
                        {
                            MessageBox.Show("Введіть коректний номер нової групи.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Студент з вказаним прізвищем не знайдений.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введіть прізвище студента для переміщення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Виберіть групу, з якої потрібно перемістити студента.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetGroupNameByStudent(Student student)
        {
            // Перший спосіб: Шукати усі групи
            var groupWithStudent = groups.FirstOrDefault(g => g.Students.Contains(student));
            if (groupWithStudent != null)
            {
                return groupWithStudent.Name;
            }

            // Другий спосіб: Шукати в усіх студентах
            var groupWithStudentAlt = groups.FirstOrDefault(g => g.FindStudentBySurname(student.Surname) != null);
            return groupWithStudentAlt != null ? groupWithStudentAlt.Name : "Група не знайдена";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                if (int.TryParse(textBox4.Text, out int grade))
                {
                    List<Student> studentsWithGrade = groups.SelectMany(g => g.FindStudentsByGrade(grade)).ToList();

                    if (studentsWithGrade.Any())
                    {
                        StringBuilder result = new StringBuilder("Студенти з оцінкою " + grade + ":");
                        foreach (var student in studentsWithGrade)
                        {
                            result.AppendLine($"- {student.Surname} у групі {GetGroupNameByStudent(student)}");
                        }
                        MessageBox.Show(result.ToString(), "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Студентів з оцінкою {grade} не знайдено.", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Введіть коректну оцінку для пошуку.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
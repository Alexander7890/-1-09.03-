using System;
using System.Windows.Forms;

namespace ПЗ1_09._03_
{
    public partial class Form2 : Form
    {
        private Group selectedGroup;
        private Group originalGroup;

        public Group Group { get; private set; }

        public Form2()
        {
            InitializeComponent();
            button1.Click += new EventHandler(buttonAddGroup_Click);
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public Form2(Group selectedGroup)
        {
            this.selectedGroup = selectedGroup;
            originalGroup = new Group 
            {
                Name = selectedGroup.Name,
                Specialty = selectedGroup.Specialty
            };

            InitializeComponent();
            button1.Click += new EventHandler(buttonEditGroup_Click);
            textBox1.Text = originalGroup.Name;
            textBox2.Text = originalGroup.Specialty;
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            Group = new Group
            {
                Name = textBox1.Text,
                Specialty = textBox2.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonEditGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid group name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedGroup.Name = textBox1.Text;
            selectedGroup.Specialty = textBox2.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
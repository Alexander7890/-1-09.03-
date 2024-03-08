using System;
using System.Windows.Forms;

namespace ПЗ1_09._03_
{
    public partial class Form2 : Form
    {
        public Group Group { get; private set; }
        public Form2()
        {
            InitializeComponent();
            button1.Click += new EventHandler(buttonAddGroup_Click);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            // Створення нової групи
            Group = new Group
            {
                Name = textBox1.Text,
                Specialty = textBox2.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
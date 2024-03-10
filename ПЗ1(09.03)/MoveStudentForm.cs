using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace ПЗ1_09._03_
{
    public partial class MoveStudentForm : Form
    {
        private List<Group> groups;
        private Group sourceGroup;

        public MoveStudentForm(List<Group> groups, Group sourceGroup)
        {
            InitializeComponent();
            button1.Click += buttonMove_Click;
            button2.Click += buttonCancel_Click;
            this.groups = groups;
            this.sourceGroup = sourceGroup;

            // Заповнити комбо бокс зі списком груп
            comboBox1.Items.AddRange(groups.Select((group, index) => $"Group {index + 1}").ToArray());

            // Заповнити список студентів у вихідній групі
            listBox1.Items.AddRange(sourceGroup.Students.Select(student => student.ToString()).ToArray());
        }

        public string GetStudentIdentifier()
        {
            return textBox1.Text.Trim();
        }

        public int GetTargetGroupIndex()
        {
            return comboBox1.SelectedIndex;
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}

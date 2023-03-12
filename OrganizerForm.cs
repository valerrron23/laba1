using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    public partial class OrganizerForm : Form
    {
      
       
        public Organizer organizer = new Organizer();

        public OrganizerForm()
        {
            InitializeComponent();
        }

        private void OrganizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEventForm eventForm = new AddEventForm(); 
            eventForm.Show();

            eventForm.set0rganize(ref organizer); 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
        public void refreshDataGridView()
        {
            dataGridView1.Rows.Clear();

            organizer.list.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}:{item.Time.Seconds}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = item.EventType.ToString(),
                    Style = new DataGridViewCellStyle
                    {
                        BackColor = item.EventType == EventType.TASK ? Color.Violet : Color.BlueViolet
                    }
                });


                dataGridView1.Rows.Add(row);
            });
        }

        private void OrganizerForm_Activated(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = !groupBox3.Visible;
            button2.Text = groupBox3.Visible ? "Скрыть поиск" : "Найти";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            List<Data> tmp = organizer.findByText(textBox2.Text);

            dataGridView1.Rows.Clear();

            tmp.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}:{item.Time.Seconds}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });

                dataGridView1.Rows.Add(row);
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            organizer.sortByTime(0);
            refreshDataGridView();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            organizer.sortByTime(1); 
            refreshDataGridView();
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(EventType.METEENG.ToString());
            comboBox1.Items.Add(EventType.TASK.ToString());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<Data> tmp =  organizer.findByCategory((EventType)Enum.Parse(typeof(EventType),
                comboBox1.Text, true));


            dataGridView1.Rows.Clear();

            tmp.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Date.Year}-{item.Date.Month}-{item.Date.Day}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{item.Time.Hours}:{item.Time.Minutes}:{item.Time.Seconds}"
                });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });

                dataGridView1.Rows.Add(row);
            });

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
    }
}
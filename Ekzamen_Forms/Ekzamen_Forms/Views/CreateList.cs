using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ekzamen_Forms.Views
{
    public partial class CreateList : Form
    {       
        public CreateList()
        {
            InitializeComponent();
            textBox4.ReadOnly = true;
        }

        private void CreateList_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkList wl = new WorkList(textBox1.Text,textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            wl.ShowDialog();
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textBox2.Text = String.Format( e.Start.ToLongDateString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Высокий";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Средний";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "Низкий";
        }
    }
}

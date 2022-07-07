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
    public partial class Posled : Form
    {
        public ListBox list = new ListBox();
        public Posled()
        {
            InitializeComponent();            
        }

        private void Posled_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < list.Items.Count; i++)
            //{
            //    try
            //    {
            //        if (Convert.ToInt32(list.Items[i + 2]) <= 7)
            //        {
            //            listBox1.Items.Add(list.Items[0]);
            //            i = i + 3;
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (listBox1.SelectedItem == list.Items[i])
                {
                    WorkList wl = new WorkList(list.Items[i], list.Items[i + 1], list.Items[i + 2], list.Items[i + 3], list.Items[i + 4]);
                    wl.ShowDialog();
                    break;
                }
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (listBox2.SelectedItem == list.Items[i])
                {
                    WorkList wl = new WorkList(list.Items[i], list.Items[i + 1], list.Items[i + 2], list.Items[i + 3], list.Items[i + 4]);
                    wl.ShowDialog();
                    break;
                }
            }
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (listBox3.SelectedItem == list.Items[i])
                {
                    WorkList wl = new WorkList(list.Items[i], list.Items[i + 1], list.Items[i + 2], list.Items[i + 3], list.Items[i + 4]);
                    wl.ShowDialog();
                    break;
                }
            }
        }
    }
}

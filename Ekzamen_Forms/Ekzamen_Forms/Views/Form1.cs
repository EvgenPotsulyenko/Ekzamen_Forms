using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apitron.PDF.Rasterizer;
using Apitron.PDF.Rasterizer.Configuration;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Ekzamen_Forms.Views
{
    public partial class Form1 : Form
    {
        ListBox list = new ListBox(); // хранит информацию о делах
        ListBox list_day = new ListBox(); //передает названия дел которые необходимо выполнить меньше чем за день
        ListBox list_week = new ListBox();//передает названия дел которые необходимо выполнить меньше чем за неделю
        ListBox list_mounth = new ListBox();//передает названия дел которые необходимо выполнить меньше чем за месяц
        string datetime; // хранит выбранную дату для поиска
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0;i < list.Items.Count;i++) // Вывод значений выбраного елемента
            {
                if (listBox1.SelectedItem == list.Items[i])
                {
                    WorkList wl = new WorkList(list.Items[i], list.Items[i + 1], list.Items[i + 2], list.Items[i + 3], list.Items[i + 4]);
                    wl.ShowDialog();
                    break;
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateList cl = new CreateList();
            cl.ShowDialog();
            listBox1.Items.Add(cl.textBox1.Text); // добавление в listBox на основной форме

            list.Items.Add(cl.textBox1.Text); // добавление в скрытый listBox для вывода данных на другую форму(WorkList)
            list.Items.Add(cl.textBox2.Text);
            list.Items.Add(cl.textBox3.Text);
            list.Items.Add(cl.textBox4.Text);
            list.Items.Add(cl.textBox5.Text);

            if(Convert.ToInt32(cl.textBox3.Text) == 1) // заполнение листа дней для вывода в хронологической последовательности
            {
                list_day.Items.Add(cl.textBox1.Text);
            }
            if (Convert.ToInt32(cl.textBox3.Text) <= 7 && Convert.ToInt32(cl.textBox3.Text) > 1) // заполнение листа недель для вывода в хронологической последовательности
            {
                list_week.Items.Add(cl.textBox1.Text);
            }
            if (Convert.ToInt32(cl.textBox3.Text) > 7) // заполнение листа месяцев для вывода в хронологической последовательности
            {
                list_mounth.Items.Add(cl.textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            for (int i = 0; i < listBox1.Items.Count; i++) // поиск по имени
            {
                if (textBox1.Text == Convert.ToString(listBox1.Items[i]))
                {
                    listBox2.Items.Add(listBox1.Items[i]);
                }
            }
            for (int i = 0; i < list.Items.Count; i++) 
            {
                if (textBox1.Text == Convert.ToString(list.Items[i]) && textBox1.Text == datetime) // поиск по дате выполнения
                {
                    listBox2.Items.Add(list.Items[i - 1]);
                }
                if (textBox1.Text == Convert.ToString(list.Items[i]) && textBox1.Text != datetime && textBox1.Text != "Высокий" && textBox1.Text != "Средний" && textBox1.Text != "Низкий") // поиск по времени выполнения
                {
                    listBox2.Items.Add(list.Items[i - 2]);
                }
                if (textBox1.Text == Convert.ToString(list.Items[i]) && textBox1.Text != datetime) // поиск по приоритету выполнения
                {
                    listBox2.Items.Add(list.Items[i - 3]);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Posled p = new Posled();
            for (int i = 0; i < list.Items.Count; i++) 
            {
                p.list.Items.Add(list.Items[i]);
            }
            for (int i = 0; i < list_day.Items.Count; i++)// заполнение листа дней для вывода в хронологической последовательности
            {                   
                    p.listBox1.Items.Add(list_day.Items[i]);                   
            }
            for (int i = 0; i < list_week.Items.Count; i++)// заполнение листа недель для вывода в хронологической последовательности
            {
                p.listBox2.Items.Add(list_week.Items[i]);
            }
            for (int i = 0; i < list_mounth.Items.Count; i++)// заполнение листа месяцев для вывода в хронологической последовательности
            {
                p.listBox3.Items.Add(list_mounth.Items[i]);
            }
            p.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = String.Format(e.Start.ToLongDateString()); //Выбор даты
            datetime = String.Format(e.Start.ToLongDateString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sf = new OpenFileDialog(); // Загрузка из pdf-файла
            sf.Filter = "PDF Document(*.pdf)|*.pdf";
            if (sf.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = sf.FileName;
            PdfReader reader = new PdfReader(filename);
            ITextExtractionStrategy its = new LocationTextExtractionStrategy();
            StringBuilder text = new StringBuilder();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                   string thePage = PdfTextExtractor.GetTextFromPage(reader, i, its);
                   string[] theLines = thePage.Split('\n');
                   foreach (var theLine in theLines)
                   {
                    listBox1.Items.Add(theLine);
                    break;
                   }
                   foreach (var theLine in theLines)
                   {
                    list.Items.Add(theLine);
                   }
                }
            
        }
    }
}

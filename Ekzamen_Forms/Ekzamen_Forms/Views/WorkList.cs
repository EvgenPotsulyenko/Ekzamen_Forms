using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
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


namespace Ekzamen_Forms.Views
{
    public partial class WorkList : Form
    {
        public WorkList()
        {
            InitializeComponent();
        }
        public WorkList(object name, object date, object time, object priority, object comment)
        {
            InitializeComponent();

            listBox1.Items.Add(name);
            listBox1.Items.Add(date);
            listBox1.Items.Add(time);
            listBox1.Items.Add(priority);
            listBox1.Items.Add(comment);
        }

        private void WorkList_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog(); // сохранение в pdf-файл
            sf.Filter = "PDF Document(*.pdf)|*.pdf";
            if (sf.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = sf.FileName;
            var document = new Document(PageSize.A4, 20, 20, 30, 20);

            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var enc1252 = Encoding.GetEncoding(1252);

            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            var writer = PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
            
            document.Open();
            document.NewPage();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                document.Add(new Paragraph($"{listBox1.Items[i]}", font));
            }
            document.Close();
            writer.Close();
        }
            
            private void button1_Click(object sender, EventArgs e)
            {
                Close();
            }        
    }
}

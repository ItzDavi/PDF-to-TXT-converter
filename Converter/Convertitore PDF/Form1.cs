using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

namespace Convertitore_PDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Open PDF";
            button2.Text = "Show PDF";
            button3.Text = "Convert to .txt";
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "PDF Files(*.pdf)|*.pdf";

            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                string percorso = openDialog.FileName.ToString();
                textBox1.Text = percorso;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PDDocument doc = PDDocument.load(textBox1.Text);
            PDFTextStripper stripper = new PDFTextStripper();
            richTextBox1.Text = (stripper.getText(doc));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();

            file.DefaultExt = "*.txt";
            file.Filter = "Text File|*.txt";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK && file.FileName.Length > 0)
            {
                richTextBox1.SaveFile(file.FileName, RichTextBoxStreamType.PlainText);
            }
        }
    }
}

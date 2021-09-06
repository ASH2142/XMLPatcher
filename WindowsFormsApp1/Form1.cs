using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Ndfl6 xDoc = new Ndfl6();
        public Form1()
        {
            InitializeComponent();

            button1.Click += button1_Click;
            button3.Click += button3_Click;
        }

        void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML files | NO_NDFL6*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;
            textBox1.Text = filename;

            xDoc.Load(filename);

            xDoc.Open(xDoc);

            textBox_INN.Text = xDoc.Inn;
            textBox_KPP.Text = xDoc.Kpp;
            textBox_Naim.Text = xDoc.Name;

            if (!textBox_INN.Text.Contains("Введите ИННЮЛ"))
            {
                label7.Text = "Файл уже готов к отправке";
                label7.Visible = true;
                label7.ForeColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string filename = textBox1.Text;

            xDoc.Patch(xDoc, textBox_INN.Text, textBox_KPP.Text, textBox_Naim.Text);

            textBox2.Text = xDoc.InnerXml;
            xDoc.Save(filename);
            label7.Visible = true;
            label7.Text = "Файл сохранен.";
            label7.ForeColor = Color.Green;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox_INN.Clear();
            textBox_KPP.Clear();
            textBox_Naim.Clear();
            label7.Text = "";
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}


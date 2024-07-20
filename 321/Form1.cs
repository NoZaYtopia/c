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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace _321
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string Data(string a, string b)
        {
            string s = a + " " + b;

            return s;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a =textBox1.ToString();
            string b =textBox2.ToString();

            string path = @"C:\CHART";

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                MessageBox.Show(@"Create dir C:\CHART");
            }
            String fileName = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";

            saveFileDialog.Title = "Сохранить точку";
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

            // saveFileDialog.FileName = comboBox1.SelectedItem.ToString();
            saveFileDialog.FileName = @"C:\CHART\chart.txt";


            StreamWriter streamwriter = new StreamWriter(@"C:\CHART\chart.txt ", true,
System.Text.Encoding.GetEncoding("utf-8"));
            streamwriter.WriteLine(Data(a,b));
            streamwriter.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

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

namespace _321
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            string filename = @"C:\CHART\chart.txt";

            if (File.Exists(filename))
            {
                StreamReader file = new StreamReader(filename);
                string[] values; //
                string newline; // считанная строка и файла
                                // считываем до конца файла
                while ((newline = file.ReadLine()) != null)
                {
                    values = newline.Split(':'); 
                    
                }
                file.Close();
            }
            else MessageBox.Show("Нет файла с данными");


            
        }
    }
}

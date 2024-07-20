using Gratrix.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gratrix
{
    public partial class Main_Page : Form
    {

        static DB dataBase = new DB();
        


        public Main_Page()
        {
            InitializeComponent();
        }

        private void Main_Page_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Background;
            this.WindowState = FormWindowState.Maximized;
            
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Icon = Properties.Resources.gr_icon;
            this.Text = "Gratrix";
            //Data_Base.openConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //graphs
            Graph_page gp = new Graph_page(this);   
                gp.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //theory
            Theory_page tp   = new Theory_page();
            tp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //calc

            ProcessStartInfo stInfo =
            new ProcessStartInfo(@"C:\windows\system32\calc.exe");

            stInfo.UseShellExecute = false;
            stInfo.CreateNoWindow = true;

            //создаем новый процесс
            Process proc = new Process();
            proc.StartInfo = stInfo;
            //Запускаем процесс
            proc.Start();

            //Ждем, пока блокнот запущен
            proc.WaitForExit();

           // MessageBox.Show("Код завершения: " + proc.ExitCode, "Завершение Код",
             //  MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Page_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Matrix_page mp = new Matrix_page(this);
            mp.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void histiryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void graphsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //graphs
            Graph_page gp = new Graph_page(this);
            gp.Show();
        }

        private void matricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matrix_page mp = new Matrix_page(this);
            mp.Show();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //calc

            ProcessStartInfo stInfo =
            new ProcessStartInfo(@"C:\windows\system32\calc.exe");

            stInfo.UseShellExecute = false;
            stInfo.CreateNoWindow = true;

            //создаем новый процесс
            Process proc = new Process();
            proc.StartInfo = stInfo;
            //Запускаем процесс
            proc.Start();

            //Ждем, пока блокнот запущен
            proc.WaitForExit();

            // MessageBox.Show("Код завершения: " + proc.ExitCode, "Завершение Код",
            //  MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void theoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //theory
            Theory_page tp = new Theory_page();
            tp.Show();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegForm rf = new RegForm(); 
            rf.Show();
        }
    }
}

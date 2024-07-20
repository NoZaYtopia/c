using Gratrix.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gratrix
{
    public partial class Graph_page : Form
    {
        private Form _mainform;
        private int index;

        public Graph_page(Form mainform)
        {
            InitializeComponent();
            _mainform = mainform;
            _mainform.Visible = false;

        }

        private void Graph_page_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Background;
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Icon = Properties.Resources.gr_icon;
            this.Text = "Gratrix";

            checkedListBox1.CheckOnClick = true;
            string[] Graph_Alg_list = { "A*", "Краскал", "РАскраска" };
            checkedListBox1.Items.AddRange(Graph_Alg_list);
            checkedListBox1.SelectionMode = SelectionMode.One;
            Tutn_Off_A();
        }

        private void Graph_page_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
        }

        private void Graph_page_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainform.Visible = true;
        }

        private void Tutn_Off_A()
        {
            L_dest.Visible = false;
            L_start.Visible = false;

            TB_dest.Visible = false;
            TB_start.Visible = false;
            TB_dest.Enabled = false;
            TB_start.Enabled = false;
        }

        private void Tutn_On_A()
        {
            L_dest.Visible = true;
            L_start.Visible = true;

            TB_dest.Visible = true;
            TB_start.Visible = true;
            TB_dest.Enabled = true;
            TB_start.Enabled = true;
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

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegForm rf = new RegForm();
            rf.Show();
        }

        private void TB_proceed_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                //A
                /*int[,] map =
             {
                 {1,1,1,1,1,1,1,1 },
                 {1,0,0,0,1,1,1,1 },
                 {1,1,1,0,1,1,1,1 },
                 {1,1,0,0,1,0,0,1 },
                 {1,1,0,0,0,0,0,1 },
                 {1,1,1,1,1,1,1,1 },
             };*/

                string source = TB_in.Text;
                int[,] map = ConvTBtoMAP(source);

                string[] start = TB_start.Text.Split(' ');
                string[] dest = TB_dest.Text.Split(' ');

                int t;
                bool success = int.TryParse(start[0].ToString(), out t);
                if (success == false)
                {
                    MessageBox.Show("can not convert start x to int", "error", MessageBoxButtons.OK,
            MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

                int x_start = t;

                success = int.TryParse(start[1].ToString(), out t);
                if (success == false)
                {
                    MessageBox.Show("can not convert start y to int", "error", MessageBoxButtons.OK,
            MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

                int y_start = t;

                success = int.TryParse(dest[0].ToString(), out t);
                if (success == false)
                {
                    MessageBox.Show("can not convert destination x to int", "error", MessageBoxButtons.OK,
            MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

                int x_dest = t;

                success = int.TryParse(dest[1].ToString(), out t);
                if (success == false)
                {
                    MessageBox.Show("can not convert destination y to int", "error", MessageBoxButtons.OK,
            MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }

                int y_dest = t;

                var node = AStar.Instance.Execute(map, x_start, y_start, x_dest, y_dest);
                //AStar.Instance.DisplayPath(node);

                string outpath = AStar.Instance.ConvPATHtoSTRING(node);
                TB_out.Text = outpath;
                //label1.Text = TB_in.Text;

            }
            if (index == 1)
            {
                //KR
                string source = TB_in.Text;
                string[] lines = source.Split('\n');

                Graph graph = new Graph();

                foreach (string line in lines)
                {
                    string[] splitted = line.Split();
                    Edge edge = new Edge(splitted[0], splitted[1], Int32.Parse(splitted[2]));
                    graph.Add(edge);
                }

                //Console.WriteLine("Your graph: ");
                //Console.WriteLine(graph.ToString());

                //Result(graph);

                graph = graph.FindMinimumSpanningTree();

                Serv tech = new Serv();
                string outgr = tech.ConvREStoSTR(graph);
                TB_out.Text = outgr;
            }
            if (index == 2)
            {
                //PG
                string source = TB_in.Text;
                string[] rows = source.Split('\n');
                int NV = Int32.Parse(rows[0]);
                Graph_PG g1 = new Graph_PG(NV);

                int n = rows.Length;
                for (int i = 1; i < n; i++)
                {
                    string[] verts = rows[i].Split(' ');
                    g1.addEdge(Int32.Parse(verts[0]), Int32.Parse(verts[1]));
                }

                string outcol = "Coloring of graph 1 : ";

                outcol += g1.greedyColoring();
                TB_out.Text = outcol;

                /*
                Graph_PG g2 = new Graph_PG(5);
                g2.addEdge(0, 1);
                g2.addEdge(0, 2);
                g2.addEdge(1, 2);
                g2.addEdge(1, 4);
                g2.addEdge(2, 4);
                g2.addEdge(4, 3);
                Console.WriteLine("\nColoring of graph 2");
                g2.greedyColoring();

                */
            }
        }

        public int[,] ConvTBtoMAP(string source, bool maze = true)
        {
            string[] rows = source.Split('\n');

            int rowCount = rows.Length;
            int colCount = rows[0].Split(' ').Length;

            if ((rowCount != colCount) && (maze == false))
            {
                MessageBox.Show("rowCount!=colCount", "error", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

            int[,] my_map = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] chars = rows[i].Split(' ');

                for (int j = 0; j < colCount; j++)
                {
                    char temp = chars[j][0];
                    int t;
                    bool success = int.TryParse(temp.ToString(), out t);
                    if (success == false)
                    {
                        MessageBox.Show("can not convert map to int", "error", MessageBoxButtons.OK,
                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                    my_map[i, j] = t;
                }
            }

            return my_map;
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = checkedListBox1.SelectedIndex;

            int count = checkedListBox1.Items.Count;

            for (int x = 0; x < count; x++)
            {
                //ignore selected checkbox from the list
                if (index != x)
                {
                    checkedListBox1.SetItemChecked(x, false);
                    TB_in.Text = "";
                    TB_out.Text = "";
                }
            }
            if (index != 0)
            {
                Tutn_Off_A();
            }
            else
            {
                Tutn_On_A();
            }
           
        }
    }
}

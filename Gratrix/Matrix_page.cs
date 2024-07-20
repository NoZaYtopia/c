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
    public partial class Matrix_page : Form
    {
        private Form _mainform;
        private int prev_index = -1;
        private int index = -1;

        public Matrix_page(Form mainform)
        {
            InitializeComponent();
            _mainform = mainform;
            _mainform.Visible = false;

        }


        private void Matrix_page_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Background;
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Icon = Properties.Resources.gr_icon;
            this.Text = "Gratrix";

            checkedListBox1.CheckOnClick = true;
            string[] Matrices_Alg_list = { "Детерминант", "Обратная", "Ранг","Перемножение","Система линейных уравнений" };
            checkedListBox1.Items.AddRange(Matrices_Alg_list);
            checkedListBox1.SelectionMode = SelectionMode.One;

            pictureBox1.Image = Resources.staple_png;
            pictureBox2.Image = Resources.staple_png;
            pictureBox3.Image = Resources.staple_png;
            pictureBox4.Image = Resources.staple_png;
            pictureBox5.Image = Resources.staple_png;
            pictureBox6.Image = Resources.staple_png;

            Turn_Off_Det();
            Turn_Off_Rev();
            Turn_Off_LS();
            Turn_Off_Rev();
            Turn_Off_AB();
        }

        private void Turn_0n_Det()
        {
            TLP_Matrix_Input.Visible = true;
            TLP_Matrix_Input.Enabled = true;
            TB_Solve_type.Text = "Детерминант: ";
            TB_Solve_Det.Visible = true;
            TB_Solve_Det.Enabled = true;
        }

        private void Turn_Off_Det()
        {
            TLP_Matrix_Input.Visible = false;
            TLP_Matrix_Input.Enabled = false;
            TB_Solve_type.Text = "";
            TB_Solve_Det.Visible = false;
            TB_Solve_Det.Enabled = false;
        }

        private void Turn_Off_AB()
        {
            TLP_Out_B.Visible = false;
            TLP_Out_B.Enabled = false;

            TLP_Matrix_Input.Visible = false;
            TLP_Matrix_Input.Enabled = false;
            TB_Solve_type.Text = "";
            TLP_Matrix_out.Visible = false;
            TLP_Matrix_out.Enabled = false;
        }

        private void Turn_On_AB()
        {
            
            
                TLP_Out_B.Visible = true;
                TLP_Out_B.Enabled = true;

                TLP_Matrix_Input.Visible = true;
                TLP_Matrix_Input.Enabled = true;
                TB_Solve_type.Text = "Выход:";
                TLP_Matrix_out.Visible = true;
                TLP_Matrix_out.Enabled = true;
            TB_Solve_Det.Visible = false;
            TB_Solve_Det.Enabled = false;

        }

        private void Turn_0n_Rev()
        {
            TLP_Matrix_Input.Visible = true;
            TLP_Matrix_Input.Enabled = true;
            TLP_Matrix_out.Visible = true;
            TLP_Matrix_out.Enabled = true;
            TB_Solve_type.Text = "Обратная матрица: ";
            
        }

        private void Turn_Off_Rev()
        {
            TLP_Matrix_Input.Visible = false;
            TLP_Matrix_Input.Enabled = false;
            TB_Solve_type.Text = "";
            TLP_Matrix_out.Visible = false;
            TLP_Matrix_out.Enabled = false;
        }

        private void Turn_On_LS()
        {
            TLP_In_b.Visible = true;
            TLP_In_b.Enabled = true;

            TLP_Matrix_Input.Visible = true;
            TLP_Matrix_Input.Enabled = true;

            TB_Solve_type.Text = "Вектор решений x:";

            TLP_Out_x.Visible = true;
            TLP_Out_x.Enabled = true;

            TB_Solve_Det.Visible = false;
            TB_Solve_Det.Enabled = false;

            label1.Visible = true;
            label1.Enabled = true;
        }

        private void Turn_Off_LS()
        {
            TLP_In_b.Visible = false;
            TLP_In_b.Enabled = false;

            TLP_Matrix_Input.Visible = false;
            TLP_Matrix_Input.Enabled = false;

            TB_Solve_type.Text = "";

            TLP_Out_x.Visible = false;
            TLP_Out_x.Enabled = false;

            label1.Visible = false;
            label1.Enabled = false;
        }

        private void Matrix_page_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainform.Visible = true;
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
                }
            }

            if(prev_index==0) 
            {
                Turn_Off_Det();
            }
            if (prev_index == 1)
            {
                Turn_Off_Rev();
            }

            if (prev_index == 3)
            {
                Turn_Off_AB();
            }

            if (prev_index == 4)
            {
                Turn_Off_LS();
            }

            if (checkedListBox1.SelectedIndex == 0) 
            {
                prev_index = 0;
                Turn_0n_Det();
            }
            
            if (checkedListBox1.SelectedIndex == 1)
            {
                prev_index = 1;
                Turn_0n_Rev();
            }

            if (checkedListBox1.SelectedIndex == 2)
            {
                prev_index = 1;
                Turn_0n_Det();
                TB_Solve_type.Text = "Ранг:";
            }

            if (checkedListBox1.SelectedIndex == 3)
            {
                prev_index = 3;
                Turn_On_AB(); 
            }

            if (checkedListBox1.SelectedIndex == 4)
            {
                prev_index = 4;
                Turn_On_LS();
            }
        }

        private void B_Solve_Click(object sender, EventArgs e)
        {
            if(index==0)
            {
                double[][] matr_a = MyMatrix.MatrixCreate(3, 3);
                double b;

                double.TryParse(numericUpDown00.Value.ToString(), out b);
                matr_a[0][0] = b;
                double.TryParse(numericUpDown01.Value.ToString(), out b);
                matr_a[0][1] = b;
                double.TryParse(numericUpDown02.Value.ToString(), out b);
                matr_a[0][2] = b;

                double.TryParse(numericUpDown10.Value.ToString(), out b);
                matr_a[1][0] = b;
                double.TryParse(numericUpDown11.Value.ToString(), out b);
                matr_a[1][1] = b;
                double.TryParse(numericUpDown12.Value.ToString(), out b);
                matr_a[1][2] = b;

                double.TryParse(numericUpDown20.Value.ToString(), out b);
                matr_a[2][0] = b;
                double.TryParse(numericUpDown21.Value.ToString(), out b);
                matr_a[2][1] = b;
                double.TryParse(numericUpDown22.Value.ToString(), out b);
                matr_a[2][2] = b;

                MyMatrix A = new MyMatrix(3,3,matr_a);


                double Solve = A.MatrixDeterminant();

                TB_Solve_Det.Text=Convert.ToString(Solve);
            }
            else if (index==1)
            {
                double[][] matr_a = MyMatrix.MatrixCreate(3, 3);
                double b;

                double.TryParse(numericUpDown00.Value.ToString(), out b);
                matr_a[0][0] = b;
                double.TryParse(numericUpDown01.Value.ToString(), out b);
                matr_a[0][1] = b;
                double.TryParse(numericUpDown02.Value.ToString(), out b);
                matr_a[0][2] = b;

                double.TryParse(numericUpDown10.Value.ToString(), out b);
                matr_a[1][0] = b;
                double.TryParse(numericUpDown11.Value.ToString(), out b);
                matr_a[1][1] = b;
                double.TryParse(numericUpDown12.Value.ToString(), out b);
                matr_a[1][2] = b;

                double.TryParse(numericUpDown20.Value.ToString(), out b);
                matr_a[2][0] = b;
                double.TryParse(numericUpDown21.Value.ToString(), out b);
                matr_a[2][1] = b;
                double.TryParse(numericUpDown22.Value.ToString(), out b);
                matr_a[2][2] = b;

                MyMatrix A = new MyMatrix(3, 3, matr_a);

                MyMatrix B = new MyMatrix(3, 3);
                B = A.GetInverse();

                TB_Out_00.Text = B.data[0][0].ToString();
                TB_Out_01.Text = B.data[0][1].ToString();
                TB_Out_02.Text = B.data[0][2].ToString();

                TB_Out_10.Text = B.data[1][0].ToString();
                TB_Out_11.Text = B.data[1][1].ToString();
                TB_Out_12.Text = B.data[1][2].ToString();

                TB_Out_20.Text = B.data[2][0].ToString();
                TB_Out_21.Text = B.data[2][1].ToString();
                TB_Out_22.Text = B.data[2][2].ToString();
            }

            else if(index == 2)
            {
                double[][] matr_a = MyMatrix.MatrixCreate(3, 3);
                double b;

                double.TryParse(numericUpDown00.Value.ToString(), out b);
                matr_a[0][0] = b;
                double.TryParse(numericUpDown01.Value.ToString(), out b);
                matr_a[0][1] = b;
                double.TryParse(numericUpDown02.Value.ToString(), out b);
                matr_a[0][2] = b;

                double.TryParse(numericUpDown10.Value.ToString(), out b);
                matr_a[1][0] = b;
                double.TryParse(numericUpDown11.Value.ToString(), out b);
                matr_a[1][1] = b;
                double.TryParse(numericUpDown12.Value.ToString(), out b);
                matr_a[1][2] = b;

                double.TryParse(numericUpDown20.Value.ToString(), out b);
                matr_a[2][0] = b;
                double.TryParse(numericUpDown21.Value.ToString(), out b);
                matr_a[2][1] = b;
                double.TryParse(numericUpDown22.Value.ToString(), out b);
                matr_a[2][2] = b;

                MyMatrix A = new MyMatrix(3, 3, matr_a);

                TB_Solve_Det.Text = A.GetRank().ToString();
            }

            else if(index == 3) 
            {
                double[][] matr_a = MyMatrix.MatrixCreate(3, 3);
                double b;

                double.TryParse(numericUpDown00.Value.ToString(), out b);
                matr_a[0][0] = b;
                double.TryParse(numericUpDown01.Value.ToString(), out b);
                matr_a[0][1] = b;
                double.TryParse(numericUpDown02.Value.ToString(), out b);
                matr_a[0][2] = b;

                double.TryParse(numericUpDown10.Value.ToString(), out b);
                matr_a[1][0] = b;
                double.TryParse(numericUpDown11.Value.ToString(), out b);
                matr_a[1][1] = b;
                double.TryParse(numericUpDown12.Value.ToString(), out b);
                matr_a[1][2] = b;

                double.TryParse(numericUpDown20.Value.ToString(), out b);
                matr_a[2][0] = b;
                double.TryParse(numericUpDown21.Value.ToString(), out b);
                matr_a[2][1] = b;
                double.TryParse(numericUpDown22.Value.ToString(), out b);
                matr_a[2][2] = b;

                MyMatrix A = new MyMatrix(3, 3, matr_a);

                double[][] matr_b = MyMatrix.MatrixCreate(3, 3);
                

                double.TryParse(numericUpDown00.Value.ToString(), out b);
                matr_b[0][0] = b;
                double.TryParse(numericUpDown01.Value.ToString(), out b);
                matr_b[0][1] = b;
                double.TryParse(numericUpDown02.Value.ToString(), out b);
                matr_b[0][2] = b;

                double.TryParse(numericUpDown10.Value.ToString(), out b);
                matr_b[1][0] = b;
                double.TryParse(numericUpDown11.Value.ToString(), out b);
                matr_b[1][1] = b;
                double.TryParse(numericUpDown12.Value.ToString(), out b);
                matr_b[1][2] = b;

                double.TryParse(numericUpDown20.Value.ToString(), out b);
                matr_b[2][0] = b;
                double.TryParse(numericUpDown21.Value.ToString(), out b);
                matr_b[2][1] = b;
                double.TryParse(numericUpDown22.Value.ToString(), out b);
                matr_b[2][2] = b;

                MyMatrix B = new MyMatrix(3, 3, matr_b);

                MyMatrix C = A.MatrixProduct(A, B);

                TB_Out_00.Text = C.data[0][0].ToString();
                TB_Out_01.Text = C.data[0][1].ToString();
                TB_Out_02.Text = C.data[0][2].ToString();

                TB_Out_10.Text = C.data[1][0].ToString();
                TB_Out_11.Text = C.data[1][1].ToString();
                TB_Out_12.Text = C.data[1][2].ToString();

                TB_Out_20.Text = C.data[2][0].ToString();
                TB_Out_21.Text = C.data[2][1].ToString();
                TB_Out_22.Text = C.data[2][2].ToString();
            }

            else if(index==4)
            {
                double[][] matr_a = MyMatrix.MatrixCreate(3, 3);
                double b;

                double.TryParse(numericUpDown00.Value.ToString(), out b);
                matr_a[0][0] = b;
                double.TryParse(numericUpDown01.Value.ToString(), out b);
                matr_a[0][1] = b;
                double.TryParse(numericUpDown02.Value.ToString(), out b);
                matr_a[0][2] = b;

                double.TryParse(numericUpDown10.Value.ToString(), out b);
                matr_a[1][0] = b;
                double.TryParse(numericUpDown11.Value.ToString(), out b);
                matr_a[1][1] = b;
                double.TryParse(numericUpDown12.Value.ToString(), out b);
                matr_a[1][2] = b;

                double.TryParse(numericUpDown20.Value.ToString(), out b);
                matr_a[2][0] = b;
                double.TryParse(numericUpDown21.Value.ToString(), out b);
                matr_a[2][1] = b;
                double.TryParse(numericUpDown22.Value.ToString(), out b);
                matr_a[2][2] = b;

                MyMatrix A = new MyMatrix(3, 3, matr_a);

                double[] vect_b = new double[3];

                double.TryParse(NUD_b_0.Value.ToString(), out b);
                vect_b[0] = b;
                double.TryParse(NUD_b_1.Value.ToString(), out b);
                vect_b[1] = b;
                double.TryParse(NUD_b_2.Value.ToString(), out b);
                vect_b[2] = b;

                double[]x= new double[3];
                x=A.LinSolve(vect_b);

                TB_Out_x_0.Text = x[0].ToString();
                TB_Out_x_1.Text = x[1].ToString();
                TB_Out_x_2.Text = x[2].ToString();
            }
        }

        private void graphsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //graphs
            Graph_page gp = new Graph_page(this);
            gp.Show();
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
    }
}

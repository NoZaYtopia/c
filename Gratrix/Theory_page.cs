using Gratrix.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gratrix
{
    public partial class Theory_page : Form
    {
        string Connect = "Data Source=DESKTOP-0C4I8FH\\SQLEXPRESS;Initial Catalog=graph;Integrated Security=True";
        string connectionString = "Data Source=DESKTOP-0C4I8FH\\SQLEXPRESS;Initial Catalog=graph;Integrated Security=True";
        public Theory_page()
        {
            InitializeComponent();
        }

        private void Theory_page_Load(object sender, EventArgs e)
        {
           // string Connect = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=graph;Integrated Security=True";

        }

        private void Page_Theory(object sender, EventArgs e)
        {
            // string Connect = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=graph;Integrated Security=True";
          

            this.BackgroundImage = Resources.Background;


            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Tile;
            this.Icon = Properties.Resources.gr_icon;


            this.Text = "Gratrix Theory";

            Source_1.Text = "Неориентированный граф";
            Source_2.Text = "Ориентированный граф";
            Source_3.Text = "Взвешенный граф";
            Source_4.Text = "Планарный граф";
            Source_5.Text = "Петлевой граф";
            Source_6.Text = "Мультиграф";
            Source_7.Text = "Граф - дерево";
            Source_8.Text = "Пустой граф";

            Source_9.Text = "Матрица смежности";
            Source_10.Text = "Транспонированная матрица";
            Source_11.Text = "Диагональная матрица";
            Source_12.Text = "Нулевая матрица";
            Source_13.Text = "Единичная матрица";
            Source_14.Text = "Симмтеричная матрица";
            Source_15.Text = "Треугольная матрица";


        }

        private void button1_Click(object sender, EventArgs e)//Source 1
        {
           //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица1 WHERE ID = 0";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }

        }

        private void Source_2_Click(object sender, EventArgs e)//Source 2
        {
           // string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица1 WHERE ID = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_3_Click(object sender, EventArgs e)
        {
            //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица1 WHERE ID = 2";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_4_Click(object sender, EventArgs e)
        {
            //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица1 WHERE ID = 3";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_5_Click(object sender, EventArgs e)
        {
            //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица1 WHERE ID = 4";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_6_Click(object sender, EventArgs e)
        {
            //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица1 WHERE ID = 5";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";   
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_7_Click(object sender, EventArgs e)
        {
            //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица1 WHERE ID = 6";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_8_Click(object sender, EventArgs e)
        {
          //  string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица1 WHERE ID = 7";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_9_Click(object sender, EventArgs e)
        {
           // string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица4 WHERE ID = 0";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_10_Click(object sender, EventArgs e)
        {
           // string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица4 WHERE ID = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_11_Click(object sender, EventArgs e)
        {
            //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица4 WHERE ID = 2";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_12_Click(object sender, EventArgs e)
        {
            //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица4 WHERE ID = 3";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_13_Click(object sender, EventArgs e)
        {
            //string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица4 WHERE ID = 4";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_14_Click(object sender, EventArgs e)
        {
           // string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица4 WHERE ID = 5";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text = "";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }

        private void Source_15_Click(object sender, EventArgs e)
        {
          //  string connectionString = "Database=graph; Data Source = localhost; User Id = root; Password = пароль ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Теория FROM dbo.Таблица4 WHERE ID = 6";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        richTextBox1.Text="";
                        string theory = reader["Теория"].ToString();
                        richTextBox1.Text = theory;
                    }
                    reader.Close();
                }
            }
        }
    }
}

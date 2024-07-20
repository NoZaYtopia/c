using Gratrix.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gratrix
{
    public partial class NORMREG : Form
    {

        public NORMREG()
        {
            InitializeComponent();
        
        }

        private void NORMREG_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Background;
            //this.WindowState = FormWindowState.Maximized;

            this.StartPosition = FormStartPosition.CenterScreen;


            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Icon = Properties.Resources.gr_icon;
            this.Text = "Gratrix";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (TB_login.Text == "")
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (checkUser())
                return;


            DB db = new DB();
            SqlCommand command = new SqlCommand("INSERT INTO 'dbo.USERS_ID' ('user_login', 'user_pass') VALUES (@login, @pass)", db.GetSqlConnection());

            command.Parameters.Add("@login", SqlDbType.VarChar).Value = TB_login.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = TB_pass.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 0)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");


            db.closeConnection();
        }

        public Boolean checkUser()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM dbo.USERS_ID WHERE 'user_login'= @l", db.GetSqlConnection());

            command.Parameters.Add("@l", SqlDbType.VarChar).Value = TB_login.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже создан, придумайте другой.");
                return true;
            }
            else
            {
                return false;
            }
        }
    
    
    }







}

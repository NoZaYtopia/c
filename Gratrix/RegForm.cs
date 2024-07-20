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
    public partial class RegForm : Form
    {
        

        public RegForm()
        {
            InitializeComponent();
        }

        

        private void RegForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Background;
            //this.WindowState = FormWindowState.Maximized;

            this.StartPosition = FormStartPosition.CenterScreen;
            

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Icon = Properties.Resources.gr_icon;
            this.Text = "Gratrix";
        }

        private void RegForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = TB_login.Text;
            String pass= TB_pass.Text;

            DB db = new DB();

            DataTable table = new DataTable(); 

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM dbo.USERS_ID WHERE 'user_login'= @l AND 'user_pass'= @p", db.GetSqlConnection());

            command.Parameters.Add("@l", SqlDbType.VarChar).Value = login;
            command.Parameters.Add("@p", SqlDbType.VarChar).Value = pass;
              
            adapter.SelectCommand=command;
            adapter.Fill(table);

            if (table.Rows.Count > 1) 
                MessageBox.Show("Yes");
            else
                MessageBox.Show("No");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reg
            NORMREG rf = new NORMREG();
            rf.Show();


        }
    }
}

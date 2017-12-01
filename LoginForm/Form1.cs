using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        public Form1()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADVENSOFT-PC\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ADVENSOFT-PC\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADVENSOFT-PC\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
            con.Open();
            Program.gLogin.UserName = textBox1.Text;
            Program.gLogin.Password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select username,password from login where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            string pLogInDate = DateTime.Now.ToShortDateString();
            string pLogInTime = DateTime.Now.ToShortTimeString();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login sucess.");
                this.Hide();
                Form2 pFrm2 = new Form2();
                pFrm2.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

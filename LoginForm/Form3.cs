using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADVENSOFT-PC\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
            con.Open();
            String pUserName = Program.gLogin.UserName;
            DateTime pFromDate = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime pToDate = Convert.ToDateTime(dateTimePicker2.Text);
            SqlCommand cmd = new SqlCommand("select * from attendance where username='" + pUserName + "' and logindate between '" + pFromDate + "' and '" + pToDate + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

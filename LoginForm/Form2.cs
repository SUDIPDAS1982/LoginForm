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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADVENSOFT-PC\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
            con.Open();
            String pUserName = Program.gLogin.UserName;
            DateTime pDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime pTime = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            SqlCommand cmd = new SqlCommand("INSERT INTO attendance (username, logindate, logintime) values ('"+pUserName+"',' " + 
                                            pDate + "', '"+pTime+"')",con);
            int i=cmd.ExecuteNonQuery();
            if(i>0)
            {
                label1.Visible=true;
                label1.Text = "Your registered entry time is: " + pTime + "";
                MessageBox.Show("Time In Done. ");
                button2.Enabled = true;
                button1.Enabled = false;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADVENSOFT-PC\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
            con.Open();
            String pUserName = Program.gLogin.UserName;
            DateTime pDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            SqlCommand cmd = new SqlCommand("select username,logindate,logintime from attendance where username='" + pUserName + "'and logindate='" + pDate + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                button2.Enabled = true;
                button1.Enabled = false;

            }
            else
            {
                button2.Enabled = false;
                button1.Enabled = true;
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=ADVENSOFT-PC\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True";
            con.Open();
            String pUserName = Program.gLogin.UserName;
            DateTime pDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime pTime = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            SqlCommand cmd = new SqlCommand("update attendance set logouttime='"+pTime+"' where username='" + pUserName + "' and logindate='"+pDate+"'", con);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                label1.Visible = true;
                label1.Text = "Your registered exit time is: " + pTime + "";
                MessageBox.Show("Time Out Done. ");
                button2.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 pFrm3 = new Form3();
            pFrm3.ShowDialog();
        }
    }
}

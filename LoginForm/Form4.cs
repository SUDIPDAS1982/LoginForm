using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            String pUserName = Program.gLogin.UserName;
            label1.Text = "Welcome " + pUserName + "";
        }

        private void leaveDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void employeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 pFrm5 = new Form5();
            pFrm5.ShowDialog();
        }

        private void editEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 pFrm6 = new Form6();
            pFrm6.ShowDialog();
        }
    }
}

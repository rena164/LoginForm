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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CashierLoginForm cashierLogin = new CashierLoginForm();
            cashierLogin.Show();
            cashierLogin.Location = this.Location;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login Successfully.");
            CashierListFrm cashierListFrm = new CashierListFrm();
            cashierListFrm.Show();
            this.Hide();

        }
    }

}

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

namespace LoginForm
{
    public partial class Cashier1Form : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JSURCQ7\SQLEXPRESS;Initial Catalog=Kiosk;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataReader reader;

        public Cashier1Form()
        {
            InitializeComponent();

            conn.Open();
            string query = "UPDATE CashierActivity SET Log_Status = @log WHERE ID = 1";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@log", "In-Use");
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE CashierActivity SET Log_Status = @log WHERE ID = 1";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@log", "Not In-Use");
            cmd.ExecuteNonQuery();
            conn.Close();

            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}

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
    public partial class CashierLoginForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JSURCQ7\SQLEXPRESS;Initial Catalog=Kiosk;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataReader reader;

        public CashierLoginForm()
        {
            InitializeComponent();

            conn.Open();
            string query = "SELECT Name FROM CashierActivity";
            cmd = new SqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                cbCashierList.Items.Add(reader["Name"]);
            }

            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            form1.Location = this.Location;
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(cbCashierList.Text != "")
            {
                conn.Open();
                string query = "SELECT * FROM CashierActivity WHERE Name = @name AND Status = 'Enabled'";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", cbCashierList.Text);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    switch (reader["ID"])
                    {
                        case 1:
                            Cashier1Form cashier1Form = new Cashier1Form();
                            cashier1Form.Show();
                            this.Close();
                            break;
                        case 2:
                            MessageBox.Show("CashierForm2");
                            break;
                        case 3:
                            MessageBox.Show("CashierForm3");
                            break;
                        case 4:
                            MessageBox.Show("CashierForm4");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Access Denied: The cashier account is currently disabled. Please contact the administrator for assistance.");
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("Please select a cashier from the list before proceeding.");
            }

        }

    }
}

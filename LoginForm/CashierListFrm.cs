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
    public partial class CashierListFrm : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JSURCQ7\SQLEXPRESS;Initial Catalog=Kiosk;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataReader reader;

        public static Button btnSave = new Button();
        public CashierListFrm()
        {
            InitializeComponent();

            btnEdit1.Click += global_button_event;
            btnEdit2.Click += global_button_event;
            btnEdit3.Click += global_button_event;
            btnEdit4.Click += global_button_event;

            btnSave = btnEvent;
            CashierActivity();
        }

        private void CashierActivity()
        {
            conn.Open();
            string query = "SELECT * FROM CashierActivity";
            cmd = new SqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            lblID1.Text = reader["ID"].ToString();
            txtName1.Text = reader["Name"].ToString();
            lblLogStatus1.Text = reader["Log_Status"].ToString();
            switch (reader["Log_Status"].ToString())
            {
                case "In-Use":
                    lblLogStatus1.Location = new Point(8, 6);
                    logStatusColor1.BackColor = Color.LimeGreen;
                    logStatusColor1.Location = new Point(73, 4);
                    logStatusColor1.Size = new Size(64, 27);
                    break;
                case "Not In-Use":
                    lblLogStatus1.Location = new Point(6, 6);
                    logStatusColor1.BackColor = Color.FromArgb(225, 0, 0);
                    logStatusColor1.Location = new Point(62, 4);
                    logStatusColor1.Size = new Size(86, 27);
                    break;
            }

            txtStatus1.Text = reader["Status"].ToString();
            switch (reader["Status"].ToString())
            {
                case "Enabled":
                    txtStatus1.Location = new Point(3, 6);
                    statusColor1.BackColor = Color.LimeGreen;
                    break;
                case "Disabled":
                    txtStatus1.Location = new Point(1, 6);
                    statusColor1.BackColor = Color.FromArgb(225, 0, 0);
                    break;
            }

            reader.Read();
            lblID2.Text = reader["ID"].ToString();
            txtName2.Text = reader["Name"].ToString();
            lblLogStatus2.Text = reader["Log_Status"].ToString();
            txtStatus2.Text = reader["Status"].ToString();
            switch (reader["Status"].ToString())
            {
                case "Enabled":
                    txtStatus2.Location = new Point(3, 6);
                    statusColor2.BackColor = Color.LimeGreen;
                    break;
                case "Disabled":
                    txtStatus2.Location = new Point(1, 6);
                    statusColor2.BackColor = Color.FromArgb(225, 0, 0);
                    break;
            }

            reader.Read();
            lblID3.Text = reader["ID"].ToString();
            txtName3.Text = reader["Name"].ToString();
            lblLogStatus3.Text = reader["Log_Status"].ToString();
            txtStatus3.Text = reader["Status"].ToString();
            switch (reader["Status"].ToString())
            {
                case "Enabled":
                    txtStatus3.Location = new Point(3, 6);
                    statusColor3.BackColor = Color.LimeGreen;
                    break;
                case "Disabled":
                    txtStatus3.Location = new Point(1, 6);
                    statusColor3.BackColor = Color.FromArgb(225, 0, 0);
                    break;
            }

            reader.Read();
            lblID4.Text = reader["ID"].ToString();
            txtName4.Text = reader["Name"].ToString();
            lblLogStatus4.Text = reader["Log_Status"].ToString();
            txtStatus4.Text = reader["Status"].ToString();
            switch (reader["Status"].ToString())
            {
                case "Enabled":
                    txtStatus4.Location = new Point(3, 6);
                    statusColor4.BackColor = Color.LimeGreen;
                    break;
                case "Disabled":
                    txtStatus4.Location = new Point(1, 6);
                    statusColor4.BackColor = Color.FromArgb(225, 0, 0);
                    break;
            }

            conn.Close();
        }

        private string currentButton;

        private void global_button_event(object sender, EventArgs e)
        {
            currentButton = ((Button)sender).Name;
            switch (((Button)sender).Name)
            {
                case "btnEdit1":
                    EditCashierForm.cashierName = txtName1.Text;
                    EditCashierForm.cashierStatus = txtStatus1.Text;
                    break;
                case "btnEdit2":
                    EditCashierForm.cashierName = txtName2.Text;
                    EditCashierForm.cashierStatus = txtStatus2.Text;
                    break;
                case "btnEdit3":
                    EditCashierForm.cashierName = txtName3.Text;
                    EditCashierForm.cashierStatus = txtStatus3.Text;
                    break;
                case "btnEdit4":
                    EditCashierForm.cashierName = txtName4.Text;
                    EditCashierForm.cashierStatus = txtStatus4.Text;
                    break;
            }

            EditCashierForm editCashier = new EditCashierForm();
            editCashier.StartPosition = FormStartPosition.Manual;
            int x = this.Location.X + (this.Width - editCashier.Width) / 2;
            int y = this.Location.Y + (this.Height - editCashier.Height) / 2;
            editCashier.Location = new Point(x, y);
            editCashier.ShowDialog();
        }

        public static string status;
        public static string name;

        private void btnEvent_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "UPDATE CashierActivity SET Name = @name, Status = @status WHERE ID = @id";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", currentButton[currentButton.Length - 1]);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            conn.Close();

            if (currentButton == "btnEdit1")
            {
                txtName1.Text = name;
                switch (status)
                {
                    case "Enabled":
                        txtStatus1.Text = "Enabled";
                        txtStatus1.Location = new Point(3, 6);
                        statusColor1.BackColor = Color.LimeGreen;
                        break;
                    case "Disabled":
                        txtStatus1.Text = "Disabled";
                        txtStatus1.Location = new Point(1, 6);
                        statusColor1.BackColor = Color.FromArgb(225, 0, 0);
                        break;
                }
            } 
            else if (currentButton == "btnEdit2")
            {
                txtName2.Text = name;
                switch (status)
                {
                    case "Enabled":
                        txtStatus2.Text = "Enabled";
                        txtStatus2.Location = new Point(3, 6);
                        statusColor2.BackColor = Color.LimeGreen;
                        break;
                    case "Disabled":
                        txtStatus2.Text = "Disabled";
                        txtStatus2.Location = new Point(1, 6);
                        statusColor2.BackColor = Color.FromArgb(225, 0, 0);
                        break;
                }
            }

            else if (currentButton == "btnEdit3")
            {
                txtName3.Text = name;
                switch (status)
                {
                    case "Enabled":
                        txtStatus3.Text = "Enabled";
                        txtStatus3.Location = new Point(3, 6);
                        statusColor3.BackColor = Color.LimeGreen;
                        break;
                    case "Disabled":
                        txtStatus3.Text = "Disabled";
                        txtStatus3.Location = new Point(1, 6);
                        statusColor3.BackColor = Color.FromArgb(225, 0, 0);
                        break;
                }
            }

            else if (currentButton == "btnEdit4")
            {
                txtName4.Text = name;
                switch (status)
                {
                    case "Enabled":
                        txtStatus4.Text = "Enabled";
                        txtStatus4.Location = new Point(3, 6);
                        statusColor4.BackColor = Color.LimeGreen;
                        break;
                    case "Disabled":
                        txtStatus4.Text = "Disabled";
                        txtStatus4.Location = new Point(1, 6);
                        statusColor4.BackColor = Color.FromArgb(225, 0, 0);
                        break;
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

    }
}

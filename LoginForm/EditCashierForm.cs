using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginForm
{
    public partial class EditCashierForm : Form
    {
        public static string cashierName;
        public static string cashierStatus;
        public EditCashierForm()
        {
            InitializeComponent();
        }

        private void EditCashierForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = cashierName;
            comboBox1.Text = cashierStatus;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CashierListFrm.name = textBox1.Text;
            CashierListFrm.status = comboBox1.Text;
            CashierListFrm.btnSave.PerformClick();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

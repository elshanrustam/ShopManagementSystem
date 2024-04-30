using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.Show();
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Show();
            Close();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

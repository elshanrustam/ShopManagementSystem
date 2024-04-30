using Microsoft.IdentityModel.Tokens;
using ShopManagementSystem.Entities;
using ShopManagementSystem.Interfaces;
using ShopManagementSystem.Repositories.EFCoreRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ShopManagementSystem
{
    public partial class Invoice : Form
    {
        private readonly BillingRepository _billingRepository;
        public Invoice()
        {
            InitializeComponent();
            _billingRepository = new BillingRepository();
        }


        private async void Invoice_Load(object sender, EventArgs e)
        {
            await FillDataGridAsync();
        }

        private async Task FillDataGridAsync()
        {
            dataGridView2.DataSource = await _billingRepository.GetAllAsync();
        }


        #region Labels
        private void label6_Click(object sender, EventArgs e)
        {
            Items items = new();
            items.Show();
            Close();
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

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
            Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
            Close();
        }

        #endregion


        #region Add
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCustomer.Text.IsNullOrEmpty() || txtAmount.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Form is not valid!");
                return;
            }

            Billing billing = new()
            {
                PaymentMode = cmbMode.Text,
                Amount = int.Parse(txtAmount.Text),
                CustomerId = int.Parse(txtCustomer.Text),
                BillingDate = DateTime.Now,
            };

            try
            {
                await _billingRepository.Add(billing);
                await _billingRepository.SaveChangesAsync();

                MessageBox.Show("Billing added successfully");

                await FillDataGridAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        #endregion


        #region Delete
        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            Billing selectedItem = (Billing)dataGridView2.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this billing?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _billingRepository.Remove(selectedItem);
                    await _billingRepository.SaveChangesAsync();

                    MessageBox.Show("Billing deleted successfully");

                    await FillDataGridAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            #endregion


        }
    }
}

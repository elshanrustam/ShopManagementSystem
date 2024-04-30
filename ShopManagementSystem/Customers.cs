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

namespace ShopManagementSystem
{
    public partial class Customers : Form
    {
        private readonly CustomerRepository _customerRepository;
        public Customers()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
        }

        private async void Customers_Load(object sender, EventArgs e)
        {
            await FillDataGridAsync();
        }
        private async Task FillDataGridAsync()
        {
            dataGridView1.DataSource = await _customerRepository.GetAllAsync();
        }


        #region Labels
        private void label6_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.Show();
            Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Categories categories = new Categories();
            categories.Show();
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
        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
            Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
            Close();
        }
        #endregion


        #region Delete
        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            Customer selectedItem = (Customer)dataGridView1.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this category?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _customerRepository.Remove(selectedItem);
                    await _customerRepository.SaveChangesAsync();

                    MessageBox.Show("Customer deleted successfully");

                    await FillDataGridAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        #endregion


        #region Add
        private async void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtName.Text.IsNullOrEmpty() || txtPhone.Text.IsNullOrEmpty() || cmbGender.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Form is not valid!");
                return;
            }

            Customer customer = new()
            {
                CustomerName = txtName.Text,
                PhoneNumber = txtPhone.Text,
                Gender = cmbGender.Text,
            };

            try
            {
                await _customerRepository.Add(customer);
                await _customerRepository.SaveChangesAsync();

                MessageBox.Show("Customer added successfully");

                await FillDataGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        #endregion


        #region Update
        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            Customer selectedRowItem = (Customer)dataGridView1.SelectedRows[0].DataBoundItem;

            try
            {
                _customerRepository.Update(selectedRowItem);
                await _customerRepository.SaveChangesAsync();

                await FillDataGridAsync();

                MessageBox.Show("Customer updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        #endregion

    }
}

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

    public partial class Categories : Form
    {
        private readonly CategoryRepository _categoryRepository;
        public Categories()
        {
            InitializeComponent();
            _categoryRepository = new CategoryRepository();
        }

        private async void Categories_Load_1(object sender, EventArgs e)
        {
            await FillDataGridAsync();
        }

        private async Task FillDataGridAsync()
        {
            dataGridView1.DataSource = await _categoryRepository.GetAllAsync();
        }


        #region Labels
        private void label6_Click(object sender, EventArgs e)
        {
            Items items = new Items();
            items.Show();
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

        private void label3_Click(object sender, EventArgs e)
        {
            Customers customers = new();
            customers.Show();
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

            Category selectedItem = (Category)dataGridView1.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this category?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _categoryRepository.Remove(selectedItem);
                    await _categoryRepository.SaveChangesAsync();

                    MessageBox.Show("Category deleted successfully");

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
            if (txtCategory.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Form is not valid!");
                return;
            }

            Category category = new()
            {
                CategoryName = txtCategory.Text,
            };

            try
            {
                await _categoryRepository.Add(category);
                await _categoryRepository.SaveChangesAsync();

                MessageBox.Show("Category added successfully");

                await FillDataGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        #endregion


        #region Update
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            Category selectedRowItem = (Category)dataGridView1.SelectedRows[0].DataBoundItem;

            try
            {
                _categoryRepository.Update(selectedRowItem);
                await _categoryRepository.SaveChangesAsync();

                await FillDataGridAsync();

                MessageBox.Show("Category updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        #endregion


    }
}

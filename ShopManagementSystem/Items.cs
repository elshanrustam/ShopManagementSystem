using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Contexts;
using ShopManagementSystem.Entities;
using ShopManagementSystem.Extensions;
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
    public partial class Items : Form
    {
        private readonly ItemRepository _itemRepository;
        private readonly CategoryRepository _categoryRepository;
        public Items()
        {
            InitializeComponent();
            _itemRepository = new ItemRepository();
            _categoryRepository = new CategoryRepository();
        }


        private async void Items_Load(object sender, EventArgs e)
        {
            await FillDataGridAsync();
            await FillComboBoxAsync();
        }
        private async Task FillDataGridAsync()
        {
           dataGridView1.DataSource = await _itemRepository.GetAllAsync();
        }
        private async Task FillComboBoxAsync()
        {
            cmbCategory.Items.Clear();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "Id";
            cmbCategory.DataSource = await _categoryRepository.GetAllAsync();
        }


        #region Labels

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

        private void label5_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
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
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new();
            dashboard.Show();
            Close();
        }
        #endregion


        #region Delete
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            Item selectedItem = (Item)dataGridView1.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _itemRepository.Remove(selectedItem);
                    await _itemRepository.SaveChangesAsync();

                    MessageBox.Show("Item deleted successfully");

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
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtItem.IsEmpty() || txtStock.IsEmpty() || !txtPrice.IsGreaterThan(3))
            {
                MessageBox.Show("Form is not valid!");
                return;
            }

            Item item = new()
            {
                ItemName = txtItem.Text,
                Price = decimal.Parse(txtPrice.Text),
                Stock = int.Parse(txtStock.Text),
                CategoryId = (int)cmbCategory.SelectedValue,
                Manufacturer = txtManu.Text,
            };

            try
            {
                await _itemRepository.Add(item);
                await _itemRepository.SaveChangesAsync();

                MessageBox.Show("Product added successfully");

                await FillDataGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        #endregion


        #region Update


        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            Item selectedRowItem = (Item)dataGridView1.SelectedRows[0].DataBoundItem;

            try
            {
                _itemRepository.Update(selectedRowItem);
                await _itemRepository.SaveChangesAsync();

                await FillDataGridAsync();

                MessageBox.Show("Item updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        } 
        #endregion


    }
}

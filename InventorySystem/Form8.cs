using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace InventorySystem
{
    
    public partial class frm_AddProduct : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public frm_AddProduct()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\EDWARD ENEJOSA\Desktop\InventorySystem\InventorySystem\CzaryCzaryStoreInventoryDB.accdb;Persist Security Info=False;";
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            if (txt_ProductName.Text == "")
            {
                MessageBox.Show("Please enter a Product Name", "Cannot Leave it Blank");
            }
            else if (txt_Category.Text == "")
            {
                MessageBox.Show("Please enter a Product Categry", "Cannot Leave it Blank");
            }
            else if (txt_Supplier.Text == "")
            {
                MessageBox.Show("Please enter a Product Supplier", "Cannot Leave it Blank");
            }
            else if (txt_Quantity.Text == "")
            {
                MessageBox.Show("Please enter a Quantity for this product", "Cannot Leave it Blank");
            }
            else if (txt_ProductPrice.Text == "")
            {
                MessageBox.Show("Please enter a Product Price", "Cannot Leave it Blank");
            }
            else
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into InventoryData (ProductName,Category,Supplier,Quantity,ProductPrice) values ('" + txt_ProductName.Text + "','" + txt_Category.Text + "','" + txt_Supplier.Text + "','" + txt_Quantity.Text + "','" + txt_ProductPrice.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Added Successfully", "Message");
                    connection.Close();

                    txt_Category.Text = "";
                    txt_ProductName.Text = "";
                    txt_Supplier.Text = "";
                    txt_Quantity.Text = "";
                    txt_ProductPrice.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                    connection.Close();
                }
            }
        }

        private void frm_AddProduct_Load(object sender, EventArgs e)
        {

        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txt_Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_ProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}

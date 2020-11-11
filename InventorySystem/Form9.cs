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
    public partial class frm_UpdateProduct : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public frm_UpdateProduct()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\EDWARD ENEJOSA\Desktop\InventorySystem\InventorySystem\CzaryCzaryStoreInventoryDB.accdb;Persist Security Info=False;";
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {

            if (txt_ProductID.Text == "")
            {
                MessageBox.Show("Please enter a ProductID", "Cannot Leave it Blank");
            }
            else if (txt_upProductName.Text == "")
            {
                MessageBox.Show("Please enter a ProductName", "Cannot Leave it Blank");
            }
            else if (txt_upCategory.Text == "")
            {
                MessageBox.Show("Please enter a Category", "Cannot Leave it Blank");
            }
            else if (txt_upSupplier.Text == "")
            {
                MessageBox.Show("Please enter a Supplier Name", "Cannot Leave it Blank");
            }
            else if (txt_upQuantity.Text == "")
            {
                MessageBox.Show("Please enter a Quantity", "Cannot Leave it Blank");
            }
            else if (txt_upProductPrice.Text == "")
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
                    string query = "update InventoryData set ProductName='" + txt_upProductName.Text + "' ,Category='" + txt_upCategory.Text + "' ,Supplier='" + txt_upSupplier.Text + "' ,Quantity='" + txt_upQuantity.Text + "' ,ProductPrice = '" + txt_upProductPrice.Text + "' where ProductID = " + txt_ProductID.Text + " ";
                    MessageBox.Show(query);
                    command.CommandText = query;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Successfully", "Message");
                    connection.Close();

                    txt_ProductID.Text = "";
                    txt_upProductName.Text = "";
                    txt_upCategory.Text = "";
                    txt_upSupplier.Text = "";
                    txt_upQuantity.Text = "";
                    txt_upProductPrice.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                    connection.Close();
                }
            }

        }

        private void frm_UpdateProduct_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txt_upQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_upProductPrice_KeyPress(object sender, KeyPressEventArgs e)
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

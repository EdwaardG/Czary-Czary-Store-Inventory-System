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
    public partial class frm_DeleteProduct : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public frm_DeleteProduct()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\EDWARD ENEJOSA\Desktop\InventorySystem\InventorySystem\CzaryCzaryStoreInventoryDB.accdb;Persist Security Info=False;";
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {

            if (txt_ProductID.Text == "")
            {
                MessageBox.Show("Please enter a ProductID", "Cannot Leave it Blank");
            }
            else
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = "delete from InventoryData where ProductID=" + txt_ProductID.Text + " ";
                    //MessageBox.Show(query);
                    command.CommandText = query;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Product has been remove successfully", "Message");
                    connection.Close();
                }
            catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                    connection.Close();
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txt_ProductID_KeyPress(object sender, KeyPressEventArgs e)
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

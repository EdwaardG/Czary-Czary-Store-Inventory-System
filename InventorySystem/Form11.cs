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
    public partial class frm_ViewInventory : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public frm_ViewInventory()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\EDWARD ENEJOSA\Desktop\InventorySystem\InventorySystem\CzaryCzaryStoreInventoryDB.accdb;Persist Security Info=False;";
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from InventoryData";
                //MessageBox.Show(query);
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridView_ProductInventory.DataSource = dt;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            frm_UpdateProduct UpdateProductOpen = new frm_UpdateProduct();
            UpdateProductOpen.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            frm_AddProduct AddProductOpen = new frm_AddProduct();
            AddProductOpen.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            frm_DeleteProduct DeleteProductOpen = new frm_DeleteProduct();
            DeleteProductOpen.ShowDialog();
        }

        private void gridView_ProductInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                DataGridViewRow row = gridView_ProductInventory.Rows[e.RowIndex];
                txt_ProductID.Text = row.Cells[0].Value.ToString();
                txt_upProductName.Text = row.Cells[1].Value.ToString();
                txt_upCategory.Text = row.Cells[2].Value.ToString();
                txt_upSupplier.Text = row.Cells[3].Value.ToString();
                txt_upQuantity.Text = row.Cells[4].Value.ToString();
                txt_upProductPrice.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Dashboard DashboardOpen = new frm_Dashboard();
            DashboardOpen.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

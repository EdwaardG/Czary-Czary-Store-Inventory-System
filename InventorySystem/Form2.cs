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
    public partial class frm_CreateAccount : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public frm_CreateAccount()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\EDWARD ENEJOSA\Desktop\InventorySystem\InventorySystem\CzaryCzaryStoreInventoryDB.accdb;Persist Security Info=False;";
        }

        private void frm_CreateAccount_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_createFname.Text == "")
            {
                MessageBox.Show("Can't leave anything blank, Please enter your Firstname.", "Creating Account Error");
            }
            else if (txt_createLname.Text == "")
            {
                MessageBox.Show("Can't leave anything blank, Please enter your Lastname.", "Creating Account Error");
            }
            else if (txt_createEmail.Text == "")
            {
                MessageBox.Show("Can't leave anything blank, Please enter your Email.", "Creating Account Error");
            }
            else if (txt_createUsername.Text == "")
            {
                MessageBox.Show("Can't leave anything blank, Please create a Username.", "Creating Account Error");
            }
            else if (txt_createPassword.Text == "")
            {
                MessageBox.Show("Can't leave anything blank, Please create a Password.", "Creating Account Error");
            }
            else if (txt_createConfirmPassword.Text == "")
            {
                MessageBox.Show("Can't leave anything blank, Please re-enter your password to verify.", "Creating Account Error");
            }
            else
            {
                try
                {
                    if (txt_createPassword.Text == txt_createConfirmPassword.Text)
                    {
                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "insert into UserData (FirstName,Username,LastName,Pw,Email) values ('" + txt_createFname.Text + "','" + txt_createUsername.Text + "','" + txt_createLname.Text + "','" + txt_createPassword.Text + "','" + txt_createEmail.Text + "')";
                        command.ExecuteNonQuery();
                        MessageBox.Show("Creating new account success", "Message");
                        connection.Close();

                        MessageBox.Show("Welcome " + txt_createUsername.Text + "!", "New User Logging In");
                        this.Hide();
                        frm_Dashboard dashboardOpen = new frm_Dashboard();
                        dashboardOpen.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Your password does not match, please try again.", "Creating Account Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            frm_Login LoginOpen = new frm_Login();
            LoginOpen.ShowDialog();
        }
    }
}

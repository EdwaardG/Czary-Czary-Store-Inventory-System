using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.ActiveControl = pictureBox1;                //Code For PlaceHolder
            textBox1.GotFocus += new EventHandler(this.TextIn);
            textBox1.LostFocus += new EventHandler(this.TextOut);
        }

        private void TextIn(object sender, EventArgs e)
        {
            TextBox p = (TextBox)sender;                //Code For PlaceHolder
            if (p.Text == "Enter Product Here")
            {
                p.Text = "";
                p.ForeColor = Color.Black;              //Code For PlaceHolder
            }
        }
        private void TextOut(object sender, EventArgs e)
        {
            TextBox p = (TextBox)sender;            //Code For PlaceHolder
            if (p.Text == "")
            {
                p.Text = "Enter Product Here";
                p.ForeColor = Color.Silver;         //Code For PlaceHolder
            }
        }

    }
}

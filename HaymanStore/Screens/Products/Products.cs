using HaymanStore.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaymanStore.Screens.Products
{
    public partial class Products : Form
    {
        Juxon_storeEntities db = new Juxon_storeEntities();

        public Products()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCode.Text == "" || txtWPrice.Text == "" || txtQty.Text == "")
            {
                MessageBox.Show("Please complete The required data!");

            }
            else
            {
                Product p = new Product();
                p.Name = txtName.Text;
                p.Notes = txtNotes.Text;
                p.Sell_price = decimal.Parse(txtSell.Text);
                p.buy_Price = decimal.Parse(txtWPrice.Text);
                p.Quantity = int.Parse(txtQty.Text);
                db.Products.Add(p);
                db.SaveChanges();
                MessageBox.Show("Complete!");
                txtName.Text = "";
                txtCode.Text = "";
                txtNotes.Text = "";
                txtWPrice.Text = "";
                txtQty.Text = "";

            }
        }
    }
}   

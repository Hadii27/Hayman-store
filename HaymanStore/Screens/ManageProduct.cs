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

namespace HaymanStore.Screens
{
    public partial class ManageProduct : UserControl
    {
        Juxon_storeEntities db = new Juxon_storeEntities();
        int id;
        public ManageProduct()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.Products.SingleOrDefault(x => x.id == id);


            result.Name = txtPname.Text;
            result.buy_Price = decimal.Parse(txtWPrice.Text);
            result.Sell_price = decimal.Parse(txt_sell.Text);
            result.Quantity = int.Parse(txtQty.Text);
            result.Notes = txtNotes.Text;
            db.SaveChanges();
            MessageBox.Show("Edited successfully! ");
            dataGridView1.DataSource = db.Products.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.Where(x => x.Name.Contains(txtName2.Text)).ToList();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.Products.SingleOrDefault(x => x.id == id);
                txtPname.Text = result.Name;
                txtWPrice.Text = result.buy_Price.ToString();
                txt_sell.Text = result.Sell_price.ToString();
                txtQty.Text = result.Quantity.ToString();
                txtNotes.Text = result.Notes;
            }
            catch { }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

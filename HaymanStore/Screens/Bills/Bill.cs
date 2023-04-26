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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;

namespace HaymanStore.Screens.Bills
{
    public partial class Bill : Form
    {
        Juxon_storeEntities db = new Juxon_storeEntities();
        int id;

        public Bill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
                try
                {
                    string[] arr = new string[4];
                    arr[0] = comboBox1.Text;
                    arr[1] = txtPrice.Text;
                    arr[2] = txtqty.Text;
                    arr[3] = txtTotal.Text;

                    ListViewItem l = new ListViewItem(arr);
                    listView1.Items.Add(l);

                    txtSub.Text = (Convert.ToInt16(txtSub.Text) + Convert.ToInt16(txtTotal.Text)).ToString();
                    invoice_info i = new invoice_info();
                    invoice b = new invoice();
                    i.Amount = int.Parse(txtqty.Text);
                    i.Price = decimal.Parse(txtPrice.Text);
                    i.Product_name = comboBox1.Text;
                    i.Cust_num = int.Parse(txtPhone.Text);
                    i.bill_id = b.bill_id;
                    db.invoices.Add(b);
                    db.invoice_info.Add(i);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


        }


        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (Convert.ToInt16(txtPrice.Text) * Convert.ToInt16(txtqty.Text)).ToString();

        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            txtAfter.Text = (Convert.ToInt16(txtSub.Text) - Convert.ToInt16(txtdiscount.Text)).ToString();

        }

        private void txtSub_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int stock = 0;
                int sell = 0;
                int Res = 0;
                int id = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
                var result = db.Products.SingleOrDefault(x => x.id == id);
                stock = Convert.ToInt16(txtStock.Text);
                sell = Convert.ToInt16(txtqty.Text);
                Res = stock - sell;
                result.Quantity = Res;
                invoice b = new invoice();
                b.Price = decimal.Parse(txtAfter.Text);
                b.Date = DateTime.Now;
                db.invoices.Add(b);
                db.SaveChanges();
                MessageBox.Show("Congratulations!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {   
                int id = int.Parse(comboBox1.SelectedValue.ToString());
                var result = db.Products.SingleOrDefault(x => x.id == id);
                if (result != null)
                {
                    txtStock.Text = result.Quantity.ToString();
                    txtPrice.Text = result.Sell_price.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void Bill_Load(object sender, EventArgs e)
        {
            var product = db.Products.Select(x=> new
            {
                id = x.id,
                Name = x.Name,

            }).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = product;
            
            comboBox1.Text = string.Empty;
            txtStock.Text = "";
            txtPrice.Text = "";


        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

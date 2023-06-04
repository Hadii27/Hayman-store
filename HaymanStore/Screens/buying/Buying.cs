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
namespace HaymanStore.Screens.buying
{
    public partial class Buying : Form
    {
        Juxon_storeEntities db = new Juxon_storeEntities();
        int id;
        
        public Buying()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string[] arr = new string[5];
                arr[0] = comboBox1.Text;
                arr[1] = txtPrice.Text;
                arr[2] = txtSname.Text;
                arr[3] = txtqty.Text;
                arr[4] = txtTotal.Text;

                ListViewItem l = new ListViewItem(arr);
                listView1.Items.Add(l);
                txtSub.Text = (Convert.ToDecimal(txtSub.Text) + Convert.ToDecimal(txtTotal.Text)).ToString();
                Buying_info i = new Buying_info();
                purchase p = new purchase();
                i.Qty = int.Parse(txtqty.Text);
                i.Price = decimal.Parse(txtPrice.Text);
                i.Pname = comboBox1.Text;
                i.Buy_id = p.Buy_id;
                i.Supp_name = txtSname.Text;
                db.purchases.Add(p);
                db.Buying_info.Add(i);
                db.SaveChanges();
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
                    txtPrice.Text = result.buy_Price.ToString();
                    txtStock.Text = result.Quantity.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Buying_Load(object sender, EventArgs e)
        {
            var product = db.Products.Select(x => new
            {
                id = x.id,
                Name = x.Name,

            }).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = product;
            comboBox1.Text = string.Empty;
            txtPrice.Text = "";
            txtStock.Text = "";
            txtqty.Text = "";

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
                txtTotal.Text = (Convert.ToInt64(txtPrice.Text) * Convert.ToInt64(txtqty.Text)).ToString();
                txtStock.Text = (Convert.ToInt64(txtqty.Text) + Convert.ToInt64(txtStock.Text)).ToString();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int stock = 0;
                int Sell = 0;
                int Res = 0;
                int id = int.Parse(comboBox1.GetItemText(comboBox1.SelectedValue));
                var result = db.Products.SingleOrDefault(x => x.id == id);
                stock = Convert.ToInt16(txtStock.Text);
                Sell = Convert.ToInt16(txtqty.Text);
                Res = stock + Sell;
                result.Quantity = Res;
                purchase b = new purchase();
                b.totaPrice = decimal.Parse(txtTotal.Text);
                b.Date = DateTime.Now;

                db.purchases.Add(b);
                db.SaveChanges();
                MessageBox.Show("Congratulations!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

   
    }
    
}

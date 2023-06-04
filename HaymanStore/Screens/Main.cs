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
    public partial class Main : Form
    {
        bool sidebarExpand;
        bool productExpand;

        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Products.ProductsManagement frm = new Products.ProductsManagement();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Customers.ManageCustomer frm = new Customers.ManageCustomer() ;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bills.Bill frm = new Bills.Bill();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buying.Buying frm = new buying.Buying();
            frm.Show();
        }



        private void button14_Click(object sender, EventArgs e)
        {
            Products.ProductsManagement frm = new Products.ProductsManagement();
            frm.Show();
        }



        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Users.NewUser frm = new Users.NewUser();
            frm.ShowDialog();
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                flowLayoutPanel1.Width -= 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();

                }
            }
            else
            {
                flowLayoutPanel1.Width += 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SidebarTimer.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProductTimer.Start();

        }

        private void ProductTimer_Tick(object sender, EventArgs e)
        {
            if (productExpand)
            {
                panel1.Height -= 10;
                if (panel1.Height == panel1.MinimumSize.Height)
                {
                    productExpand = false;
                    ProductTimer.Stop();

                }
            }
            else
            {
                panel1.Height += 10;
                if (panel1.Height == panel1.MaximumSize.Height)
                {
                    productExpand = true;
                    ProductTimer.Stop();
                }
            }
        }
    }
}

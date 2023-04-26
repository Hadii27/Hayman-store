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
        public Main()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void newUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users.NewUser frm = new Users.NewUser();
            frm.Show();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products.Products frm = new Products.Products();
            frm.Show();
        }

        private void editProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products.ProductsManagement frm = new Products.ProductsManagement();
            frm.Show();
        }

        private void listOfClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers.NewCustomers frm = new Customers.NewCustomers();
            frm.Show();
        }

        private void listOfClientsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customers.ManageCustomer frm = new Customers.ManageCustomer();
            frm.Show();
        }

        private void listOfProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products.ProductsManagement frm = new Products.ProductsManagement();
            frm.Show();
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
    }
}

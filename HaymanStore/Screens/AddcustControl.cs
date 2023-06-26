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
    public partial class AddcustControl : UserControl
    {
        Juxon_storeEntities db = new Juxon_storeEntities();

        public AddcustControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAddress.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please complete The required data!");

            }
            else
            {
                Customer c = new Customer();
                c.Name = txtName.Text;
                c.Mail = txtEmail.Text;
                c.Address = txtAddress.Text;
                c.Notes = txtNotes.Text;
                c.Phone = txtPhone.Text;
                db.Customers.Add(c);
                db.SaveChanges();
                MessageBox.Show("Complete!");
                txtName.Text = "";
                txtAddress.Text = "";
                txtNotes.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

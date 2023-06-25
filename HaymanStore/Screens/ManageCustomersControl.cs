using HaymanStore.DB;
using HaymanStore.Screens.Customers;
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
    public partial class ManageCustomersControl : UserControl
    {
        Juxon_storeEntities db = new Juxon_storeEntities();
        int id;

        public ManageCustomersControl()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.Customers.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.Customers.SingleOrDefault(x => x.id == id);


            result.Name = txtname.Text;
            result.Phone = txtPhone.Text;
            result.Address = txtAddress.Text;
            result.Gender = txtgender.Text;
            result.Notes = txtNotes.Text;
            db.SaveChanges();
            MessageBox.Show("Edited successfully! ");
            dataGridView1.DataSource = db.Customers.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhone2.Text)).ToList();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.Customers.SingleOrDefault(x => x.id == id);
                txtname.Text = result.Name;
                txtPhone.Text = result.Phone;
                txtNotes.Text = result.Notes;
                txtAddress.Text = result.Address;
                txtgender.Text = result.Gender;
                txtEmail.Text = result.Mail;
            }
            catch { }
        }

        private void txtPhone2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customers.Where(x => x.Phone.Contains(txtPhone2.Text)).ToList();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            NewCustomers frm = new NewCustomers();
            frm.Show();
        }
    }
}

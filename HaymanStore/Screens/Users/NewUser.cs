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

namespace HaymanStore.Screens.Users
{
    public partial class NewUser : Form
    {
        Juxon_storeEntities db = new Juxon_storeEntities();

        public NewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please complete The data!");

            }
            else
            {
                User u = new User();
                u.Name = txtUser.Text;
                u.Password = txtPass.Text;
                db.Users.Add(u);
                db.SaveChanges();
                MessageBox.Show("Saved");
            }

        }
    }
}

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

        private void addUsercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Products.ProductsManagement frm = new Products.ProductsManagement();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           ManageCustomersControl uc = new ManageCustomersControl();
            addUsercontrol(uc);
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
            ProductsControl uc = new ProductsControl();
            addUsercontrol(uc);
            uc.Show();
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
                sideBar.Width -= 10;
                if (sideBar.Width == sideBar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();

                }
            }
            else
            {
                sideBar.Width += 10;
                if (sideBar.Width == sideBar.MaximumSize.Width)
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

        private void sideBar_Paint(object sender, PaintEventArgs e)
        {
            sideBar.BringToFront();
        }
    }
}

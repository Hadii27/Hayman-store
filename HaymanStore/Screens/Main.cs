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

       

        private void button5_Click(object sender, EventArgs e)
        {
           ManageCustomersControl uc = new ManageCustomersControl();
            addUsercontrol(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           BillsControl uc = new BillsControl();
            addUsercontrol(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           BuyingControl uc = new BuyingControl();
            addUsercontrol(uc);
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
                Sidebar.Width -= 10;
                LogoutPanel.Width -= 10;
                if (LogoutPanel.Width == LogoutPanel.MinimumSize.Width & Sidebar.Width == Sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();

                }
            }
            else
            {
                Sidebar.Width += 10;
                LogoutPanel.Width += 10;
                if (LogoutPanel.Width == LogoutPanel.MaximumSize.Width & Sidebar.Width == Sidebar.MaximumSize.Width)
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
            LogoutPanel.BringToFront();
        }

        private void ProductTimer_Tick(object sender, EventArgs e)
        {
            if (productExpand)
            {
                ProductPanel.Height -= 10;
                if (ProductPanel.Height == ProductPanel.MinimumSize.Height)
                {
                    productExpand = false;
                    ProductTimer.Stop();

                }
            }
            else
            {
                ProductPanel.Height += 10;
                if (ProductPanel.Height == ProductPanel.MaximumSize.Height)
                {
                    productExpand = true;
                    ProductTimer.Stop();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProductTimer.Start();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ManageProduct uc = new ManageProduct();
            addUsercontrol(uc);
        }
    }
}

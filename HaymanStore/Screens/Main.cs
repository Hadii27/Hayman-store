using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaymanStore.Screens
{
    public partial class Main : Form
    {
        bool sidebarExpand;
        private login _login;
        bool productExpand;
        bool custExpand;
        public Main()
        {
            InitializeComponent();


        }
        public Main(login login)
        {
            InitializeComponent();
              _login = login;
        }
        private void animation(Panel panel, Timer time, bool Expand)
        {
             if (Expand)
            {
                panel.Height -= 10;

                if (panel.Height == panel.MinimumSize.Height)
                {
                    Expand = true;
                    time.Stop();

                }
            }
            else
            {
                panel.Height += 10;

                if (panel.Height == panel.MaximumSize.Height)
                {
                    Expand = false;
                    time.Stop();
                }
            }
            

            

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
            animation(ProductPanel, ProductTimer,productExpand);
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == "login");
            if (!isOpen)
            {
                login frm = new login();
                frm.Show();
            }
            else
            {
                _login.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            _login.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddcustControl uc = new AddcustControl();
            addUsercontrol(uc );
        }

        private void button8_Click(object sender, EventArgs e)
        {
            custTimer.Start();
        }

        private void custTimer_Tick(object sender, EventArgs e)
        {
            animation(panel3, custTimer, custExpand);
        }

        private void Sidebar_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

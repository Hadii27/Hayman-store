using HaymanStore.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaymanStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Juxon_storeEntities db = new Juxon_storeEntities();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        void openform()
        {
            Application.Run(new Screens.Main());
        }
    }
}

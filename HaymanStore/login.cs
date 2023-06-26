using HaymanStore.DB;
using HaymanStore.Screens;
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
    public partial class login : Form
    {
        public login()
        {
            Juxon_storeEntities db = new Juxon_storeEntities();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == "Main");
            if (!isOpen)
            {
                Main frm = new Main(this);
                frm.Show();
                this.Hide();
            }
        }
      
    }
}

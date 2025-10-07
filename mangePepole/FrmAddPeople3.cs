using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_Management__full_pro__1set
{
    public partial class frmAddPeople3 : Form
    {
        private int _conID;
        private UserControl1 userControl1;


        public frmAddPeople3(int conID)
        {

            InitializeComponent();
            _conID = conID;
        }

        private void frmAddPeople_Load(object sender, EventArgs e)
        {
            userControl1 = new UserControl1(_conID);
            userControl1.Dock = DockStyle.Fill;
            this.Controls.Add(userControl1);
            ////userControl1 = new UserControl1(_conID);
            ////this.Controls.Add(userControl1);
            //userControl11 = new UserControl1();
            //this.Controls.Add(userControl11);
        }

        public frmAddPeople3()
        {
            InitializeComponent();
           
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void userControl11_Load_1(object sender, EventArgs e)
        {

        }
    }
}

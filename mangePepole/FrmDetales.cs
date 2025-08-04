using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_Management__full_pro__1set
{
    public partial class FrmDetales : Form
    {
        int _conid;
        public FrmDetales( int con)
        {
            InitializeComponent();
            _conid = con;
        }

        private void FrmDetales_Load(object sender, EventArgs e)
        {
          
            UserControl2 user = new UserControl2(_conid);
            user.Dock = DockStyle.Fill;
            this.Controls.Add(user);
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }
    }
}

using BusinessLayer;
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
    public partial class manage_User : Form
    {
        public manage_User()
        {
            InitializeComponent();
        }

        DataView filtering() 
        {
            var dt  = clsContact.getUser();
            
            for (int i = 0; i < dt.Count; i++)
            {
                
                MessageBox.Show($"0{dt[i][0].ToString()}");
            }

            return dt;


        }


        private void manage_User_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsContact.getUser();
        }
    }
}

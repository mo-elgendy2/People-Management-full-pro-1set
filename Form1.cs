using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_Management__full_pro__1set
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void personControl11_Load(object sender, EventArgs e)
        {

        }

        private void pepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void btPeople_Click(object sender, EventArgs e)
        {
            Form frm = new MangePeople();
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /////////////////////////////////////////////
   
    }

        private void button3_Click(object sender, EventArgs e)
        {
 
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(button2,new Point(0,button2.Height));
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm log= new LoginForm();
            log.ShowDialog();
        }
    }
}

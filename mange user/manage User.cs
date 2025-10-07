using bescnesLayer.BusinessLayer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace People_Management__full_pro__1set
{
    public partial class manage_User : Form
    {
        DataTable dtUsers;
          
        public manage_User()
        {
            InitializeComponent();
        }
        private string GetColumnName(string displayName)
        {
            switch (displayName)
            {
                case "User ID": return "UserID";
                case "UserName": return "UserName";
                case "Person ID": return "PersonID";
                case "Full Name": return "FullName";
                case "Is Archive": return "IsArchive";
                default: return "";
            }
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
            dtUsers = clsUser.getUser();
            dataGridView1.DataSource = clsUser.getUser();
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            filterItim.Items.Add("None");
            filterItim.Items.Add("User ID");
            filterItim.Items.Add("UserName");
            filterItim.Items.Add("Person ID");
            filterItim.Items.Add("Full Name");
            filterItim.Items.Add("Is Archive");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            filterItim.SelectedIndex = 0; // الافتراضي "None"


            if (filterItim.SelectedIndex == 0)
            {
                textFilter.Visible = false;



            }
            else
            {
                textFilter.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = textFilter.Text.Trim();
            string columnName = GetColumnName(filterItim.SelectedItem.ToString());

            if (string.IsNullOrEmpty(columnName))
            {
                dtUsers.DefaultView.RowFilter = "";
                return;
            }

            if (string.IsNullOrEmpty(filterText))
            {
                dtUsers.DefaultView.RowFilter = "";
            }
            else
            {
                if (columnName == "UserID" || columnName == "PersonID" || columnName == "IsArchive")
                {
                    dtUsers.DefaultView.RowFilter = $"{columnName} = {filterText}";
                }
                else
                {
                    dtUsers.DefaultView.RowFilter = $"{columnName} LIKE '%{filterText}%'";
                }
            }
        }

    }
}


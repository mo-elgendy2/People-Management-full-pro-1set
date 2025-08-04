using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace People_Management__full_pro__1set
{
    public partial class MangePeople : Form
    {
        private int _conID;  // لحفظ الـ ID الممرر
        frmAddPeople3 frmAdd;
    

        // Constructor للمصمم فقط (ليس للاستخدام العادي)
        //public MangePeople() : this(-1)
        //{
        //}

        public MangePeople()
        {
            InitializeComponent();
        }
        public MangePeople( int conID)
        {
            InitializeComponent();

            _conID = conID;
        }

       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هفتح الفورم دلوقتي");

            frmAdd = new frmAddPeople3(-1);
            frmAdd.ShowDialog();
            _refresh();

        }

     






        //private int _ConID;

        //// ... الباقي كما هو ...

        ///// <summary>
        ///// دالة لتحميل بيانات الشخص داخل الكنترول
        ///// </summary>
        //public void LoadPerson(int conID)
        //{
        //    _ConID = conID;
        //    _refresh();  // هذه الدالة تملأ الـ DataGridView
        //}

       
        void _refresh()
        {
            dataGridViewPeople.DataSource = clsContact.GetallContacet();
            //DataTable dt = new DataTable();

            //// تعبئة dt بالبيانات (مثلاً من قاعدة بيانات أو يدويًا)
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Age");

            //dt.Rows.Add("Ahmed", 30);
            //dt.Rows.Add("Mona", 25);

            //// الآن ربط البيانات بالـ DataGridView
            //dataGridViewPeople.DataSource = dt;



        }
        public Button button1Public
        {
            get { return button1; }
        }
        void fliter()
        {
            if (comboFilter.SelectedItem == null || string.IsNullOrWhiteSpace(textBoxFiltter.Text))
            {
                dataGridViewPeople.DataSource = clsContact.GetallContacet();
                return;
            }

            DataView DV = clsContact.GetallContacet().DefaultView;

            string selectedValue = comboFilter.SelectedItem.ToString();
            string searchText = textBoxFiltter.Text.Trim();

            switch (selectedValue)
            {
                case "PersonID":
                case "NationalityCountryID":
                    if (int.TryParse(searchText, out int number))
                    {
                        DV.RowFilter = $"[{selectedValue}] = {number}";
                    }
                    else
                    {
                        DV.RowFilter = "1 = 0"; // خطأ في الرقم
                    }
                    break;

                case "DateOfBirth":
                    if (DateTime.TryParse(searchText, out DateTime dateVal))
                    {
                        DV.RowFilter = $"[{selectedValue}] = #{dateVal:MM/dd/yyyy}#";
                    }
                    else
                    {
                        DV.RowFilter = "1 = 0"; // خطأ في التاريخ
                    }
                    break;

                default:
                    // فلترة نصية
                    DV.RowFilter = $"[{selectedValue}] LIKE '%{searchText.Replace("'", "''")}%'";
                    break;
            }

            dataGridViewPeople.DataSource = DV;
        }


        private void dataGridViewPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.FindForm().Close();
        }

      

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selctedID = Convert.ToInt32(dataGridViewPeople.CurrentRow.Cells[0].Value);
            frmAddPeople3 frm = new frmAddPeople3(selctedID);
            frm.ShowDialog();
            _refresh();

        }
        //private void ApplyFilter()
        //{
        //    if (dataGridViewPeople.DataSource == null) return;

        //    string column = comboFilter.SelectedItem.ToString();
        //    string value = textBoxFiltter.Text.Trim().Replace("'", "''");

        //    if (string.IsNullOrEmpty(value))
        //    {
        //        (dataGridViewPeople.DataSource as DataTable).DefaultView.RowFilter = "";
        //    }
        //    else
        //    {
        //        (dataGridViewPeople.DataSource as DataTable).DefaultView.RowFilter =
        //            $"[{column}] LIKE '%{value}%'";
        //    }
        //}


        private void MangePeople_Load(object sender, EventArgs e)
        {
            _refresh();
            fliter();
            //ApplyFilter();
            dataGridViewPeople.AllowUserToAddRows = false;



        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            
        
            MessageBox.Show("هفتح الفورم دلوقتي");

            frmAdd = new frmAddPeople3(-1);
            frmAdd.ShowDialog();
            _refresh();

        
    }

        private void updateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int selectedID = (int)dataGridViewPeople.CurrentRow.Cells[0].Value;
            MessageBox.Show("Selected ID = " + selectedID);
            frmAdd = new frmAddPeople3(selectedID);
            frmAdd.ShowDialog();

            

            _refresh();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هفتح الفورم دلوقتي");

            frmAdd = new frmAddPeople3(-1);
            frmAdd.ShowDialog();
            _refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedID = (int)dataGridViewPeople.CurrentRow.Cells[0].Value;
             frmAdd = new frmAddPeople3(selectedID);
            frmAdd.ShowDialog();
            _refresh();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int PersonID = (int)dataGridViewPeople.CurrentRow.Cells["PersonID"].Value;
            MessageBox.Show("Selected ID = " + PersonID);

            DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                clsContact.Delete(PersonID);
            }
            _refresh();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnAdd_Click_1(sender, e);
        }

        private void upDateToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            button1_Click(sender, e); 
                
         }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewPeople.SelectedRows.Count > 0)
            {
                int contactID = Convert.ToInt32(dataGridViewPeople.SelectedRows[0].Cells[0].Value);
                MessageBox.Show(" do you want delete this ?"," confirm",MessageBoxButtons.OKCancel) ;   
                clsContact.Delete(contactID);

                dataGridViewPeople.Rows.RemoveAt(dataGridViewPeople.SelectedRows[0].Index);

                MessageBox.Show("تم حذف الشخص بنجاح");
            }
            else
            {
                MessageBox.Show("يرجى تحديد صف للحذف.");
            }

            
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedID = (int)dataGridViewPeople.CurrentRow.Cells[0].Value;

            FrmDetales frm6 = new FrmDetales(selectedID);

            //UserControl2 us = new UserControl2(selectedID);
            //frm6.Controls.Add(us);
            frm6.ShowDialog();
        
        }
    }
}

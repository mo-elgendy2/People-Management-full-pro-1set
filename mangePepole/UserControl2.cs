using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace People_Management__full_pro__1set
{
    public partial class UserControl2 : UserControl
    {
     private   clsContact _Person;
        int _PersonId;

        public UserControl2()
        {
            InitializeComponent();
            
        }
        public UserControl2(int person)
        {
            InitializeComponent();
            _PersonId = person;
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }


        void  LoadPerson()
        {
            _Person =clsContact.Find(_PersonId);
            if (_PersonId <= 0)
            {
                MessageBox.Show("❌ الرقم المرسل غير صالح.");
                return;
            }
            label13.Text = _Person.ID.ToString();
            string fullname =( _Person.FirstName + _Person.SecondName+ _Person.ThirdName+_Person.LastName).ToString();
            label1.Text=fullname;
            label2.Text = _Person.NationalNo.ToString();
            if (_Person.Gendor==0)
            {
                label3.Text = _Person.Gendor.ToString("male");

            }
            else { label3.Text = _Person.Gendor.ToString("female"); }

                label4.Text = _Person.Email.ToString();
            label16.Text = _Person.Address.ToString();
            label26.Text=_Person.DateOfBirth.ToString();
            label27.Text=_Person.Phone.ToString();
            label28.Text = clsContact.GetCountryNameByID(_Person.CountryID);
            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pictureBox1.Image = Image.FromFile(_Person.ImagePath);
            }
            else
            { 
            
                pictureBox1.Image = null;
            }


        }
        private void UserControl2_Load(object sender, EventArgs e)
        {
            LoadPerson();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = Application.OpenForms["MangePeople"] as MangePeople;

            if (frm != null)
            {
                // الكائن موجود... شغلك هنا
                frm.button1Public.PerformClick();
            }
            else
            {
                MessageBox.Show("الفورم مش مفتوح أو الاسم غير صحيح.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}

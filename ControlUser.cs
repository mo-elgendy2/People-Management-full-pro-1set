using People_Management__full_pro__1set.Properties;
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
using BusinessLayer;

namespace People_Management__full_pro__1set
{
    public partial class Uosr_pepole_1 : UserControl
    {

        public enum enMode { Update = 0, Add = 1 }
        private enMode _mode;


        private int _ConID;
        clsContact _Contact;


        /// <summary>
        /// يحمل بيانات شخص أو يهيئ وضع الإضافة
        /// </summary>
        public void LoadPerson(int conID)
        {
            _ConID = conID;
            _mode = (_ConID == -1) ? enMode.Add : enMode.Update;
            LoadData();
        }


        //public Uosr_pepole_1()
        //{
        //    InitializeComponent();
        //}


        public Uosr_pepole_1(int conID)
        {
            InitializeComponent();

            _ConID = conID;

            if (_ConID == -1)
            {
                _mode = enMode.Add;
            }


            else
            {
                _mode = enMode.Update;
            }
            //LoadData();


        }
        private string SaveImageToProjectFolder(string sourcePath)
        {
            // اسم مجلد الصور
            string imagesFolder = Path.Combine(Application.StartupPath, "Images");

            // لو المجلد مش موجود، أنشئه
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);

            // اسم جديد عشوائي للصورة (لتجنب التكرار)
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourcePath);
            string destinationPath = Path.Combine(imagesFolder, fileName);

            // انسخ الصورة للمجلد
            File.Copy(sourcePath, destinationPath, true);

            return destinationPath; // ده اللي هتخزنه في قاعدة البيانات
        } ////////////// شات جيبتي


        public string GetSelectedGender()

        {
            var selected = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
            if (selected != null)
                return selected.Tag?.ToString();
            else
                return null;



        }
        private void _fillCountry()
        {
            DataTable dtCountry = clsContact.GetAllCountries();
            foreach (DataRow row in dtCountry.Rows)
            {
                comboBox2.Items.Add(row["CountryName"]);

            }

        }
        void savePHotofile()
        {
            //SaveImageToProjectFolder(pictureBox1.ImageLocation);
            if (pictureBox1.ImageLocation != null)
            {
                MessageBox.Show(" ! image");
                //_Contact.ImagePath = pictureBox1.ImageLocation; 
                string savedPath = SaveImageToProjectFolder(pictureBox1.ImageLocation);
                _Contact.ImagePath = savedPath;


            }
            else
            {
                _Contact.ImagePath = "";
            }

            //try
            //{
            //    string folder = Application.StartupPath + @"\Photos";
            //    Directory.CreateDirectory(folder); // لو المجلد مش موجود، هيعمل   gggg system.io

            //    string fileName = txtNationalNo.Text.Trim() + ".jpg";

            //    string fullPath = Path.Combine(folder, fileName);

            //    // نحفظ الصورة في الملف بالصيغة المطلوبة
            //    pictureBox1.Image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    MessageBox.Show("✔️ الصورة اتحفظت بنجاح");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("❌ خطأ أثناء حفظ الصورة:\n" + ex.Message);
            //}


        }

        public string GenSave()
        {
            string gender;

            if (RdBtnMan.Checked)
                gender = RdBtnMan.Tag.ToString();
            else
                gender = RdBtnfemale.Tag.ToString();

            // تستخدم gender هنا مثلاً:
            MessageBox.Show(gender);

            return gender;

        }
        private void LoadData()
        {

            _fillCountry();
            if (_mode == enMode.Add)

            {
                label6.Text = " AddNew Person";
                _Contact = new clsContact();
                return;
            }
            if (_mode==enMode.Update&&_ConID!=-1)
            {
                _Contact = clsContact.Find(_ConID);
             


            }
            //if (_Contact == null)
            //{
            //    MessageBox.Show("This form will be closed because No Contact with ID = " + _ConID);
            //    //this.FindForm().Close();

            //    return;
            //}
            label6.Text = "UpDate Person id =" + _ConID;
            LbID.Text = _ConID.ToString();
            textBox1.Text = _Contact.FirstName;
            textBox2.Text = _Contact.SecondName;
            textBox3.Text = _Contact.ThirdName;
            textBox4.Text = _Contact.LastName;
            textBox5.Text = _Contact.Phone;
            textBox6.Text = _Contact.Email;
            textBox7.Text = _Contact.Address;
            comboBox2.SelectedIndex = _Contact.CountryID;
            dateTimePicker1.Value = _Contact.DateOfBirth;

            if (_Contact.ImagePath == "")
            {

                pictureBox1.Load(_Contact.ImagePath);
            }
            linkLabel1.Visible = (_Contact.ImagePath != "");



        }


        private void button3_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = " image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Multiselect = false;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = openFileDialog1.FileName;

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "هل أنت متأكد ؟", // نص الرسالة
       "تأكيد ",                   // عنوان الرسالة
       MessageBoxButtons.OKCancel,      // نوع الأزرار
       MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {

                this.FindForm().Close();

            }
            else
                return;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.admin_female;
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "  we shoud a vشlue!");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }

        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox2, "We should enter a value!");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            string NaTH = txtNationalNo.Text.Trim();
            if (string.IsNullOrWhiteSpace(NaTH))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(txtNationalNo, "  we shoud a 14 num");


            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void Uosr_pepole_1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" save?!");
            _Contact.FirstName = textBox1.Text.Trim();
            _Contact.SecondName = textBox2.Text.Trim();
            _Contact.ThirdName = textBox3.Text.Trim();
            _Contact.LastName = textBox4.Text.Trim();
            _Contact.Phone = textBox5.Text.Trim();
            _Contact.Email = textBox6.Text.Trim();
            _Contact.Address = textBox7.Text.Trim();
            _Contact.DateOfBirth = dateTimePicker1.Value;
            _Contact.CountryID = comboBox2.SelectedIndex;
            //if (RdBtnMan.Checked)
            
            //    _Contact.Gendor =RdBtnMan.Tag.ToString();
            //else  (RdBtnfemale.Checked)
            //    _Contact.Gendor == RdBtnfemale.Tag.ToString();

           //GenSave();
            savePHotofile();
            if (_Contact.Save())
            {


                MessageBox.Show("data save successfly");
            }
            else
            {
                MessageBox.Show("data not saveed error!!!!");
            }
            _mode = enMode.Update;
            label6.Text = "Edit :Date Is Saved Sucessfully";
            LbID.Text = _Contact.ID.ToString();






        }

        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

      

        private void RdBtnMan_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.librarian;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            linkLabel1.Visible = false;
        }

       
    }
}

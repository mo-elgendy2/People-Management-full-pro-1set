using BusinessLayer;
using People_Management__full_pro__1set.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace People_Management__full_pro__1set
{
    public partial class UserControl1 : UserControl
    {

        private int _Contactid = -1;
        clsContact _Contact;
        public enum EnMode { Add = 0, UpDate = 1 };
        private EnMode _Mode;
        void RestDefualtValyous()
        {



            if (_Mode == EnMode.Add)
            {
                label11.Text = "Add Person";
                _Contact = new clsContact();
                _fillCountryCopoBox();

                return;
            }
            //else
            //{
            //    label11.Text = "u12pdata";
            //}
            //GetSelectedGenderdor();
            //dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
            //dateTimePicker1.Value = dateTimePicker1.MaxDate;
            //textBox1.Text = "";
            // textBox2.Text="";
            // textBox3.Text="";
            // textBox4.Text="";
            // textBox5.Text="";
            // textBox6.Text="";
            // textBox7.Text="";
            // textBox8.Text="";
            //radioButtonman.Checked=true;


        }

        public UserControl1()
        {
            InitializeComponent();

            _Mode = EnMode.Add;
            _Contactid = -1;
            return;

        }
        public UserControl1(int Contactid)
        {
            InitializeComponent();
            if (Contactid == -1)
            {
                _Mode
                    = EnMode.Add;

                return;
            }
            _Mode = EnMode.UpDate;
            _Contactid = Contactid;


        }
        //public int ContactID
        //{
        //    get { return _Contactid; }
        //    set
        //    {
        //        _Contactid = value;
        //        _Mode = (_Contactid == -1) ? EnMode.Add : EnMode.UpDate;
        //    }
        //}


        private void _fillCountryCopoBox()
        {

            DataTable dt = clsContact.GetAllCountries();
            //foreach ( DataRow c in dt.Rows ) 
            //{
            //    comboBox1.Items.Add(c["CountryName"]);


            //}
            //comboBox1.SelectedIndex = 50;
            //comboBox1.DisplayMember = "CountryName";        // اسم الدولة اللي يظهر
            //comboBox1.ValueMember = "CountryID";            // القيمة المرتبطة (هتستخدمها في الحفظ)
            //comboBox1.DataSource = dt;
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "CountryName";
            comboBox1.ValueMember = "CountryID";
            comboBox1.SelectedIndex = 50;

        }
        private void LoadGender()
        {
            if (_Contact.Gendor == 1)
            {
                radioButtonFemale.Checked = true;
            }
            else if (_Contact.Gendor == 0)
            {
                radioButtonman.Checked = true;
            }
           
        }

        //private int GetSelectedGenderdor()
        //{


        //    //var gendor = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
        //    ////var selectedRadio = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
        //    ////if (gendor != null)
        //    ////    return gendor;
        //    ////else
        //    ////    return null; // أو قيمة افتراضية زي "غير محدد"
        //    //return gendor?.Tag?.ToString();
        private int GetSelectedGender()
        {
            var selectedRadio = groupBox1.Controls
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);

            if (selectedRadio != null && selectedRadio != null)
            {
                return Convert.ToInt32(selectedRadio);
            }

            return -1; // في حالة عدم تحديد أي خيار
        }



        private byte GetSelectedGenderAsByte()
        {
            if (radioButtonman.Checked)
                return 0;
            else if (radioButtonFemale.Checked)
                return 1;
            else
                return 255; // قيمة خاطئة عشان نكتشف الخطأ لاحقًا
        }



        public void LoadPerson(int Personid)//update
        {


            _Contact = clsContact.Find(Personid);


            _Mode = EnMode.UpDate;

            label11.Text = "upppppp11 data Person";
            label13.Text = _Contactid.ToString();
            //_Contact = new clsContact();
            //return;

            if (_Contact == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _Contactid);
                this.FindForm()?.Close();
                return;
            }
            _Contactid = Personid; // احفظه للاستخدام لاحقًا


            label11.Text = "Edit Person ID " + _Contactid;

            textBox1.Text = _Contact.FirstName;
            textBox2.Text = _Contact.SecondName;
            textBox3.Text = _Contact.ThirdName;
            textBox4.Text = _Contact.LastName;
            textBox5.Text = _Contact.NationalNo;
            textBox6.Text = _Contact.Email;
            textBox7.Text = _Contact.Address;
            textBox8.Text = _Contact.Phone;
            label13.Text = _Contact.ID.ToString();
            dateTimePicker1.Value = _Contact.DateOfBirth;
            comboBox1.SelectedValue = _Contact.CountryID;

            MessageBox.Show("Loading from: " + _Contact.ImagePath);
             if (_Contact.ImagePath != "") 
            {
                pictureBox1.ImageLocation = _Contact.ImagePath;
            
            }
            // تحميل الصورة
            //if (!string.IsNullOrEmpty(_Contact.ImagePath) && File.Exists(_Contact.ImagePath))
            //{
            //    pictureBox1.Load(_Contact.ImagePath);
            //    linkLabel1.Visible = true;
            //}
            //else
            //{
            //    pictureBox1.Image = null;
            //    //linkLabel2.Visible = false;
            //}
            if (_Contact.Gendor == 0)
            {
                 radioButtonman.Checked = true;

            }
            else  radioButtonFemale.Checked = true; 
                //_Contact.Gendor = GetSelectedGender();
            //byte gender = GetSelectedGenderAsByte();
            //if (gender == 255)
            //{
            //    MessageBox.Show("❌ من فضلك اختر النوع (ذكر أو أنثى).");
            //    return;
            //}

          

        //    if (_Contact.Gendor == 0)
        //    {
        //        radioButtonman.Checked = true;

        //    }
        //    else if (_Contact.Gendor == 1)
        //        radioButtonFemale.Checked = true;

        }




        
        private DateTime BirhtofDate()
        {
            //DateTime SLD = dateTimePicker1.Value;
            //dateTimePicker1.MaxDate = new DateTime(2008, 1, 1);

            return dateTimePicker1.Value = DateTime.Now.AddYears(-18);


        }

        private PictureBox SaveImage(PictureBox pictureBox1)
        {
            // تأكد إن فيه صورة أصلًا محمّلة
            if (pictureBox1.Image == null || string.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                MessageBox.Show("There is no image to save.");
                return pictureBox1;
            }

            string folderSave = @"D:\People";

            // أنشئ المجلد إذا لم يكن موجودًا
            if (!Directory.Exists(folderSave))
            {
                Directory.CreateDirectory(folderSave);
            }

            string oldImagePath=_Contact.ImagePath;

            try
            {
                if (oldImagePath != null && File.Exists(oldImagePath))
                {

                    if (pictureBox1.Image != null)
                    {
                        //pictureBox1.Image.Dispose(); هيرمي اكسبشن
                        pictureBox1.Image = null;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }
                    File.Delete(oldImagePath);


                }
                // اسم فريد للصورة باستخدام Guid (لتفادي تكرار الأسماء)
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(pictureBox1.ImageLocation);

                // المسار الجديد لحفظ الصورة
                string newFilePath = Path.Combine(folderSave, fileName);

                // انسخ الصورة من مكانها الحالي إلى مجلد الحفظ
                File.Copy(pictureBox1.ImageLocation, newFilePath, true);

                // حدث مسار الصورة في PictureBox
                pictureBox1.ImageLocation = newFilePath;

               
                // اربط المسار بالكائن _Contact
                _Contact.ImagePath = newFilePath;
                //if (_Contact.ImagePath != null && File.Exists(_Contact.ImagePath))
                //{

                //    if (pictureBox1.Image != null)
                //    {
                //        pictureBox1.Image.Dispose();
                //        pictureBox1.Image = null;

                //    }
                //    File.Delete(_Contact.ImagePath);


                //}



                MessageBox.Show("✅ Image saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the image: " + ex.Message);
            }

            return pictureBox1;
        }


        public void LoadData()
        {
            _fillCountryCopoBox();

            LoadPerson(_Contactid);


        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //    if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            //
            //   return;
            RestDefualtValyous();

            if (_Mode == EnMode.UpDate)
            {
                LoadData();

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                int countryID = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Please select a country first.");
            }
            byte gender = GetSelectedGenderAsByte();
            if (gender == 255)
            {
                MessageBox.Show("❌ Please select the gender (Male or Female).");
                return;
            }
            _Contact.Gendor = gender;


            
            _Contact.FirstName = textBox1.Text.Trim();
            _Contact.SecondName = textBox2.Text.Trim();
            _Contact.ThirdName = textBox3.Text.Trim();
            _Contact.LastName = textBox4.Text.Trim();
            _Contact.NationalNo = textBox5.Text.Trim();
            _Contact.Email = textBox6.Text.Trim();
            _Contact.Address = textBox7.Text.Trim();
            _Contact.Phone = textBox8.Text.Trim();

          

            //_Contact.Gendor = GetSelectedGenderAsByte();
            _Contact.DateOfBirth = dateTimePicker1.Value;
            _Contact.CountryID = Convert.ToInt32(comboBox1.SelectedValue);
            //SaveImage(pictureBox1);


            //if (_Contact.Save())
            //    MessageBox.Show("Data Saved Successfully.");
            //else
            //    MessageBox.Show("Error: Data Is not Saved Successfully.");

            // حفظ الصورة فقط لو تم اختيارها من الجهاز (مش من Resources)
            if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                SaveImage(pictureBox1);
            }
            else
            {
                // لو الصورة من الريسورس
                _Contact.ImagePath = null;
            }

            // محاولة حفظ البيانات

            try
            {
                bool result = _Contact.Save();
                if (result)
                {
                    MessageBox.Show("✅ Data has been saved successfully.");
                }
                else
                {
                    MessageBox.Show("❌ Data was not saved. Check the code.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ حدث خطأ أثناء الحفظ:\n" + ex.Message);
            }
        

        _Mode = EnMode.UpDate;
            label11.Text = "Edit Contact ID = " + _Contact.ID;
            label13.Text = _Contact.ID.ToString();


            }



        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "select image";
            openFileDialog1.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                string select=openFileDialog1.FileName;
                MessageBox.Show("Selected Image is:" + select);

                pictureBox1.Load(select);
                
            }


        }

        public void delete()
        {
            try
            {
                string imagePath = _Contact.ImagePath;

                // تأكد إن الصورة موجودة
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    // فك ارتباط PictureBox بالصورة لو كانت معروضة
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;

                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }

                    // حذف الملف من القرص
                    File.Delete(imagePath);
                    _Contact.ImagePath = null;

                    MessageBox.Show("✅ تم حذف الصورة من القرص بنجاح.");
                }
                else
                {
                    MessageBox.Show("❌ الصورة غير موجودة على القرص.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ خطأ أثناء حذف الصورة:\n" + ex.Message);
            }
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            delete();

            linkLabel2.Visible = true;
        }

        private void radioButtonman_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.librarian1;
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Image =Resources.admin_female;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, " shoud A  valuo");
            }
            else {
                e.Cancel= false;
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider1.SetError(textBox2, " shoud A  valuo");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider1.SetError(textBox3, " shoud A  valuo");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox3, "");

            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider1.SetError(textBox4, " shoud A  valuo");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox4, "");

            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider1.SetError(textBox5, " shoud A  valuo");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox5, "");

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider1.SetError(textBox6, " shoud A  valuo");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox6, "");

            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                e.Cancel = true;
                textBox7.Focus();
                errorProvider1.SetError(textBox7, " shoud A  valuo");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox7, "");

            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                e.Cancel = true;
                textBox8.Focus();
                errorProvider1.SetError(textBox8, " shoud A  valuo");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox8, "");

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);

            dateTimePicker1.Value = DateTime.Now.AddYears(-18);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

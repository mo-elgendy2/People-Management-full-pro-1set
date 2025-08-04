using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace People_Management__full_pro__1set
{
    public partial class LoginForm : Form
    {

        string usersFile = "MYfile.txt";
        string rememberFile = "remember.txt";
        int attempts = 0;
        const int maxAttempts = 3;

        void rememper() 
        {
            string x1, x2;
            x1 = textBox1.Text.ToString();
            x2 = textBox2.Text.ToString();
            string save = rememberFile;
            string content = x1 + Environment.NewLine + x2;
           
                System.IO.File.WriteAllText(save, content);
            


        }
        void RememberUser()
        {
            if (radioButton1.Checked)
            {
                string user = textBox1.Text.Trim();
                string pass = textBox2.Text.Trim();
                string content = user + Environment.NewLine + pass;
                System.IO.File.WriteAllText(rememberFile, content);
            }
            else
            {
                // لو مش عايز يتذكره نحذف الملف
                if (System.IO.File.Exists(rememberFile))
                    System.IO.File.Delete(rememberFile);
            }
        }

        void LoadRememberedUser()
        {
            if (System.IO.File.Exists(rememberFile))
            {
                string[] lines = System.IO.File.ReadAllLines(rememberFile);
                if (lines.Length >= 2)
                {
                    textBox1.Text = lines[0];
                    textBox2.Text = lines[1];
                    radioButton1.Checked = true;
                }
            }
        }



        void CreateUserFileIfNotExists()//// تجربه  
        {
            string path = "MYfile.txt";

            if (!System.IO.File.Exists(path))
            {
                // إضافة مستخدم افتراضي
                string defaultUser = "Username: admin, Password: 1234";
                System.IO.File.WriteAllText(path, defaultUser);
            }
        }


        public LoginForm()
        {
            InitializeComponent();
        }

        bool findUser(string username, string Password)
        {
            string filePath = usersFile;
            if (!System.IO.File.Exists(filePath))
                return false;

            string[] lines = System.IO.File.ReadAllLines(filePath);

            foreach (var l in lines)
            {
                if (l.Trim() == $"Username: {username}, Password: {Password}")

                    //if (l.StartsWith($"UserName:{username},Password{Password}"))
                {
                    return true;

                }
            }

            return false;

        }
        void WriteUserInfo(string username, string password)
        {
            FileStream Myfile = new FileStream(usersFile, FileMode.Append, FileAccess.Write);
            //            StreamReader reader = new StreamReader(Myfile);

            string data = $"Username: {username}, Password: {password}\n";
            byte[] byteData = Encoding.UTF8.GetBytes(data); // هذا هو التعريف مهم

            Myfile.Seek(0, SeekOrigin.End);
            Myfile.Write(byteData, 0, byteData.Length);




        }
        void loadUserInfo(string username, string password)
        {
            string[] users = System.IO.File.ReadAllLines("MYfile.txt");




        }
        bool Checklogin(string username, string password)
        {

            return findUser(username, password);

        }

        void login()
        {
            bool loginSuccess = true;

            string userName = textBox1.Text.Trim();
            string Password = textBox2.Text.Trim();
            loginSuccess = Checklogin(userName, Password);

            if (!loginSuccess)
            {
                attempts++;

                int remaining = maxAttempts - attempts;

                lblAttempts.Text = $"Attempts Left: {remaining}";

                MessageBox.Show("❌ The username or password is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (attempts >= maxAttempts)
                {
                    MessageBox.Show("Too many failed attempts. The app will now close.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }

                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();

                return;
            }

            // نجاح الدخول
            MessageBox.Show("✅ Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Hide();
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RememberUser();
            login();
          

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;

            LoadRememberedUser();
            CreateUserFileIfNotExists();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;

        }
    }
}

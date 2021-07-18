using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Đồ_án_ltwin
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxConfirmPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            LOGIN lgin = new LOGIN();
            if (TextBoxPassword.Text == TextBoxConfirmPass.Text)
            {
                int id;
                Random rd = new Random();
                id = rd.Next(1, 1000);
                string username = TextBoxUsername.Text;
                string password = TextBoxPassword.Text;
                string fname = TextBoxFname.Text;
                string lname = TextBoxLname.Text;
                string phone = TextBoxPhone.Text;
                DateTime bdate = DateTimePicker1.Value;
                string gender = "Male";
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }
                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;

                if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The Student Age Must Be Between 10 and 100 years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    if (!lgin.customeridExist(id))
                    {
                        PictureBoxImage.Image.Save(pic, PictureBoxImage.Image.RawFormat);
                        if (lgin.insertCustomer(id, username, password, fname, lname, bdate, pic, gender, phone))
                        {
                            NotificationSignup notisignup = new NotificationSignup(TextBoxFname.Text);
                            notisignup.Show(this);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Confirm the password!", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Hide();
        }
        bool verif()
        {
            if ((TextBoxUsername.Text.Trim()==""||TextBoxPassword.Text.Trim()==""||TextBoxFname.Text.Trim() == "") || (TextBoxLname.Text.Trim() == "")  || (PictureBoxImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxImage.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}

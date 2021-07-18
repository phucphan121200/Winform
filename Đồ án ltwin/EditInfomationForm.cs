using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace Đồ_án_ltwin
{
    public partial class EditInfomationForm : Form
    {
        public EditInfomationForm()
        {
            InitializeComponent();
        }
        User us = new User();
        private void EditInfomationForm_Load(object sender, EventArgs e)
        {
            ButtonEye1.Visible = false;
            ButtonEye2.Visible = false;
            ButtonEye3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            loaddata();
        }
        public void loaddata()
        {
            int id = int.Parse(Global.ID);
            SqlCommand command = new SqlCommand("SELECT id,username, fname, lname, gender, phone FROM Login WHERE id = " + id);
            DataTable table = us.getUsers(command);
            if (table.Rows.Count > 0)
            {
                TextBoxID.Text = Global.ID;
                TextBoxuser.Text = table.Rows[0]["username"].ToString();
                TextBoxID.Enabled = false;
                TextBoxuser.Enabled = false;
                TextBoxFname.Text = table.Rows[0]["fname"].ToString();
                TextBoxLname.Text = table.Rows[0]["lname"].ToString();
                if (table.Rows[0]["gender"].ToString().Trim() == "Female")
                {
                    RadioButtonFemale.Checked = true;

                }
                else if (table.Rows[0]["gender"].ToString().Trim() == "Male")
                {
                    RadioButtonMale.Checked = true;
                }

                TextBoxPhone.Text = table.Rows[0]["phone"].ToString();
            }
            else
            {
                MessageBox.Show("not found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        bool verif()
        {
            if ((TextBoxID.Text.Trim() == "")
                || (TextBoxFname.Text.Trim() == "")
                || (TextBoxLname.Text.Trim() == "")
                || (TextBoxPhone.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            ButtonEye1.Visible = false;
            ButtonEye2.Visible = false;
            ButtonEye3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            ButtonGeneral.Checked = true;
            TextBoxID.Visible = true;
            RadioButtonMale.Visible = true;
            RadioButtonFemale.Visible = true;
            TextBoxPhone.Visible = true;
            LabelID.Visible = true;
            LabelLname.Visible = true;
            LabelDoB.Visible = true;
            LabelPhone.Visible = true;
            LabelUsernameID.Text = "Username";
            LabelPassword.Text = "FirstName";
            LabelLname.Text = "LastName";
            TextBoxuser.UseSystemPasswordChar = false;
            TextBoxFname.UseSystemPasswordChar = false;
            TextBoxLname.UseSystemPasswordChar = false;
            loaddata();
        }
        
        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            ButtonEye1.Visible = true;
            ButtonEye2.Visible = true;
            ButtonEye3.Visible = true;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            ButtonSecurity.Checked = true;
            TextBoxID.Visible = false;
            RadioButtonMale.Visible = false;
            RadioButtonFemale.Visible = false;
            TextBoxPhone.Visible = false;
            LabelID.Visible = false;
            LabelDoB.Visible = false;
            LabelPhone.Visible = false;
            LabelUsernameID.Text = "Password";
            LabelPassword.Text = "New Password";
            LabelLname.Text = "Confirm";
            TextBoxuser.Text = "";
            TextBoxFname.Text = "";
            TextBoxLname.Text = "";
            TextBoxuser.Enabled = true;
            TextBoxuser.UseSystemPasswordChar = true;
            TextBoxFname.UseSystemPasswordChar = true;
            TextBoxLname.UseSystemPasswordChar = true;
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {
            if (ButtonGeneral.Checked == true)
            {
                int id;
                string user = TextBoxuser.Text;
                string fname = TextBoxFname.Text;
                string lname = TextBoxLname.Text;
                string phone = TextBoxPhone.Text;
                string gender = "Male";
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }
                else if (verif())
                {
                    try
                    {
                        id = Convert.ToInt32(Global.ID);
                        if (us.updateUser(id, fname, lname, gender, phone))
                        {
                            MessageBox.Show("Your Information Updated", "Edit Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            if (ButtonSecurity.Checked == true)
            {
                int id;
                string pass = TextBoxFname.Text;
                string currentpass = TextBoxuser.Text;
                id = Convert.ToInt32(Global.ID);
                if (verif())
                {
                    if (us.existPass(currentpass))
                    {
                        if (TextBoxFname.Text == TextBoxLname.Text)
                        {
                            if (us.updatePass(id, pass))
                            {
                                MessageBox.Show("Your Password has been changed", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Confirm the password", "Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Current Password is not correct", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Field", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gunaLabel1_MouseEnter_1(object sender, EventArgs e)
        {
            gunaLabel1.Text = "UPDATE";
            gunaLabel1.BackColor = Color.White;
            gunaLabel1.ForeColor = Color.SteelBlue;
        }

        private void gunaLabel1_MouseLeave(object sender, EventArgs e)
        {
            gunaLabel1.Text = "";
            gunaLabel1.BackColor = Color.Transparent;
            gunaLabel1.ForeColor = Color.Transparent;
        }

        private void ButtonEye1_Click(object sender, EventArgs e)
        {
            TextBoxuser.UseSystemPasswordChar = false;
        }

        private void ButtonEye2_Click(object sender, EventArgs e)
        {
            TextBoxFname.UseSystemPasswordChar = false;
        }

        private void ButtonEye3_Click(object sender, EventArgs e)
        {
            TextBoxLname.UseSystemPasswordChar = false;
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            Hide();
            MenuForm menu = new MenuForm();
            menu.Show(this);
        }
    }
}

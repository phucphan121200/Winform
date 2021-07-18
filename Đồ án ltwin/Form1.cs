using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Đồ_án_ltwin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxUsername.ForeColor = Color.Gray;
            textBoxUsername.Text = "Username";
            this.textBoxUsername.Leave += new System.EventHandler(this.textBoxUsername_Leave);
            this.textBoxUsername.Enter += new System.EventHandler(this.textBoxUsername_Enter);
            textBoxPassword.ForeColor = Color.Gray;
            textBoxPassword.Text = "Password";
            this.textBoxPassword.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);


        }
        MY_DB mydb = new MY_DB();
        EditInfomationForm editinfo = new EditInfomationForm();

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxUsername_BackColorChanged(object sender, EventArgs e)
        {
            
        }

        private void ButtonLogin_Click_1(object sender, EventArgs e)
        {
            if(RadioButtonWarehouse.Checked==true)
            {
                //try
                //{

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username = @User AND password = @Pass", mydb.getConnection);

                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUsername.Text;

                    command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxPassword.Text;

                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {
                        int userId = Convert.ToInt16(table.Rows[0][8].ToString());
                        Global.SetGlobalUserId(userId);
                        editinfo.TextBoxID.Text = table.Rows[0][8].ToString();
                        Global.SetId(editinfo.TextBoxID.Text);
                    Global.check = 6;
                    LoadingForm load = new LoadingForm();
                    load.Show(this);
                    Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
                //finally
                //{
                //    Close();
                //}
            }
            if (RadioButtonStaff.Checked==true)
            {
                //try
                //{

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand("SELECT * FROM QL WHERE username = @User AND password = @Pass", mydb.getConnection);

                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUsername.Text;

                    command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxPassword.Text;

                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {
                        int userId = Convert.ToInt16(table.Rows[0][8].ToString());
                        Global.SetGlobalUserId(userId);
                        editinfo.TextBoxID.Text = table.Rows[0][8].ToString();
                        Global.SetId(editinfo.TextBoxID.Text);

                    Global.check = 5;
                    EnterCode enterCode = new EnterCode();
                    enterCode.Show(this);
                    Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
                
            }
            if(RadioButtonWarehouse.Checked==false && RadioButtonStaff.Checked==false)
            {
                MessageBox.Show("Please choose your part", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show(this);

        }

        private void gunaTransfarantPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBoxPassword.Focus();
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (RadioButtonWarehouse.Checked == true)
                {
                    //try
                    //{

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username = @User AND password = @Pass", mydb.getConnection);

                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUsername.Text;

                    command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxPassword.Text;

                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {
                        int userId = Convert.ToInt16(table.Rows[0][8].ToString());
                        Global.SetGlobalUserId(userId);
                        editinfo.TextBoxID.Text = table.Rows[0][8].ToString();
                        Global.SetId(editinfo.TextBoxID.Text);
                        Global.check = 6;
                        LoadingForm load = new LoadingForm();
                        load.Show(this);
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw ex;
                    //}
                    //finally
                    //{
                    //    Close();
                    //}
                }
                if (RadioButtonStaff.Checked == true)
                {
                    //try
                    //{

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand("SELECT * FROM QL WHERE username = @User AND password = @Pass", mydb.getConnection);

                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = textBoxUsername.Text;

                    command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxPassword.Text;

                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {
                        int userId = Convert.ToInt16(table.Rows[0][8].ToString());
                        Global.SetGlobalUserId(userId);
                        editinfo.TextBoxID.Text = table.Rows[0][8].ToString();
                        Global.SetId(editinfo.TextBoxID.Text);

                        Global.check = 5;
                        EnterCode enterCode = new EnterCode();
                        enterCode.Show(this);
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    throw ex;
                    //}

                }
                if (RadioButtonWarehouse.Checked == false && RadioButtonStaff.Checked == false)
                {
                    MessageBox.Show("Please choose your part", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonLogin.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageAllForm mange = new ManageAllForm();
            mange.Show(this);
        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            if(textBoxUsername.Text=="Username")
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {                
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.Text = "Password";
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
    
}

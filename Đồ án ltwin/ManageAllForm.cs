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
    public partial class ManageAllForm : Form
    {
        public ManageAllForm()
        {
            InitializeComponent();
        }

        MEMBER mem = new MEMBER();
        LOGIN customer = new LOGIN();
        private void PictureBoxImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxImage.Image = Image.FromFile(opf.FileName);
            }
        }
        MenuForm menu = new MenuForm();
        bool verif()
        {
            if ((TextBoxUsernameID.Text.Trim() == "")
                || (TextBoxFname.Text.Trim() == "")
                || (TextBoxLname.Text.Trim() == "")
                || (TextBoxPasswordAddress.Text.Trim() == "")
                || (TextBoxPhone.Text.Trim() == "")
                || (PictureBoxImage.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public void fillGrid(SqlCommand command)
        {
            
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = customer.getCustomers(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (Global.check==1)
            {
                int id = Convert.ToInt32(TextBoxUsernameID.Text);
                string fname = TextBoxFname.Text;
                string lname = TextBoxLname.Text;
                DateTime bdate = DateTimePicker1.Value;
                string phone = TextBoxPhone.Text;
                string adrs = TextBoxPasswordAddress.Text;
                string gender = TextBoxProduct.Text;
                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;

                if (!mem.memberExist(id))
                {
                    if (verif())
                    {
                        PictureBoxImage.Image.Save(pic, PictureBoxImage.Image.RawFormat);
                        if (mem.insertMember(id, fname, lname, bdate, gender, phone, adrs, pic))
                        {
                            MessageBox.Show("New Store Added", "Add Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Add Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields", "Add Store", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
                    fillGrid(new SqlCommand("SELECT id AS ID, fname AS Store, lname AS Name, bdate AS FD, gender AS NoP, phone AS Phone, " +
                    "address AS Address, picture AS Picture FROM std"));
                }
                else
                {
                    MessageBox.Show("This ID is already", "Add Store", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if(Global.check==2)
            {
                int id;
                Random rd = new Random();
                id = rd.Next(1, 1000);
                string user = TextBoxUsernameID.Text;
                string fname = TextBoxFname.Text;
                string lname = TextBoxLname.Text;
                DateTime bdate = DateTimePicker1.Value;
                string phone = TextBoxPhone.Text;
                string pass = TextBoxPasswordAddress.Text;
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
                else if (!customer.customerExist(user))
                {
                    if (!customer.customeridExist(id))
                    {
                        if (verif())
                        {
                            PictureBoxImage.Image.Save(pic, PictureBoxImage.Image.RawFormat);
                            if (customer.insertCustomer(id, user, pass, fname, lname, bdate, pic, gender, phone))
                            {
                                MessageBox.Show("New Member Added", "Add Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error", "Add Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Empty Fields", "Add Member", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
                        fillGrid(new SqlCommand("SELECT id as ID,fname as FirstName,lname as LastName,username as Username,bdate as DoB,gender as Gender" +
                    ",phone as Phone, picture as Picture FROM Login"));
                    }
                }
                else
                {
                    TextBoxUsernameID.Enabled = false;
                    TextBoxPasswordAddress.Enabled = false;
                }
            }
        }

        private void ManageAllForm_Load(object sender, EventArgs e)
        {
            if(Global.check==1)
            {
                ButtonAdd.Visible = true;
                TextBoxUsernameID.Enabled = true;
                TextBoxPasswordAddress.Enabled = true;
                Label1.Text = (TextBoxFname.Text +" "+ TextBoxLname.Text);
                fillGrid(new SqlCommand("SELECT id AS ID, fname AS Store, lname AS Name, bdate AS FD, gender AS NoP, phone AS Phone, " +
                    "address AS Address, picture AS Picture FROM std"));
            }
            if(Global.check==2)
            {

                TextBoxProduct.Visible = false;
                ButtonAdd.Visible = false;
                TextBoxUsernameID.Enabled = false;
                TextBoxPasswordAddress.Enabled = false;
                SqlCommand command = new SqlCommand("SELECT id as ID,fname as FirstName,lname as LastName,username as Username,bdate as DoB,gender as Gender" +
                    ",phone as Phone, picture as Picture FROM Login");
                fillGrid(command);
                Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
                TextBoxUsernameID.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
                TextBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                TextBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                DateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;

                if ((dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Female    "))
                {
                    RadioButtonFemale.Checked = true;
                }
                else if ((dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Male      "))
                {
                    RadioButtonMale.Checked = true;
                }

                TextBoxPhone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
                TextBoxPasswordAddress.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxImage.Image = Image.FromStream(picture);
                Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (Global.check==1)
            {
                LabelUsernameID.Text = ("ID");
                LabelPasswordAddress.Text = ("Address");
                TextBoxUsernameID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                TextBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                TextBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                DateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
                TextBoxProduct.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
                //if ((dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female    "))
                //{
                //    RadioButtonFemale.Checked = true;
                //}
                //else if ((dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Male      "))
                //{
                //    RadioButtonMale.Checked = true;
                //}

                TextBoxPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
                TextBoxPasswordAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();

                byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxImage.Image = Image.FromStream(picture);
                Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
            }
            if (Global.check==2)
            {
                TextBoxProduct.Visible = false;
                LabelUsernameID.Text = ("Username");
                LabelPasswordAddress.Text = ("ID");
                Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
                TextBoxUsernameID.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
                TextBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                TextBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                DateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;

                if ((dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Female    "))
                {
                    RadioButtonFemale.Checked = true;
                }
                else if ((dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Male      "))
                {
                    RadioButtonMale.Checked = true;
                }

                TextBoxPhone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
                TextBoxPasswordAddress.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxImage.Image = Image.FromStream(picture);
                Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if(Global.check==1)
            {
                try
                {
                    int id = Convert.ToInt32(TextBoxUsernameID.Text);
                    if ((MessageBox.Show("Do you want to Delete this store? ", "Delete Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (mem.deleteMember(id))
                        {
                            MessageBox.Show("Store Deleted", "Delete Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Label1.Text = "";
                            TextBoxUsernameID.Text = "";
                            TextBoxFname.Text = "";
                            TextBoxLname.Text = "";
                            TextBoxPasswordAddress.Text = "";
                            TextBoxPhone.Text = "";
                            DateTimePicker1.Value = DateTime.Now;
                            PictureBoxImage.Image = null;
                            Label1.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Store Not Deleted", "Delete Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter A Valid", "Delete Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                fillGrid(new SqlCommand("SELECT id AS ID, fname AS Store, lname AS Name, bdate AS FD, gender AS NoP, phone AS Phone, " +
                    "address AS Address, picture AS Picture FROM std"));
            }
            if (Global.check==2)
            {
                try
                {
                    string user = TextBoxUsernameID.Text;
                    if ((MessageBox.Show("Do you want to Delete this member? ", "Delete Member", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        if (customer.deleteCustomer(user))
                        {
                            MessageBox.Show("Member Deleted", "Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Label1.Text = "";
                            TextBoxUsernameID.Text = "";
                            TextBoxFname.Text = "";
                            TextBoxLname.Text = "";
                            TextBoxPasswordAddress.Text = "";
                            TextBoxPhone.Text = "";
                            DateTimePicker1.Value = DateTime.Now;
                            PictureBoxImage.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Member Not Deleted", "Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter A Valid", "Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                fillGrid(new SqlCommand("SELECT id as ID,fname as FirstName,lname as LastName,username as Username,bdate as DoB,gender as Gender" +
                    ",phone as Phone, picture as Picture FROM Login"));
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if(Global.check==1)
            {
                int id;
                string fname = TextBoxFname.Text;
                string lname = TextBoxLname.Text;
                DateTime bdate = DateTimePicker1.Value;
                string phone = TextBoxPhone.Text;
                string adrs = TextBoxPasswordAddress.Text;
                string gender = TextBoxProduct.Text;                
                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;
                if (verif())
                {
                    try
                    {
                        id = Convert.ToInt32(TextBoxUsernameID.Text);
                        PictureBoxImage.Image.Save(pic, PictureBoxImage.Image.RawFormat);
                        if (mem.updateMember(id, fname, lname, bdate, gender, phone, adrs, pic))
                        {
                            MessageBox.Show("Store Information Updated", "Edit Store", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit Store", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Store", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Field", "Edit Store", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
                fillGrid(new SqlCommand("SELECT id AS ID, fname AS Store, lname AS Name, bdate AS FD, gender AS NoP, phone AS Phone, " +
                    "address AS Address, picture AS Picture FROM std"));
            }
            else if (Global.check == 2)
            {
                
                string username= TextBoxUsernameID.Text;
                string fname = TextBoxFname.Text;
                string lname = TextBoxLname.Text;
                DateTime bdate = DateTimePicker1.Value;
                string phone = TextBoxPhone.Text;
                string gender = "Male";
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }
                MemoryStream pic = new MemoryStream();
                int born_year = DateTimePicker1.Value.Year;
                int this_year = DateTime.Now.Year;
                if (((this_year - born_year) < 10) || (this_year - born_year > 100))
                {
                    MessageBox.Show("The Student Age Must Be Between 10 and 100 year", "Birth Date Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (verif())
                {
                    try
                    {
                        PictureBoxImage.Image.Save(pic, PictureBoxImage.Image.RawFormat);
                        if (customer.updateCustomer(username,fname,lname,bdate,pic,gender,phone))
                        {
                            MessageBox.Show("Member Information Updated", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Field", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Label1.Text = (TextBoxFname.Text + " " + TextBoxLname.Text);
                fillGrid(new SqlCommand("SELECT id as ID,fname as FirstName,lname as LastName,username as Username,bdate as DoB,gender as Gender" +
                    ",phone as Phone, picture as Picture FROM Login"));
            }
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show(this);
            Hide();
        }
    }
}

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
using System.Drawing.Printing;
using Đồ_án_ltwin.Class;

namespace Đồ_án_ltwin
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            TextBoxSearch.ForeColor = Color.Gray;
            TextBoxSearch.Text = "Search...";
            this.TextBoxSearch.Leave += new System.EventHandler(this.TextBoxSearch_Leave);
            this.TextBoxSearch.Enter += new System.EventHandler(this.TextBoxSearch_Enter);

        }
        DataTable tblKH;
        DataTable tblNCC;
        DataTable tblH;
        MY_DB mydb = new MY_DB();
        MEMBER member = new MEMBER();
        LOGIN customer = new LOGIN();
        public void getImageUsername()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE id=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Global.GlobalUserId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                PicUser.Image = Image.FromStream(picture);
                Label1.Text=table.Rows[0]["fname"].ToString();

            }
        }
        private void MenuForm_Load(object sender, EventArgs e)
        {
            Global.check = 1;
            getImageUsername();
            //if (ButtonCustomer.Checked == true)
            //{
            //    dataGridView1.Refresh();
            //    SqlCommand command = new SqlCommand("SELECT id AS ID,fname AS Store,lname AS Name,bdate AS FD,gender AS NoP, phone AS Phone," +
            //        "address AS Address, picture AS Picture FROM std");
            //    fillGrid(command);
            //    gunaLabel1.Text = "Total Store: " + dataGridView1.Rows.Count;
            //}
            dataGridView1.RowTemplate.Height = 80;
            string sql;
            sql = "SELECT MaNCC, TenNCC FROM tblNhaCC"; Functions.Connect();
            tblNCC = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dataGridView1.DataSource = tblNCC; //Nguồn dữ liệu            
            dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
            gunaLabel1.Text = "Total Supplier: " + dataGridView1.Rows.Count;

        }
        public void fillGrid(SqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = member.getMembers(command);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

        }
       
        private void ButtonContract_Click(object sender, EventArgs e)
        {

            //frmDMNhaCC ncc = new frmDMNhaCC();
            //ncc.Show(this);
            //frmHoaDonBan hdb = new frmHoaDonBan();  // chua chay được
            //hdb.Show(this);
            frmDMKhachHang kh = new frmDMKhachHang(); // loi sdt
            string sql;
            sql = "SELECT * from tblKhach";
            Functions.Connect();
            tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dataGridView1.DataSource = tblKH; //Hiển thị vào dataGridView
            dataGridView1.Columns[0].HeaderText = "Mã khách";
            dataGridView1.Columns[1].HeaderText = "Tên khách";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Điện thoại";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            gunaLabel1.Text = "Total Customer: " + dataGridView1.Rows.Count;
            //kh.Show(this);


            dataGridView1.Refresh();
        }
        private void ButtonProduct_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblHang";
            Functions.Connect();
            tblH = Functions.GetDataToTable(sql);
            dataGridView1.DataSource = tblH;
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Tên hàng";
            dataGridView1.Columns[2].HeaderText = "Nhà cung cấp";
            dataGridView1.Columns[3].HeaderText = "Số lượng";
            dataGridView1.Columns[4].HeaderText = "Đơn giá nhập";
            dataGridView1.Columns[5].HeaderText = "Đơn giá bán";
            
            dataGridView1.Columns[6].HeaderText = "Bảo hành + giảm giá";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            
            dataGridView1.Columns[6].Width = 300;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            gunaLabel1.Text = "Total Product: " + dataGridView1.Rows.Count;
        }
        private void ButtonNCC_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaNCC, TenNCC FROM tblNhaCC"; Functions.Connect();
            tblNCC = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dataGridView1.DataSource = tblNCC; //Nguồn dữ liệu            
            dataGridView1.Columns[0].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[1].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
            gunaLabel1.Text = "Total Supplier: " + dataGridView1.Rows.Count;
        }
        private void ButtonMember_Click(object sender, EventArgs e)
        {
            Global.check = 1;            
            dataGridView1.Refresh();
            SqlCommand command = new SqlCommand("SELECT id AS ID,fname AS Store,lname AS Name,bdate AS FD,gender AS NoP, phone AS Phone," +
                    "address AS Address, picture AS Picture FROM std");           
            fillGrid(command);
            gunaLabel1.Text = "Total Store: " + dataGridView1.Rows.Count;
            //this.dataGridView1.Columns[3].Visible = false;
        }

        
        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            //EnterCode enterform = new EnterCode();
            //enterform.Show();
            Global.check = 2;
                dataGridView1.Refresh();
                SqlCommand command = new SqlCommand("SELECT id as ID,fname as FirstName,lname as LastName,username as Username,bdate as DoB,gender as Gender" +
                    ",phone as Phone, picture as Picture FROM Login");
                fillGrid(command);
            gunaLabel1.Text = "Total Member: " + dataGridView1.Rows.Count;
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string commd = "select * from std where concat(fname,lname,address) like '%" + TextBoxSearch.Text + "%'";
            string cus = "select * from Login where concat(fname,lname) like '%" + TextBoxSearch.Text + "%'";
            SqlCommand command = new SqlCommand(commd, mydb.getConnection);
            SqlCommand commandd = new SqlCommand(cus, mydb.getConnection);
            if (ButtonMembers.Checked == true)
            {
                if(TextBoxSearch.Text=="")
                {
                    dataGridView1.Refresh();
                }
                command.Parameters.Add("@us", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                command.Parameters.Add("@ps", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                command.Parameters.Add("@fn", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                command.Parameters.Add("@ln", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                command.Parameters.Add("@phn", SqlDbType.VarChar).Value = TextBoxSearch.Text;

            }
            else 
            if (ButtonCustomer.Checked == true)
            {
                
                    if (TextBoxSearch.Text == "")
                    {
                        dataGridView1.Refresh();
                    }
                    //command.Parameters.Add("@id", SqlDbType.Int).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@fn", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@ln", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@phn", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                
            }
            if(ButtonCustomer.Checked==true)
            {
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                dataGridView1.ReadOnly = true;
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                dataGridView1.RowTemplate.Height = 80;

                dataGridView1.DataSource = table;

                picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AllowUserToAddRows = false;
            }
            if (ButtonMembers.Checked == true)
            {
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(commandd);
                adapter.Fill(table);
                dataGridView1.ReadOnly = true;
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                dataGridView1.RowTemplate.Height = 80;

                dataGridView1.DataSource = table;

                picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void TextBoxSearch_Leave(object sender, EventArgs e)
        {
            if (TextBoxSearch.Text == "")
            {
                TextBoxSearch.Text = "Search...";
                TextBoxSearch.ForeColor = Color.Gray;
            }
        }

        private void TextBoxSearch_Enter(object sender, EventArgs e)
        {
            if (TextBoxSearch.Text == "Search...")
            {
                TextBoxSearch.Text = "";
                TextBoxSearch.ForeColor = Color.Black;
            }
        }

        private void TextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string commd = "select * from std where concat(fname,lname,address) like '%" + TextBoxSearch.Text + "%'";
                string cus = "select * from Login where concat(fname,lname) like '%" + TextBoxSearch.Text + "%'";
                SqlCommand command = new SqlCommand(commd, mydb.getConnection);
                SqlCommand commandd = new SqlCommand(cus, mydb.getConnection);
                if (ButtonMembers.Checked == true)
                {
                    if (TextBoxSearch.Text == "")
                    {
                        dataGridView1.Refresh();
                    }
                    command.Parameters.Add("@us", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@ps", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@fn", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@ln", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@phn", SqlDbType.VarChar).Value = TextBoxSearch.Text;

                }
                else
                if (ButtonCustomer.Checked == true)
                {

                    if (TextBoxSearch.Text == "")
                    {
                        dataGridView1.Refresh();
                    }
                    //command.Parameters.Add("@id", SqlDbType.Int).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@fn", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@ln", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@phn", SqlDbType.VarChar).Value = TextBoxSearch.Text;
                    command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = TextBoxSearch.Text;

                }
                if (ButtonCustomer.Checked == true)
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                    dataGridView1.ReadOnly = true;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    dataGridView1.RowTemplate.Height = 80;

                    dataGridView1.DataSource = table;

                    picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    dataGridView1.AllowUserToAddRows = false;
                }
                if (ButtonMembers.Checked == true)
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(commandd);
                    adapter.Fill(table);
                    dataGridView1.ReadOnly = true;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    dataGridView1.RowTemplate.Height = 80;

                    dataGridView1.DataSource = table;

                    picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    dataGridView1.AllowUserToAddRows = false;
                }
            }
        }
        //Xử lý click       
        private void gunaButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.check = 3;
            Hide();
            EditInfomationForm editInfomationForm = new EditInfomationForm();
            editInfomationForm.Show(this);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Restart();
            Environment.Exit(0);
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (ButtonCustomer.Checked == true)
            {
                Global.check = 1;
                ManageAllForm manage = new ManageAllForm();
                manage.LabelUsernameID.Text = ("ID");
                manage.LabelPasswordAddress.Text = ("Address");
                manage.LabelNoP.Text = "NoP";
                manage.LabelDoB.Text = "FD";
                manage.RadioButtonFemale.Visible = false;
                manage.RadioButtonMale.Visible = false;
                manage.TextBoxUsernameID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                manage.TextBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                manage.TextBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                manage.DateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
                manage.TextBoxProduct.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
                //if ((dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female    "))
                //{
                //    manage.RadioButtonFemale.Checked = true;
                //}
                //else if ((dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Male      "))
                //{
                //    manage.RadioButtonMale.Checked = true;
                //}

                manage.TextBoxPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
                manage.TextBoxPasswordAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();

                byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream(pic);
                manage.PictureBoxImage.Image = Image.FromStream(picture);
                Hide();
                manage.Show();
                ButtonCustomer.Checked = true;
            }
            if (ButtonMembers.Checked == true)
            {
                Global.check = 2;
                ManageAllForm manage = new ManageAllForm();
                manage.TextBoxPasswordAddress.Enabled = false;
                manage.TextBoxUsernameID.Enabled = false;
                manage.TextBoxProduct.Visible = false;
                manage.TextBoxUsernameID.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
                manage.TextBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
                manage.TextBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
                manage.DateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;

                if ((dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Female    "))
                {
                    manage.RadioButtonFemale.Checked = true;
                }
                else if ((dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Male      "))
                {
                    manage.RadioButtonMale.Checked = true;
                }

                manage.TextBoxPhone.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
                manage.TextBoxPasswordAddress.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();
                byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream(pic);
                manage.PictureBoxImage.Image = Image.FromStream(picture);
                manage.Show(this);
                manage.Hide();
                EnterCode code = new EnterCode();
                code.Show(this);
                Hide();
                ButtonMembers.Checked = true;
            }
            if (ButtonContract.Checked == true)
            {
                frmDMKhachHang kh = new frmDMKhachHang();
                kh.Show(this);
                Hide();
                ButtonMembers.Checked = true;
            }
            if(ButtonProduct.Checked == true)
            {
                frmDMHang h = new frmDMHang();
                h.Show(this);
                Hide();
                ButtonMembers.Checked = true;
            }
            if (ButtonNCC.Checked == true)
            {
                frmDMNhaCC nhaCC = new frmDMNhaCC();
                nhaCC.Show(this);
                Hide();
                ButtonMembers.Checked = true;
            }
        }

        private void PicUser_Click(object sender, EventArgs e)
        {
            Global.check = 3;
            ChangePic changePic = new ChangePic();
            changePic.Show(this);
            Hide();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            if(ButtonCustomer.Checked==true)
            {
                SaveFileDialog savefile = new SaveFileDialog() { Filter = "Text Document|*.txt|Text Word|*.doc|Text Excel|*.xls", ValidateNames = true };
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    DateTime bdate;
                    StreamWriter writer = new StreamWriter(File.Create(savefile.FileName));
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                        {
                            if (j == 3)
                            {
                                bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                                writer.Write("\t" + bdate.ToString("yyyy-MM-dd") + "\t" + "|");
                            }
                            else if (j == dataGridView1.Columns.Count - 2)
                            {
                                writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                            }
                            else
                            {
                                writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                            }
                        }
                        writer.WriteLine("");
                    }
                    writer.Dispose();
                    MessageBox.Show("Đã lưu File!", "Save File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            if (ButtonMembers.Checked == true)
            {
                SaveFileDialog savefile = new SaveFileDialog() { Filter = "Text Document|*.txt|Text Word|*.doc|Text Excel|*.xls", ValidateNames = true };
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    DateTime bdate;
                    StreamWriter writer = new StreamWriter(File.Create(savefile.FileName));
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count - 1; j++)
                        {
                            if (j == 4)
                            {
                                bdate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                                writer.Write("\t" + bdate.ToString("yyyy-MM-dd") + "\t" + "|");
                            }
                            else if (j == dataGridView1.Columns.Count - 2)
                            {
                                writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                            }
                            else
                            {
                                writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                            }
                        }
                        writer.WriteLine("");
                    }
                    writer.Dispose();
                    MessageBox.Show("Đã lưu File!", "Save File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gunaPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            ChartForm chart = new ChartForm();
            chart.Show(this);            
        }

        private void gunaAdvenceButton4_Click_1(object sender, EventArgs e)
        {
            frmHoaDonBan frmHoaDon = new frmHoaDonBan();
            frmHoaDon.Show(this);
            Hide();
        }
    }
}

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

namespace Đồ_án_ltwin
{
    public partial class ManageOWELLForm : Form
    {
        public ManageOWELLForm()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        STAFF staff = new STAFF();
        POSITION position = new POSITION();
        public void getImageUsername()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM QL WHERE id=@uid", mydb.getConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = Global.GlobalUserId;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                byte[] pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                PicUser.Image = Image.FromStream(picture);
                Label1.Text = table.Rows[0]["fname"].ToString();

            }
        }
        private void ManageOWELLForm_Load(object sender, EventArgs e)
        {
            getImageUsername();
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = staff.getFullStaff();
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
            comboBoxPosition.DataSource = position.getAllPosition();
            comboBoxPosition.DisplayMember = "name";
            comboBoxPosition.ValueMember = "id";
            TextBoxFname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            TextBoxLname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            TextBoxPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            TextBoxEmail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
            TextBoxAddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim();
            comboBoxPosition.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            gunaPictureBox2.Image = Image.FromStream(picture);

        }
        void fillGridStaff()
        {
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = staff.getFullStaff();
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[8];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }
        void fillGridPosition()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.DataSource = position.getAllPosition();
            dataGridView1.AllowUserToAddRows = false;
        }
        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                gunaPictureBox2.Image = Image.FromFile(opf.FileName);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if(ButtonStaff.Checked==true)
            {
                int id;
                Random rd = new Random();
                id = rd.Next(1, 1000);
                string fname = TextBoxFname.Text;
                string lname = TextBoxLname.Text;
                int positionid = Convert.ToInt32(comboBoxPosition.SelectedValue);
                string phone = TextBoxPhone.Text;
                string email = TextBoxEmail.Text;
                string address = TextBoxAddress.Text;
                MemoryStream picture = new MemoryStream();
                gunaPictureBox2.Image.Save(picture, gunaPictureBox2.Image.RawFormat);
                int userid = Global.GlobalUserId;
                if (Verifieds())
                {
                    if (staff.InsertStaff(id, fname, lname, positionid, phone, email, address, picture,userid))
                    {
                        MessageBox.Show("Add Staff Success", "Add Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillGridStaff();
                    }
                    else
                    {
                        MessageBox.Show("Error!", "Add Staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Field!", "Add Staff", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(ButtonPosition.Checked==true)
            {
                try
                {
                    int id;
                    Random rd = new Random();
                    id = rd.Next(1, 1000);
                    string positionname = TextBoxEmail.Text;
                    if (TextBoxEmail.Text != "")
                    {
                        if (!position.PositionExist(positionname,id))
                        {
                            if (position.InsertPosition(positionname,id))
                            {
                                MessageBox.Show("Insert Position Success", "Add Position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                comboBoxPosition.DataSource = position.getAllPosition();
                                comboBoxPosition.DisplayMember = "name";
                                comboBoxPosition.ValueMember = "id";
                                
                                fillGridPosition();
                            }
                            else
                            {
                                MessageBox.Show("Error!", "Add Position", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("This Position Have Been Existed!", "Add Position", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter the position name", "Add Position", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Add Position", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool Verifieds()
        {
            if (TextBoxFname.Text == "" || TextBoxLname.Text == "" || TextBoxPhone.Text == "" || TextBoxEmail.Text == "" || TextBoxAddress.Text == "" || comboBoxPosition.Text == "")
            {
                return false;
            }
            else
                return true;
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if(ButtonStaff.Checked==true)
            {
                int id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                string fname = TextBoxFname.Text;
                string lname = TextBoxLname.Text;
                string phone = TextBoxPhone.Text;
                string email = TextBoxEmail.Text;
                string address = TextBoxAddress.Text;
                int userid = Global.GlobalUserId;
                int positionid = Convert.ToInt32(comboBoxPosition.SelectedValue);
                MemoryStream picture = new MemoryStream();
                gunaPictureBox2.Image.Save(picture, gunaPictureBox2.Image.RawFormat);

                if (staff.UpdateStaff(id, userid, fname, lname, positionid, phone, email, address, picture))
                {
                    MessageBox.Show("Edit Staff Success", "Edit Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillGridStaff();
                }
                else
                {
                    MessageBox.Show("Error!", "Edit Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if(ButtonPosition.Checked==true)
            {
                string newposition = TextBoxEmail.Text;
                int id = Convert.ToInt32(comboBoxPosition.SelectedValue);
                if (position.updateposition(id, newposition))
                {
                    MessageBox.Show("The Position has been updated", "Edit Position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillGridPosition();
                    comboBoxPosition.DataSource = position.getAllPosition();
                    comboBoxPosition.DisplayMember = "name";
                    comboBoxPosition.ValueMember = "id";

                }
                else
                {
                    MessageBox.Show("Error", "Edit Position", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            TextBoxFname.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            TextBoxLname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            TextBoxPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            TextBoxEmail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
            TextBoxAddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim();
            comboBoxPosition.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            gunaPictureBox2.Image = Image.FromStream(picture);
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {

            if (ButtonStaff.Checked == true)
            {
                int id = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
                if (MessageBox.Show("Do you want to delete this staff?", "Remove Staff", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (staff.DeleteStaff(id))
                    {
                        MessageBox.Show("The Staff has been deleted!", "Remove Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBoxFname.Text = "";
                        TextBoxLname.Text = "";
                        TextBoxPhone.Text = "";
                        TextBoxAddress.Text = "";
                        TextBoxEmail.Text = "";
                        gunaPictureBox2.Image = null;
                        fillGridStaff();
                    }
                    else
                    {
                        MessageBox.Show("Error!", "Remove Staff", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            if(ButtonPosition.Checked==true)
            {
                
                    int delete = Convert.ToInt32(comboBoxPosition.SelectedValue);
                    if (MessageBox.Show("Are You sure want to delete this Position?", "Remove Position", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (position.DeletePosition(delete))
                        {
                            MessageBox.Show("The Position has been deleted", "Remove Position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fillGridPosition();
                            comboBoxPosition.DataSource = position.getAllPosition();
                            comboBoxPosition.DisplayMember = "name";
                            comboBoxPosition.ValueMember = "id";
                        }
                        else
                        {
                            MessageBox.Show("Error", "Remove Position", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                
                
            }
        }

        private void ButtonPosition_Click(object sender, EventArgs e)
        {
            TextBoxFname.Visible = false;
            TextBoxLname.Visible = false;
            TextBoxAddress.Visible = false;
            TextBoxPhone.Visible = false;
            TextBoxEmail.Text = "";
            LabelAddress.Visible = false;
            LabelFname.Visible = false;
            LabelLname.Visible = false;
            LabelPhone.Visible = false;
            LabelPositionN.Text = "";
            gunaPictureBox2.Visible = false;
            fillGridPosition();
            
        }

        private void ButtonStaff_Click(object sender, EventArgs e)
        {
            TextBoxFname.Visible = true;
            TextBoxLname.Visible = true;
            TextBoxAddress.Visible = true;
            TextBoxPhone.Visible = true;
            LabelAddress.Visible = true;
            LabelFname.Visible = true;
            LabelLname.Visible = true;
            LabelPhone.Visible = true;
            LabelPositionN.Text = "Email";
            gunaPictureBox2.Visible = true;
            fillGridStaff();
            TextBoxFname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();
            TextBoxLname.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString().Trim();
            TextBoxPhone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim();
            TextBoxEmail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim();
            TextBoxAddress.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString().Trim();
            comboBoxPosition.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
            byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[8].Value;
            MemoryStream picture = new MemoryStream(pic);
            gunaPictureBox2.Image = Image.FromStream(picture);
        }

        private void PicUser_Click(object sender, EventArgs e)
        {
            Global.check = 4;
            Hide();
            ChangePic changePic = new ChangePic();
            changePic.Show(this);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.check = 4;
            Hide();
            EditInfomationForm editInfomationForm = new EditInfomationForm();
            editInfomationForm.Show(this);
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
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
                        if (j == dataGridView1.Columns.Count - 2)
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
    }
}

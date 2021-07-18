using Đồ_án_ltwin.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_ltwin
{
    public partial class frmDMHang : Form
    {
        public frmDMHang()
        {
            InitializeComponent();
        }
        DataTable tblH;
        

        private void frmHang_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblNhaCC";
            txtMahang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cboMaNCC, "MaNCC", "TenNCC");
            cboMaNCC.SelectedIndex = -1;
            ResetValues();
        }



        private void ResetValues()
        {
            txtMahang.Text = "";
            txtTenhang.Text = "";
            cboMaNCC.Text = "";
            txtSoluong.Text = "0";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";
            txtSoluong.Enabled = true;
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            
            txtGhichu.Text = "";
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblHang";
            Functions.Connect();
            tblH = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblH;
            DataGridView.Columns[0].HeaderText = "Mã hàng";
            DataGridView.Columns[1].HeaderText = "Tên hàng";
            DataGridView.Columns[2].HeaderText = "Nhà cung cấp";
            DataGridView.Columns[3].HeaderText = "Số lượng";
            DataGridView.Columns[4].HeaderText = "Đơn giá nhập";
            DataGridView.Columns[5].HeaderText = "Đơn giá bán";
            
            DataGridView.Columns[6].HeaderText = "Bảo hành + giảm giá";
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 140;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 80;
            DataGridView.Columns[4].Width = 100;
            DataGridView.Columns[5].Width = 100;
            
            DataGridView.Columns[6].Width = 300;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            string maNCC;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMahang.Text = DataGridView.CurrentRow.Cells["Mahang"].Value.ToString();
            txtTenhang.Text = DataGridView.CurrentRow.Cells["Tenhang"].Value.ToString();
            maNCC = DataGridView.CurrentRow.Cells["MaNCC"].Value.ToString();
            sql = "SELECT TenNCC FROM tblNhaCC WHERE MaNCC=N'" + maNCC + "'";
            cboMaNCC.Text = Functions.GetFieldValues(sql);
            txtSoluong.Text = DataGridView.CurrentRow.Cells["Soluong"].Value.ToString();
            txtDongianhap.Text = DataGridView.CurrentRow.Cells["Dongianhap"].Value.ToString();
            txtDongiaban.Text = DataGridView.CurrentRow.Cells["Dongiaban"].Value.ToString();
            
            sql = "SELECT Ghichu FROM tblHang WHERE Mahang = N'" + txtMahang.Text + "'";
            txtGhichu.Text = Functions.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMahang.Enabled = true;
            txtMahang.Focus();
            txtSoluong.Enabled = true;
            txtDongianhap.Enabled = true;
            txtDongiaban.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return;
            }
            if (cboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNCC.Focus();
                return;
            }
            
            sql = "SELECT Mahang FROM tblHang WHERE Mahang=N'" + txtMahang.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            sql = "INSERT INTO tblHang(Mahang,Tenhang,MaNCC,Soluong,Dongianhap, Dongiaban,Ghichu) VALUES(N'"
                + txtMahang.Text.Trim() + "',N'" + txtTenhang.Text.Trim() +
                "',N'" + cboMaNCC.SelectedValue.ToString() +
                "'," + txtSoluong.Text.Trim() + "," + txtDongianhap.Text +
                "," + txtDongiaban.Text  +  ",N'" + txtGhichu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return;
            }
            if (cboMaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNCC.Focus();
                return;
            }
            
            sql = "UPDATE tblHang SET Tenhang=N'" + txtTenhang.Text.Trim().ToString() +
                "',MaNCC=N'" + cboMaNCC.SelectedValue.ToString() +
                "',Soluong=" + txtSoluong.Text +
                ",Ghichu=N'" + txtGhichu.Text + "' WHERE Mahang=N'" + txtMahang.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblHang WHERE Mahang=N'" + txtMahang.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;
        }

        

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahang.Text == "") && (txtTenhang.Text == "") && (cboMaNCC.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblHang WHERE 1=1";
            if (txtMahang.Text != "")
                sql += " AND Mahang LIKE N'%" + txtMahang.Text + "%'";
            if (txtTenhang.Text != "")
                sql += " AND Tenhang LIKE N'%" + txtTenhang.Text + "%'";
            if (cboMaNCC.Text != "")
                sql += " AND MaNCC LIKE N'%" + cboMaNCC.SelectedValue + "%'";
            tblH = Functions.GetDataToTable(sql);
            if (tblH.Rows.Count == 0)
                MessageBox.Show("Không có hàng hóa thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblH.Rows.Count + "  hàng hóa thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataGridView.DataSource = tblH;
            ResetValues();
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Mahang, Tenhang,MaNCC,Soluong,Dongianhap,Dongiaban,Ghichu FROM tblHang";
            tblH = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblH;
        }

        
        //giá bán bằng giá nhập * 10%
        private void txtDongianhap_TextChanged(object sender, EventArgs e)
        {
            double gn, gb;
            gn = Convert.ToDouble(txtDongianhap.Text);
            gb = gn + (gn / 10);
            txtDongiaban.Text = gb.ToString();
        }

       

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            menu.Show(this);
            Hide();
        }
    }
}

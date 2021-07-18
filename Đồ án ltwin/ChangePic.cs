﻿using System;
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
    public partial class ChangePic : Form
    {
        public ChangePic()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        User user = new User();
        MenuForm menu = new MenuForm();
        private void ChangePic_Load(object sender, EventArgs e)
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

            }
        }

        private void PicUser_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*png;*gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PicUser.Image = Image.FromFile(opf.FileName);
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt16(Global.ID);
            MemoryStream pic = new MemoryStream();
            PicUser.Image.Save(pic, PicUser.Image.RawFormat);
            if (user.updatePic(id, pic))
            {
                MessageBox.Show("Your Picure Updated, back to the menu.", "Avatar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                menu.Show(this);
                Hide();
            }
        }
    }
}

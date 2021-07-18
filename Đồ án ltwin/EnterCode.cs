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
    public partial class EnterCode : Form
    {
        public EnterCode()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        MenuForm menu = new MenuForm();
        private void ButtonEnter_Click(object sender, EventArgs e)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM CODE WHERE Code = @cd", mydb.getConnection);

            command.Parameters.Add("@cd", SqlDbType.VarChar).Value = TextBoxEnter.Text;


            adapter.SelectCommand = command;

            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
;
                ManageAllForm manage = new ManageAllForm();                
                manage.Show(this);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Error Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public bool check()
        {
            DataTable table = new DataTable();
            if ((table.Rows.Count > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ButtonEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void TextBoxEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {

                    SqlDataAdapter adapter = new SqlDataAdapter();

                    DataTable table = new DataTable();

                    SqlCommand command = new SqlCommand("SELECT * FROM CODE WHERE Code = @cd", mydb.getConnection);

                    command.Parameters.Add("@cd", SqlDbType.VarChar).Value = TextBoxEnter.Text;


                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {                        
                        ManageAllForm manage = new ManageAllForm();
                        manage.Show(this);
                        Hide();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Error Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                }
            }
        }

        private void TextBoxEnter_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

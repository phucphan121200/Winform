using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System;

namespace Đồ_án_ltwin
{
    class LOGIN
    {
        MY_DB mydb = new MY_DB();
        public bool insertCustomer(int id, string user,string pass, string fname, string lname, DateTime bdate, MemoryStream picture, string gender, string phone)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Login(id,username,password,fname,lname,bdate,picture,gender,phone)" +
                "VALUES (@id,@us,@ps,@fn,@ln,@bdt,@pic,@gdr,@phn)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@us", SqlDbType.VarChar).Value = user;
            command.Parameters.Add("@ps", SqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.openConnection();
                return false;
            }
        }
        public bool updateCustomer(string user, string fname, string lname, DateTime bdate, MemoryStream picture, string gender, string phone)
        {
            SqlCommand command = new SqlCommand("UPDATE Login SET fname=@fn, lname=@ln, bdate=@bdt," +
                "picture = @pic,gender=@gdr, phone=@phn WHERE username=@us", mydb.getConnection);
            command.Parameters.Add("@us", SqlDbType.VarChar).Value = user;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }
        public DataTable getCustomers(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        //Kiểm tra trùng
        public bool customerExist(string Username)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username=@user", mydb.getConnection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = Username;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool customeridExist(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool deleteCustomer(string user)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Login WHERE username=@user", mydb.getConnection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}

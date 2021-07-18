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
    class User
    {
        MY_DB mydb = new MY_DB();
        public bool updateUserStaff(int id, string fname, string lname, string gender, string phone)
        {
            SqlCommand command = new SqlCommand("UPDATE Login SET fname=@fn, lname=@ln," +
                "gender=@gdr, phone=@phn WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
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
        public bool updateUserMana(int id, string fname, string lname, string gender, string phone)
        {
            SqlCommand command = new SqlCommand("UPDATE QL SET fname=@fn, lname=@ln," +
                "gender=@gdr, phone=@phn WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
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
        public bool existPassStaff(string pass)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE password=@pass", mydb.getConnection);
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            { return true; }
            else { return false; }
        }
        public bool existPassMana(string pass)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM QL WHERE password=@pass", mydb.getConnection);
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            { return true; }
            else { return false; }
        }
        public bool updatePassStaff(int id, string pass)
        {
            SqlCommand command = new SqlCommand("UPDATE Login SET password" +
                "=@ps WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@ps", SqlDbType.VarChar).Value = pass;

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
        public bool updatePassMana(int id, string pass)
        {
            SqlCommand command = new SqlCommand("UPDATE QL SET password" +
                "=@ps WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@ps", SqlDbType.VarChar).Value = pass;

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
        public DataTable getUsers(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updatePicStaff(int id, MemoryStream pic)
        {
            SqlCommand command = new SqlCommand("UPDATE Login SET picture=@pic WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();

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
        public bool updatePicMana(int id, MemoryStream pic)
        {
            SqlCommand command = new SqlCommand("UPDATE QL SET picture=@pic WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();

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

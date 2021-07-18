using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Đồ_án_ltwin
{
    class STAFF
    {
        MY_DB mydb = new MY_DB();
        public DataTable getFullStaff()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = ("SELECT id AS ID, userid AS Respond,fname AS FirstName, lname AS LastName, position_id AS 'Position ID', phone AS Phone, email AS Email, address AS Address, pic AS Picture FROM staff");
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool InsertStaff(int id, string fname, string lname, int positionid, string phone, string email, string address, MemoryStream picture,int userid)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Staff(id,fname,lname,position_id,phone,email,address,pic,userid)" +
                "VALUES (@id,@fn,@ln,@grd,@phn,@mail,@adr,@pic,@cuserid)", mydb.getConnection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@grd", SqlDbType.Int).Value = positionid;
            command.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.NChar).Value = email;
            command.Parameters.Add("@adr", SqlDbType.NChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@cuserid", SqlDbType.Int).Value = Global.GlobalUserId;
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
        public bool UpdateStaff(int id, int userid, string fname, string lname, int positionid, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Staff SET fname = @fname, lname = @lname, position_id = @positionid, phone = @phone, address = @address, email = @email, pic = @pic,userid=@uid WHERE id = @id   ", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@positionid", SqlDbType.Int).Value = positionid;
            command.Parameters.Add("@phone", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.NChar).Value = email;
            command.Parameters.Add("@address", SqlDbType.NChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
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
        public bool DeleteStaff(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Staff WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            mydb.openConnection();

            if (command.ExecuteNonQuery() == 1)
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

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
    class POSITION
    {
        MY_DB mydb = new MY_DB();
        public DataTable getAllPosition()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Position", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool PositionExist(string positionname, int positionid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Position WHERE name = @name AND id <> @id", mydb.getConnection);
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = positionname;
            command.Parameters.Add("@id", SqlDbType.Int).Value = positionid;


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if ((table.Rows.Count == 0))    //không có môn nào bị trùng
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool InsertPosition(string groupname, int id)
        {

            SqlCommand command = new SqlCommand("INSERT INTO Position(name,id)" +
                "VALUES (@name,@id)", mydb.getConnection);

            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = groupname;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;


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
        public bool updateposition(int id, string positionname)
        {

            SqlCommand cmd = new SqlCommand("UPDATE Position SET name=@name WHERE id=@id ", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = positionname;
            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
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
        public bool DeletePosition(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Position WHERE id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
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

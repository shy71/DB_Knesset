using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using System.Windows;
namespace DB_Project
{
    public class DBSingleton
    {
        private static OracleConnection oracleConnection1 = null;
        public static OracleConnection GetConnection()
        {
            if (oracleConnection1 == null)
            {
                OracleConnectionStringBuilder myCStringB = new OracleConnectionStringBuilder();
                myCStringB.UserID = "tennenba";
                myCStringB.Password = "207447897";
                myCStringB.DataSource = "labdbwin";
                oracleConnection1 = new OracleConnection(myCStringB.ConnectionString);
            }
            return oracleConnection1;
        }
        public static DataTable SelectSql(string sql)
        {
            try
            {
                OracleDataAdapter dataAdapter = new OracleDataAdapter();
                dataAdapter.SelectCommand = new OracleCommand();
                dataAdapter.SelectCommand.Connection = DBSingleton.GetConnection();
                dataAdapter.SelectCommand.CommandText = sql;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SQL Error!");
                return null;
            }

        }
        public static void DeleteSql(string sql)
        {
            try
            {
                var con=GetConnection();
                con.Open();
                OracleCommand command;
                command=new OracleCommand();
                command.Connection =con ;
                command.CommandText = sql;
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("The item was deleted!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SQL Error!");
            }

        }
        public static bool InsertSql(string sql)
        {
            try
            {
                var con = GetConnection();
                con.Open();
                OracleCommand command;
                command = new OracleCommand();
                command.Connection = con;
                command.CommandText = sql;
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("The item was added!");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SQL Error!");
                return false;
            }

        }
    }
}

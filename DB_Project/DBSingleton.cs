using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.OracleClient;
//using Oracle.ManagedDataAccess.Client;
namespace DB_Project
{
    public class DBSingleton
    {
        private static OracleConnection oConnection1 = null;
        public static OracleConnection GetConnection()
        {
            if (oConnection1 == null)
            {
                OracleConnectionStringBuilder myCStringB = new OracleConnectionStringBuilder()
                {
                    
                    UserID = "tennenba",
                    Password = "207447897",
                    DataSource = "labdbwin"
                };
                oConnection1 = new OracleConnection(myCStringB.ToString());
            }
            return oConnection1;
        }
        public static DataTable SelectSql(string sql)
        {
            try
            {
                OracleDataAdapter dataAdapter = new OracleDataAdapter();
                dataAdapter.SelectCommand = new OracleCommand()
                {
                    Connection = DBSingleton.GetConnection(),
                    CommandText = sql
                };
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

        public static bool UpdateSql(string sql)
        {
            try
            {
                var con = GetConnection();
                con.Open();
                OracleCommand command;
                command = new OracleCommand()
                {
                    Connection = con,
                    CommandText = sql
                };
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("The item was updated!");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SQL Error!");
                return false;
            }

        }

        public static void DeleteSql(string sql)
        {
            try
            {
                var con=GetConnection();
                con.Open();
                OracleCommand command;
                command = new OracleCommand()
                {
                    Connection = con,
                    CommandText = sql
                };
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
                command = new OracleCommand()
                {
                    Connection = con,
                    CommandText = sql
                };
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
        public static string AdaptFieldValueToSql(string item)
        {
            int o;
            DateTime t;
            if (DateTime.TryParse(item, out t))
                return "to_date('" + t.ToString("dd-MM-yyy HH:mm:ss") + "', 'dd-mm-yyyy hh24:mi:ss')";
            if (!int.TryParse(item, out o))
                return "'" + item + "'";


            return item;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.OleDb;
//using Oracle.ManagedDataAccess.Client;
namespace DB_Project
{
    public class DBSingleton
    {
        private static OleDbConnection oConnection1 = null;
        public static OleDbConnection GetConnection()
        {
            if (oConnection1 == null)
            {
               /* OleDbConnectionStringBuilder myCStringB = new OleDbConnectionStringBuilder()
                {
                    
                    UserID = "tennenba",
                    Password = "207447897",
                    DataSource = "labdbwin"
                };*/
                oConnection1 = new OleDbConnection("provider=MSDAORA; Data Source=labdbwin; user id = tennenba; password = 207447897;");
            }
            return oConnection1;
        }
        public static DataTable SelectSql(string sql)
        {
            try
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = new OleDbCommand()
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
                OleDbCommand command;
                command = new OleDbCommand()
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
                OleDbCommand command;
                command = new OleDbCommand()
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
                OleDbCommand command;
                command = new OleDbCommand()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OracleClient;
using System.Data;

namespace DB_Project
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class ResultView : UserControl
    {
        string viewSql;
        public ResultView()
        {
            InitializeComponent();
        }
        public ResultView(string sql)
            : this()
        {
            Init(sql);
        }
        public void Init(string sql)
        {
            viewSql = sql;
            RefreshView();
        }
        void RefreshView()
        {
            mainView.ItemsSource = DBSingleton.SelectSql(viewSql).AsDataView();
        }



        public void DeleteRow(string tableName)
        {
            string sql="delete "+tableName+" where ";
            if (mainView.SelectedItem == null)
            {
                MessageBox.Show("You didn't chose any item to delete!");
                return;
            }
            var item = ((DataRowView)mainView.SelectedItem).Row.ItemArray;
            int i=0;
            foreach (var col in mainView.Columns)
	        {
                sql+=col.Header.ToString()+"="+adaptToSql(item[i++].ToString())+" AND ";
	        }
            sql=sql.Remove(sql.Length-5, 5);
            DBSingleton.DeleteSql(sql);
            RefreshView();
        }
        public string adaptToSql(string item)
        {
            int o;
            DateTime t;
            if (DateTime.TryParse(item, out t))
                return "to_date('" + t.ToString("dd-MM-yyy HH:mm:ss") + "', 'dd-mm-yyyy hh24:mi:ss')";
            if(!int.TryParse(item,out o))
                return "'"+item+"'";

           
            return item;
        }
    }
}

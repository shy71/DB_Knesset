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
        public bool TryUpdateQuery(string newSql)
        {
                var temp= DBSingleton.TrySelectSql(newSql);
            if(temp==null)
            {
                MessageBox.Show("The select sql query wasn't valid!");
                return false;
            }
                mainView.ItemsSource = temp.AsDataView();
            return true;
        }
        public void RefreshView()
        {
            mainView.ItemsSource = DBSingleton.SelectSql(viewSql).AsDataView();
        }



        public void DeleteRow(string tableName)
        {
            if (mainView.SelectedItem == null)
            {
                MessageBox.Show("You didn't chose any item to delete!");
                return;
            }
            string sql = "delete " + tableName + DBSingleton.MakeWhereClause(mainView.Columns.Select(x => x.Header.ToString()).ToArray(), ((DataRowView)mainView.SelectedItem).Row.ItemArray.Select(x => x.ToString()).ToArray());
            DBSingleton.DeleteSql(sql);
            RefreshView();
        }
    }
}

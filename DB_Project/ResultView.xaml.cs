﻿using System;
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
        DataTable dt=null; 
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
                dt= DBSingleton.TrySelectSql(newSql);
            if(dt==null)
            {
                MessageBox.Show("The select sql query wasn't valid!");
                return false;
            }
                mainView.ItemsSource = dt.AsDataView();
            return true;
        }
        public void RefreshView()
        {
            dt = DBSingleton.SelectSql(viewSql);
            mainView.ItemsSource = dt.AsDataView();
        }


        public void Filter(string []column,string text)
        {
            if(dt == null)
            {
                dt = ((DataView) mainView.ItemsSource).ToTable();
            }
            mainView.ItemsSource = dt.AsEnumerable().Where(x =>column.Select(col=>x[col].ToString().ToUpper().Contains(text.ToUpper())).Count(contain=> contain)>0).AsDataView();
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

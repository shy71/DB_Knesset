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
using System.Windows.Shapes;

namespace DB_Project
{
    /// <summary>
    /// Interaction logic for ManageTable.xaml
    /// </summary>
    public partial class ManageTable : Window
    {
        string tableName;
        public ManageTable()
        {
            InitializeComponent();
        }

        public ManageTable(string tableName)
            : this()
        {
            this.tableName = tableName;
            title.Text = tableName;
            resultView.Init(string.Format("select * from {0}", tableName));
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            resultView.DeleteRow(tableName);

        }
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            new InsertItem(tableName, resultView.mainView.Columns).Show();

        }
    }
}

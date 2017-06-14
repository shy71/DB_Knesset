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
using System.Data;
using System.Collections.ObjectModel;
namespace DB_Project
{
    /// <summary>
    /// Interaction logic for insertItem.xaml
    /// </summary>
    public partial class InsertItem : Window
    {
        
        public InsertItem(string tableName,ObservableCollection<DataGridColumn> field)
        {
            InitializeComponent();
            title.Text = tableName;
            foreach (var item in field)
            {
                stackFields.Children.Add(new getField(item.Header.ToString()));
                
            }
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            string comm = "insert into " + title.Text+"(";
            foreach (getField item in stackFields.Children)
            {
                comm += item.getName()+",";
            }
            comm = comm.Substring(0, comm.Length - 1);
            comm+=") values (";
            foreach (getField item in stackFields.Children)
            {
                comm += adaptToSql(item.getValue()) + ",";
            }
            comm = comm.Substring(0,comm.Length - 1);
            comm += ")";
            if (DBSingleton.InsertSql(comm))
                Close();
            
        }
        public string adaptToSql(string item)
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

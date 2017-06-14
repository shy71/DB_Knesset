using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UpdateItem.xaml
    /// </summary>
    public partial class UpdateItem : Window
    {
        public UpdateItem(string tableName, ObservableCollection<DataGridColumn> field)
        {
            InitializeComponent();
            title.Text = tableName;
            foreach (var item in field)
            {
                stackFields.Children.Add(new getField(item.Header.ToString()));

            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string comm = "update " + title.Text + "set";
            foreach (getField item in stackFields.Children)
            {
                if (item.IsChanged())
                    comm += item.getName() + "="+DBSingleton.AdaptFieldValueToSql(item.getValue())+",";
            }
       
            comm = comm.Substring(0, comm.Length - 1);
            comm += ")";
            if (DBSingleton.UpdateSql(comm))
                Close();

        }
        
    }
}

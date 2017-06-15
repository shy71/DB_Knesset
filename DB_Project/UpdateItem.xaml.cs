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
        public UpdateItem(string tableName, ObservableCollection<DataGridColumn> field, string[] itemArray)
        {
            InitializeComponent();
            title.Text = tableName;
            int i = 0;
            foreach (var item in field)
            {
                stackFields.Children.Add(new getField(item.Header.ToString(),itemArray[i++]));

            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
            string comm = "update " + title.Text + " set ";
            bool changed = false;
            foreach (getField item in stackFields.Children)
            {
                if (item.IsChanged())
                {
                    comm += item.getName() + "=" + DBSingleton.AdaptFieldValueToSql(item.getValue()) + ",";
                    changed = true;
                }
            }
            if (!changed)
            {
                MessageBox.Show("You didn't updated anything!");
                Close();
            }
            comm = comm.Substring(0, comm.Length - 1);
            if (DBSingleton.UpdateSql(comm))
                Close();

        }
        
    }
}

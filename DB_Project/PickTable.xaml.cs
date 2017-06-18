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
    /// Interaction logic for PickTable.xaml
    /// </summary>
    public partial class PickTable : Window
    {
        public PickTable()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ManageTable((sender as Button).Content.ToString().ToUpper()).Show();
            Close();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            new MainWindow().Show();
        }
    }
}

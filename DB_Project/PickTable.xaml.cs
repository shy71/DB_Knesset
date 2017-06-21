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
        bool progClosing=false;
        public PickTable()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ManageTable((sender as Button).Content.ToString().ToUpper()).Show();
            progClosing = true;
            Close();
            
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            if(!progClosing)
            new MainWindow().Show();
        }

        private void TextInput_table(object sender, EventArgs e)
        {
            if (otherTable.Text != "")
                new ManageTable(otherTable.Text.ToUpper()).Show();
            progClosing = true;
            Close();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TextInput_table(sender, null);
        }

        private void otherTable_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

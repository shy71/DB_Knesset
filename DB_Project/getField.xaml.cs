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

namespace DB_Project
{
    /// <summary>
    /// Interaction logic for getField.xaml
    /// </summary>
    public partial class getField : UserControl
    {
        public getField(string name)
        {
            InitializeComponent();
            title.Text = name;
        }
        public string getName()
        {
            return title.Text;
        }
        public string getValue()
        {
            return value.Text;
        }
    }
}

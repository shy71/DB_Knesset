using System;
using System.Collections.Generic;
using System.Data;
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
        string originalValue;
        bool IsForigenKey=false;
        public getField(string name)
        {
            InitializeComponent();
            if (name.EndsWith("_ID"))
                SetUpForigenKey(name.Replace("_ID",""));
            title.Text = name;
        }

        private void SetUpForigenKey(string name)
        {
            IsForigenKey = true;
            comboBox.Visibility = Visibility.Visible;
            value.Visibility = Visibility.Collapsed;
            DataTable dt=DBSingleton.SelectSql(string.Format("select {0}_ID,{0}_name from {0}", name));
            comboBox.ItemsSource = dt.AsDataView();
        }

        public getField(string name,string value):this(name)
        {
            this.value.Text = value;
            originalValue = value;
        }
        public bool IsChanged()
        {
            return originalValue != value.Text;
        }
        public string getName()
        {
            return title.Text;
        }
        public string getValue()
        {
            if (IsForigenKey)
                return comboBox.SelectedValue.ToString();
            return value.Text;
        }
    }
}

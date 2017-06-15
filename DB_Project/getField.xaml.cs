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
        public getField(string name,string tableName)
        {
            InitializeComponent();
            SetUp(name, tableName);
        }
        void SetUp(string name, string tableName)
        {
            if ((tableName + "_ID").ToUpper() == name)
                value.IsEnabled = false;
            else if (name.EndsWith("_ID"))
                SetUpForigenKey(name.Replace("_ID", ""));
            title.Text = name;
        }
        private void SetUpForigenKey(string name)
        {
            IsForigenKey = true;
            comboBox.Visibility = Visibility.Visible;
            value.Visibility = Visibility.Collapsed;
            int i = 0;
            int index=-1;
            DataTable dt;
            dt = DBSingleton.SelectSql(string.Format("select {0}_ID,{0}_name from {0}", name), string.Format("select {0}_ID,{0}_location from {0}", name));
            foreach (DataRowView item in dt.AsDataView())
            {
                i++;
                if (IsForigenKey)
                    if (item.Row.ItemArray[0].ToString() == originalValue)
                        index = i;
                if(item.Row.ItemArray.Length>1)
                    comboBox.Items.Add(item.Row.ItemArray[0].ToString()+" - "+item.Row.ItemArray[1].ToString());
                else
                comboBox.Items.Add(item.Row.ItemArray[0].ToString());
            }
            if (IsForigenKey)
                comboBox.SelectedIndex = index;
        }

        public getField(string name,string value, string tableName)
        {
            InitializeComponent();
            this.value.Text = value;
            originalValue = value;
            SetUp(name, tableName);
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
                return comboBox.SelectedValue.ToString().Substring(0, comboBox.SelectedValue.ToString().IndexOf(" - "));
            return value.Text;
        }
    }
}

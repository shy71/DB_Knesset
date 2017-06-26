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
using System.Windows.Shapes;

namespace DB_Project
{
    /// <summary>
    /// Interaction logic for SearchBill.xaml
    /// </summary>
    public partial class SearchBill : Window
    {
        public SearchBill()
        {
            InitializeComponent();
            SetUpPartyBox();
            resultView.Init("select * from bill");
        }
        private void SetUpPartyBox( )
        {
    
            DataTable dt;
            dt = DBSingleton.TrySelectSql("select party_ID,party_name from party");
            foreach (DataRowView item in dt.AsDataView())
            {
                if (item.Row.ItemArray.Length > 1)
                    partyBox.Items.Add(item.Row.ItemArray[0].ToString() + " - " + item.Row.ItemArray[1].ToString());
            }
        }
        public string getSelectedParty()
        {
            return partyBox.SelectedValue.ToString().Substring(0, partyBox.SelectedValue.ToString().IndexOf(" - "));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            resultView.Filter(new string []{ "bill_name","bill_content" }, searchBox.Text);
        }

        private void partyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            resultView.Init("select * from bill natural join member natural join legislate where party_id=" + getSelectedParty());
            resultView.Filter(new string[] { "bill_name", "bill_content" }, searchBox.Text);

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}

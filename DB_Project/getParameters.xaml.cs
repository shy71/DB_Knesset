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
using System.Data.OracleClient;
namespace DB_Project
{
    /// <summary>
    /// Interaction logic for getParameters.xaml
    /// </summary>
    public partial class getParameters : Window
    {
        string[] field;
        OracleCommand command;
        bool IsFunc;
       public string returnValue;
        public getParameters(string funcName,string[] param,OracleCommand com,bool IsFunc)
        {
            InitializeComponent();
            field = param;
            command = com;
            title.Text = funcName;
            this.IsFunc = IsFunc;
            foreach (var item in field)
            {
                stackFields.Children.Add(new getField(item));

            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            int o;
            foreach (var item in stackFields.Children)
            {
                var value = ((getField)item).getValue();
                if (int.TryParse(value, out o))
                    command.Parameters[((getField)item).getName()].Value = o;
                else
                 command.Parameters[((getField)item).getName()].Value =value;
            }
            try
            {
                command.ExecuteNonQuery();
                if (IsFunc)
                {
                    returnValue = command.Parameters["FunctionResult"].Value.ToString();
                   // MessageBox.Show("The Function returned: " + command.Parameters["FunctionResult"].Value.ToString(), "Retunred Value");
                    Close();
                }
                else
                {
                    MessageBox.Show("The Procedure executed successfully");
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();


        }
    }
}

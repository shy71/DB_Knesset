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
using System.Data.OracleClient;
namespace DB_Project
{
    /// <summary>
    /// Interaction logic for PickFunc.xaml
    /// </summary>
    public partial class PickFunc : Window
    {
        public PickFunc()
        {
            InitializeComponent();
        }

        
        private void Bonus_For_Assistent(object sender, RoutedEventArgs e)
        {
            OracleCommand com = getNewCommand("PKG_ASSISTENT.bonusForAssistants");
            addArgNumber("bonusPoolp",com);
            addArgNumber("partyId", com);
            addArgNumber("bonus", com);
            exeProc("Bonus For Assistent", new string[] { "bonusPoolp", "partyId", "bonus" }, com);
        }
        private void Move_Email_Domain(object sender, RoutedEventArgs e)
        {
            OracleCommand com = getNewCommand("PKG_MEMBER.MoveEmailDomain");
            addArgString("domain", com);
            exeProc("Move Email Domain", new string[] { "domain" }, com);
        }
        private void Member_Cost(object sender, RoutedEventArgs e)
        {
            OracleCommand com = getNewCommand("PKG_MEMBER.member_cost");
            addArgNumber("memberId", com);
            com.Parameters.Add("FunctionResult", OracleType.Int32);
            com.Parameters["FunctionResult"].Direction = System.Data.ParameterDirection.ReturnValue;
            var wind = new getParameters("Member Cost", new string[] { "memberId" }, com, true);
            wind.Closing += (sende, ev)=>MessageBox.Show("The member cost is: "+((getParameters)sende).returnValue+ "₪");
            wind.ShowDialog();

        }
        private void Ratio_Bills_Over_Average(object sender, RoutedEventArgs e)
        {
            OracleCommand com = getNewCommand("PKG_MEMBER.ratioBillsOverAverage");
            addArgNumber("memberId", com);
            com.Parameters.Add("FunctionResult", OracleType.Int16);
            com.Parameters["FunctionResult"].Direction = System.Data.ParameterDirection.ReturnValue;
            var wind = new getParameters("Ratio Bills Over Average", new string[] { "memberId" }, com, true);
            wind.Closing += (sende, ev) => MessageBox.Show((Convert.ToInt32(((getParameters)sende).returnValue)==1)?"The member is over the Bills average!": "The member is under the Bills average!");
            wind.ShowDialog();


        }
        private static void addArgString(string name, OracleCommand com)
        {
            com.Parameters.Add(name, OracleType.VarChar);
            com.Parameters[name].Direction = System.Data.ParameterDirection.Input;
            com.Parameters[name].Size = 100;
        }

        private void exeProc(string funcName, string[] paramt , OracleCommand com)
        {
            new getParameters(funcName, paramt,com, false).ShowDialog();
        }

        private static OracleCommand getNewCommand(string funcName)
        {
            OracleCommand com = new OracleCommand();
            var connection = DBSingleton.GetConnection();
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            com.Connection = connection;
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.CommandText = funcName;
            return com;

        }
        private static void addArgNumber(string name,OracleCommand com)
        {
            com.Parameters.Add(name, OracleType.Number);
            com.Parameters[name].Direction = System.Data.ParameterDirection.Input;
        }
    }
}

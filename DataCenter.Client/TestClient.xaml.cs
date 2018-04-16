using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using DataCenter.Proxy;
using DataCenter.Access;

namespace DataCenter.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TestClient : Window
    {
        public TestClient()
        {
            InitializeComponent();
        }

        private void GetClicked(object sender, RoutedEventArgs e)
        {
            var client = new DataClient();
            int i = int.Parse(param.Text);
            var trades = client.GetData(i);
            result.Content = string.Empty;
            foreach (var t in trades)
            {
                result.Content += string.Format("{0}: {1} £{2} of {3}\n", t.ID, t.IsBuy ? "Buy" : "Sell", t.Amount, t.MarketName);
            }
            client.Close();
        }
    }
}

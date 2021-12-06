using Cryptography.WpfApp.Models;
using Cryptography.WpfApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Cryptography.WpfApp.Views
{
    /// <summary>
    /// Interaction logic for RsaView.xaml
    /// </summary>
    public partial class RsaView : UserControl
    {
        public RsaView()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            int value;
            var rsaData = new RsaData
            {
                P = int.TryParse(p1.Text, out value) ? value : 0,
                Q = int.TryParse(q1.Text, out value) ? value : 0,
                Exponent = int.TryParse(e1.Text, out value) ? value : 0,
                Value = int.TryParse(inputValue1.Text, out value) ? value : 0,
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Rsa/Encrypt", rsaData).Result;

            if (response.IsSuccessStatusCode)
            {
                int result = response.Content.ReadAsAsync<int>().Result;
                outputValue1.Text = result.ToString();
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            int value;
            var rsaData = new RsaData
            {
                P = int.TryParse(p2.Text, out value) ? value : 0,
                Q = int.TryParse(q2.Text, out value) ? value : 0,
                Exponent = int.TryParse(d2.Text, out value) ? value : 0,
                Value = int.TryParse(inputValue2.Text, out value) ? value : 0,
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Rsa/Decrypt", rsaData).Result;

            if (response.IsSuccessStatusCode)
            {
                int result = response.Content.ReadAsAsync<int>().Result;
                outputValue2.Text = result.ToString();
            }
        }
    }
}

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
    /// Interaction logic for CaesarCipherView.xaml
    /// </summary>
    public partial class CaesarCipherView : UserControl
    {
        public CaesarCipherView()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var caesarCipherData = new CaesarCipherData
            {
                Language = language1.Text,
                Text = inputText1.Text
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("CaesarCipher/Encrypt", caesarCipherData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputList = response.Content.ReadAsAsync<string[]>().Result;
                outputList1.ItemsSource = outputList;
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            var caesarCipherData = new CaesarCipherData
            {
                Language = language2.Text,
                Text = inputText2.Text
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("CaesarCipher/Decrypt", caesarCipherData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputList = response.Content.ReadAsAsync<string[]>().Result;
                outputList2.ItemsSource = outputList;
            }
        }
    }
}

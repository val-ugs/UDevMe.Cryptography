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
    /// Interaction logic for GronsfeldCipherView.xaml
    /// </summary>
    public partial class GronsfeldCipherView : UserControl
    {
        private char _delimiter = ',';

        public GronsfeldCipherView()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var gronsfeldCipher = new GronsfeldCipherData
            {
                Language = language1.Text,
                Text = inputText1.Text,
                Key = DataConverter.ConvertStringToIntList(inputKey1.Text, _delimiter)
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("GronsfeldCipher/Encrypt", gronsfeldCipher).Result;

            if (response.IsSuccessStatusCode)
            {
                outputText1.Text = response.Content.ReadAsAsync<string>().Result;
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            var gronsfeldCipher = new GronsfeldCipherData
            {
                Language = language2.Text,
                Text = inputText2.Text,
                Key = DataConverter.ConvertStringToIntList(inputKey1.Text, _delimiter)
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("GronsfeldCipher/Decrypt", gronsfeldCipher).Result;

            if (response.IsSuccessStatusCode)
            {
                outputText2.Text = response.Content.ReadAsAsync<string>().Result;
            }
        }
    }
}

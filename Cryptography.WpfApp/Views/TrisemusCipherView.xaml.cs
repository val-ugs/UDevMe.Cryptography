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
    /// Interaction logic for TrisemusCipherView.xaml
    /// </summary>
    public partial class TrisemusCipherView : UserControl
    {
        public TrisemusCipherView()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var trisemusCipherData = new TrisemusCipherData
            {
                Language = language1.Text,
                Text = inputText1.Text
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("TrisemusCipher/Encrypt", trisemusCipherData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputText = response.Content.ReadAsAsync<string>().Result;
                outputText1.Text = outputText;
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            var caesarCipherData = new CaesarCipherData
            {
                Language = language2.Text,
                Text = inputText2.Text
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("TrisemusCipher/Decrypt", caesarCipherData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputText = response.Content.ReadAsAsync<string>().Result;
                outputText2.Text = outputText;
            }
        }
    }
}

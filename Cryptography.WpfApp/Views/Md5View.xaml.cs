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
    /// Interaction logic for Md5View.xaml
    /// </summary>
    public partial class Md5View : UserControl
    {
        public Md5View()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            uint uintValue;
            var md5Data = new Md5Data
            {
                A = uint.TryParse(a1.Text, out uintValue) ? uintValue : 0,
                B = uint.TryParse(b1.Text, out uintValue) ? uintValue : 0,
                C = uint.TryParse(c1.Text, out uintValue) ? uintValue : 0,
                D = uint.TryParse(d1.Text, out uintValue) ? uintValue : 0,
                M = uint.TryParse(m1.Text, out uintValue) ? uintValue : 0,
                K = uint.TryParse(k1.Text, out uintValue) ? uintValue : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Md5/Encrypt", md5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var newMd5Data = response.Content.ReadAsAsync<Md5Data>().Result;

                outputA1.Text = newMd5Data.A.ToString();
                outputB1.Text = newMd5Data.B.ToString();
                outputC1.Text = newMd5Data.C.ToString();
                outputD1.Text = newMd5Data.D.ToString();
            }
        }

        private void btnEncryptPerRound_Click(object sender, RoutedEventArgs e)
        {
            uint uintValue;
            int intValue;
            var md5Data = new Md5Data
            {
                A = uint.TryParse(a1.Text, out uintValue) ? uintValue : 0,
                B = uint.TryParse(b1.Text, out uintValue) ? uintValue : 0,
                C = uint.TryParse(c1.Text, out uintValue) ? uintValue : 0,
                D = uint.TryParse(d1.Text, out uintValue) ? uintValue : 0,
                M = uint.TryParse(m1.Text, out uintValue) ? uintValue : 0,
                K = uint.TryParse(k1.Text, out uintValue) ? uintValue : 0,
                Round = int.TryParse(round1.Text, out intValue) ? intValue : 0,
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Md5/EncryptPerRound", md5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var newMd5Data = response.Content.ReadAsAsync<Md5Data>().Result;

                outputRoundA1.Text = newMd5Data.A.ToString();
                outputRoundB1.Text = newMd5Data.B.ToString();
                outputRoundC1.Text = newMd5Data.C.ToString();
                outputRoundD1.Text = newMd5Data.D.ToString();
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            uint uintValue;
            var md5Data = new Md5Data
            {
                A = uint.TryParse(a2.Text, out uintValue) ? uintValue : 0,
                B = uint.TryParse(b2.Text, out uintValue) ? uintValue : 0,
                C = uint.TryParse(c2.Text, out uintValue) ? uintValue : 0,
                D = uint.TryParse(d2.Text, out uintValue) ? uintValue : 0,
                M = uint.TryParse(m2.Text, out uintValue) ? uintValue : 0,
                K = uint.TryParse(k2.Text, out uintValue) ? uintValue : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Md5/Decrypt", md5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var newMd5Data = response.Content.ReadAsAsync<Md5Data>().Result;

                outputA2.Text = newMd5Data.A.ToString();
                outputB2.Text = newMd5Data.B.ToString();
                outputC2.Text = newMd5Data.C.ToString();
                outputD2.Text = newMd5Data.D.ToString();
            }
        }

        private void btnDecryptPerRound_Click(object sender, RoutedEventArgs e)
        {
            uint uintValue;
            int intValue;
            var md5Data = new Md5Data
            {
                A = uint.TryParse(a2.Text, out uintValue) ? uintValue : 0,
                B = uint.TryParse(b2.Text, out uintValue) ? uintValue : 0,
                C = uint.TryParse(c2.Text, out uintValue) ? uintValue : 0,
                D = uint.TryParse(d2.Text, out uintValue) ? uintValue : 0,
                M = uint.TryParse(m2.Text, out uintValue) ? uintValue : 0,
                K = uint.TryParse(k2.Text, out uintValue) ? uintValue : 0,
                Round = int.TryParse(round2.Text, out intValue) ? intValue : 0,
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Md5/DecryptPerRound", md5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var newMd5Data = response.Content.ReadAsAsync<Md5Data>().Result;

                outputRoundA2.Text = newMd5Data.A.ToString();
                outputRoundB2.Text = newMd5Data.B.ToString();
                outputRoundC2.Text = newMd5Data.C.ToString();
                outputRoundD2.Text = newMd5Data.D.ToString();
            }
        }
    }
}

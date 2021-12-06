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
    /// Interaction logic for A5View.xaml
    /// </summary>
    public partial class A5View : UserControl
    {
        private char _delimiter = ',';

        public A5View()
        {
            InitializeComponent();
        }

        private void btnGetKey1_Click(object sender, RoutedEventArgs e)
        {
            var a5Data = new A5Data
            {
                RegisterA = DataConverter.ConvertStringToIntList(registerA1.Text, _delimiter),
                RegisterB = DataConverter.ConvertStringToIntList(registerB1.Text, _delimiter),
                RegisterC = DataConverter.ConvertStringToIntList(registerC1.Text, _delimiter),
                IndicesA = DataConverter.ConvertStringToIntList(indicesA1.Text, _delimiter),
                IndicesB = DataConverter.ConvertStringToIntList(indicesB1.Text, _delimiter),
                IndicesC = DataConverter.ConvertStringToIntList(indicesC1.Text, _delimiter),
                InputValues = DataConverter.ConvertStringToIntList(inputValues1.Text, _delimiter).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("A5/GetKey", a5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var key = response.Content.ReadAsAsync<int[]>().Result;
                key1.Text = DataConverter.ConvertIntArrayToString(key, _delimiter);
            }
        }

        private void btnGetKey2_Click(object sender, RoutedEventArgs e)
        {
            var a5Data = new A5Data
            {
                RegisterA = DataConverter.ConvertStringToIntList(registerA2.Text, _delimiter),
                RegisterB = DataConverter.ConvertStringToIntList(registerB2.Text, _delimiter),
                RegisterC = DataConverter.ConvertStringToIntList(registerC2.Text, _delimiter),
                IndicesA = DataConverter.ConvertStringToIntList(indicesA2.Text, _delimiter),
                IndicesB = DataConverter.ConvertStringToIntList(indicesB2.Text, _delimiter),
                IndicesC = DataConverter.ConvertStringToIntList(indicesC2.Text, _delimiter),
                InputValues = DataConverter.ConvertStringToIntList(inputValues2.Text, _delimiter).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("A5/GetKey", a5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var key = response.Content.ReadAsAsync<int[]>().Result;
                key2.Text = DataConverter.ConvertIntArrayToString(key, _delimiter);
            }
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var a5Data = new A5Data
            {
                RegisterA = DataConverter.ConvertStringToIntList(registerA1.Text, _delimiter),
                RegisterB = DataConverter.ConvertStringToIntList(registerB1.Text, _delimiter),
                RegisterC = DataConverter.ConvertStringToIntList(registerC1.Text, _delimiter),
                IndicesA = DataConverter.ConvertStringToIntList(indicesA1.Text, _delimiter),
                IndicesB = DataConverter.ConvertStringToIntList(indicesB1.Text, _delimiter),
                IndicesC = DataConverter.ConvertStringToIntList(indicesC1.Text, _delimiter),
                InputValues = DataConverter.ConvertStringToIntList(inputValues1.Text, _delimiter).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("A5/Encrypt", a5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputValues = response.Content.ReadAsAsync<int[]>().Result;
                outputValues1.Text = DataConverter.ConvertIntArrayToString(outputValues, _delimiter);
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            var a5Data = new A5Data
            {
                RegisterA = DataConverter.ConvertStringToIntList(registerA2.Text, _delimiter),
                RegisterB = DataConverter.ConvertStringToIntList(registerB2.Text, _delimiter),
                RegisterC = DataConverter.ConvertStringToIntList(registerC2.Text, _delimiter),
                IndicesA = DataConverter.ConvertStringToIntList(indicesA2.Text, _delimiter),
                IndicesB = DataConverter.ConvertStringToIntList(indicesB2.Text, _delimiter),
                IndicesC = DataConverter.ConvertStringToIntList(indicesC2.Text, _delimiter),
                InputValues = DataConverter.ConvertStringToIntList(inputValues2.Text, _delimiter).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("A5/Decrypt", a5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputValues = response.Content.ReadAsAsync<int[]>().Result;
                outputValues2.Text = DataConverter.ConvertIntArrayToString(outputValues, _delimiter);
            }
        }
    }
}

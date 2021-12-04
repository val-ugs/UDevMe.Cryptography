using Cryptography.Domain.Models;
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
                RegisterA = ConvertStringToIntList(registerA1.Text, _delimiter),
                RegisterB = ConvertStringToIntList(registerB1.Text, _delimiter),
                RegisterC = ConvertStringToIntList(registerC1.Text, _delimiter),
                IndicesA = ConvertStringToIntList(indicesA1.Text, _delimiter),
                IndicesB = ConvertStringToIntList(indicesB1.Text, _delimiter),
                IndicesC = ConvertStringToIntList(indicesC1.Text, _delimiter),
                InputValues = ConvertStringToIntList(inputValues1.Text, _delimiter).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("A5/GetKey", a5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var key = response.Content.ReadAsAsync<int[]>().Result;
                key1.Text = ConvertIntArrayToString(key, _delimiter);
            }
        }

        private void btnGetKey2_Click(object sender, RoutedEventArgs e)
        {
            var a5Data = new A5Data
            {
                RegisterA = ConvertStringToIntList(registerA2.Text, _delimiter),
                RegisterB = ConvertStringToIntList(registerB2.Text, _delimiter),
                RegisterC = ConvertStringToIntList(registerC2.Text, _delimiter),
                IndicesA = ConvertStringToIntList(indicesA2.Text, _delimiter),
                IndicesB = ConvertStringToIntList(indicesB2.Text, _delimiter),
                IndicesC = ConvertStringToIntList(indicesC2.Text, _delimiter),
                InputValues = ConvertStringToIntList(inputValues2.Text, _delimiter).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("A5/GetKey", a5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var key = response.Content.ReadAsAsync<int[]>().Result;
                key2.Text = ConvertIntArrayToString(key, _delimiter);
            }
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var a5Data = new A5Data
            {
                RegisterA = ConvertStringToIntList(registerA1.Text, _delimiter),
                RegisterB = ConvertStringToIntList(registerB1.Text, _delimiter),
                RegisterC = ConvertStringToIntList(registerC1.Text, _delimiter),
                IndicesA = ConvertStringToIntList(indicesA1.Text, _delimiter),
                IndicesB = ConvertStringToIntList(indicesB1.Text, _delimiter),
                IndicesC = ConvertStringToIntList(indicesC1.Text, _delimiter),
                InputValues = ConvertStringToIntList(inputValues1.Text, _delimiter).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("A5/Encrypt", a5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputValues = response.Content.ReadAsAsync<int[]>().Result;
                outputValues1.Text = ConvertIntArrayToString(outputValues, _delimiter);
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            var a5Data = new A5Data
            {
                RegisterA = ConvertStringToIntList(registerA2.Text, _delimiter),
                RegisterB = ConvertStringToIntList(registerB2.Text, _delimiter),
                RegisterC = ConvertStringToIntList(registerC2.Text, _delimiter),
                IndicesA = ConvertStringToIntList(indicesA2.Text, _delimiter),
                IndicesB = ConvertStringToIntList(indicesB2.Text, _delimiter),
                IndicesC = ConvertStringToIntList(indicesC2.Text, _delimiter),
                InputValues = ConvertStringToIntList(inputValues2.Text, _delimiter).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("A5/Decrypt", a5Data).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputValues = response.Content.ReadAsAsync<int[]>().Result;
                outputValues2.Text = ConvertIntArrayToString(outputValues, _delimiter);
            }
        }

        private List<int> ConvertStringToIntList(string text, char delimiter)
        {
            List<int> numbers = new List<int>();
            int value;
            var textMembers = text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            foreach(var textMember in textMembers)
            {
                numbers.Add(int.TryParse(textMember, out value) ? value : 0);
            }

            return numbers;
        }

        private string ConvertIntArrayToString(int[] outputValues, char delimiter)
        {
            StringBuilder outputString = new StringBuilder();

            for (int i = 0; i < outputValues.Length; i++)
            {
                outputString.Append(outputValues[i]);
                if (i != outputValues.Length - 1)
                {
                    outputString.Append(_delimiter + " ");
                }
            }

            return outputString.ToString();
        }
    }
}

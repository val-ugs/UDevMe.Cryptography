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
    /// Interaction logic for FibonacciLfsrView.xaml
    /// </summary>
    public partial class FibonacciLfsrView : UserControl
    {
        private char _delimiter = ',';

        public FibonacciLfsrView()
        {
            InitializeComponent();
        }

        private void btnGetPeriod_Click(object sender, RoutedEventArgs e)
        {
            var fibonacciLfsr = new FibonacciLfsrData
            {
                Values = DataConverter.ConvertStringToIntList(inputValues.Text, _delimiter),
                Indices = DataConverter.ConvertStringToIntList(inputIndices.Text, _delimiter)
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("FibonacciLfsr/GetPeriod", fibonacciLfsr).Result;

            if (response.IsSuccessStatusCode)
            {
                var period = response.Content.ReadAsAsync<int>().Result;
                outputPeriod.Text = period.ToString();
            }
        }

        private void btnGenerateSequence_Click(object sender, RoutedEventArgs e)
        {
            var fibonacciLfsr = new FibonacciLfsrData
            {
                Values = DataConverter.ConvertStringToIntList(inputValues.Text, _delimiter),
                Indices = DataConverter.ConvertStringToIntList(inputIndices.Text, _delimiter)
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("FibonacciLfsr/GenerateSequence", fibonacciLfsr).Result;

            if (response.IsSuccessStatusCode)
            {
                var sequence = response.Content.ReadAsAsync<int[]>().Result;
                outputValues.Text = DataConverter.ConvertIntArrayToString(sequence, _delimiter);
            }
        }
    }
}

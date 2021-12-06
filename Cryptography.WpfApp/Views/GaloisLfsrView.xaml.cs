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
    /// Interaction logic for GaloisLfsrView.xaml
    /// </summary>
    public partial class GaloisLfsrView : UserControl
    {
        private char _delimiter = ',';

        public GaloisLfsrView()
        {
            InitializeComponent();
        }

        private void btnGetPeriod_Click(object sender, RoutedEventArgs e)
        {
            var galoisLfsrData = new GaloisLfsrData
            {
                Values = DataConverter.ConvertStringToIntList(inputValues.Text, _delimiter),
                LinkIndices = DataConverter.ConvertStringToIntList(inputLinkIndices.Text, _delimiter)
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("GaloisLfsr/GetPeriod", galoisLfsrData).Result;

            if (response.IsSuccessStatusCode)
            {
                var period = response.Content.ReadAsAsync<int>().Result;
                outputPeriod.Text = period.ToString();
            }
        }

        private void btnGenerateSequence_Click(object sender, RoutedEventArgs e)
        {
            var galoisLfsrData = new GaloisLfsrData
            {
                Values = DataConverter.ConvertStringToIntList(inputValues.Text, _delimiter),
                LinkIndices = DataConverter.ConvertStringToIntList(inputLinkIndices.Text, _delimiter)
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("GaloisLfsr/GenerateSequence", galoisLfsrData).Result;

            if (response.IsSuccessStatusCode)
            {
                var sequence = response.Content.ReadAsAsync<int[]>().Result;
                outputValues.Text = DataConverter.ConvertIntArrayToString(sequence, _delimiter);
            }
        }
    }
}

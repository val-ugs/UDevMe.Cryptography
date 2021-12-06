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
    /// Interaction logic for FeistelView.xaml
    /// </summary>
    public partial class FeistelView : UserControl
    {
        private List<Element> _inputList1;
        private List<Element> _inputList2;

        public class Element
        {
            public string LabelName { get; set; }
            public string Value { get; set; }

        }

        public FeistelView()
        {
            InitializeComponent();
        }

        private void btnCreateInputList1_Click(object sender, RoutedEventArgs e)
        {
            int value;
            int listSize = int.TryParse(inputKSize1.Text, out value) ? value : 0;

            _inputList1 = CreateInputList("K", listSize);

            inputList1.ItemsSource = _inputList1;
        }

        private void btnCreateInputList2_Click(object sender, RoutedEventArgs e)
        {
            int value;
            int listSize = int.TryParse(inputKSize2.Text, out value) ? value : 0;

            _inputList2 = CreateInputList("K", listSize);

            inputList2.ItemsSource = _inputList2;
        }

        private List<Element> CreateInputList(string listName, int size)
        {
            List<Element> inputList = new List<Element>();

            for (int i = 0; i < size; i++)
            {
                Element element = new Element();
                element.LabelName = listName + "(" + i + "):";
                inputList.Add(element);
            }

            return inputList;
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            Element[] elements = inputList1.Items.OfType<Element>().ToArray();

            var feistelData = new FeistelData
            {
                L = BaseConverter.StringToUint(l1.Text, 16),
                R = BaseConverter.StringToUint(r1.Text, 16),
                K = elements.Select(x => BaseConverter.StringToUint(x.Value, 16)).ToList()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Feistel/Encrypt", feistelData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<FeistelData>().Result;

                outputL1.Text = BaseConverter.UintToString(result.L, 16).ToString();
                outputR1.Text = BaseConverter.UintToString(result.R, 16).ToString();
            }
        }

        private void btnEncryptPerRound_Click(object sender, RoutedEventArgs e)
        {
            Element[] elements = inputList1.Items.OfType<Element>().ToArray();

            int intValue;
            var feistelData = new FeistelData
            {
                L = BaseConverter.StringToUint(l1.Text, 16),
                R = BaseConverter.StringToUint(r1.Text, 16),
                K = elements.Select(x => BaseConverter.StringToUint(x.Value, 16)).ToList(),
                Round = int.TryParse(round1.Text, out intValue) ? intValue : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Feistel/EncryptPerRound", feistelData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<FeistelData>().Result;

                outputRoundL1.Text = BaseConverter.UintToString(result.L, 16).ToString();
                outputRoundR1.Text = BaseConverter.UintToString(result.R, 16).ToString();
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            Element[] elements = inputList2.Items.OfType<Element>().ToArray();

            var feistelData = new FeistelData
            {
                L = BaseConverter.StringToUint(l2.Text, 16),
                R = BaseConverter.StringToUint(r2.Text, 16),
                K = elements.Select(x => BaseConverter.StringToUint(x.Value, 16)).ToList()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Feistel/Decrypt", feistelData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<FeistelData>().Result;

                outputL2.Text = BaseConverter.UintToString(result.L, 16).ToString();
                outputR2.Text = BaseConverter.UintToString(result.R, 16).ToString();
            }
        }

        private void btnDecryptPerRound_Click(object sender, RoutedEventArgs e)
        {
            Element[] elements = inputList2.Items.OfType<Element>().ToArray();

            int intValue;
            var feistelData = new FeistelData
            {
                L = BaseConverter.StringToUint(l2.Text, 16),
                R = BaseConverter.StringToUint(r2.Text, 16),
                K = elements.Select(x => BaseConverter.StringToUint(x.Value, 16)).ToList(),
                Round = int.TryParse(round2.Text, out intValue) ? intValue : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Feistel/DecryptPerRound", feistelData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<FeistelData>().Result;

                outputRoundL2.Text = BaseConverter.UintToString(result.L, 16).ToString();
                outputRoundR2.Text = BaseConverter.UintToString(result.R, 16).ToString();
            }
        }

        private List<Element> CreateOutputList(string listName, int[] outputIntList)
        {
            List<Element> inputList = new List<Element>();

            for (int i = 0; i < outputIntList.Length; i++)
            {
                Element element = new Element();
                element.LabelName = listName + "(" + i + "):";
                element.Value = outputIntList[i].ToString();
                inputList.Add(element);
            }

            return inputList;
        }
    }
}

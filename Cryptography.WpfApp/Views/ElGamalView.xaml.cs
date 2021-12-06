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
    /// Interaction logic for ElGamalView.xaml
    /// </summary>
    public partial class ElGamalView : UserControl
    {
        private List<Element> _inputList1;
        private List<Element> _inputList2;

        public class Element
        {
            public string LabelName { get; set; }
            public string Value { get; set; }

        }

        public ElGamalView()
        {
            InitializeComponent();
        }

        private void btnCreateInputList1_Click(object sender, RoutedEventArgs e)
        {
            int value;
            int listSize = int.TryParse(inputListSize1.Text, out value) ? value : 0;

            _inputList1 = CreateInputList("M", listSize);

            inputList1.ItemsSource = _inputList1;
        }

        private void btnCreateInputList2_Click(object sender, RoutedEventArgs e)
        {
            int value;
            int listSize = int.TryParse(inputListSize2.Text, out value) ? value : 0;

            _inputList2 = CreateInputList("B", listSize);

            inputList2.ItemsSource = _inputList2;
        }

        private List<Element> CreateInputList(string listName ,int size)
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

            int value;
            var elGamalData = new ElGamalData
            {
                P = int.TryParse(p1.Text, out value) ? value : 0,
                G = int.TryParse(g1.Text, out value) ? value : 0,
                K = int.TryParse(k1.Text, out value) ? value : 0,
                X = int.TryParse(x1.Text, out value) ? value : 0,
                Values = elements.Select(x => int.TryParse(x.Value, out value) ? value : 0).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("ElGamal/Encrypt", elGamalData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputIntList = response.Content.ReadAsAsync<int[]>().Result;

                List<Element> outputList = CreateOutputList("B", outputIntList);

                outputList1.ItemsSource = outputList;
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            Element[] elements = inputList2.Items.OfType<Element>().ToArray();

            int value;
            var elGamalData = new ElGamalData
            {
                P = int.TryParse(p2.Text, out value) ? value : 0,
                G = int.TryParse(g2.Text, out value) ? value : 0,
                K = int.TryParse(k2.Text, out value) ? value : 0,
                X = int.TryParse(x2.Text, out value) ? value : 0,
                Values = elements.Select(x => int.TryParse(x.Value, out value) ? value : 0).ToArray()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("ElGamal/Decrypt", elGamalData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputIntList = response.Content.ReadAsAsync<int[]>().Result;

                List<Element> outputList = CreateOutputList("M", outputIntList);

                outputList2.ItemsSource = outputList;
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

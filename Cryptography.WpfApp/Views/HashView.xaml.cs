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
    /// Interaction logic for HashView.xaml
    /// </summary>
    public partial class HashView : UserControl
    {
        private List<Element> _inputList;
        public class Element
        {
            public string LabelName { get; set; }
            public string Value { get; set; }

        }

        public HashView()
        {
            InitializeComponent();
        }

        private void btnCreateInputList_Click(object sender, RoutedEventArgs e)
        {
            int value;
            int listSize = int.TryParse(inputListSize.Text, out value) ? value : 0;

            _inputList = CreateInputList("M", listSize);

            inputList.ItemsSource = _inputList;
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            Element[] elements = inputList.Items.OfType<Element>().ToArray();

            foreach (Element element in elements)
                if (String.IsNullOrWhiteSpace(element.Value))
                {
                    outputH.Text = "0";
                    return;
                } 

            int value;
            var hashData = new HashData
            {
                H0 = int.TryParse(h0.Text, out value) ? value : 0,
                P = int.TryParse(p.Text, out value) ? value : 0,
                M = elements.Select(x => int.TryParse(x.Value, out value) ? value : 0).ToList()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Hash/Calculate", hashData).Result;

            if (response.IsSuccessStatusCode)
            {
                outputH.Text = response.Content.ReadAsAsync<int>().Result.ToString();
            }
        }
    }
}

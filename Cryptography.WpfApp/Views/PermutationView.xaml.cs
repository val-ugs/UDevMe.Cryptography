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
    /// Interaction logic for PermutationView.xaml
    /// </summary>
    public partial class PermutationView : UserControl
    {
        private List<Element> _listOfElements;

        public class Element
        {
            public string Sequence { get; set; }
            public string Text { get; set; }

        }

        public PermutationView()
        {
            InitializeComponent();
        }

        private void btnPermutate_Click(object sender, RoutedEventArgs e)
        {
            var permutationData = new PermutationData
            {
                Text = text.Text
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Permutation/Permutate", permutationData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;

                _listOfElements = CreateOutputList(result);

                outputList.ItemsSource = _listOfElements;
            }
        }

        private List<Element> CreateOutputList(Dictionary<string, string> outputDictionary)
        {
            List<Element> inputList = new List<Element>();

            for (int i = 0; i < outputDictionary.Count; i++)
            {
                Element element = new Element();
                element.Sequence = outputDictionary.ElementAt(i).Key;
                element.Text = outputDictionary.ElementAt(i).Value;
                inputList.Add(element);
            }

            return inputList;
        }

        private void textSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Element> newList = new List<Element>();
            if (!string.IsNullOrWhiteSpace(textSearch.Text))
            {
                foreach (Element element in _listOfElements)
                {
                    if (element.Text.ToUpper().StartsWith(textSearch.Text.Trim().ToUpper()))
                    {
                        newList.Add(element);
                    }
                }
                outputList.ItemsSource = newList;
            }
            else if (string.IsNullOrWhiteSpace(textSearch.Text))
            {
                outputList.ItemsSource = _listOfElements;
            }
        }
    }
}

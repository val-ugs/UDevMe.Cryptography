﻿using Cryptography.WpfApp.Models;
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
    /// Interaction logic for BlowfishView.xaml
    /// </summary>
    public partial class BlowfishView : UserControl
    {
        private List<Element> _inputList1;
        private List<Element> _inputList2;

        public class Element
        {
            public string LabelName { get; set; }
            public string Value { get; set; }

        }

        public BlowfishView()
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

            var blowfishData = new BlowfishData
            {
                L = BaseConverter.StringToUint(l1.Text, 16),
                R = BaseConverter.StringToUint(r1.Text, 16),
                K = elements.Select(x => BaseConverter.StringToUint(x.Value, 16)).ToList()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Blowfish/Encrypt", blowfishData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<FeistelData>().Result;

                outputL1.Text = BaseConverter.UintToString(result.L, 16);
                outputR1.Text = BaseConverter.UintToString(result.R, 16);
            }
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            Element[] elements = inputList2.Items.OfType<Element>().ToArray();

            var blowfishData = new BlowfishData
            {
                L = BaseConverter.StringToUint(l2.Text, 16),
                R = BaseConverter.StringToUint(r2.Text, 16),
                K = elements.Select(x => BaseConverter.StringToUint(x.Value, 16)).ToList()
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Blowfish/Decrypt", blowfishData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<FeistelData>().Result;

                outputL2.Text = BaseConverter.UintToString(result.L, 16);
                outputR2.Text = BaseConverter.UintToString(result.R, 16);
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

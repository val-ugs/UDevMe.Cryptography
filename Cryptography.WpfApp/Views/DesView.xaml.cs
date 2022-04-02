using Cryptography.WpfApp.Models;
using Cryptography.WpfApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for DesView.xaml
    /// </summary>
    public partial class DesView : UserControl
    {
        private char _delimiter = ',';
        private List<Element> _inputList1;
        private List<Element> _inputKey1;
        private DataView _initialIpView1;
        private DataView _finalIpView1;

        public class Element
        {
            public string Value { get; set; }
        }

        public DesView()
        {
            InitializeComponent();

            _inputList1 = CreateInputList(4);
            _inputKey1 = CreateInputList(3);
            _initialIpView1 = CreateGrid(8, 4);
            _finalIpView1 = CreateGrid(8, 4);

            inputList1.ItemsSource = _inputList1;
            inputKey1.ItemsSource = _inputKey1;
            initialIpGrid1.ItemsSource = _initialIpView1;
            finalIpGrid1.ItemsSource = _finalIpView1;
        }

        private List<Element> CreateInputList(int size)
        {
            List<Element> inputList = new List<Element>();

            for (int i = 0; i < size; i++)
            {
                Element element = new Element();
                inputList.Add(element);
            }

            return inputList;
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyData() == false)
            {
                uint[] outputUintList = new uint[] { 0, 0, 0, 0};
                List<Element> outputList = CreateOutputList(outputUintList);
                outputList1.ItemsSource = outputList;

                return;
            }

            Element[] inputElements = inputList1.Items.OfType<Element>().ToArray();
            Element[] keyElements = inputKey1.Items.OfType<Element>().ToArray();

            uint[][] initialIpValues = new uint[_initialIpView1.ToTable().Rows.Count][];
            for (int i = 0; i < _initialIpView1.ToTable().Rows.Count; i++)
                initialIpValues[i] = new uint[_initialIpView1.ToTable().Columns.Count];

            uint[][] finalIpValues = new uint[_finalIpView1.ToTable().Rows.Count][];
            for (int i = 0; i < _finalIpView1.ToTable().Rows.Count; i++)
                finalIpValues[i] = new uint[_finalIpView1.ToTable().Columns.Count];

            uint uintValue;
            for (int i = 0; i < _initialIpView1.ToTable().Rows.Count; i++)
            {
                for (int j = 0; j < _initialIpView1.ToTable().Columns.Count; j++)
                {
                    initialIpValues[i][j] = uint.TryParse((string)_initialIpView1[i][j], out uintValue) ? uintValue : 0;
                }
            }
            for (int i = 0; i < _finalIpView1.ToTable().Rows.Count; i++)
            {
                for (int j = 0; j < _finalIpView1.ToTable().Columns.Count; j++)
                {
                    finalIpValues[i][j] = uint.TryParse((string)_finalIpView1[i][j], out uintValue) ? uintValue : 0;
                }
            }

            var desData = new DesData
            {
                Values = inputElements.Select(x => BaseConverter.StringToUint(x.Value, 16)).ToArray(),
                Key = keyElements.Select(x => BaseConverter.StringToUint(x.Value, 16)).ToArray(),
                InitialIP = initialIpValues,
                PBlock = DataConverter.ConvertStringToUIntList(pBlock1.Text, _delimiter).ToArray(),
                FinalIP = finalIpValues
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Des/Encrypt", desData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputUintList = response.Content.ReadAsAsync<uint[]>().Result;

                List<Element> outputList = CreateOutputList(outputUintList);

                outputList1.ItemsSource = outputList;
            }
        }

        private List<Element> CreateOutputList(uint[] outputIntList)
        {
            List<Element> inputList = new List<Element>();

            for (int i = 0; i < outputIntList.Length; i++)
            {
                Element element = new Element();
                element.Value =  BaseConverter.UintToString(outputIntList[i], 16);
                inputList.Add(element);
            }

            return inputList;
        }

        private DataView CreateGrid(int columnSize, int rowSize)
        {
            string[][] array = new string[columnSize][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new string[rowSize];
            }
            var table = new DataTable();

            for (var c = 0; c < array.Length; c++)
            {
                table.Columns.Add(new DataColumn(c.ToString()));
            }

            for (var r = 0; r < array[0].Length; r++)
            {
                table.Rows.Add(table.NewRow());
            }

            return table.DefaultView;
        }

        private bool VerifyData()
        {
            bool isCorrect = true;

            if (_initialIpView1 == null && _finalIpView1 == null && String.IsNullOrEmpty(pBlock1.Text))
            {
                isCorrect = false;
            }

            Element[] inputElements = inputList1.Items.OfType<Element>().ToArray();
            Element[] keyElements = inputKey1.Items.OfType<Element>().ToArray();

            for (int i = 0; i < inputElements.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(inputElements[i].Value))
                    isCorrect = false;
            }
            for (int i = 0; i < keyElements.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(keyElements[i].Value))
                    isCorrect = false;
            }

            for (int i = 0; i < _initialIpView1.ToTable().Rows.Count; i++)
            {
                for (int j = 0; j < _initialIpView1.ToTable().Columns.Count; j++)
                {
                    if (_initialIpView1[i][j] == DBNull.Value)
                        isCorrect = false;
                }
            }

            for (int i = 0; i < _finalIpView1.ToTable().Rows.Count; i++)
            {
                for (int j = 0; j < _finalIpView1.ToTable().Columns.Count; j++)
                {
                    if (_finalIpView1[i][j] == DBNull.Value)
                        isCorrect = false;
                }
            }

            return isCorrect;
        }
    }
}

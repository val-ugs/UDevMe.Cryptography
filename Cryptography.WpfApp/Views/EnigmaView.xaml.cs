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
    /// Interaction logic for EnigmaView.xaml
    /// </summary>
    public partial class EnigmaView : UserControl
    {
        private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _defaultRotor1 = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
        private const string _defaultRotor2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
        private const string _defaultRotor3 = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
        private const string _defaultRotor4 = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
        private const string _defaultRotor5 = "VZBRGITYUPSDNHLXAWMJQOFECK";
        private const string _defaultRotor6 = "JPGVOUMFYQBENHZRDKASXLICTW";
        private const string _defaultRotor7 = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
        private const string _defaultRotor8 = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
        private const string _defaultReflectorB = "AYBRCUDHEQFSGLIPJXKNMOTZVW";
        private const string _defaultReflectorC = "AFBVCPDJEIGOHYKRLZMXNWTQSU";
        private const string _defaultReflectorBDunn = "AEBNCKDQFUGYHWIJLOMPRXSZTV";
        private const string _defaultReflectorCDunn = "ARBDCOEJFNGTHKIVLMPWQZSXUY";
        private int[] _rotorOptions = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        private string[] _reflectorOptions = new string[] { "Empty", "B", "C", "B Dunn", "C Dunn" };

        private DataView _alphabetView;
        private DataView _patchPanelView;
        private DataView _rotor1View;
        private DataView _rotor2View;
        private DataView _rotor3View;
        private DataView _reflectorView;

        public class Element
        {
            public string Letter { get; set; }

        }

        public EnigmaView()
        {
            InitializeComponent();

            // Create grids
            _alphabetView = CreateGrid(_alphabet.Length, 1);
            _patchPanelView = CreateGrid(_alphabet.Length, 1);
            _rotor1View = CreateGrid(_alphabet.Length, 1);
            _rotor2View = CreateGrid(_alphabet.Length, 1);
            _rotor3View = CreateGrid(_alphabet.Length, 1);
            _reflectorView = CreateGrid(_alphabet.Length, 1);

            // Default fill
            FillAlphabet(_alphabetView);
            FillAlphabet(_patchPanelView);

            // Set ComboBoxes
            indexOfRotor1.ItemsSource = _rotorOptions;
            indexOfRotor2.ItemsSource = _rotorOptions;
            indexOfRotor3.ItemsSource = _rotorOptions;
            letterOfReflector.ItemsSource = _reflectorOptions;

            // Set Grids
            alphabetGrid.ItemsSource = _alphabetView;
            panelPatchGrid.ItemsSource = _patchPanelView;
            rotor1Grid.ItemsSource = _rotor1View;
            rotor2Grid.ItemsSource = _rotor2View;
            rotor3Grid.ItemsSource = _rotor3View;
            reflectorGrid.ItemsSource = _reflectorView;
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

        private DataView FillAlphabet(DataView device)
        {
            return Fill(device, _alphabet);
        }

        private void CmbRotor1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectOptionsForRotor(_rotor1View, indexOfRotor1);
        }

        private void CmbRotor2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectOptionsForRotor(_rotor2View, indexOfRotor2);
        }

        private void CmbRotor3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectOptionsForRotor(_rotor3View, indexOfRotor3);
        }

        void SelectOptionsForRotor(DataView rotorView, ComboBox comboBox)
        {
            int intValue;
            int option = Int32.TryParse(comboBox.SelectedItem.ToString(), out intValue) ? intValue : 0;
            FillRotor(rotorView, option);
        }

        private void CmbReflector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillReflector(_reflectorView, letterOfReflector.SelectedItem.ToString());;
        }

        private DataView FillRotor(DataView rotor, int option)
        {
            switch (option)
            {
                case 0:
                    rotor = FillEmpty(rotor);
                    break;
                case 1:
                    rotor = Fill(rotor, _defaultRotor1);
                    break;
                case 2:
                    rotor = Fill(rotor, _defaultRotor2);
                    break;
                case 3:
                    rotor = Fill(rotor, _defaultRotor3);
                    break;
                case 4:
                    rotor = Fill(rotor, _defaultRotor4);
                    break;
                case 5:
                    rotor = Fill(rotor, _defaultRotor5);
                    break;
                case 6:
                    rotor = Fill(rotor, _defaultRotor6);
                    break;
                case 7:
                    rotor = Fill(rotor, _defaultRotor7);
                    break;
                case 8:
                    rotor = Fill(rotor, _defaultRotor8);
                    break;
                default:
                    break;
            }

            return rotor;
        }

        private DataView FillReflector(DataView reflector, string option)
        {
            switch (option)
            {
                case "Empty":
                    reflector = FillEmpty(reflector);
                    break;
                case "B":
                    reflector = Fill(reflector, _defaultReflectorB);
                    break;
                case "C":
                    reflector = Fill(reflector, _defaultReflectorC);
                    break;
                case "B Dunn":
                    reflector = Fill(reflector, _defaultReflectorBDunn);
                    break;
                case "C Dunn":
                    reflector = Fill(reflector, _defaultReflectorCDunn);
                    break;
                default:
                    break;
            }

            return reflector;
        }

        private DataView Fill(DataView dataView, string deviceValues)
        {
            for (int i = 0; i < _patchPanelView.ToTable().Rows.Count; i++)
            {
                for (int j = 0; j < _patchPanelView.ToTable().Columns.Count; j++)
                {
                    dataView[i][j] = deviceValues[j];
                }
            }

            return dataView;
        }

        private DataView FillEmpty(DataView dataView)
        {
            for (int i = 0; i < _patchPanelView.ToTable().Rows.Count; i++)
            {
                for (int j = 0; j < _patchPanelView.ToTable().Columns.Count; j++)
                {
                    dataView[i][j] = " ";
                }
            }

            return dataView;
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {

            if (VerifyData() == false)
            {
                outputText.Text = "";
                return;
            }

            string patchPanel = FillString(_patchPanelView);
            string rotor1 = FillString(_rotor1View);
            string rotor2 = FillString(_rotor2View);
            string rotor3 = FillString(_rotor3View);
            string reflector = FillString(_reflectorView);

            var enigmaData = new EnigmaData
            {
                InputText = inputText.Text,
                PatchPanel = patchPanel,
                Rotor1 = rotor1,
                Rotor2 = rotor2,
                Rotor3 = rotor3,
                Reflector = reflector
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Enigma/Decrypt", enigmaData).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<string>().Result;

                outputText.Text = result;
            }
        }

        private string FillString(DataView dataView)
        {
            string line = "";

            for (int i = 0; i < dataView.ToTable().Rows.Count; i++)
            {
                for (int j = 0; j < dataView.ToTable().Columns.Count; j++)
                {
                    line += (string)dataView[i][j];
                }
            }

            return line;
        }

        private bool VerifyData()
        {
            bool isCorrect = true;

            isCorrect = ValidateDataView(_patchPanelView) && ValidateDataView(_rotor1View)
                && ValidateDataView(_rotor2View) && ValidateDataView(_rotor3View)
                && ValidateDataView(_reflectorView);

            return isCorrect;
        }

        private bool ValidateDataView(DataView dataView)
        {
            List<string> alphabet = new List<string>();
            for (int i = 0; i < _alphabet.Length; i++)
            {
                alphabet.Add(_alphabet[i].ToString());
            }

            for (int i = 0; i < dataView.ToTable().Rows.Count; i++)
            {
                for (int j = 0; j < dataView.ToTable().Columns.Count; j++)
                {
                    if (dataView[i][j] == DBNull.Value)
                    {
                        return false;
                    }
                    foreach (string letter in alphabet)
                    {
                        if ((string)dataView[i][j] == letter)
                        {
                            alphabet.Remove(letter);
                            break;
                        }
                    }
                }
            }

            if (alphabet.Count != 0)
                return false;

            return true;
        }
    }
}

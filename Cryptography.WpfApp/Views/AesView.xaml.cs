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
    /// Interaction logic for AesView.xaml
    /// </summary>
    public partial class AesView : UserControl
    {
        int _gridSize;
        private DataView _blockView1;
        private DataView _keyView1;

        public AesView()
        {
            InitializeComponent();
        }

        private void btnCreateBlockView1_Click(object sender, RoutedEventArgs e)
        {
            int value;
            _gridSize = int.TryParse(gridSize1.Text, out value) ? value : 0;

            _blockView1 = CreateGrid(_gridSize);
            _keyView1 = CreateGrid(_gridSize);

            blockGrid1.ItemsSource = _blockView1;
            keyGrid1.ItemsSource = _keyView1;
        }

        private void btnGetSubBytesPerRound_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(round1.Text) && _blockView1 == null && _keyView1 == null)
            {
                return;
            }

            uint[][] blockValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _blockView1.ToTable().Rows.Count; i++)
                blockValues[i] = new uint[_blockView1.ToTable().Rows.Count];
            uint[][] keyValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _keyView1.ToTable().Rows.Count; i++)
                keyValues[i] = new uint[_keyView1.ToTable().Rows.Count];

            for (int i = 0; i < _blockView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _blockView1.ToTable().Rows.Count; j++)
                {
                    blockValues[i][j] = BaseConverter.StringToUint((string)_blockView1[i][j], 16) ;
                }
            }
            for (int i = 0; i < _keyView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _keyView1.ToTable().Rows.Count; j++)
                {
                    keyValues[i][j] = BaseConverter.StringToUint((string)_keyView1[i][j], 16);
                }
            }

            int intValue;
            var aesData = new AesData
            {
                Values = blockValues,
                Key = keyValues,
                Round = int.TryParse(round1.Text, out intValue) ? intValue : 0,
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Aes/GetSubBytesPerRound", aesData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputGrid = response.Content.ReadAsAsync<uint[][]>().Result;

                DataView outputView = CreateGrid(_gridSize);

                for (int i = 0; i < outputView.ToTable().Columns.Count; i++)
                {
                    for (int j = 0; j < outputView.ToTable().Rows.Count; j++)
                    {
                        outputView[i][j] = BaseConverter.UintToString(outputGrid[i][j], 16);
                    }
                }

                subBytesGrid.ItemsSource = outputView;
            }
        }

        private void btnGetShiftRowsPerRound_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(round1.Text) && _blockView1 == null && _keyView1 == null)
            {
                return;
            }

            uint[][] blockValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _blockView1.ToTable().Rows.Count; i++)
                blockValues[i] = new uint[_blockView1.ToTable().Rows.Count];
            uint[][] keyValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _keyView1.ToTable().Rows.Count; i++)
                keyValues[i] = new uint[_keyView1.ToTable().Rows.Count];

            for (int i = 0; i < _blockView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _blockView1.ToTable().Rows.Count; j++)
                {
                    blockValues[i][j] = BaseConverter.StringToUint((string)_blockView1[i][j], 16);
                }
            }
            for (int i = 0; i < _keyView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _keyView1.ToTable().Rows.Count; j++)
                {
                    keyValues[i][j] = BaseConverter.StringToUint((string)_keyView1[i][j], 16);
                }
            }

            int intValue;
            var aesData = new AesData
            {
                Values = blockValues,
                Key = keyValues,
                Round = int.TryParse(round1.Text, out intValue) ? intValue : 0,
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Aes/GetShiftRowsPerRound", aesData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputGrid = response.Content.ReadAsAsync<uint[][]>().Result;

                DataView outputView = CreateGrid(_gridSize);

                for (int i = 0; i < outputView.ToTable().Columns.Count; i++)
                {
                    for (int j = 0; j < outputView.ToTable().Rows.Count; j++)
                    {
                        outputView[i][j] = BaseConverter.UintToString(outputGrid[i][j], 16);
                    }
                }

                shiftRowsGrid.ItemsSource = outputView;
            }
        }

        private void btnGetMixColumnsPerRound_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(round1.Text) && _blockView1 == null && _keyView1 == null)
            {
                return;
            }

            uint[][] blockValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _blockView1.ToTable().Rows.Count; i++)
                blockValues[i] = new uint[_blockView1.ToTable().Rows.Count];
            uint[][] keyValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _keyView1.ToTable().Rows.Count; i++)
                keyValues[i] = new uint[_keyView1.ToTable().Rows.Count];

            for (int i = 0; i < _blockView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _blockView1.ToTable().Rows.Count; j++)
                {
                    blockValues[i][j] = BaseConverter.StringToUint((string)_blockView1[i][j], 16);
                }
            }
            for (int i = 0; i < _keyView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _keyView1.ToTable().Rows.Count; j++)
                {
                    keyValues[i][j] = BaseConverter.StringToUint((string)_keyView1[i][j], 16);
                }
            }

            int intValue;
            var aesData = new AesData
            {
                Values = blockValues,
                Key = keyValues,
                Round = int.TryParse(round1.Text, out intValue) ? intValue : 0,
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Aes/GetMixColumnsPerRound", aesData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputGrid = response.Content.ReadAsAsync<uint[][]>().Result;

                DataView outputView = CreateGrid(_gridSize);

                for (int i = 0; i < outputView.ToTable().Columns.Count; i++)
                {
                    for (int j = 0; j < outputView.ToTable().Rows.Count; j++)
                    {
                        outputView[i][j] = BaseConverter.UintToString(outputGrid[i][j], 16);
                    }
                }

                mixColumnsGrid.ItemsSource = outputView;
            }
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(round1.Text) && _blockView1 == null && _keyView1 == null)
            {
                return;
            }

            uint[][] blockValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _blockView1.ToTable().Rows.Count; i++)
                blockValues[i] = new uint[_blockView1.ToTable().Rows.Count];
            uint[][] keyValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _keyView1.ToTable().Rows.Count; i++)
                keyValues[i] = new uint[_keyView1.ToTable().Rows.Count];

            for (int i = 0; i < _blockView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _blockView1.ToTable().Rows.Count; j++)
                {
                    blockValues[i][j] = BaseConverter.StringToUint((string)_blockView1[i][j], 16);
                }
            }
            for (int i = 0; i < _keyView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _keyView1.ToTable().Rows.Count; j++)
                {
                    keyValues[i][j] = BaseConverter.StringToUint((string)_keyView1[i][j], 16);
                }
            }

            int intValue;
            var aesData = new AesData
            {
                Values = blockValues,
                Key = keyValues,
                Round = int.TryParse(round1.Text, out intValue) ? intValue : 0,
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("Aes/Encrypt", aesData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputGrid = response.Content.ReadAsAsync<uint[][]>().Result;

                DataView outputView = CreateGrid(_gridSize);

                for (int i = 0; i < outputView.ToTable().Columns.Count; i++)
                {
                    for (int j = 0; j < outputView.ToTable().Rows.Count; j++)
                    {
                        outputView[i][j] = BaseConverter.UintToString(outputGrid[i][j], 16);
                    }
                }

                outputGrid1.ItemsSource = outputView;
            }
        }   

        private DataView CreateGrid(int size)
        {
            string[][] array = new string[size][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new string[size];
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
    }
}

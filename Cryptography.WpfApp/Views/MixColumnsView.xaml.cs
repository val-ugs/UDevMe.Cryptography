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
    /// Interaction logic for MixColumnsView.xaml
    /// </summary>
    public partial class MixColumnsView : UserControl
    {
        int _gridSize1, _gridSize2;
        private DataView _blockView1;
        private DataView _blockView2;

        public MixColumnsView()
        {
            InitializeComponent();
        }

        private void btnCreateBlockView1_Click(object sender, RoutedEventArgs e)
        {
            int value;
            _gridSize1 = int.TryParse(gridSize1.Text, out value) ? value : 0;
            _blockView1 = CreateGrid(_gridSize1);
            blockGrid1.ItemsSource = _blockView1;
        }

        private void btnCreateBlockView2_Click(object sender, RoutedEventArgs e)
        {
            int value;
            _gridSize2 = int.TryParse(gridSize2.Text, out value) ? value : 0;
            _blockView2 = CreateGrid(_gridSize2);
            blockGrid2.ItemsSource = _blockView2;
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (_blockView1 == null)
                return;

            uint[][] blockValues = new uint[_blockView1.ToTable().Columns.Count][];
            for (int i = 0; i < _blockView1.ToTable().Rows.Count; i++)
                blockValues[i] = new uint[_blockView1.ToTable().Rows.Count];

            for (int i = 0; i < _blockView1.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _blockView1.ToTable().Rows.Count; j++)
                {
                    blockValues[i][j] = BaseConverter.StringToUint((string)_blockView1[i][j], 16);
                }
            }

            var mixColumnsData = new MixColumnsData
            {
                Values = blockValues
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("MixColumns/Encrypt", mixColumnsData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputGrid = response.Content.ReadAsAsync<uint[][]>().Result;

                DataView outputView = CreateGrid(_gridSize1);

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

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (_blockView2 == null)
                return;

            uint[][] blockValues = new uint[_blockView2.ToTable().Columns.Count][];
            for (int i = 0; i < _blockView2.ToTable().Rows.Count; i++)
                blockValues[i] = new uint[_blockView2.ToTable().Rows.Count];

            for (int i = 0; i < _blockView2.ToTable().Columns.Count; i++)
            {
                for (int j = 0; j < _blockView2.ToTable().Rows.Count; j++)
                {
                    blockValues[i][j] = BaseConverter.StringToUint((string)_blockView2[i][j], 16);
                }
            }

            var mixColumnsData = new MixColumnsData
            {
                Values = blockValues
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("MixColumns/Decrypt", mixColumnsData).Result;

            if (response.IsSuccessStatusCode)
            {
                var outputGrid = response.Content.ReadAsAsync<uint[][]>().Result;

                DataView outputView = CreateGrid(_gridSize2);

                for (int i = 0; i < outputView.ToTable().Columns.Count; i++)
                {
                    for (int j = 0; j < outputView.ToTable().Rows.Count; j++)
                    {
                        outputView[i][j] = BaseConverter.UintToString(outputGrid[i][j], 16);
                    }
                }

                outputGrid2.ItemsSource = outputView;
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

            for (var r = 0; r < array.Length; r++)
            {
                table.Rows.Add(table.NewRow());
            }

            return table.DefaultView;
        }
    }
}

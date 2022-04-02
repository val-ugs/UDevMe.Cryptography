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
    /// Interaction logic for SBlockGenerationView.xaml
    /// </summary>
    public partial class SBlockGenerationView : UserControl
    {
        public SBlockGenerationView()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int value;
            var sBlockGenerationData = new SBlockGenerationData
            {
                A = int.TryParse(a.Text, out value) ? value : 0,
                B = int.TryParse(b.Text, out value) ? value : 0,
                C = int.TryParse(c.Text, out value) ? value : 0,
                Z0 = int.TryParse(z0.Text, out value) ? value : 0,
                IMax = int.TryParse(iMax.Text, out value) ? value : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("SBlockGeneration/Generate", sBlockGenerationData).Result;

            if (response.IsSuccessStatusCode)
            {
                int[] values = response.Content.ReadAsAsync<int[]>().Result;
                outputValues.Text = String.Join(" ", values);
            }
        }
    }
}

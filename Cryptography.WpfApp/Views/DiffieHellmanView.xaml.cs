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
    /// Interaction logic for DiffieHellmanView.xaml
    /// </summary>
    public partial class DiffieHellmanView : UserControl
    {
        public DiffieHellmanView()
        {
            InitializeComponent();
        }

        private void btnGetA_Click(object sender, RoutedEventArgs e)
        {
            int value;
            var diffieHellmanData = new DiffieHellmanData
            {
                N = int.TryParse(n.Text, out value) ? value : 0,
                Q = int.TryParse(q.Text, out value) ? value : 0,
                X = int.TryParse(x.Text, out value) ? value : 0,
                Y = int.TryParse(y.Text, out value) ? value : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("DiffieHellman/GetA", diffieHellmanData).Result;

            if (response.IsSuccessStatusCode)
            {
                a.Text = response.Content.ReadAsAsync<int>().Result.ToString();
            }
        }

        private void btnGetB_Click(object sender, RoutedEventArgs e)
        {
            int value;
            var diffieHellmanData = new DiffieHellmanData
            {
                N = int.TryParse(n.Text, out value) ? value : 0,
                Q = int.TryParse(q.Text, out value) ? value : 0,
                X = int.TryParse(x.Text, out value) ? value : 0,
                Y = int.TryParse(y.Text, out value) ? value : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("DiffieHellman/GetB", diffieHellmanData).Result;

            if (response.IsSuccessStatusCode)
            {
                b.Text = response.Content.ReadAsAsync<int>().Result.ToString();
            }
        }

        private void btnGetKeyX_Click(object sender, RoutedEventArgs e)
        {
            int value;
            var diffieHellmanData = new DiffieHellmanData
            {
                N = int.TryParse(n.Text, out value) ? value : 0,
                Q = int.TryParse(q.Text, out value) ? value : 0,
                X = int.TryParse(x.Text, out value) ? value : 0,
                Y = int.TryParse(y.Text, out value) ? value : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("DiffieHellman/GetKeyX", diffieHellmanData).Result;

            if (response.IsSuccessStatusCode)
            {
                k_x.Text = response.Content.ReadAsAsync<int>().Result.ToString();
            }
        }

        private void btnGetKeyY_Click(object sender, RoutedEventArgs e)
        {
            int value;
            var diffieHellmanData = new DiffieHellmanData
            {
                N = int.TryParse(n.Text, out value) ? value : 0,
                Q = int.TryParse(q.Text, out value) ? value : 0,
                X = int.TryParse(x.Text, out value) ? value : 0,
                Y = int.TryParse(y.Text, out value) ? value : 0
            };

            var response = HttpClientSample.Client.PostAsJsonAsync("DiffieHellman/GetKeyY", diffieHellmanData).Result;

            if (response.IsSuccessStatusCode)
            {
                k_y.Text = response.Content.ReadAsAsync<int>().Result.ToString();
            }
        }
    }
}

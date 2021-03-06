using Cryptography.WpfApp.Models;
using Cryptography.WpfApp.Utils;
using Cryptography.WpfApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cryptography.WpfApp.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private Algorithm _selectedAlgorithm;
        private TextBlock _algorithmName;
        private ContentControl _algorithmContent;

        public List<Algorithm> Algorithms { get; set; }
        public Algorithm SelectedAlgorithm 
        {
            get { return _selectedAlgorithm; }
            set
            {
                _selectedAlgorithm = value;
                OnViewChanged(_selectedAlgorithm);
                OnPropertyChanged("SelectedAlgorithm");
            }
        }

        public MainWindowViewModel(TextBlock algorithmName, ContentControl algrorithmContent)
        {
            _algorithmName = algorithmName;
            _algorithmContent = algrorithmContent;

            Algorithms = new List<Algorithm>
            {
                new Algorithm(){ Name = "A5", UserControlSample = new A5View() },
                new Algorithm(){ Name = "Aes", UserControlSample = new AesView() },
                new Algorithm(){ Name = "Blowfish", UserControlSample = new BlowfishView() },
                new Algorithm(){ Name = "Caesar Cipher", UserControlSample = new CaesarCipherView() },
                new Algorithm(){ Name = "DES", UserControlSample = new DesView() },
                new Algorithm(){ Name = "El Gamal", UserControlSample = new ElGamalView() },
                new Algorithm(){ Name = "Enigma", UserControlSample = new EnigmaView() },
                new Algorithm(){ Name = "Diffie Hellman", UserControlSample = new DiffieHellmanView() },
                new Algorithm(){ Name = "Feistel", UserControlSample = new FeistelView() },
                new Algorithm(){ Name = "Fibonacci Lfsr", UserControlSample = new FibonacciLfsrView() },
                new Algorithm(){ Name = "Galois Lfsr", UserControlSample = new GaloisLfsrView() },
                new Algorithm(){ Name = "Gronsfeld Cipher", UserControlSample = new GronsfeldCipherView() },
                new Algorithm(){ Name = "Hash", UserControlSample = new HashView() },
                new Algorithm(){ Name = "MD5", UserControlSample = new Md5View() },
                new Algorithm(){ Name = "MixColumns", UserControlSample = new MixColumnsView() },
                new Algorithm(){ Name = "Permutation", UserControlSample = new PermutationView() },
                new Algorithm(){ Name = "RSA", UserControlSample = new RsaView() },
                new Algorithm(){ Name = "S Block Generation", UserControlSample = new SBlockGenerationView() },
                new Algorithm(){ Name = "Triple Des (3DES)", UserControlSample = new TripleDesView() },
                new Algorithm(){ Name = "Trisemus Cipher", UserControlSample = new TrisemusCipherView() },
                new Algorithm(){ Name = "Vigenere Cipher", UserControlSample = new VigenereCipherView() }
            };

            SelectedAlgorithm = Algorithms.FirstOrDefault();
        }
        private void OnViewChanged(Algorithm algorithm)
        {
            _algorithmName.Text = algorithm.Name;
            _algorithmContent.Content = algorithm.UserControlSample;
        }
    }
}

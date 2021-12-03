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
                new Algorithm(){ Name = "Caesar Cipher", UserControlSample = new CaesarCipherView() },
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

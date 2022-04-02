using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.WpfApp.Models
{
    public class GronsfeldCipherData
    {
        public string Language { get; set; }
        public string Text { get; set; }
        public List<int> Key { get; set; }
    }
}

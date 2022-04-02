using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.WpfApp.Models
{
    public class RsaData
    {
        public int P { get; set; }
        public int Q { get; set; }
        // e or d exponent
        public int Exponent { get; set; }
        public int Value { get; set; }
    }
}

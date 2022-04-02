using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Models
{
    public class ElGamalData
    {
        public int P { get; set; }
        public int G { get; set; }
        public int K { get; set; }
        public int X { get; set; }
        public int[] Values { get; set; }
    }
}

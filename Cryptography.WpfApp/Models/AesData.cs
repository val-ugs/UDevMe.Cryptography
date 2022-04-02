using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.WpfApp.Models
{
    public class AesData
    {
        public uint[][] Values { get; set; }
        public uint[][] Key { get; set; }
        public int Round { get; set; }
    }
}

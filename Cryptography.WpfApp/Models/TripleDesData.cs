using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.WpfApp.Models
{
    public class TripleDesData
    {
        public uint L { get; set; }
        public uint R { get; set; }
        public List<uint> K { get; set; }
        public int DesNumber { get; set; }
    }
}

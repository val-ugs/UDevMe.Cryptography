using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Models
{
    public class DesData
    {
        public uint[] Values { get; set; }
        public uint[] Key { get; set; }
        public uint[][] InitialIP { get; set; }
        public uint[] PBlock { get; set; }
        public uint[][] FinalIP { get; set; }
    }
}

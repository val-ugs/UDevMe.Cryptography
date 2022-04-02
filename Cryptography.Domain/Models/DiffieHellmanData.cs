using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Models
{
    public class DiffieHellmanData
    {
        public int N { get; set; }
        public int Q { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Models
{
    public class Md5Data
    {
        public uint A { get; set; }
        public uint B { get; set; }
        public uint C { get; set; }
        public uint D { get; set; }
        public uint M { get; set; }
        public uint K { get; set; }
        public int Round { get; set; }
    }
}

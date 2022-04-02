using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Models
{
    public class HashData
    {
        public int H0 { get; set; }
        public int P { get; set; }
        public List<int> M { get; set; }
    }
}

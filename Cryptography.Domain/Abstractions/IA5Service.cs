using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IA5Service
    {
        int[] Encrypt(A5Data a5Data);
        int[] Decrypt(A5Data a5Data);
        int[] GetKey(A5Data a5Data);
    }
}

using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IVigenereCipherService
    {
        string Encrypt(VigenereCipherData vigenereCipherData);
        string Decrypt(VigenereCipherData vigenereCipherData);
    }
}

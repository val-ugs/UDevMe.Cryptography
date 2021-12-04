using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IMd5Service
    {
        Md5Data Encrypt(Md5Data md5Data);
        Md5Data EncryptPerRound(Md5Data md5Data);
        Md5Data Decrypt(Md5Data md5Data);
        Md5Data DecryptPerRound(Md5Data md5Data);
    }
}

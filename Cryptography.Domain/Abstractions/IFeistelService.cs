using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IFeistelService
    {
        FeistelData Encrypt(FeistelData feistelData);
        FeistelData EncryptPerRound(FeistelData feistelData);
        FeistelData Decrypt(FeistelData feistelData);
        FeistelData DecryptPerRound(FeistelData feistelData);
    }
}

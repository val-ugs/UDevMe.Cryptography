using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IAesService
    {
        uint[][] GetSubBytesPerRound(AesData aesData);
        uint[][] GetShiftRowsPerRound(AesData aesData);
        uint[][] GetMixColumnsPerRound(AesData aesData);
        uint[][] Encrypt(AesData aesData);
        uint[][] Decrypt(AesData aesData);
    }
}

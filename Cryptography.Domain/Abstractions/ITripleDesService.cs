using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface ITripleDesService
    {
        TripleDesData Encrypt(TripleDesData tripleDesData);
        TripleDesData EncryptPerDesNumber(TripleDesData tripleDesData);
        TripleDesData Decrypt(TripleDesData tripleDesData);
        TripleDesData DecryptPerDesNumber(TripleDesData tripleDesData);
    }
}

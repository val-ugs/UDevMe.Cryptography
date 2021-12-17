using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IDesService
    {
        uint[] Encrypt(DesData desData);
        uint[] Decrypt(DesData desData);
    }
}

using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IDiffieHellmanService
    {
        int GetA(DiffieHellmanData diffieHellmanData);
        int GetB(DiffieHellmanData diffieHellmanData);
        int GetKeyX(DiffieHellmanData diffieHellmanData);
        int GetKeyY(DiffieHellmanData diffieHellmanData);

    }
}

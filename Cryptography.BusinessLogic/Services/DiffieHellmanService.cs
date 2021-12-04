using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class DiffieHellmanService : IDiffieHellmanService
    {
        public int GetKeyX(DiffieHellmanData diffieHellmanData)
        {
            return (int)Math.Pow(GetB(diffieHellmanData), diffieHellmanData.X) % diffieHellmanData.N;
        }

        public int GetKeyY(DiffieHellmanData diffieHellmanData)
        {
            return (int)Math.Pow(GetA(diffieHellmanData), diffieHellmanData.Y) % diffieHellmanData.N;
        }

        public int GetA(DiffieHellmanData diffieHellmanData)
        {
            return (int)Math.Pow(diffieHellmanData.Q, diffieHellmanData.X) % diffieHellmanData.N;
        }

        public int GetB(DiffieHellmanData diffieHellmanData)
        {
            return (int)Math.Pow(diffieHellmanData.Q, diffieHellmanData.Y) % diffieHellmanData.N;
        }
    }
}

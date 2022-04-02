using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class DiffieHellmanService : IDiffieHellmanService
    {
        public int GetKeyX(DiffieHellmanData diffieHellmanData)
        {
            int b = GetB(diffieHellmanData);
            decimal temp = b;
            for (int i = 0; i < diffieHellmanData.X - 1; i++)
                temp *= b;
            return (int)(temp % diffieHellmanData.N);
        }

        public int GetKeyY(DiffieHellmanData diffieHellmanData)
        {
            int a = GetA(diffieHellmanData);
            decimal temp = a;
            for (int i = 0; i < diffieHellmanData.Y - 1; i++)
                temp *= a;
            return (int)(temp % diffieHellmanData.N);
        }

        public int GetA(DiffieHellmanData diffieHellmanData)
        {
            BigInteger temp = diffieHellmanData.Q;
            for (int i = 0; i < diffieHellmanData.X - 1; i++)
                temp *= diffieHellmanData.Q;
            return (int)(temp % diffieHellmanData.N);
        }

        public int GetB(DiffieHellmanData diffieHellmanData)
        {
            BigInteger temp = diffieHellmanData.Q;
            for (int i = 0; i < diffieHellmanData.Y - 1; i++)
                temp *= diffieHellmanData.Q;
            return (int)(temp % diffieHellmanData.N);
        }
    }
}

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
    public class RsaService : IRsaService
    {
        bool CheckPrimeNumber(int number)
        {
            for (int i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        int CoPrime(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            if (a == b)
                return a;

            if (a > b)
                return CoPrime(a - b, b);

            return CoPrime(a, b - a);
        }

        bool CheckCoPrime(int a, int b)
        {
            if (CoPrime(a, b) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Encrypt(RsaData rsaData)
        {
            int m, n, y;

            CheckPQ(rsaData.P, rsaData.Q);

            m = rsaData.P * rsaData.Q;
            n = (rsaData.P - 1) * (rsaData.Q - 1);

            if (rsaData.Exponent <= 1 && rsaData.Exponent >= n)
                throw new Exception("1 < e < n not performed");

            if (!CheckCoPrime(rsaData.Exponent, n))
                throw new Exception("e and n is not co-prime");

            BigInteger temp = rsaData.Value;
            for (int i = 0; i < rsaData.Exponent - 1; i++)
                temp *= rsaData.Value;
            y = (int)(temp % m);

            return y;
        }

        public int Decrypt(RsaData rsaData)
        {
            int m, n, x;

            CheckPQ(rsaData.P, rsaData.Q);

            m = rsaData.P * rsaData.Q;
            n = (rsaData.P - 1) * (rsaData.Q - 1);

            BigInteger temp = rsaData.Value;
            for (int i = 0; i < rsaData.Exponent - 1; i++)
                temp *= rsaData.Value;
            x = (int)(temp % m);

            return x;
        }

        void CheckPQ(int p, int q)
        {
            if (!CheckPrimeNumber(p))
                throw new Exception("p is not prime");
            if (!CheckPrimeNumber(q))
                throw new Exception("q is not prime");
        }
    }
}

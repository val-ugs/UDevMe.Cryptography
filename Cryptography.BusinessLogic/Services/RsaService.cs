using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                throw new Exception("Не допустимое e. Должно быть в пределах 1 < e < n");

            if (!CheckCoPrime(rsaData.Exponent, n))
                throw new Exception("e и n не взаимо простые");

            y = (int)Math.Pow(rsaData.Value, rsaData.Exponent) % m;

            return y;
        }

        public int Decrypt(RsaData rsaData)
        {
            int m, n, x;

            CheckPQ(rsaData.P, rsaData.Q);

            m = rsaData.P * rsaData.Q;
            n = (rsaData.P - 1) * (rsaData.Q - 1);

            x = (int)Math.Pow(rsaData.Value, rsaData.Exponent) % m;

            return x;
        }

        void CheckPQ(int p, int q)
        {
            if (!CheckPrimeNumber(p))
                throw new Exception("p - не простое");
            if (!CheckPrimeNumber(q))
                throw new Exception("q - не простое");
        }
    }
}

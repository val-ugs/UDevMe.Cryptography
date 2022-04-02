using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class ElGamalService : IElGamalService
    {
        public int[] Encrypt(ElGamalData elGamalData)
        {
            int y;
            int[] newValues = new int[elGamalData.Values.Length];

            y = (int)(Math.Pow(elGamalData.G, elGamalData.X) % elGamalData.P);

            for (int i = 0; i < elGamalData.Values.Length; i++)
            {
                newValues[i] = elGamalData.Values[i] * (int)(Math.Pow(y, elGamalData.K) % elGamalData.P);
            }

            return newValues;
        }

        public int[] Decrypt(ElGamalData elGamalData)
        {
            int a;
            int[] newValues = new int[elGamalData.Values.Length];

            a = (int)(Math.Pow(elGamalData.G, elGamalData.K) % elGamalData.P);

            for (int i = 0; i < elGamalData.Values.Length; i++)
            {
                newValues[i] = elGamalData.Values[i] / (int)(Math.Pow(a, elGamalData.X) % elGamalData.P);
            }

            return newValues;
        }
    }
}

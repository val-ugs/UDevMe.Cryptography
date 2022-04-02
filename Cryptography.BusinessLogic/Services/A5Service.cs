using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class A5Service : IA5Service
    {
        public int[] Encrypt(A5Data a5Data)
        {
            int[] key = GetKey(a5Data);

            for (int i = 0; i < a5Data.InputValues.Length; i++)
            {
                a5Data.InputValues[i] ^= key[i];
            }

            return a5Data.InputValues;
        }

        public int[] Decrypt(A5Data a5Data)
        {
            return Encrypt(a5Data);
        }
        public int[] GetKey(A5Data a5Data)
        {
            List<int> registerA = a5Data.RegisterA;
            List<int> registerB = a5Data.RegisterB;
            List<int> registerC = a5Data.RegisterC;
            int outValue, tailA, tailB, tailC;
            int[] output = new int[16];

            for (int i = 0; i < 16; i++)
            {
                outValue = registerA[0] ^ registerB[0] ^ registerC[0];
                tailA = 0;
                tailB = 0;
                tailC = 0;

                tailA = Feedback(registerA, a5Data.IndicesA);
                tailB = Feedback(registerB, a5Data.IndicesB);
                tailC = Feedback(registerC, a5Data.IndicesC);

                registerA = updateRegister(registerA, tailA);
                registerB = updateRegister(registerB, tailB);
                registerC = updateRegister(registerC, tailC);

                output[i] = outValue;
            }

            return output;
        }

        private int Feedback(List<int> register, List<int> indices)
        {
            int value = 0;

            foreach (int index in indices)
                value ^= register[index];

            return value;
        }

        private List<int> updateRegister(List<int> register, int value)
        {
            // shift
            for (int i = 0; i < register.Count - 1; i++)
            {
                register[i] = register[i + 1];
            }
            register[register.Count - 1] = value;

            return register;
        }
    }
}

using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class MixColumnsService : IMixColumnsService
    {
        private uint[] _c = new uint[] { 3, 1, 1, 2 };
        private uint[] _g = new uint[] { 0x0b, 0x0d, 0x09, 0x0e }; // invC

        public uint[][] Encrypt(MixColumnsData mixColumnsData)
        {
            return MixColumns(mixColumnsData.Values, isEncrypt:true);
        }

        public uint[][] Decrypt(MixColumnsData mixColumnsData)
        {
            return MixColumns(mixColumnsData.Values, isEncrypt: false);
        }

        private uint[][] MixColumns(uint[][] values, bool isEncrypt)
        {
            uint[] arr = isEncrypt ? _c : _g;

            uint[][] matr;
            switch (values.Length)
            {
                case 2:
                    matr = new uint[][] { new uint[] { arr[3], arr[2] },
                                          new uint[] { arr[2], arr[3] } };
                    break;
                case 4:
                    matr = new uint[][] { new uint[] { arr[3], arr[0], arr[1], arr[2]},
                                          new uint[] { arr[2], arr[3], arr[0], arr[1]},
                                          new uint[] { arr[1], arr[2], arr[3], arr[0]},
                                          new uint[] { arr[0], arr[1], arr[2], arr[3]},};
                    break;
                default:
                    throw new Exception("Order is not 2 or 4");
            }

            values = MixColumnsMatrices(values, matr);

            return values;
        }

        private uint[][] MixColumnsMatrices(uint[][] matr1, uint[][] matr2)
        {
            uint[][] matr = new uint[matr1.Length][];
            for (int i = 0; i < matr.Length; i++)
                matr[i] = new uint[matr1.Length];

            for (int i = 0; i < matr2.Length; i++)
            {
                for (int j = 0; j < matr1.Length; j++)
                {
                    for (int k = 0; k < matr2.Length; k++)
                    {
                        matr[i][j] ^= GMul((byte)matr2[i][k], (byte)matr1[k][j]);
                    }
                }
            }

            return matr;
        }

        private byte GMul(byte a, byte b)
        { // Galois Field (256) Multiplication of two Bytes
            byte p = 0;

            for (int counter = 0; counter < 8; counter++)
            {
                if ((b & 1) != 0)
                {
                    p ^= a;
                }

                bool hi_bit_set = (a & 0x80) != 0;
                a <<= 1;
                if (hi_bit_set)
                {
                    a ^= 0x1B; /* x^8 + x^4 + x^3 + x + 1 */
                }
                b >>= 1;
            }

            return p;
        }
    }
}

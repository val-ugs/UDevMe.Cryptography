using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class AesService : IAesService
    {
        private uint[] _subBytesValues = new uint[] {
            0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
            0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
            0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
            0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
            0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
            0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
            0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
            0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
            0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
            0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
            0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
            0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
            0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
            0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
            0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
            0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
        };
        private uint[] _invSubBytesValues = new uint[]{
            0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
            0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
            0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
            0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
            0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
            0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
            0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
            0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
            0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
            0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
            0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
            0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
            0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
            0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
            0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
            0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
        };
        private uint[] _c = new uint[] { 3, 1, 1, 2 };
        private uint[] _g = new uint[] { 0x0b, 0x0d, 0x09, 0x0e}; // invC
        private uint[] _rcon = new uint[]{0x00, 0x01, 0x02, 0x04, 0x08, 0x10,
                                            0x20, 0x40, 0x80, 0x1b, 0x36};
        public uint[][] Encrypt(AesData aesData)
        {
            return AesAlgorithm(aesData, mode:0, isEncrypt:true);
        }

        public uint[][] Decrypt(AesData aesData)
        {
            return AesAlgorithm(aesData, mode: 0, isEncrypt: false);
        }

        public uint[][] GetSubBytesPerRound(AesData aesData)
        {
            return AesAlgorithm(aesData, mode:1, isEncrypt: true);
        }

        public uint[][] GetShiftRowsPerRound(AesData aesData)
        {
            return AesAlgorithm(aesData, mode:2, isEncrypt: true);
        }

        public uint[][] GetMixColumnsPerRound(AesData aesData)
        {
            return AesAlgorithm(aesData, mode:3, isEncrypt: true);
        }

        //mode: 0 - Full Algorithm, 1 - SubBytes, 2 - ShiftRows, 3 - MixColumns
        private uint[][] AesAlgorithm(AesData aesData, int mode, bool isEncrypt)
        {
            if (aesData.Values.Length != aesData.Key.Length && aesData.Values[0].Length == aesData.Key[0].Length)
            {
                uint[][] arr = new uint[aesData.Values.Length][];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = new uint[aesData.Values.Length];

                return Fill2DArrayWithValue(arr, 0);
            }

            uint[][] outputValues = new uint[aesData.Values.Length][];
            for (int i = 0; i < outputValues.Length; i++)
                outputValues[i] = new uint[aesData.Values.Length];

            if (isEncrypt)
            {
                // Encrypt
                outputValues = AddRoundKey(aesData.Values, aesData.Key);

                for (int i = 0; i < aesData.Round; i++)
                {
                    outputValues = SubBytes(outputValues, isEncrypt);
                    if (mode == 1 && i == aesData.Round - 1)
                        break;

                    outputValues = ShiftRows(outputValues, isEncrypt);
                    if (mode == 2 && i == aesData.Round - 1)
                        break;

                    if (i != aesData.Round - 1 || i == 0) // The last round does not use the function
                    {
                        outputValues = MixColumns(outputValues, isEncrypt);
                        if (mode == 3)
                            break;
                    }

                    outputValues = AddRoundKey(outputValues, KeyExpansion(aesData.Key, i));
                }
            }
            else
            {
                // Decrypt
                outputValues = AddRoundKey(aesData.Values, KeyExpansion(aesData.Key, aesData.Round - 1));

                for (int i = aesData.Round - 1; i >= 0; i--)
                {
                    outputValues = ShiftRows(outputValues, isEncrypt);
                    if (mode == 2 && i == 0)
                        break;

                    outputValues = SubBytes(outputValues, isEncrypt);
                    if (mode == 1 && i == 0)
                        break;

                    outputValues = i == 0 ? AddRoundKey(outputValues, aesData.Key)
                                          : AddRoundKey(outputValues, KeyExpansion(aesData.Key, i));

                    if (i != aesData.Round - 1 || i == 0) // The last round does not use the function
                    {
                        outputValues = MixColumns(outputValues, isEncrypt);
                        if (mode == 3)
                            break;
                    }
                }
            }

            return outputValues;
        }

        private uint[][] AddRoundKey(uint[][] values, uint[][] key)
        {
            for (int i = 0; i < values.Length; i++)
            {
                for(int j = 0; j < values.Length; j++)
                {
                    values[i][j] ^= key[i][j];
                }
            }

            return values;
        }

        private uint[][] SubBytes(uint[][] values, bool isEncrypt)
        {
            uint[] arr = isEncrypt ? _subBytesValues : _invSubBytesValues;

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    values[i][j] = arr[values[i][j]];
                }
            }

            return values;
        }

        private uint[][] ShiftRows(uint[][] values, bool isEncypt)
        {
            uint temp;
            int repeatTimes = 0;
            if (isEncypt)
            {
                //Encrypt
                for (int i = 0; i < values.Length; i++)
                {
                    repeatTimes = i;
                    while (repeatTimes > 0)
                    {
                        temp = values[i][0];
                        for (int j = 0; j < values.Length - 1; j++)
                        {
                            values[i][j] = values[i][j + 1];
                        }
                        values[i][values.Length - 1] = temp;

                        repeatTimes--;
                    }
                }
            }
            else
            {
                //Decrypt
                for (int i = 0; i < values.Length; i++)
                {
                    repeatTimes = i;
                    while (repeatTimes > 0)
                    {
                        temp = values[i][values.Length - 1];
                        for (int j = values.Length - 1; j > 0; j--)
                        {
                            values[i][j] = values[i][j - 1];
                        }
                        values[i][0] = temp;

                        repeatTimes--;
                    }
                }
            }

            return values;
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

        private uint[][] KeyExpansion(uint[][] key, int round)
        {
            uint[][] newKey = new uint[key.Length][];
            for (int i = 0; i < newKey.Length; i++)
                newKey[i] = new uint[key.Length];

            int allRounds = key.Length * (_rcon.Length + 1); // 11 * key.Length
            uint[,] w = new uint[allRounds, key.Length];
            uint[] x, y, newW;
            uint[] z = null;
            uint[] rcon = new uint[key.Length];
            Array.Fill(rcon, (uint)0);

            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    w[i, j] = key[j][i];
                }
            }

            for (int i = key.Length; i < allRounds; i++)
            {
                if (i % key.Length == 0)
                {
                    x = RotWord(GetRow(w, i - 1));
                    y = SubWord(x);
                    rcon[0] = _rcon[i / key.Length];
                    z = XorValuesFromArrays(y, rcon);
                }
                
                newW = XorValuesFromArrays(GetRow(w, i - key.Length), z);
                z = newW;

                for (int j = 0; j < key.Length; j++)
                {
                    w[i, j] = newW[j];
                }

                if (i == (round + 2) * key.Length - 1)
                    break;
            }

            // Set new key
            for (int i = 0; i < newKey.Length; i++)
            {
                for (int j = 0; j < newKey.Length; j++)
                {
                    newKey[j][i] = w[i + (round + 1) * key.Length, j];
                }
            }

            return newKey;
        }

        private uint[] RotWord(uint[] row)
        {
            uint temp = row[0];
            
            for (int i = 0; i < row.Length - 1; i++)
            {
                row[i] = row[i + 1];
            }
            row[row.Length - 1] = temp;

            return row;
        }

        private uint[] SubWord(uint[] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                row[i] = _subBytesValues[row[i]];
            }

            return row;
        }

        private uint[] XorValuesFromArrays(uint[] a, uint[] b)
        {
            return a.Select((x, index) => x ^ b[index]).ToArray();
        }

        public uint[][] Fill2DArrayWithValue(uint[][] arr, uint value)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                for (int j = 0; j < arr.Length; ++j)
                {
                    arr[i][j] = value;
                }
            }

            return arr;
        }

        public uint[] GetColumn(uint[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public uint[] GetRow(uint[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}

using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
	public class DesService : IDesService
	{
		private uint[,] _s1 = {
			{ 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 },
			{ 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8 },
			{ 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 },
			{ 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 }
		};

		private uint[,] _s2 = {
			{ 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 },
			{ 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
			{ 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 },
			{ 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 }
		};

		private uint[,] _s3 = {
			{ 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 },
			{ 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1 },
			{ 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 },
			{ 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 }
		};

		private uint[,] _s4 = {
			{ 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 },
			{ 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 },
			{ 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 },
			{ 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 }
		};

		private int[] _extensionIndices = new int[] {
			15, 0, 1, 2, 3, 4, 3, 4, 5, 6, 7, 8, 7, 8, 9, 10, 11, 12, 11, 12, 13, 14, 15, 0
		};

		public uint[] Encrypt(DesData desData)
		{
			uint[] inputBits = ConvertUintArrayToBits(desData.Values);
			uint[] keyBits = ConvertUintArrayToBits(desData.Key);

			inputBits = PermutationIP(desData.InitialIP, inputBits);

			uint[] rBits = inputBits.Skip(16).ToArray();

			uint[] currentRBits = BitExtension(rBits);

			currentRBits = XorBits(currentRBits, keyBits);

			uint[] bitsAfterSBlocks = FunctionS(currentRBits);

			uint[] bitsAfterPBlock = FunctionP(bitsAfterSBlocks, desData);

			uint[] r1Bits = XorBits(inputBits.Take(16).ToArray(), bitsAfterPBlock);

			uint[] l1r1 = inputBits.Skip(16).ToArray().Concat(r1Bits).ToArray();

			l1r1 = PermutationIP(desData.FinalIP, l1r1);

			uint[] outputValues = ConvertBitsToUintArray(l1r1);

			return outputValues;
		}

		public uint[] Decrypt(DesData desData)
		{
			throw new NotImplementedException();
		}

		private uint[] PermutationIP(uint[][] iP, uint[] bits)
		{
			uint[] arr = new uint[bits.Length];
			int k = 0;
			for (int i = 0; i < iP.Length; i++)
			{
				for (int j = 0; j < iP[0].Length; j++)
				{
					arr[k] = bits[(int)iP[i][j] - 1];
					k++;
				}
			}

			return arr;
		}

		private uint[] BitExtension(uint[] bits)
		{
			uint[] arr = new uint[24];

			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = bits[_extensionIndices[i]];
			}

			return arr;
		}

		private uint[] XorBits(uint[] bits1, uint[] bits2)
		{
			for (int i = 0; i < bits2.Length; i++)
			{
				bits1[i] ^= bits2[i];
			}

			return bits1;
		}

		private uint[] FunctionS(uint[] bits)
		{
			uint[] arr = new uint[] { };
			uint[] values = new uint[4];
			uint[] columnIndexBits, rowIndexBits;
			uint columnIndex, rowIndex;

			for (int i = 0; i < 4; i++) // 4 - 4 s blocks
            {
				columnIndexBits = new uint[] { bits.Skip(6 * i).ToArray()[0], bits.Skip(6 * i + 5).ToArray()[0] };
				rowIndexBits = bits.Skip(6 * i + 1).Take(4).ToArray();
				columnIndex = ConvertBitsToUint(columnIndexBits);
				rowIndex = ConvertBitsToUint(rowIndexBits);
				values[i] = GetSBlockValue(columnIndex, rowIndex, i);
            }

			for (int i = 0; i < values.Length; i++)
            {
				arr = arr.Concat(ConvertUintToBits(values[i]).Skip(4).ToArray()).ToArray();
            }

			return arr;
        }

		private uint GetSBlockValue(uint columnIndex, uint rowIndex, int numberBlock)
        {
			uint[,] sBlock = new uint[4, 16];
            switch (numberBlock)
            {
				case 0:
					sBlock = _s1;
					break;
				case 1:
					sBlock = _s2;
					break;
				case 2:
					sBlock = _s3;
					break;
				case 3:
					sBlock = _s4;
					break;
			}

			return sBlock[columnIndex, rowIndex];
        }

		private uint[] FunctionP(uint[] bits, DesData desData)
        {
			uint[] arr = new uint[desData.PBlock.Length];

			for (int i = 0; i < arr.Length; i++)
            {
				arr[i] = bits[ (int)desData.PBlock[i] - 1];
            }

			return arr;
        }

		private uint[] ConvertUintArrayToBits(uint[] values)
        {
			uint[] arr = new uint[8 * values.Length]; // 8 bits
			
			for (int i = 0; i < values.Length; i++)
            {
				uint[] valueBits = ConvertUintToBits(values[i]);
				for (int j = 0; j < 8; j++)
                {
					arr[i * 8 + j] = valueBits[j];
                }
            }

			return arr;
        }

		private uint[] ConvertUintToBits(uint value)
        {
			uint[] arr = new uint[8]; // 8 bits
			int i = 0;
			
			for (int j = arr.Length - 1; j >= 0; j--)
            {
				arr[i] = (uint)( (value & (1 << j)) > 0 ? 1 : 0);
				i++;
            }

			return arr;
		}

		private uint[] ConvertBitsToUintArray(uint[] bits)
        {
			uint[] arr = new uint[bits.Length / 8];

			for (int i = 0; i < bits.Length / 8; i++)
            {
				arr[i] = ConvertBitsToUint(bits.Skip(8 * i).Take(8).ToArray());
            }

			return arr;
        }

		private uint ConvertBitsToUint(uint[] bits)
		{
			uint value = 0;
			int i = 0;
			for (int j = bits.Length - 1; j >= 0; j--)
			{
				value += (bits[i] << j);
				i++;
			}

			return value;
		}
	}
}

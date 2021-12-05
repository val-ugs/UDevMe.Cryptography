using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class Md5Service : IMd5Service
    {
        private int _maxRound = 4;
        private uint _limitUInt = 16;

        private Md5Data _emptyMd5Data = new Md5Data
        {
            A = 0,
            B = 0,
            C = 0,
            D = 0
        };

        public Md5Data Encrypt(Md5Data md5Data)
        {
            md5Data.Round = _maxRound;
            return EncryptPerRound(md5Data);
        }

        public Md5Data EncryptPerRound(Md5Data md5Data)
        {
            uint temp;
            Md5Data currentMd5Data = md5Data;

            if (VerifyMd5Data(currentMd5Data) == false)
                return _emptyMd5Data;

            for (int i = 1; i <= md5Data.Round; i++)
            {
                temp = F(currentMd5Data.B, currentMd5Data.C, currentMd5Data.D, i);
                temp ^= currentMd5Data.A;
                temp ^= currentMd5Data.M;
                temp ^= currentMd5Data.K;
                temp = LeftRotateS(temp, i);
                temp ^= currentMd5Data.B;
                currentMd5Data.A = currentMd5Data.D;
                currentMd5Data.D = currentMd5Data.C;
                currentMd5Data.C = currentMd5Data.B;
                currentMd5Data.B = temp;
            }

            return currentMd5Data;
        }

        public Md5Data Decrypt(Md5Data md5Data)
        {
            md5Data.Round = _maxRound;
            return DecryptPerRound(md5Data);
        }

        public Md5Data DecryptPerRound(Md5Data md5Data)
        {
            uint temp;
            Md5Data currentMd5Data = md5Data;

            if (VerifyMd5Data(currentMd5Data) == false)
                return _emptyMd5Data;

            for (int i = _maxRound; i > _maxRound - md5Data.Round; i--)
            {
                temp = currentMd5Data.B;
                temp ^= currentMd5Data.C;
                temp = RightRotateS(temp, i);
                temp ^= currentMd5Data.K;
                temp ^= currentMd5Data.M;
                temp ^= F(currentMd5Data.C, currentMd5Data.D, currentMd5Data.A, i);
                currentMd5Data.B = currentMd5Data.C;
                currentMd5Data.C = currentMd5Data.D;
                currentMd5Data.D = currentMd5Data.A;
                currentMd5Data.A = temp;
            }

            return currentMd5Data;
        }

        private uint F(uint B, uint C, uint D, int round)
        {
            uint f = 0;
            switch (round)
            {
                case 1:
                    f = (B & C) | (~B & D);
                    break;
                case 2:
                    f = (B & D) | (~D & C);
                    break;
                case 3:
                    f = B ^ C ^ D;
                    break;
                case 4:
                    f = C ^ (~D | B);
                    break;
                default:
                    new Exception("No such round");
                    break;
            }
            f %= _limitUInt;

            return f;
        }

        private uint LeftRotateS(uint temp, int s)
        {
            s += 1;
            return ((temp << (s % 4)) | (temp >> (((4 - s) + 4) % 4))) % _limitUInt;
        }

        private uint RightRotateS(uint temp, int s)
        {
            s += 1;
            return ((temp >> s % 4) | (temp << (((4 - s) + 4) % 4))) % _limitUInt;
        }

        private bool VerifyMd5Data(Md5Data md5Data)
        {
            if (VerifyUInt(md5Data.A) && VerifyUInt(md5Data.B) && VerifyUInt(md5Data.C)
                && VerifyUInt(md5Data.D) && VerifyUInt(md5Data.M) && VerifyUInt(md5Data.K)
                && VerifyRound(md5Data.Round))
                return true;
            return false;
        }

        private bool VerifyUInt(uint value)
        {
            return value >= 0 && value <= _limitUInt;
        }

        private bool VerifyRound(int round)
        {
            if (round > 0 && round <= _maxRound)
            {
                return true;
            }
            return false;
        }
    }
}

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

        public Md5Data Encrypt(Md5Data md5Data)
        {
            md5Data.Round = _maxRound;
            return EncryptPerRound(md5Data);
        }

        public Md5Data EncryptPerRound(Md5Data md5Data)
        {
            uint temp;
            Md5Data currentMd5Data = md5Data;

            if (md5Data.Round < 0 && md5Data.Round >= _maxRound)
                throw new Exception("No such round");

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

            if (md5Data.Round < 0 && md5Data.Round >= _maxRound)
                throw new Exception("No such round");

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
                    new Exception("No sych round");
                    break;
            }
            f %= _limitUInt;

            return f;
        }

        private uint LeftRotateS(uint temp, int s)
        {
            return ((temp << s) | (temp >> (4 - s))) % _limitUInt;
        }

        private uint RightRotateS(uint temp, int s)
        {
            return ((temp >> s) | (temp << (4 - s))) % _limitUInt;
        }
    }
}

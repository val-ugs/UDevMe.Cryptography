using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class BlowfishService : IBlowfishService
    {
        private BlowfishData _emptyBlowfishData = new BlowfishData
        {
            L = 0,
            R = 0
        };

        public BlowfishData Encrypt(BlowfishData blowfishData)
        {
            uint temp;

            if (VerifyRound(blowfishData) == false)
                return (_emptyBlowfishData);

            for (int i = 0; i < blowfishData.K.Count - 2; i++)
            {
                temp = blowfishData.L;
                temp ^= blowfishData.K[i];

                if (i == blowfishData.K.Count - 3)
                {
                    blowfishData.R = F(temp) ^ blowfishData.R;
                    blowfishData.L = temp;
                    break;
                }

                blowfishData.L = F(temp) ^ blowfishData.R;
                blowfishData.R = temp;
            }

            blowfishData.L ^= blowfishData.K[blowfishData.K.Count - 2];
            blowfishData.R ^= blowfishData.K[blowfishData.K.Count - 1];

            return blowfishData;
        }

        public BlowfishData Decrypt(BlowfishData blowfishData)
        {
            uint temp;

            blowfishData.L ^= blowfishData.K[blowfishData.K.Count - 2];
            blowfishData.R ^= blowfishData.K[blowfishData.K.Count - 1];

            if (VerifyRound(blowfishData) == false)
                return (_emptyBlowfishData);

            for (int i = blowfishData.K.Count - 3; i >= 0; i--)
            {
                temp = blowfishData.L;

                if (i == 0)
                {
                    blowfishData.R = F(temp) ^ blowfishData.R;
                    blowfishData.L = temp ^ blowfishData.K[i];
                    break;
                }

                blowfishData.L = F(temp) ^ blowfishData.R;
                blowfishData.R = temp ^ blowfishData.K[i];
            }

            return blowfishData;
        }

        private uint F(uint value)
        {
            int count = 0;
            while (value != 0)
            {
                count++;
                value &= value - 1;
            }
            return (uint)(count % 2);
        }

        private bool VerifyRound(BlowfishData blowfishData)
        {
            if (blowfishData.K.Count >= 3)
            {

                return true;
            }
            return false;
        }
    }
}

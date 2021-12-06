using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class FeistelService : IFeistelService
    {
        private FeistelData _emptyFeistelData = new FeistelData
        {
            L = 0,
            R = 0
        };

        public FeistelData Encrypt(FeistelData feistelData)
        {
            feistelData.Round = feistelData.K.Count;
            return EncryptPerRound(feistelData);
        }

        public FeistelData EncryptPerRound(FeistelData feistelData)
        {
            uint temp;

            if (VerifyRound(feistelData) == false)
                return (_emptyFeistelData);

            for (int i = 0; i < feistelData.Round; i++)
            {
                temp = F(feistelData.L, feistelData.K[i]);
                temp ^= feistelData.R;

                if (i == feistelData.Round - 1)
                {
                    feistelData.R = temp;
                    break;
                }
                
                feistelData.R = feistelData.L;
                feistelData.L = temp;
            }
            return feistelData;
        }

        public FeistelData Decrypt(FeistelData feistelData)
        {
            feistelData.Round = feistelData.K.Count;
            return DecryptPerRound(feistelData);
        }

        public FeistelData DecryptPerRound(FeistelData feistelData)
        {
            uint temp;

            if (VerifyRound(feistelData) == false)
                return (_emptyFeistelData);

            for (int i = feistelData.Round - 1; i >= 0; i--)
            {
                temp = F(feistelData.L, feistelData.K[i]);
                temp ^= feistelData.R;

                if (i == 0)
                {
                    feistelData.R = temp;
                    break;
                }
                
                feistelData.R = feistelData.L;
                feistelData.L = temp;
            }
            return feistelData;
        }

        private uint F(uint A, uint B)
        {
            return A ^ B;
        }

        private bool VerifyRound(FeistelData feistelData)
        {
            if (feistelData.Round > 0 && feistelData.Round <= feistelData.K.Count)
            {

                return true;
            }
            return false;
        }
    }
}

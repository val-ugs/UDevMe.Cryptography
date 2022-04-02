using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class TripleDesService : ITripleDesService
    {
        private int _maxDesNumber = 3;
        private TripleDesData _emptyTripleDesData = new TripleDesData
        {
            L = 0,
            R = 0
        };

        public TripleDesData Encrypt(TripleDesData tripleDesData)
        {
            tripleDesData.DesNumber = _maxDesNumber;
            return EncryptPerDesNumber(tripleDesData);
        }

        public TripleDesData EncryptPerDesNumber(TripleDesData tripleDesData)
        {
            uint temp;

            if (VerifyRound(tripleDesData) == false)
                return (_emptyTripleDesData);

            for (int j = 1; j <= _maxDesNumber; j++)
            {
                for (int i = 0; i < tripleDesData.K.Count; i++)
                {
                    temp = F(tripleDesData.R, tripleDesData.K[i]);
                    temp ^= tripleDesData.L;

                    tripleDesData.L = tripleDesData.R;
                    tripleDesData.R = temp;
                }

                if (j == tripleDesData.DesNumber)
                    break;
            }

            return tripleDesData;
        }

        public TripleDesData Decrypt(TripleDesData tripleDesData)
        {
            tripleDesData.DesNumber = _maxDesNumber;
            return DecryptPerDesNumber(tripleDesData);
        }

        public TripleDesData DecryptPerDesNumber(TripleDesData tripleDesData)
        {
            uint temp;

            if (VerifyRound(tripleDesData) == false)
                return (_emptyTripleDesData);

            for (int j = 1; j <= _maxDesNumber; j++)
            {
                for (int i = tripleDesData.K.Count - 1; i >= 0; i--)
                {
                    temp = F(tripleDesData.L, tripleDesData.K[i]);
                    temp ^= tripleDesData.R;

                    tripleDesData.R = tripleDesData.L;
                    tripleDesData.L = temp;
                }

                if (j == _maxDesNumber - tripleDesData.DesNumber)
                    break;
            }

            return tripleDesData;
        }

        private uint F(uint A, uint B)
        {
            return A ^ B;
        }

        private bool VerifyRound(TripleDesData tripleDesData)
        {
            if (tripleDesData.DesNumber > 0 && tripleDesData.DesNumber <= _maxDesNumber)
            {
                return true;
            }
            return false;
        }
    }
}

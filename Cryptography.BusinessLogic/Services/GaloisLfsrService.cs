using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class GaloisLfsrService : IGaloisLfsrService
    {
        public int GetPeriod(GaloisLfsrData galoisLfsrData)
        {
            int period = 0;
            List<int> values = new List<int>(galoisLfsrData.Values);
            int feedbackValue;

            do
            {
                feedbackValue = galoisLfsrData.Values.LastOrDefault();

                for (int i = galoisLfsrData.Values.Count - 1; i > 0; i--)
                {
                    foreach (int index in galoisLfsrData.LinkIndices)
                        if (index == i - 1)
                            galoisLfsrData.Values[i - 1] ^= feedbackValue;
                    galoisLfsrData.Values[i] = galoisLfsrData.Values[i - 1];
                }

                galoisLfsrData.Values[0] = feedbackValue;

                period++;
            } while (values.SequenceEqual(galoisLfsrData.Values) == false);

            return period;
        }

        public int[] GenerateSequence(GaloisLfsrData galoisLfsrData)
        {
            List<int> outputValues = new List<int>();
            List<int> values = new List<int>(galoisLfsrData.Values);
            int feedbackValue;

            do
            {
                feedbackValue = galoisLfsrData.Values.LastOrDefault();
                outputValues.Add(feedbackValue);

                for (int i = galoisLfsrData.Values.Count - 1; i > 0; i--)
                {
                    foreach (int index in galoisLfsrData.LinkIndices)
                        if (index == i - 1)
                            galoisLfsrData.Values[i - 1] ^= feedbackValue;
                    galoisLfsrData.Values[i] = galoisLfsrData.Values[i - 1];
                }

                galoisLfsrData.Values[0] = feedbackValue;

            } while (values.SequenceEqual(galoisLfsrData.Values) == false);

            return outputValues.ToArray();
        }
    }
}

using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class FibonacciLfsrService : IFibonacciLfsrService
    {
        public int GetPeriod(FibonacciLfsrData fibonacciLfsrData)
        {
            int period = 0;
            List<int> values = new List<int>(fibonacciLfsrData.Values);
            int feedbackValue;

            do
            {
                feedbackValue = Feedback(fibonacciLfsrData.Values, fibonacciLfsrData.Indices);
                
                for (int i = fibonacciLfsrData.Values.Count - 1; i > 0; i--)
                {
                    fibonacciLfsrData.Values[i] = fibonacciLfsrData.Values[i - 1];
                }

                fibonacciLfsrData.Values[0] = feedbackValue;
                
                period++;
            } while (values.SequenceEqual(fibonacciLfsrData.Values) == false);

            return period;
        }

        public int[] GenerateSequence(FibonacciLfsrData fibonacciLfsrData)
        {
            List<int> outputValues = new List<int>();
            List<int> values = new List<int>(fibonacciLfsrData.Values);
            int feedbackValue;

            do
            {
                outputValues.Add(fibonacciLfsrData.Values.LastOrDefault());
                feedbackValue = Feedback(fibonacciLfsrData.Values, fibonacciLfsrData.Indices);

                for (int i = fibonacciLfsrData.Values.Count - 1; i > 0; i--)
                {
                    fibonacciLfsrData.Values[i] = fibonacciLfsrData.Values[i - 1];
                }

                fibonacciLfsrData.Values[0] = feedbackValue;
            } while (values.SequenceEqual(fibonacciLfsrData.Values) == false);

            return (outputValues.ToArray());
        }

        private int Feedback(List<int> register, List<int> indices)
        {
            int value = 0;

            foreach (int index in indices)
                value ^= register[index];

            return value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.WpfApp.Utils
{
    public static class DataConverter
    {
        public static List<int> ConvertStringToIntList(string text, char delimiter)
        {
            List<int> numbers = new List<int>();
            int value;
            var textMembers = text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            foreach (var textMember in textMembers)
            {
                numbers.Add(int.TryParse(textMember, out value) ? value : 0);
            }

            return numbers;
        }

        public static string ConvertIntArrayToString(int[] outputValues, char delimiter)
        {
            StringBuilder outputString = new StringBuilder();

            for (int i = 0; i < outputValues.Length; i++)
            {
                outputString.Append(outputValues[i]);
                if (i != outputValues.Length - 1)
                {
                    outputString.Append(delimiter + " ");
                }
            }

            return outputString.ToString();
        }

        public static List<uint> ConvertStringToUIntList(string text, char delimiter)
        {
            List<uint> numbers = new List<uint>();
            uint value;
            var textMembers = text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            foreach (var textMember in textMembers)
            {
                numbers.Add(uint.TryParse(textMember, out value) ? value : 0);
            }

            return numbers;
        }
    }
}


using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class PermutationService : IPermutationService
    {
        private char[] _characters;

        public Dictionary<string, string> Permutate(PermutationData permutationData)
        {
            string currentText = permutationData.Text.ToUpper();
            _characters = currentText.ToCharArray();
            char[] currentCharacters = currentText.ToCharArray();
            int[] currentSequence = Enumerable.Range(0, currentCharacters.Length).ToArray();
            Dictionary<string, string> dictionaryOfWords = new Dictionary<string, string>();
            int[] c = new int[currentText.Length];

            int i;
            for (i = 0; i < currentCharacters.Length; i++)
            {
                c[i] = 0;
            }

            dictionaryOfWords[intArrayToString(currentSequence)] = new string(currentCharacters);

            // Heap Algorithm
            i = 0;
            while(i < currentCharacters.Length)
            {
                if (c[i] < i)
                {
                    if (i % 2 == 0)
                    {
                        (currentSequence[0], currentSequence[i]) = (currentSequence[i], currentSequence[0]); // Permutate sequence
                        (currentCharacters[0], currentCharacters[i]) = (currentCharacters[i], currentCharacters[0]); // Permutate characters
                    }
                    else
                    {
                        (currentSequence[c[i]], currentSequence[i]) = (currentSequence[i], currentSequence[c[i]]); // Permutate sequence
                        (currentCharacters[c[i]], currentCharacters[i]) = (currentCharacters[i], currentCharacters[c[i]]); // Permutate characters
                    }

                    dictionaryOfWords[intArrayToString(currentSequence)] = new string(currentCharacters);

                    c[i]++;

                    i = 0;
                }
                else
                {
                    c[i] = 0;
                    i++;
                }
            }

            return dictionaryOfWords;
        }

        private string intArrayToString(int[] sequence)
        {
            return string.Join("", sequence);
        }
    }
}

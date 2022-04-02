using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class GronsfeldCipherService : IGronsfeldCipherService
    {
        delegate int Operation(int a, int b);

        public string Encrypt(GronsfeldCipherData gronsfeldCipherData)
        {
            string alphabet = DefineAlphabet(gronsfeldCipherData);

            return GronsfeldCipher(gronsfeldCipherData.Text, gronsfeldCipherData.Key, alphabet, Sum);
        }

        public string Decrypt(GronsfeldCipherData gronsfeldCipherData)
        {
            string alphabet = DefineAlphabet(gronsfeldCipherData);

            return GronsfeldCipher(gronsfeldCipherData.Text, gronsfeldCipherData.Key, alphabet, Substract);
        }

        public string DefineAlphabet(GronsfeldCipherData gronsfeldCipherData)
        {
            string alphabet;
            switch (gronsfeldCipherData.Language.ToUpper())
            {
                case "RU":
                    alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    break;
                case "EN":
                    alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
                default:
                    throw new Exception("Language is not set");
            }
            return alphabet;
        }

        private string GronsfeldCipher(string text, List<int> key, string alphabet, Operation operation)
        {
            text = text.ToUpper();

            string newText = "";
            int shift = 0;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        shift = key[i % key.Count];
                        newText += alphabet[(operation(j, shift) + alphabet.Length) % alphabet.Length];
                        break;
                    }
                }
            }
            return newText;
        }

        int GetIndexOfLetterInAlphabet(char letter, string alphabet)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (letter == alphabet[i])
                {
                    return i;
                }
            }
            return 0;
        }

        private int Sum(int a, int b)
        {
            return a + b;
        }
        private int Substract(int a, int b)
        {
            return a - b;
        }
    }
}

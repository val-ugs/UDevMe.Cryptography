using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class VigenereCipherService : IVigenereCipherService
    {
        delegate int Operation(int a, int b);

        public string Encrypt(VigenereCipherData vigenereCipherData)
        {
            string alphabet = DefineAlphabet(vigenereCipherData);

            return VigenereCipher(vigenereCipherData.Text, vigenereCipherData.Key, alphabet, Sum);
        }

        public string Decrypt(VigenereCipherData vigenereCipherData)
        {
            string alphabet = DefineAlphabet(vigenereCipherData);

            return VigenereCipher(vigenereCipherData.Text, vigenereCipherData.Key, alphabet, Substract);
        }

        public string DefineAlphabet(VigenereCipherData vigenereCipherData)
        {
            string alphabet;
            switch (vigenereCipherData.Language.ToUpper())
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

        private string VigenereCipher(string text, string key, string alphabet, Operation operation)
        {
            text = text.ToUpper();
            key = key.ToUpper();

            string newText = "";
            int shift = 0;

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        shift = GetIndexOfLetterInAlphabet(key[i % key.Length], alphabet);
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

using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class CaesarCipherService : ICaesarCipherService
    {
        delegate int Operation(int a, int b);

        public string[] Encrypt(CaesarCipherData caesarCipherData)
        {
            string alphabet = DefineAlphabet(caesarCipherData);

            return CaesarCipher(caesarCipherData.Text, alphabet, Sum);
        }

        public string[] Decrypt(CaesarCipherData caesarCipherData)
        {
            string alphabet = DefineAlphabet(caesarCipherData);

            return CaesarCipher(caesarCipherData.Text, alphabet, Substract);
        }

        public string DefineAlphabet(CaesarCipherData caesarCipherData)
        {
            string alphabet;
            switch (caesarCipherData.Language.ToUpper())
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

        private string[] CaesarCipher(string text, string alphabet, Operation operation)
        {
            text = text.ToUpper();
            List<string> allTexts = new List<string>();
            for (int shift = 0; shift < alphabet.Length; shift++)
            {
                string newText = "";
                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (text[i] == alphabet[j])
                        {
                            newText += alphabet[(operation(j, shift) + alphabet.Length) % alphabet.Length];
                            break;
                        }
                    }
                }
                allTexts.Add(newText);
            }
            return allTexts.ToArray();
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

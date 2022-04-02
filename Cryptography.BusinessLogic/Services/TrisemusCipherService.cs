using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class TrisemusCipherService : ITrisemusCipherService
    {
        delegate int Operation(int a, int b);

        public string Encrypt(TrisemusCipherData trisemusCipherData)
        {
            string alphabet = DefineAlphabet(trisemusCipherData);

            return TrisemusCipher(trisemusCipherData.Text, alphabet, Sum);
        }

        public string Decrypt(TrisemusCipherData trisemusCipherData)
        {
            string alphabet = DefineAlphabet(trisemusCipherData);

            return TrisemusCipher(trisemusCipherData.Text, alphabet, Substract);
        }

        public string DefineAlphabet(TrisemusCipherData trisemusCipherData)
        {
            string alphabet;
            switch (trisemusCipherData.Language.ToUpper())
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

        private string TrisemusCipher(string text, string alphabet, Operation operation)
        {
            text = text.ToUpper();
            string newText = "";
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        newText += alphabet[(operation(j, i) + alphabet.Length) % alphabet.Length];
                        break;
                    }
                }
            }
            return newText;
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

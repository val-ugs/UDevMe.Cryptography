using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    enum Passage
    {
        Direct,
        Back
    }

    enum Direction
    {
        Left, // Counterclock-wise
        Right // Clockwise
    }

    public class EnigmaService : IEnigmaService
    {
        private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Decrypt(EnigmaData enigmaData)
        {
            string inputText = enigmaData.InputText.ToUpper();
            

            string decodedText = "";
            int shift = 1;

            for (int i = 0; i < inputText.Length; i++)
            {
                char letter = inputText[i];
                
                // Direct passage
                letter = GetLetterFromPatchPanel(letter, enigmaData.PatchPanel, Passage.Direct);
                letter = Rotate(letter, Direction.Right, shift);
                letter = GetLetterFromRotor(letter, enigmaData.Rotor1, Passage.Direct);
                letter = Rotate(letter, Direction.Left, shift);
                letter = GetLetterFromRotor(letter, enigmaData.Rotor2, Passage.Direct);
                // No rotate
                letter = GetLetterFromRotor(letter, enigmaData.Rotor3, Passage.Direct);

                letter = GetLetterFromReflector(letter, enigmaData.Reflector);

                // Back passage
                letter = GetLetterFromRotor(letter, enigmaData.Rotor3, Passage.Back);
                // No rotate
                letter = GetLetterFromRotor(letter, enigmaData.Rotor2, Passage.Back);
                letter = Rotate(letter, Direction.Right, shift);
                letter = GetLetterFromRotor(letter, enigmaData.Rotor1, Passage.Back);
                letter = Rotate(letter, Direction.Left, shift);
                letter = GetLetterFromPatchPanel(letter, enigmaData.PatchPanel, Passage.Back);

                decodedText += letter;
                shift++;
            }

            return decodedText;
        }

        private char GetLetterFromPatchPanel(char letter, string patchPanel, Passage passage)
        {
            return GetLetterFromDevice(letter, patchPanel, passage);
        }

        private char GetLetterFromRotor(char letter, string rotor, Passage passage)
        {
            return GetLetterFromDevice(letter, rotor, passage);
        }

        private char GetLetterFromDevice(char letter, string device, Passage passage)
        {
            char outputLetter = letter;
            int letterIndex;

            switch (passage)
            {
                case Passage.Direct:
                    letterIndex = _alphabet.IndexOf(letter);
                    outputLetter = device[letterIndex];
                    break;
                case Passage.Back:
                    letterIndex = device.IndexOf(letter);
                    outputLetter = _alphabet[letterIndex];
                    break;
            }

            return outputLetter;
        }

        private char Rotate(char letter, Direction direction, int shift)
        {
            char outputLetter = letter;
            int letterIndex = _alphabet.IndexOf(letter);
            switch (direction)
            {
                case Direction.Left:
                    outputLetter = _alphabet[letterIndex - shift];
                    break;
                case Direction.Right:
                    outputLetter = _alphabet[letterIndex + shift];
                    break;
            }
            return outputLetter;
        }

        private char GetLetterFromReflector(char letter, string reflector)
        {
            char outputLetter = letter;
            int letterIndex = reflector.IndexOf(letter);
            if (letterIndex % 2 == 0)
            {
                letterIndex++;
                
            }
            else
            {
                letterIndex--;
            }
            outputLetter = reflector[letterIndex];
            return outputLetter;
        }
    }
}

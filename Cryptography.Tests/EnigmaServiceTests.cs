using Cryptography.BusinessLogic.Services;
using Cryptography.Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Tests
{
    class EnigmaServiceTests
    {
        private EnigmaService _service;

        [SetUp]
        public void Setup()
        {
            _service = new EnigmaService();
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            // arrange
            string inputText = "GV";
            string patchPanel = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string rotor1 = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
            string rotor2 = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
            string rotor3 = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
            string reflector = "AFBVCPDJEIGOHYKRLZMXNWTQSU";
            string expectedResult = "PI";

            EnigmaData enigmaData = new EnigmaData
            {
                InputText = inputText,
                PatchPanel = patchPanel,
                Rotor1 = rotor1,
                Rotor2 = rotor2,
                Rotor3 = rotor3,
                Reflector = reflector
            };

            // act
            var result = _service.Decrypt(enigmaData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}

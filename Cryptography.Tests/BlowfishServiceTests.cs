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
    class BlowfishServiceTests
    {
        private BlowfishService _service;

        [SetUp]
        public void Setup()
        {
            _service = new BlowfishService();
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            // L0 = 1010
            uint l = 10;
            // R0 = 0100
            uint r = 4;
            // K1 = 0110, K2 = 1001, K3 = 1000, K4 = 0001, K5 = 0111 
            List<uint> k = new List<uint> { 6, 9, 8, 1, 7};
            BlowfishData expectedBlowfishData = new BlowfishData
            {
                // L = 0100
                L = 4,
                // R = 1010
                R = 10,
            };

            BlowfishData feistelData = new BlowfishData
            {
                L = l,
                R = r,
                K = k
            };

            // act
            var result = _service.Encrypt(feistelData);

            // assert
            Assert.AreEqual(expectedBlowfishData.L, result.L);
            Assert.AreEqual(expectedBlowfishData.R, result.R);
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            // L = 0100
            uint l = 4;
            // R = 1010
            uint r = 10;
            // K1 = 0110, K2 = 1001, K3 = 1000, K4 = 0001, K5 = 0111 
            List<uint> k = new List<uint> { 6, 9, 8, 1, 7 };
            BlowfishData expectedBlowfishData = new BlowfishData
            {
                // L0 = 1010
                L = 10,
                // R0 = 0100
                R = 4,
            };

            BlowfishData feistelData = new BlowfishData
            {
                L = l,
                R = r,
                K = k
            };

            // act
            var result = _service.Decrypt(feistelData);

            // assert
            Assert.AreEqual(expectedBlowfishData.L, result.L);
            Assert.AreEqual(expectedBlowfishData.R, result.R);
        }
    }
}

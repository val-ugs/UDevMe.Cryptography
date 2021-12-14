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
    class TripleDesServiceTests
    {
        private TripleDesService _service;

        [SetUp]
        public void Setup()
        {
            _service = new TripleDesService();
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            // L0 = 0100
            uint l = 4;
            // R0 = 1010
            uint r = 10;
            // K1 = 0010, K2 = 0000, K3 = 0110 
            List<uint> k = new List<uint> { 2, 0, 6 };
            TripleDesData expectedTripleDesData = new TripleDesData
            {
                // L = 0110
                L = 6,
                // R = 1100
                R = 12,
            };

            TripleDesData tripleDesData = new TripleDesData
            {
                L = l,
                R = r,
                K = k
            };

            // act
            var result = _service.Encrypt(tripleDesData);

            // assert
            Assert.AreEqual(expectedTripleDesData.L, result.L);
            Assert.AreEqual(expectedTripleDesData.R, result.R);
        }

        [Test]
        public void EncryptPerDesNumber__ShouldReturnTrue()
        {
            // L0 = 0100
            uint l = 4;
            // R0 = 1010
            uint r = 10;
            // K1 = 0010, K2 = 0000, K3 = 0110 
            List<uint> k = new List<uint> { 2, 0, 6 };
            int desNumber = 2;
            TripleDesData expectedTripleDesData = new TripleDesData
            {
                // L = 0100
                L = 4,
                // R = 1010
                R = 10,
            };

            TripleDesData tripleDesData = new TripleDesData
            {
                L = l,
                R = r,
                K = k,
                DesNumber = desNumber
            };

            // act
            var result = _service.EncryptPerDesNumber(tripleDesData);

            // assert
            Assert.AreEqual(expectedTripleDesData.L, result.L);
            Assert.AreEqual(expectedTripleDesData.R, result.R);
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            // L = 0110
            uint l = 6;
            // R = 1100
            uint r = 12;
            // K1 = 0010, K2 = 0000, K3 = 0110 
            List<uint> k = new List<uint> { 2, 0, 6 };
            TripleDesData expectedTripleDesData = new TripleDesData
            {
                // L0 = 0100
                L = 4,
                // R0 = 1010
                R = 10,
            };

            TripleDesData tripleDesData = new TripleDesData
            {
                L = l,
                R = r,
                K = k
            };

            // act
            var result = _service.Decrypt(tripleDesData);

            // assert
            Assert.AreEqual(expectedTripleDesData.L, result.L);
            Assert.AreEqual(expectedTripleDesData.R, result.R);
        }

        [Test]
        public void DecryptPerRound__ShouldReturnTrue()
        {
            // L = 0110
            uint l = 6;
            // R = 1100
            uint r = 12;
            // K1 = 0010, K2 = 0000, K3 = 0110 
            List<uint> k = new List<uint> { 2, 0, 6 };
            int desNumber = 1;
            TripleDesData expectedTripleDesData = new TripleDesData
            {
                // L0 = 0110
                L = 6,
                // R0 = 1100
                R = 12,
            };

            TripleDesData tripleDesData = new TripleDesData
            {
                L = l,
                R = r,
                K = k,
                DesNumber = desNumber
            };

            // act
            var result = _service.DecryptPerDesNumber(tripleDesData);

            // assert
            Assert.AreEqual(expectedTripleDesData.L, result.L);
            Assert.AreEqual(expectedTripleDesData.R, result.R);
        }
    }
}

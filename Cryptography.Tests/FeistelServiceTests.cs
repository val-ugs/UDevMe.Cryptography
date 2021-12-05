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
    class FeistelServiceTests
    {
        private FeistelService _service;

        [SetUp]
        public void Setup()
        {
            _service = new FeistelService();
        }

        [Test]
        public void EncryptPerRound__ShouldReturnTrue()
        {
            // Li = 90 88
            uint l = 37000;
            // Ri = 92 8C
            uint r = 37516; 
            // K1 = C5, K2 = 71, K3 = E3, K4 = B8 
            List<uint> k = new List<uint> { 197, 113, 227, 184 };
            int round = 4;
            FeistelData expectedFeistelData = new FeistelData
            {
                // L = 90 1A
                L = 36890,
                // R = 02 9A
                R = 666,
            };

            FeistelData feistelData = new FeistelData
            {
                // L = 90 1A
                L = l,
                // R = 02 9A
                R = r,
                // K1 = C5, K2 = 71, K3 = E3, K4 = B8 
                K = k,
                Round = round
            };

            // act
            var result = _service.EncryptPerRound(feistelData);

            // assert
            Assert.AreEqual(expectedFeistelData.L, result.L);
            Assert.AreEqual(expectedFeistelData.R, result.R);
        }

        [Test]
        public void DecryptPerRound__ShouldReturnTrue()
        {
            // L = 90 1A
            uint l = 36890;
            // R = 02 9A
            uint r = 666;
            // K1 = C5, K2 = 71, K3 = E3, K4 = B8 
            List<uint> k = new List<uint> { 197, 113, 227, 184 };
            int round = 4;
            FeistelData expectedFeistelData = new FeistelData
            {
                // Li = 90 88
                L = 37000,
                // Ri = 92 8C
                R = 37516,
            };

            FeistelData feistelData = new FeistelData
            {
                // L = 90 88
                L = l,
                // R = 928C
                R = r,
                // K1 = C5, K2 = 71, K3 = E3, K4 = B8 
                K = k,
                Round = round
            };

            // act
            var result = _service.DecryptPerRound(feistelData);

            // assert
            Assert.AreEqual(expectedFeistelData.L, result.L);
            Assert.AreEqual(expectedFeistelData.R, result.R);
        }
    }
}

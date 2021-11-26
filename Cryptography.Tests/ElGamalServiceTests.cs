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
    public class ElGamalServiceTests
    {
        private ElGamalService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ElGamalService();
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            // arrange
            int p = 19;
            int g = 5;
            int k = 13;
            int x = 11;
            int[] m = { 2, 5, 7 }; 

            int[] expectedResult = { 8, 20, 28};

            var elGamalData = new ElGamalData
            {
                P = p,
                G = g,
                K = k,
                X = x,
                Values = m
            };

            // act
            var result = _service.Encrypt(elGamalData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            // arrange
            int p = 19;
            int g = 5;
            int k = 13;
            int x = 11;
            int[] b = { 8, 20, 28 };

            int[] expectedResult = { 2, 5, 7 };

            var elGamalData = new ElGamalData
            {
                P = p,
                G = g,
                K = k,
                X = x,
                Values = b
            };

            // act
            var result = _service.Decrypt(elGamalData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}

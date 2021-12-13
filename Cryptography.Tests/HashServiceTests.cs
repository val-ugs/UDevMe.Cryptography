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
    class HashServiceTests
    {
        private HashService _service;

        [SetUp]
        public void Setup()
        {
            _service = new HashService();
        }

        [Test]
        public void Calculate__ShouldReturnTrue()
        {
            // arrange
            int h0 = 0;
            int p = 11;
            List<int> m = new List<int> { 5, 14, 12 };
            int expectedResult = 5;

            var hashData = new HashData
            {
                H0 = h0,
                P = p,
                M = m
            };

            // act
            var result = _service.Calculate(hashData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}

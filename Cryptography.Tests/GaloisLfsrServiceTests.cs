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
    class GaloisLfsrServiceTests
    {
        private GaloisLfsrService _service;

        [SetUp]
        public void Setup()
        {
            _service = new GaloisLfsrService();
        }

        [Test]
        public void GetPeriod__ShouldReturnTrue()
        {
            // arrange
            List<int> inputValues = new List<int> { 1, 1, 0};
            List<int> inputLinkIndices = new List<int> { 1 };
            int expectedResult = 7;

            GaloisLfsrData galoisLfsrData = new GaloisLfsrData
            {
                Values = inputValues,
                LinkIndices = inputLinkIndices
            };

            // act
            var result = _service.GetPeriod(galoisLfsrData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GenerateSequence__ShouldReturnTrue()
        {
            // arrange
            List<int> inputValues = new List<int> { 1, 1, 0 };
            List<int> inputLinkIndices = new List<int> { 1 };
            int[] expectedResult = new int[] { 0, 1, 0, 0, 1, 1, 1 };

            GaloisLfsrData galoisLfsrData = new GaloisLfsrData
            {
                Values = inputValues,
                LinkIndices = inputLinkIndices
            };

            // act
            var result = _service.GenerateSequence(galoisLfsrData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}

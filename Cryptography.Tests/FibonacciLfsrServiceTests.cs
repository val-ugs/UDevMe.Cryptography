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
    class FibonacciLfsrServiceTests
    {
        private FibonacciLfsrService _service;

        [SetUp]
        public void Setup()
        {
            _service = new FibonacciLfsrService();
        }

        [Test]
        public void GetPeriod__ShouldReturnTrue()
        {
            // arrange
            List<int> inputValues = new List<int> { 0, 0, 1, 0 };
            List<int> inputIndices = new List<int> { 0, 2 };
            int expectedResult = 7;

            FibonacciLfsrData fibonacciLfsrData = new FibonacciLfsrData
            {
                Values = inputValues,
                Indices = inputIndices
            };

            // act
            var result = _service.GetPeriod(fibonacciLfsrData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GenerateSequence__ShouldReturnTrue()
        {
            // arrange
            List<int> inputValues = new List<int> { 0, 0, 1, 0 };
            List<int> inputIndices = new List<int> { 0, 2 };
            int[] expectedResult = new int[] { 0, 1, 0, 0, 1, 1, 1 };

            FibonacciLfsrData fibonacciLfsrData = new FibonacciLfsrData
            {
                Values = inputValues,
                Indices = inputIndices
            };

            // act
            var result = _service.GenerateSequence(fibonacciLfsrData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}

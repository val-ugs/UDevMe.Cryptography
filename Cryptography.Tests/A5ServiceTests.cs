using Cryptography.BusinessLogic.Services;
using Cryptography.Domain.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cryptography.Tests
{
    class A5ServiceTests
    {
        private A5Service _service;

        [SetUp]
        public void Setup()
        {
            _service = new A5Service();
        }

        [Test]
        public void GetKey__ShouldReturnTrue()
        {
            // arrange
            List<int> registerA = new List<int> { 1, 1, 0, 1, 0, 1 };
            List<int> registerB = new List<int> { 0, 1, 0, 0, 1, 0, 1 };
            List<int> registerC = new List<int> { 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1 };
            List<int> indicesA = new List<int> { 0, 1 };
            List<int> indicesB = new List<int> { 0, 3 };
            List<int> indicesC = new List<int> { 0, 2 };
            int[] expectedResult = { 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1 };

            A5Data a5Data = new A5Data
            {
                InputValues = null,
                RegisterA = registerA,
                RegisterB = registerB,
                RegisterC = registerC,
                IndicesA = indicesA,
                IndicesB = indicesB,
                IndicesC = indicesC
            };

            // act
            var result = _service.GetKey(a5Data);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            // arrange
            int[] inputValues = new int[] { 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1 };
            List<int> registerA = new List<int> { 1, 1, 0, 1, 0, 1};
            List<int> registerB = new List<int> { 0, 1, 0, 0, 1, 0, 1};
            List<int> registerC = new List<int> { 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1};
            List<int> indicesA = new List<int> { 0, 1};
            List<int> indicesB = new List<int> { 0, 3};
            List<int> indicesC = new List<int> { 0, 2};
            int[] expectedResult = { 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0 };

            A5Data a5Data = new A5Data
            {
                InputValues = inputValues,
                RegisterA = registerA,
                RegisterB = registerB,
                RegisterC = registerC,
                IndicesA = indicesA,
                IndicesB = indicesB,
                IndicesC = indicesC
            };

            // act
            var result = _service.Encrypt(a5Data);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            // arrange
            int[] inputValues = new int[] { 0, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1 };
            List<int> registerA = new List<int> { 1, 1, 0, 1, 0, 1 };
            List<int> registerB = new List<int> { 0, 1, 0, 0, 1, 0, 1 };
            List<int> registerC = new List<int> { 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1 };
            List<int> indicesA = new List<int> { 0, 1 };
            List<int> indicesB = new List<int> { 0, 3 };
            List<int> indicesC = new List<int> { 0, 2 };
            int[] expectedResult = { 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0 };

            A5Data a5Data = new A5Data
            {
                InputValues = inputValues,
                RegisterA = registerA,
                RegisterB = registerB,
                RegisterC = registerC,
                IndicesA = indicesA,
                IndicesB = indicesB,
                IndicesC = indicesC
            };

            // act
            var result = _service.Decrypt(a5Data);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}

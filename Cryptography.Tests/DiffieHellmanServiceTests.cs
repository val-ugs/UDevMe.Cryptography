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
    class DiffieHellmanServiceTests
    {
        private DiffieHellmanService _service;

        [SetUp]
        public void Setup()
        {
            _service = new DiffieHellmanService();
        }

        [Test]
        public void GetA__ShouldReturnTrue()
        {
            // arrange
            int n = 7;
            int q = 3;
            int x = 3;
            int y = 2;

            int expectedResult = 6;

            var diffieHellmanData = new DiffieHellmanData
            {
                N = n,
                Q = q,
                X = x,
                Y = y
            };

            // act
            var result = _service.GetA(diffieHellmanData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetB__ShouldReturnTrue()
        {
            // arrange
            int n = 7;
            int q = 3;
            int x = 3;
            int y = 2;

            int expectedResult = 2;

            var diffieHellmanData = new DiffieHellmanData
            {
                N = n,
                Q = q,
                X = x,
                Y = y
            };

            // act
            var result = _service.GetB(diffieHellmanData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetKeyX__ShouldReturnTrue()
        {
            // arrange
            int n = 7;
            int q = 3;
            int x = 3;
            int y = 2;

            int expectedResult = 1;

            var diffieHellmanData = new DiffieHellmanData
            {
                N = n,
                Q = q,
                X = x,
                Y = y
            };

            // act
            var result = _service.GetKeyX(diffieHellmanData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetKeyY__ShouldReturnTrue()
        {
            // arrange
            int n = 7;
            int q = 3;
            int x = 3;
            int y = 2;

            int expectedResult = 1;

            var diffieHellmanData = new DiffieHellmanData
            {
                N = n,
                Q = q,
                X = x,
                Y = y
            };

            // act
            var result = _service.GetKeyY(diffieHellmanData);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}

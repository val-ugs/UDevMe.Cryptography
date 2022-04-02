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
    class AesServiceTests
    {
        private AesService _service;

        [SetUp]
        public void Setup()
        {
            _service = new AesService();
        }

        [Test]
        public void GetSubBytesPerRound__ShouldReturnTrue()
        {
            // arrange
            uint[][] values = new uint[][] { new uint[] { 17, 19 },
                                            new uint[] { 9, 13 }};
            uint[][] key = new uint[][] { new uint[] { 12, 10 },
                                          new uint[] { 0, 13 }};
            int round = 1;
            uint[][] expectedResult = new uint[][] { new uint[] { 164, 212 },
                                                     new uint[] { 1, 99 }};

            AesData aesData = new AesData
            {
                Values = values,
                Key = key,
                Round = round
            };

            // act
            var result = _service.GetSubBytesPerRound(aesData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetShiftRowsPerRound__ShouldReturnTrue()
        {
            // arrange
            uint[][] values = new uint[][] { new uint[] { 17, 19 },
                                            new uint[] { 9, 13 }};
            uint[][] key = new uint[][] { new uint[] { 12, 10 },
                                          new uint[] { 0, 13 }};
            int round = 1;
            uint[][] expectedResult = new uint[][] { new uint[] { 164, 212 },
                                                     new uint[] { 99, 1 }};

            AesData aesData = new AesData
            {
                Values = values,
                Key = key,
                Round = round
            };

            // act
            var result = _service.GetShiftRowsPerRound(aesData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetMixColumnsPerRound__ShouldReturnTrue()
        {
            // arrange
            uint[][] values = new uint[][] { new uint[] { 17, 19 },
                                           new uint[] { 9, 13 }};
            uint[][] key = new uint[][] { new uint[] { 12, 10 },
                                        new uint[] { 0, 13 }};
            int round = 1;
            uint[][] expectedResult = new uint[][] { new uint[] { 48, 178 },
                                                   new uint[] { 98, 214 }};

            AesData aesData = new AesData
            {
                Values = values,
                Key = key,
                Round = round
            };

            // act
            var result = _service.GetMixColumnsPerRound(aesData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            // arrange
            uint[][] values = new uint[][] { new uint[] { 17, 19 },
                                            new uint[] { 9, 13 }};
            uint[][] key = new uint[][] { new uint[] { 12, 10 },
                                          new uint[] { 0, 13 }};
            int round = 1;
            uint[][] expectedResult = new uint[][] { new uint[] { 234, 98 },
                                                     new uint[] { 5, 188 } };

            AesData aesData = new AesData
            {
                Values = values,
                Key = key,
                Round = round
            };

            // act
            var result = _service.Encrypt(aesData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            // arrange
            uint[][] values = new uint[][] { new uint[] { 234, 98 },
                                             new uint[] { 5, 188 } };
            uint[][] key = new uint[][] { new uint[] { 12, 10 },
                                          new uint[] { 0, 13 }};
            int round = 1;
            uint[][] expectedResult = new uint[][] { new uint[] { 17, 19 },
                                                     new uint[] { 9, 13 } };

            AesData aesData = new AesData
            {
                Values = values,
                Key = key,
                Round = round
            };

            // act
            var result = _service.Decrypt(aesData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}

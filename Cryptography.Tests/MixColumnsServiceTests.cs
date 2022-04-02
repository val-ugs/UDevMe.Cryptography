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
    class MixColumnsServiceTests
    {
        private MixColumnsService _service;

        [SetUp]
        public void Setup()
        {
            _service = new MixColumnsService();
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            // arrange
            uint[][] values = new uint[][] { new uint[] { 164, 212 },
                                             new uint[] { 99, 1 }};
            uint[][] expectedResult = new uint[][] { new uint[] { 48, 178 },
                                                     new uint[] { 98, 214 }};

            MixColumnsData mixColumnsData = new MixColumnsData
            {
                Values = values
            };

            // act
            var result = _service.Encrypt(mixColumnsData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            // arrange
            uint[][] values = new uint[][] { new uint[] { 182, 255, 116, 78 },
                                             new uint[] { 210, 194, 201, 191 },
                                             new uint[] { 108, 89, 12, 191 },
                                             new uint[] { 4, 105, 191, 65 }};
            uint[][] expectedResult = new uint[][] { new uint[] { 87, 78, 144, 41 },
                                                     new uint[] { 172, 16, 229, 29 },
                                                     new uint[] { 149, 242, 244, 198 },
                                                     new uint[] { 98, 161, 143, 253 }};

            MixColumnsData mixColumnsData = new MixColumnsData
            {
                Values = values
            };

            // act
            var result = _service.Decrypt(mixColumnsData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}

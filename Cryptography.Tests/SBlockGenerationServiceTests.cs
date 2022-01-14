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
    class SBlockGenerationServiceTests
    {
        private SBlockGenerationService _service;

        [SetUp]
        public void Setup()
        {
            _service = new SBlockGenerationService();
        }

        [Test]
        public void Generate__ShouldReturnTrue()
        {
            // arrange
            int a = 13;
            int b = 9;
            int c = 11;
            int z0 = 25;
            int iMax = 7;

            int[] expectedResult = { 10, 4, 6, 9, 8, 1, 7 };

            SBlockGenerationData sBlockGenerationData = new SBlockGenerationData
            {
                A = a,
                B = b,
                C = c,
                Z0 = z0,
                IMax = iMax
            };

            // act
            var result = _service.Generate(sBlockGenerationData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}

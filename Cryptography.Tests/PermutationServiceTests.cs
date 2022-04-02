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
    class PermutationServiceTests
    {
        private PermutationService _service;

        [SetUp]
        public void Setup()
        {
            _service = new PermutationService();
        }

        [Test]
        public void Permutate__ShouldReturnTrue()
        {
            // arrange
            string text= "Hello";
            string expectedKey = "01234";
            string expectedText = "HELLO";

            var permutationData = new PermutationData
            {
                Text = text
            };

            // act
            var result = _service.Permutate(permutationData);

            // assert
            Assert.AreEqual(expectedText, result[expectedKey]);
        }
    }
}

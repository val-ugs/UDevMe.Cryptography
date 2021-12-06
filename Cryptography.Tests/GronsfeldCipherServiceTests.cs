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
    class GronsfeldCipherServiceTests
    {
        private GronsfeldCipherService _service;

        [SetUp]
        public void Setup()
        {
            _service = new GronsfeldCipherService();
        }

        [Test]
        public void Encrypt__EN_ShouldReturnTrue()
        {
            // arrange
            string language = "en";
            string text = "tbilisi";
            List<int> key = new List<int> { 1, 8, 10, 4};
            string expectedText = "UJSPJAS";

            var gronsfeldCipherData = new GronsfeldCipherData
            {
                Language = language,
                Text = text,
                Key = key
            };

            // act
            var result = _service.Encrypt(gronsfeldCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }
        [Test]
        public void Encrypt__RU__ShouldReturnTrue()
        {
            // arrange
            string language = "ru";
            string text = "белград";
            List<int> key = new List<int> { 6, 27, 11, 20};
            string expectedText = "ЖЯЦЦЦЪО";

            var gronsfeldCipherData = new GronsfeldCipherData
            {
                Language = language,
                Text = text,
                Key = key
            };

            // act
            var result = _service.Encrypt(gronsfeldCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void Decrypt__EN__ShouldReturnTrue()
        {
            // arrange
            string language = "en";
            string text = "ujspjas";
            List<int> key = new List<int> { 1, 8, 10, 4 };
            string expectedText = "TBILISI";

            var gronsfeldCipherData = new GronsfeldCipherData
            {
                Language = language,
                Text = text,
                Key = key
            };

            // act
            var result = _service.Decrypt(gronsfeldCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void Decrypt__RU__ShouldReturnTrue()
        {
            // arrange
            string language = "ru";
            string text = "жяцццъо";
            List<int> key = new List<int> { 6, 27, 11, 20 };
            string expectedText = "БЕЛГРАД";

            var gronsfeldCipherData = new GronsfeldCipherData
            {
                Language = language,
                Text = text,
                Key = key
            };

            // act
            var result = _service.Decrypt(gronsfeldCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }
    }
}

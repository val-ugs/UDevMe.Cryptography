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
    class VigenereCipherServiceTests
    {
        private VigenereCipherService _service;

        [SetUp]
        public void Setup()
        {
            _service = new VigenereCipherService();
        }

        [Test]
        public void Encrypt__EN_ShouldReturnTrue()
        {
            // arrange
            string language = "en";
            string text = "university";
            string key = "key";
            string expectedText = "ERGFIPCMRI";

            var vigenereCipherData = new VigenereCipherData
            {
                Language = language,
                Text = text,
                Key = key
            };

            // act
            var result = _service.Encrypt(vigenereCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }
        [Test]
        public void Encrypt__RU__ShouldReturnTrue()
        {
            // arrange
            string language = "ru";
            string text = "безопасность";
            string key = "киб";
            string expectedText = "ЛНИЩШБЬЦПЬЫЭ";

            var vigenereCipherData = new VigenereCipherData
            {
                Language = language,
                Text = text,
                Key = key
            };

            // act
            var result = _service.Encrypt(vigenereCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void Decrypt__EN__ShouldReturnTrue()
        {
            // arrange
            string language = "en";
            string text = "ergfipcmri";
            string key = "key";
            string expectedText = "UNIVERSITY";

            var vigenereCipherData = new VigenereCipherData
            {
                Language = language,
                Text = text,
                Key = key
            };

            // act
            var result = _service.Decrypt(vigenereCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void Decrypt__RU__ShouldReturnTrue()
        {
            // arrange
            string language = "ru";
            string text = "лнищшбьцпьыэ";
            string key = "киб";
            string expectedText = "БЕЗОПАСНОСТЬ";

            var vigenereCipherData = new VigenereCipherData
            {
                Language = language,
                Text = text,
                Key = key
            };

            // act
            var result = _service.Decrypt(vigenereCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }
    }
}

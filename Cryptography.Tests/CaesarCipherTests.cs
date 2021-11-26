using Cryptography.BusinessLogic.Services;
using Cryptography.Domain.Models;
using NUnit.Framework;


namespace Cryptography.Tests
{
    class CaesarCipherTests
    {
        private CaesarCipherService _service;

        [SetUp]
        public void Setup()
        {
            _service = new CaesarCipherService();
        }

        [Test]
        public void Encrypt__EN_ShouldReturnTrue()
        {
            // arrange
            string language = "en";
            string text = "cat";
            string expectedText = "DBU";

            var caesarCipherData = new CaesarCipherData
            {
                Language = language,
                Text = text
            };

            // act
            var result = _service.Encrypt(caesarCipherData);

            // assert
            Assert.AreEqual(expectedText, result[1]);
        }
        [Test]
        public void Encrypt__RU__ShouldReturnTrue()
        {
            // arrange
            string language = "ru";
            string text = "кот";
            string expectedText = "ЛПУ";

            var caesarCipherData = new CaesarCipherData
            {
                Language = language,
                Text = text
            };

            // act
            var result = _service.Encrypt(caesarCipherData);

            // assert
            Assert.AreEqual(expectedText, result[1]);
        }

        [Test]
        public void Decrypt__EN__ShouldReturnTrue()
        {
            // arrange
            string language = "en";
            string text = "cat";
            string expectedText = "BZS";

            var caesarCipherData = new CaesarCipherData
            {
                Language = language,
                Text = text
            };

            // act
            var result = _service.Decrypt(caesarCipherData);

            // assert
            Assert.AreEqual(expectedText, result[1]);
        }

        [Test]
        public void Decrypt__RU__ShouldReturnTrue()
        {
            // arrange
            string language = "ru";
            string text = "кот";
            string expectedText = "ЙНС";

            var caesarCipherData = new CaesarCipherData
            {
                Language = language,
                Text = text
            };

            // act
            var result = _service.Decrypt(caesarCipherData);

            // assert
            Assert.AreEqual(expectedText, result[1]);
        }
    }
}

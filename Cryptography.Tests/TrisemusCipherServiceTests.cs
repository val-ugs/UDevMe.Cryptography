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
    class TrisemusCipherServiceTests
    {
        private TrisemusCipherService _service;

        [SetUp]
        public void Setup()
        {
            _service = new TrisemusCipherService();
        }

        [Test]
        public void Encrypt__EN_ShouldReturnTrue()
        {
            // arrange
            string language = "en";
            string text = "cat";
            string expectedText = "CBV";

            var trisemusCipherData = new TrisemusCipherData
            {
                Language = language,
                Text = text
            };

            // act
            var result = _service.Encrypt(trisemusCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }
        [Test]
        public void Encrypt__RU__ShouldReturnTrue()
        {
            // arrange
            string language = "ru";
            string text = "кот";
            string expectedText = "КПФ";

            var trisemusCipherData = new TrisemusCipherData
            {
                Language = language,
                Text = text
            };

            // act
            var result = _service.Encrypt(trisemusCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void Decrypt__EN__ShouldReturnTrue()
        {
            // arrange
            string language = "en";
            string text = "cbv";
            string expectedText = "CAT";

            var trisemusCipherData = new TrisemusCipherData
            {
                Language = language,
                Text = text
            };

            // act
            var result = _service.Decrypt(trisemusCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }

        [Test]
        public void Decrypt__RU__ShouldReturnTrue()
        {
            // arrange
            string language = "ru";
            string text = "кпф";
            string expectedText = "КОТ";

            var trisemusCipherData = new TrisemusCipherData
            {
                Language = language,
                Text = text
            };

            // act
            var result = _service.Decrypt(trisemusCipherData);

            // assert
            Assert.AreEqual(expectedText, result);
        }
    }
}

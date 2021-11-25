using Cryptography.BusinessLogic.Services;
using Cryptography.Domain.Models;
using NUnit.Framework;

namespace Cryptography.Tests
{
    public class RsaServiceTests
    {
        private RsaService _service;

        [SetUp]
        public void Setup()
        {
            _service = new RsaService();
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            int p = 13;
            int q = 7;
            int e = 5;
            int x = 45;

            int expectedResult = 54;

            var rsaData = new RsaData
            {
                P = p,
                Q = q,
                Exponent = e,
                Value = x
            };

            var result = _service.Encrypt(rsaData);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            int p = 13;
            int q = 7;
            int e = 5;
            int x = 45;

            int expectedResult = 54;

            var rsaData = new RsaData
            {
                P = p,
                Q = q,
                Exponent = e,
                Value = x
            };

            var result = _service.Decrypt(rsaData);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
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
    class Md5ServiceTests
    {
        private Md5Service _service;

        [SetUp]
        public void Setup()
        {
            _service = new Md5Service();
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            // arrange
            uint a = 0b_0100;
            uint b = 0b_1010;
            uint c = 0b_0110;
            uint d = 0b_1100;
            uint m = 0b_1011;
            uint k = 0b_0101;
            Md5Data expectedMd5Data = new Md5Data
            {
                A = 0b_0011,
                B = 0b_1001,
                C = 0b_0001,
                D = 0b_0001,
                M = m,
                K = k
            };

            var md5Data = new Md5Data
            {
                A = a,
                B = b,
                C = c,
                D = d,
                M = m,
                K = k
            };

            // act
            var result = _service.Encrypt(md5Data);

            // assert
            Assert.AreEqual(expectedMd5Data.A, result.A);
            Assert.AreEqual(expectedMd5Data.B, result.B);
            Assert.AreEqual(expectedMd5Data.C, result.C);
            Assert.AreEqual(expectedMd5Data.D, result.D);
        }

        [Test]
        public void EncryptPerRound__ShouldReturnTrue()
        {
            // arrange
            uint a = 0b_0100;
            uint b = 0b_1010;
            uint c = 0b_0110;
            uint d = 0b_1100;
            uint m = 0b_1011;
            uint k = 0b_0101;
            Md5Data expectedMd5Data = new Md5Data
            {
                A = 0b_0110,
                B = 0b_0001,
                C = 0b_0011,
                D = 0b_1010,
                M = m,
                K = k
            };

            var md5Data = new Md5Data
            {
                A = a,
                B = b,
                C = c,
                D = d,
                M = m,
                K = k,
                Round = 2
            };

            // act
            var result = _service.EncryptPerRound(md5Data);

            // assert
            Assert.AreEqual(expectedMd5Data.A, result.A);
            Assert.AreEqual(expectedMd5Data.B, result.B);
            Assert.AreEqual(expectedMd5Data.C, result.C);
            Assert.AreEqual(expectedMd5Data.D, result.D);
        }

        [Test]
        public void Decrypt__ShouldReturnTrue()
        {
            // arrange
            uint a = 0b_0011;
            uint b = 0b_1001;
            uint c = 0b_0001;
            uint d = 0b_0001;
            uint m = 0b_1011;
            uint k = 0b_0101;
            Md5Data expectedMd5Data = new Md5Data
            {
                A = 0b_0100,
                B = 0b_1010,
                C = 0b_0110,
                D = 0b_1100,
                M = m,
                K = k
            };

            var md5Data = new Md5Data
            {
                A = a,
                B = b,
                C = c,
                D = d,
                M = m,
                K = k
            };

            // act
            var result = _service.Decrypt(md5Data);

            // assert
            Assert.AreEqual(expectedMd5Data.A, result.A);
            Assert.AreEqual(expectedMd5Data.B, result.B);
            Assert.AreEqual(expectedMd5Data.C, result.C);
            Assert.AreEqual(expectedMd5Data.D, result.D);
        }

        [Test]
        public void DecryptPerRound__ShouldReturnTrue()
        {
            // arrange
            uint a = 0b_0011;
            uint b = 0b_1001;
            uint c = 0b_0001;
            uint d = 0b_0001;
            uint m = 0b_1011;
            uint k = 0b_0101;
            Md5Data expectedMd5Data = new Md5Data
            {
                A = 0b_0110,
                B = 0b_0001,
                C = 0b_0011,
                D = 0b_1010,
                M = m,
                K = k
            };

            var md5Data = new Md5Data
            {
                A = a,
                B = b,
                C = c,
                D = d,
                M = m,
                K = k,
                Round = 2
            };

            // act
            var result = _service.DecryptPerRound(md5Data);

            // assert
            Assert.AreEqual(expectedMd5Data.A, result.A);
            Assert.AreEqual(expectedMd5Data.B, result.B);
            Assert.AreEqual(expectedMd5Data.C, result.C);
            Assert.AreEqual(expectedMd5Data.D, result.D);
        }
    }
}

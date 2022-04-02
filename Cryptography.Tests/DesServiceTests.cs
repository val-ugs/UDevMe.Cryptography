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
    class DesServiceTests
    {
        private DesService _service;

        [SetUp]
        public void Setup()
        {
            _service = new DesService();
        }

        [Test]
        public void Encrypt__ShouldReturnTrue()
        {
            // arrange
            uint[] values = new uint[] { 11, 19, 18, 15};
            uint[] key = new uint[] { 11, 9, 1};
            uint[][] initialIP = new uint[][] { new uint[] { 26, 18, 10, 2, 28, 20, 12, 4 },
                                              new uint[] { 30, 22, 14, 6, 32, 24, 16, 8 },
                                              new uint[] { 25, 17, 9, 1, 27, 19, 11, 3 },
                                              new uint[] { 29, 21, 13, 5, 31, 23, 15, 7} };
            uint[] pBlock = new uint[] { 16, 7, 12, 13, 1, 5, 15, 10, 2, 8, 3, 9, 14, 6, 4, 11 };
            uint[][] finalIP = new uint[][] { new uint[] { 20, 4, 24, 8, 28, 12, 32, 16 },
                                              new uint[] { 19, 3, 23, 7, 27, 11, 31, 15 },
                                              new uint[] { 18, 2, 22, 6, 26, 10, 30, 14 },
                                              new uint[] { 17, 1, 21, 5, 25, 9, 29, 13 } };
            uint[] expectedResult = new uint[] { 133, 129, 137, 13};

            DesData desData = new DesData
            {
                Values = values,
                Key = key,
                InitialIP = initialIP,
                PBlock = pBlock,
                FinalIP = finalIP
            };

            // act
            var result = _service.Encrypt(desData);

            // assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        //[Test]
        //public void Decrypt__ShouldReturnTrue()
        //{
        //    // arrange
        //    uint[][] values = new uint[][] { new uint[] { 234, 98 },
        //                                     new uint[] { 5, 188 } };
        //    uint[][] key = new uint[][] { new uint[] { 12, 10 },
        //                                  new uint[] { 0, 13 }};
        //    int round = 1;
        //    uint[][] expectedResult = new uint[][] { new uint[] { 17, 19 },
        //                                             new uint[] { 9, 13 } };

        //    DesData desData = new DesData
        //    {
        //        Values = values,
        //        Key = key,
        //        Round = round
        //    };

        //    // act
        //    var result = _service.Decrypt(desData);

        //    // assert
        //    CollectionAssert.AreEqual(expectedResult, result);
        //}
    }
}

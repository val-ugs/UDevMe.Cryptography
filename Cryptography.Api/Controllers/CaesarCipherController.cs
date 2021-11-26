using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cryptography.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaesarCipherController
    {
        private readonly ICaesarCipherService _caesarCipherService;

        public CaesarCipherController(ICaesarCipherService caesarCipherService)
        {
            _caesarCipherService = caesarCipherService;
        }

        [HttpPost("[action]")]
        public ActionResult<string[]> Encrypt(CaesarCipherData caesarCipherData)
        {
            var result = _caesarCipherService.Encrypt(caesarCipherData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<string[]> Decrypt(CaesarCipherData caesarCipherData)
        {
            var result = _caesarCipherService.Decrypt(caesarCipherData);

            return result;
        }
    }
}

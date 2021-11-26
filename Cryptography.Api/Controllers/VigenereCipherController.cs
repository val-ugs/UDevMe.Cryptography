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
    public class VigenereCipherController
    {
        private readonly IVigenereCipherService _viginereCipherService;

        public VigenereCipherController(IVigenereCipherService viginereCipherService)
        {
            _viginereCipherService = viginereCipherService;
        }

        [HttpPost("[action]")]
        public ActionResult<string> Encrypt(VigenereCipherData vigenereCipherData)
        {
            var result = _viginereCipherService.Encrypt(vigenereCipherData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<string> Decrypt(VigenereCipherData vigenereCipherData)
        {
            var result = _viginereCipherService.Decrypt(vigenereCipherData);

            return result;
        }
    }
}

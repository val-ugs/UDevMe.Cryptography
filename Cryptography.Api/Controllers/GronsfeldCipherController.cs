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
    public class GronsfeldCipherController : ControllerBase
    {
        private readonly IGronsfeldCipherService _gronsfeldCipherService;

        public GronsfeldCipherController(IGronsfeldCipherService gronsfeldCipherService)
        {
            _gronsfeldCipherService = gronsfeldCipherService;
        }

        [HttpPost("[action]")]
        public ActionResult<string> Encrypt(GronsfeldCipherData gronsfeldCipherData)
        {
            var result = _gronsfeldCipherService.Encrypt(gronsfeldCipherData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<string> Decrypt(GronsfeldCipherData gronsfeldCipherData)
        {
            var result = _gronsfeldCipherService.Decrypt(gronsfeldCipherData);

            return result;
        }
    }
}

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
    public class RsaController : ControllerBase
    {
        private readonly IRsaService _rsaService;

        public RsaController(IRsaService rsaService)
        {
            _rsaService = rsaService;
        }

        [HttpPost ("[action]")]
        public ActionResult<int> Encrypt(RsaData rsaData)
        {
            var result = _rsaService.Encrypt(rsaData);

            return result;
        }

        [HttpPost ("[action]")]
        public ActionResult<int> Decrypt(RsaData rsaData)
        {
            var result = _rsaService.Decrypt(rsaData);

            return result;
        }
    }
}

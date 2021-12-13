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
    public class BlowfishController
    {
        private readonly IBlowfishService _blowfishService;

        public BlowfishController(IBlowfishService blowfishService)
        {
            _blowfishService = blowfishService;
        }

        [HttpPost("[action]")]
        public ActionResult<BlowfishData> Encrypt(BlowfishData blowfishData)
        {
            var result = _blowfishService.Encrypt(blowfishData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<BlowfishData> Decrypt(BlowfishData blowfishData)
        {
            var result = _blowfishService.Decrypt(blowfishData);

            return result;
        }
    }
}

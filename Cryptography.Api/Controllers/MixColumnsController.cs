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
    public class MixColumnsController
    {
        private readonly IMixColumnsService _mixColumnsService;

        public MixColumnsController(IMixColumnsService mixColumnsService)
        {
            _mixColumnsService = mixColumnsService;
        }

        [HttpPost("[action]")]
        public ActionResult<uint[][]> Encrypt(MixColumnsData mixColumnsData)
        {
            var result = _mixColumnsService.Encrypt(mixColumnsData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<uint[][]> Decrypt(MixColumnsData mixColumnsData)
        {
            var result = _mixColumnsService.Decrypt(mixColumnsData);

            return result;
        }
    }
}

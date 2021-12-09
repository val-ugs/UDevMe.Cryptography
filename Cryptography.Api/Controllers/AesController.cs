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
    public class AesController : ControllerBase
    {
        private readonly IAesService _aesService;

        public AesController(IAesService aesService)
        {
            _aesService = aesService;
        }

        [HttpPost("[action]")]
        public ActionResult<uint[][]> GetSubBytesPerRound(AesData aesData)
        {
            var result = _aesService.GetSubBytesPerRound(aesData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<uint[][]> GetShiftRowsPerRound(AesData aesData)
        {
            var result = _aesService.GetShiftRowsPerRound(aesData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<uint[][]> GetMixColumnsPerRound(AesData aesData)
        {
            var result = _aesService.GetMixColumnsPerRound(aesData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<uint[][]> Encrypt(AesData aesData)
        {
            var result = _aesService.Encrypt(aesData);

            return result;
        }
    }
}

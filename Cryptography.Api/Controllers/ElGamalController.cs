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
    public class ElGamalController : ControllerBase
    {
        private readonly IElGamalService _elGamalService;

        public ElGamalController(IElGamalService elGamalService)
        {
            _elGamalService = elGamalService;
        }

        [HttpPost("[action]")]
        public ActionResult<int[]> Encrypt(ElGamalData elGamalData)
        {
            var result = _elGamalService.Encrypt(elGamalData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<int[]> Decrypt(ElGamalData elGamalData)
        {
            var result = _elGamalService.Decrypt(elGamalData);

            return result;
        }
    }
}

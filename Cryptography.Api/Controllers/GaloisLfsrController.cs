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
    public class GaloisLfsrController : ControllerBase
    {
        private readonly IGaloisLfsrService _galoisLfsrService;

        public GaloisLfsrController(IGaloisLfsrService galoisLfsrService)
        {
            _galoisLfsrService = galoisLfsrService;
        }

        [HttpPost("[action]")]
        public ActionResult<int> GetPeriod(GaloisLfsrData galoisLfsrData)
        {
            var result = _galoisLfsrService.GetPeriod(galoisLfsrData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<int[]> GenerateSequence(GaloisLfsrData galoisLfsrData)
        {
            var result = _galoisLfsrService.GenerateSequence(galoisLfsrData);

            return result;
        }
    }
}

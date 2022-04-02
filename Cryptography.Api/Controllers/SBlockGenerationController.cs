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
    public class SBlockGenerationController : ControllerBase
    {
        private readonly ISBlockGenerationService _sBlockGenerationService;

        public SBlockGenerationController(ISBlockGenerationService sBlockGenerationService)
        {
            _sBlockGenerationService = sBlockGenerationService;
        }

        [HttpPost("[action]")]
        public ActionResult<int[]> Generate(SBlockGenerationData sBlockGenerationData)
        {
            var result = _sBlockGenerationService.Generate(sBlockGenerationData);

            return result;
        }
    }
}

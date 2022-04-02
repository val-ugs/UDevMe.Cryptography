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
    public class PermutationController : ControllerBase
    {
        private readonly IPermutationService _permutationService;

        public PermutationController(IPermutationService permutationService)
        {
            _permutationService = permutationService;
        }

        [HttpPost("[action]")]
        public ActionResult<Dictionary<string, string>> Permutate(PermutationData permutationData)
        {
            var result = _permutationService.Permutate(permutationData);

            return result;
        }
    }
}

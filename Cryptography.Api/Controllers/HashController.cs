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
    public class HashController : ControllerBase
    {
        private readonly IHashService _hashService;

        public HashController(IHashService hashService)
        {
            _hashService = hashService;
        }

        [HttpPost("[action]")]
        public ActionResult<int> Calculate(HashData hashData)
        {
            var result = _hashService.Calculate(hashData);

            return result;
        }
    }
}

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
    public class EnigmaController : ControllerBase
    {
        private readonly IEnigmaService _enigmaService;

        public EnigmaController(IEnigmaService enigmaService)
        {
            _enigmaService = enigmaService;
        }

        [HttpPost("[action]")]
        public ActionResult<string> Decrypt(EnigmaData enigmaData)
        {
            var result = _enigmaService.Decrypt(enigmaData);

            return result;
        }
    }
}
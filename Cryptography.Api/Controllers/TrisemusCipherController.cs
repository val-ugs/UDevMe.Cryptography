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
    public class TrisemusCipherController : ControllerBase
    {
        private readonly ITrisemusCipherService _trisemusCipherService;

        public TrisemusCipherController(ITrisemusCipherService trisemusCipherService)
        {
            _trisemusCipherService = trisemusCipherService;
        }

        [HttpPost("[action]")]
        public ActionResult<string> Encrypt(TrisemusCipherData trisemusCipherData)
        {
            var result = _trisemusCipherService.Encrypt(trisemusCipherData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<string> Decrypt(TrisemusCipherData trisemusCipherData)
        {
            var result = _trisemusCipherService.Decrypt(trisemusCipherData);

            return result;
        }
    }
}

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
    public class TripleDesController
    {
        private readonly ITripleDesService _tripleDesService;

        public TripleDesController(ITripleDesService tripleDesService)
        {
            _tripleDesService = tripleDesService;
        }

        [HttpPost("[action]")]
        public ActionResult<TripleDesData> Encrypt(TripleDesData tripleDesData)
        {
            var result = _tripleDesService.Encrypt(tripleDesData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<TripleDesData> EncryptPerDesNumber(TripleDesData tripleDesData)
        {
            var result = _tripleDesService.EncryptPerDesNumber(tripleDesData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<TripleDesData> Decrypt(TripleDesData tripleDesData)
        {
            var result = _tripleDesService.Decrypt(tripleDesData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<TripleDesData> DecryptPerDesNumber(TripleDesData tripleDesData)
        {
            var result = _tripleDesService.DecryptPerDesNumber(tripleDesData);

            return result;
        }
    }
}

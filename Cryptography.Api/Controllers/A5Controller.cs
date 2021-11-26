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
    public class A5Controller : ControllerBase
    {
        private readonly IA5Service _a5Service;

        public A5Controller(IA5Service rsaService)
        {
            _a5Service = rsaService;
        }

        [HttpPost("[action]")]
        public ActionResult<int[]> GetKey(A5Data a5Data)
        {
            var result = _a5Service.GetKey(a5Data);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<int[]> Encrypt(A5Data a5Data)
        {
            var result = _a5Service.Encrypt(a5Data);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<int[]> Decrypt(A5Data a5Data)
        {
            var result = _a5Service.Decrypt(a5Data);

            return result;
        }
    }
}

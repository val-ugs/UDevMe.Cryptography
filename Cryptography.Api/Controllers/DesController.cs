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
    public class DesController : ControllerBase
    {
        private readonly IDesService _desService;

        public DesController(IDesService desService)
        {
            _desService = desService;
        }

        [HttpPost("[action]")]
        public ActionResult<uint[]> Encrypt(DesData desData)
        {
            var result = _desService.Encrypt(desData);

            return result;
        }
    }
}

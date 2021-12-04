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
    public class DiffieHellmanController : ControllerBase
    {
        private readonly IDiffieHellmanService _diffieHellmanService;

        public DiffieHellmanController(IDiffieHellmanService diffieHellmanService)
        {
            _diffieHellmanService = diffieHellmanService;
        }

        [HttpPost("[action]")]
        public ActionResult<int> GetA(DiffieHellmanData diffieHellmanData)
        {
            var result = _diffieHellmanService.GetA(diffieHellmanData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<int> GetB(DiffieHellmanData diffieHellmanData)
        {
            var result = _diffieHellmanService.GetB(diffieHellmanData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<int> GetKeyX(DiffieHellmanData diffieHellmanData)
        {
            var result = _diffieHellmanService.GetKeyX(diffieHellmanData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<int> GetKeyY(DiffieHellmanData diffieHellmanData)
        {
            var result = _diffieHellmanService.GetKeyY(diffieHellmanData);

            return result;
        }
    }
}

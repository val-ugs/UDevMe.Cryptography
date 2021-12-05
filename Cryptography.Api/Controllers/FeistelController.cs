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
    public class FeistelController : ControllerBase
    {
        private readonly IFeistelService _feistelService;

        public FeistelController(IFeistelService feistelService)
        {
            _feistelService = feistelService;
        }

        [HttpPost("[action]")]
        public ActionResult<FeistelData> EncryptPerRound(FeistelData feistelData)
        {
            var result = _feistelService.EncryptPerRound(feistelData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<FeistelData> DecryptPerRound(FeistelData feistelData)
        {
            var result = _feistelService.DecryptPerRound(feistelData);

            return result;
        }
    }
}

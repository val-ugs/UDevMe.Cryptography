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
    public class Md5Controller : ControllerBase
    {
        private readonly IMd5Service _md5Service;

        public Md5Controller(IMd5Service md5Service)
        {
            _md5Service = md5Service;
        }

        [HttpPost("[action]")]
        public ActionResult<Md5Data> Encrypt(Md5Data md5Data)
        {
            var result = _md5Service.Encrypt(md5Data);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<Md5Data> EncryptPerRound(Md5Data md5Data)
        {
            var result = _md5Service.EncryptPerRound(md5Data);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<Md5Data> Decrypt(Md5Data md5Data)
        {
            var result = _md5Service.Decrypt(md5Data);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<Md5Data> DecryptPerRound(Md5Data md5Data)
        {
            var result = _md5Service.DecryptPerRound(md5Data);

            return result;
        }
    }
}

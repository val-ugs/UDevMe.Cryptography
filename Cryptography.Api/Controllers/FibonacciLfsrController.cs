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
    public class FibonacciLfsrController : ControllerBase
    {
        private readonly IFibonacciLfsrService _fibonacciLfsrService;

        public FibonacciLfsrController(IFibonacciLfsrService fibonacciLfsrService)
        {
            _fibonacciLfsrService = fibonacciLfsrService;
        }

        [HttpPost("[action]")]
        public ActionResult<int> GetPeriod(FibonacciLfsrData fibonacciLfsrData)
        {
            var result = _fibonacciLfsrService.GetPeriod(fibonacciLfsrData);

            return result;
        }

        [HttpPost("[action]")]
        public ActionResult<int[]> GenerateSequence(FibonacciLfsrData fibonacciLfsrData)
        {
            var result = _fibonacciLfsrService.GenerateSequence(fibonacciLfsrData);

            return result;
        }
    }
}

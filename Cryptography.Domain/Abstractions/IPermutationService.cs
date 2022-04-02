using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IPermutationService
    {
        Dictionary<string, string> Permutate(PermutationData permutationData);
    }
}

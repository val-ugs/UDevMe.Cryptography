using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class SBlockGenerationService : ISBlockGenerationService
    {
        public int[] Generate(SBlockGenerationData sBlockGenerationData)
        {
            int[] s = new int[sBlockGenerationData.IMax];

            s[0] = (sBlockGenerationData.A * sBlockGenerationData.Z0 * sBlockGenerationData.B) % sBlockGenerationData.C;
            for (int i = 0; i < sBlockGenerationData.IMax - 1; i++)
            {
                s[i + 1] = (sBlockGenerationData.A * s[i] * sBlockGenerationData.B) % sBlockGenerationData.C;
            }

            return s;
        }
    }
}

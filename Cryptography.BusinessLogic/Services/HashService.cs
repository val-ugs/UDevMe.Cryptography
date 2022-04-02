using Cryptography.Domain.Abstractions;
using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.BusinessLogic.Services
{
    public class HashService : IHashService
    {
        public int Calculate(HashData hashData)
        {
            int h = hashData.H0;
            
            for (int i =0; i < hashData.M.Count; i++)
            {
                h = (int)Math.Pow((h + hashData.M[i]), 2) % hashData.P;
            }

            return h;
        }
    }
}

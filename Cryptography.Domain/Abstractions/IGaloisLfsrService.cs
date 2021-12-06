﻿using Cryptography.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Domain.Abstractions
{
    public interface IGaloisLfsrService
    {
        int GetPeriod(GaloisLfsrData galoisLfsrData);
        int[] GenerateSequence(GaloisLfsrData galoisLfsrData);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiffApi.Models;

namespace DiffApi.Contracts
{
    public interface IDiffService
    {
        DiffResult GetDiff(byte[] left, byte[] right);
    }
}

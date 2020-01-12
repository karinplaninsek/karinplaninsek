using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiffApi.Models;

namespace DiffApi.Contracts
{
    public interface IStateService
    {
        void Set(string id, Side side, byte[] data);
        byte[] Get(string id, Side side);
    }
}

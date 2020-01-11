using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Models
{
    // used for defining result types of comparing sides between each other
    public enum DiffResultType
    {
        // data on both sides is equal
        Equals,
        // data sizes are not equal
        SizeDoNotMatch,
        // data sizes are equal, but contents differ
        ContentDoNotMatch
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Models
{
    public class DiffResultDetails
    {
        // diff offset
        public int Offset { get; set; }
        // diff length
        public int Length { get; set; }
    }
}

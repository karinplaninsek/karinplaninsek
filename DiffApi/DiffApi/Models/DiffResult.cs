using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DiffApi.Models
{
    public class DiffResult
    {
        public DiffResult()
        {

        }

        public DiffResult(IEnumerable<DiffResultDetails> diffs) : this(DiffResultType.ContentDoNotMatch)
        {
            Diffs = diffs;
        }

        public DiffResult(DiffResultType resultType)
        {
            DiffResultType = resultType;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public DiffResultType DiffResultType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<DiffResultDetails> Diffs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiffApi.Models;
using DiffApi.Contracts;

namespace DiffApi.Services
{
    public class DiffService : IDiffService
    {
        public DiffResult GetDiff(byte[] left, byte[] right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            } else if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            if (left.Length != right.Length)
            {
                return new DiffResult(DiffResultType.SizeDoNotMatch);
            }

            var diff = GetDiffDetails(left, right).ToList();
            if (diff.Count == 0)
            {
                return new DiffResult(DiffResultType.Equals);
            }

            return new DiffResult(diff);
        }

        private static IEnumerable<DiffResultDetails> GetDiffDetails(byte[] left, byte[] right)
        {
            var diffLength = 0;
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] == right[i])
                {
                    if (diffLength > 0)
                    {
                        yield return GetResult(diffLength, i);
                        diffLength = 0;
                    }
                } else
                {
                    diffLength++;
                }
            }

            if (diffLength > 0)
            {
                yield return GetResult(diffLength, left.Length);
            }
        }

        // calculates diff length and offset
        private static DiffResultDetails GetResult(int diffLength, int index)
        {
            return new DiffResultDetails
            {
                Length = diffLength,
                Offset = index - diffLength
            };
        }
    }
}

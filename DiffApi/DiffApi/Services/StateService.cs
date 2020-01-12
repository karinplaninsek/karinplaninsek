using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using DiffApi.Contracts;
using DiffApi.Models;

namespace DiffApi.Services
{
    public class StateService : IStateService
    {
        private class Key
        {
            public Key(string id, Side side)
            {
                Id = id;
                Side = side;
            }

            public string Id { get; set; }
            public Side Side { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                var key = (Key)obj;
                return key.Id == Id && key.Side == Side;
            }

            public override int GetHashCode()
            {
                return Id.GetHashCode() ^ Side.GetHashCode();
            }
        }

        private readonly ConcurrentDictionary<Key, byte[]> state = new ConcurrentDictionary<Key, byte[]>();

        public byte[] Get(string id, Side side)
        {
            byte[] result;
            return state.TryGetValue(new Key(id, side), out result) ? result : null;
        }

        public void Set(string id, Side side, byte[] data)
        {
            state.AddOrUpdate(new Key(id, side), data, (key, original) => data);
        }
    }
}

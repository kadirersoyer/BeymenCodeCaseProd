using BeymenCodeCase.Services.Abstact;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeymenCodeCase.Services.Redis
{
    public class RedisService : IRedisService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer = null;

        //public RedisService(IConnectionMultiplexer connectionMultiplexer)
        //{
        //    _connectionMultiplexer = connectionMultiplexer;
        //}

        public void Connect()
        {
        }

        public async Task<string> GetValueCacheValueAsync(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);
        }

        public string KeyBuilder(string applicationName, string key, bool isActive)
        {
            var keys = isActive ? $"{applicationName}_{key}_IsActive:1"
                : $"{applicationName}_{key}_IsActive:0";
            return keys;
        }

        public async Task SetCacheValueAsync(string key1, string value)
        {
            var db = _connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key1, value);
        }
    }
}

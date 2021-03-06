using Autofac;
using BeymenCodeCase.Common;
using BeymenCodeCase.Services.Factory;
using BeymenCodeCase.Services.Helper;
using BeymenCodeCase.Services.Redis;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeymenCodeCase.Services.Configuration
{
    public class ConfigurationReaderService
    {

        private readonly string applicationName;
        private readonly string connectionString;
        private readonly int refreshTimerIntervalInMs;
        public ConfigurationReaderService(string applicationName, string connectionString, int refreshTimerIntervalInMs)
        {
            this.applicationName = applicationName;
            this.connectionString = connectionString;
            this.refreshTimerIntervalInMs = refreshTimerIntervalInMs;
        }

        public T GetValue<T>(string key)
        {
            
            // Connect Redis And Get Key Value From Redis Storage
            using (var scope = StaticHelper.GetScope())
            {
                var creatorFactory = scope.ServiceProvider.GetService<ICreatorFactory>();

                var redisService = creatorFactory.GetService(NoSqlType.Redis) as IRedisService;

                var builedKey = redisService.KeyBuilder(applicationName, key, true);

                var data = redisService.GetValueCacheValueAsync(builedKey).Result;

                return JsonConvert.DeserializeObject<T>(data);
            }
        }
    }
}

using BeymenCodeCase.Common;
using BeymenCodeCase.Services.Abstact;
using BeymenCodeCase.Services.Redis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeymenCodeCase.Services.Factory
{
    public class CreatorFactory: ICreatorFactory
    {
        private IServiceProvider _serviceProvider;

        public CreatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        ///  I Used Ony Redis Creator
        /// </summary>
        /// <param name="noSqlType"></param>
        /// <returns></returns>
        public INoSqlService GetService(NoSqlType noSqlType)
        {
            INoSqlService noSqlService = null;
            switch (noSqlType)
            {
                case NoSqlType.Redis:
                    noSqlService = ActivatorUtilities.CreateInstance<IRedisService>(_serviceProvider);
                    break;
                case NoSqlType.Elastic:
                    noSqlService = ActivatorUtilities.CreateInstance<IRedisService>(_serviceProvider);
                    break;
                case NoSqlType.Mongo:
                    noSqlService = ActivatorUtilities.CreateInstance<IRedisService>(_serviceProvider);
                    break;
                default:
                    break;
            }
            return noSqlService;
        }
    }
}

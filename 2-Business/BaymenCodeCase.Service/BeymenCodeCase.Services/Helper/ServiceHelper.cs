using Autofac;
using BeymenCodeCase.Common;
using BeymenCodeCase.Services.Factory;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeymenCodeCase.Services.Helper
{
    public class ServiceHelper: IServiceHelper
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T GetService<T>()
        {
            var creatorFactory = (ICreatorFactory)_serviceProvider.GetService(typeof(ICreatorFactory));
            return (T)creatorFactory.GetService(NoSqlType.Redis);
        }

    }
}

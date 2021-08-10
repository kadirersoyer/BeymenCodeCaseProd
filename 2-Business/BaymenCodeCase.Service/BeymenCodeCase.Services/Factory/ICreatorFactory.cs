using BeymenCodeCase.Common;
using BeymenCodeCase.Services.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeymenCodeCase.Services.Factory
{
    public interface ICreatorFactory
    {
        INoSqlService GetService(NoSqlType noSqlType);
    }
}

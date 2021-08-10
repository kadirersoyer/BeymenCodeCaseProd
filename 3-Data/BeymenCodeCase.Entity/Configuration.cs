using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeymenCodeCase.Entity
{
    public class Configuration: BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string IsActive { get; set; }
        public string ApplicationName { get; set; }
    }
}

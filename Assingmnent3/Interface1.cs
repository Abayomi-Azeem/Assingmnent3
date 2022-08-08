using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingmnent3
{
    internal interface IShippingRules
    {
        
        public bool IsExport { get; set; }

        public string? Country { get; set; }

        
    }
}

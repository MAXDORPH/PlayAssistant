using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSModules
{
    public interface IReturnValue
    {
        string Title { get; set; }

        string Value { get; set; }
    }
}

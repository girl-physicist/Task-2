using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Creator;

namespace Task_2.Parser
{
    public interface IParser<T>
    {
        T Parse(IEnumerable<string> str);
    }
}

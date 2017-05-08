using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Parser
{
    public interface IParser<T>
    {
        T Parse(List<string> str);
    }
}

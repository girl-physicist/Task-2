using System.Collections.Generic;

namespace Task_2.Parser
{
    public interface IParser<T>
    {
        T Parse(IEnumerable<string> str);
    }
}

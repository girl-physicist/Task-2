using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Part_2.Subject_index;

namespace Task_2_Part_2.Parser
{
    public interface IParser
    {
        Dictionary<string, Word> Parse(IEnumerable<string> text);
    }
}

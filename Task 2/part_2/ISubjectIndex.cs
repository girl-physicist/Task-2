using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Task_2_part_2
{
    interface ISubjectIndex
    {
        IDictionary<char, string[]> Some(int lineNumberOnPage);
    }
}

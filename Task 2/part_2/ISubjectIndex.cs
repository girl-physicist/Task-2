using System.Collections.Generic;

namespace Task_2.part_2
{
    interface ISubjectIndex
    {
        IDictionary<char, string[]> GetDictionary(IEnumerable<string> listSentences, int lineNumberOnPage);
    }
}

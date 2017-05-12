using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Dictionary
{
    public class Dictionary
    {
     public   Dictionary<string, string> EndOfSentenceСharacters = new Dictionary<string, string>
        {
            ["pointIndex"] = ".",
            ["exlamationIndex"] = "!",
            ["questionIndex"] = "?",
            ["ellipsisIndex"] = "...",
            ["interrogatoryExclamationIndex"] = "?!",
            ["hardExclamationIndex"] = "!!"
        };
    }
}

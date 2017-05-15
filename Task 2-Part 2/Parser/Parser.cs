using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task_2_Part_2.Subject_index;

namespace Task_2_Part_2.Parser
{
    public class Parser : IParser
    {
        public Dictionary<string, Word> Parse(IEnumerable<string> text)
        {
            var result = new Dictionary<string, Word>();
            var iLine = 0;
            foreach (var line in text)
            {
                iLine++;
                foreach (Match match in Regex.Matches(line, @"\w+"))
                {
                    var wordKey = match.Value;

                    if (!result.TryGetValue(wordKey, out Word word))
                        word = result[wordKey] = new Word(wordKey);
                    word.AddLine(iLine);
                }
            }
            return result;
        }
    }
}

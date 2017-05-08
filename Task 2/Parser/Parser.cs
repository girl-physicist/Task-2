using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task_2.Classes;
using Task_2.Enums;

namespace Task_2.Parser
{
    public class TextParser : IParser<Text>
    {
        public Text Parse(List<string> sentences)
        {
            {
                var text = new Text();
                string pattern = @"(\w+)|(\p{P})";
                foreach (var currentSentence in sentences)
                {
                    var sentence = new Sentence();
                    var matches = Regex.Matches(currentSentence, pattern);
                    foreach (Match match in matches)
                    {
                        if (Regex.IsMatch(match.Value, @"(\p{P})"))
                        {
                            sentence.AddElementToEnd(new SentenceItem(match.Value, SentenceItemType.PunctuationSign));
                        }
                        else
                        {
                            sentence.AddElementToEnd(new SentenceItem(match.Value, SentenceItemType.Word));
                        }
                    }
                    text.AddSentence(sentence);
                }
                return text;
            }
        }
    }
}

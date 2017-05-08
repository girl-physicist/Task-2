using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Classes
{
    public class InterrogativeSentence : IInterrogativeSentence
    {
        public bool IsQuestionMark(ISentenceItem element)
        {
            return element.SentenceItemType == SentenceItemType.PunctuationSign && element.Value.Equals("?");
            //if (element.SentenceItemType == SentenceItemType.PunctuationSign)
            //{
            //    if (element.Value.Equals("?"))
            //    {
            //        return true;
            //    }
            //    else return false;
            //}
            //else return false;
        }
    }
}

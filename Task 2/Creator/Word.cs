using System.Text.RegularExpressions;
using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Creator
{
    public class Word : IWord
    {
        public bool FirstLetterIsConsonant(ISentenceItem element)
        {
            const string pattern = @"[aAeEiIoOuU]";
            if (element.SentenceItemType == SentenceItemType.Word)
            {
                // проверка, чтоб слово не было null или Empty и чтоб были слова, начинающиеся с согласной
                //    if (!string.IsNullOrEmpty(element.Value) && !(Regex.Matches(element.Value[0].ToString(), pattern).Count > 0))
                //    {
                //        return true;
                //    }
                //    else return false;
                //}
                //else return false;
                return !string.IsNullOrEmpty(element.Value) && !(Regex.Matches(element.Value[0].ToString(), pattern).Count > 0);
            }
             return false;
        }
        public int GetWordLength(ISentenceItem element)
        {
            return element.Value.Length;
        }

        public void ReplaceValue(int wordLenght, ISentenceItem element, string newValue)
        {
            if (element.SentenceItemType == SentenceItemType.Word && GetWordLength(element) == wordLenght)
            {
                element.Value = newValue;
            }
        }
    }
}








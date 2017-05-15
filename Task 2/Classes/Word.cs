using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Classes
{
    public class Word : IWord
    {
        public bool FirstLetterIsConsonant(ISentenceItem element)
        {
            const string pattern = @"[aAeEiIoOuU]";
            if (element.SentenceItemType == SentenceItemType.Word)
            {
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








using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_2.Classes;
using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Creator
{
    public class Sentence : ISentence
    {
        // присвоение значений таким полям может происходить только как часть объявления или в конструкторе в том же классе.
        private readonly ICollection<ISentenceItem> _sententenceElements;
        private readonly IWord _word;
        public Sentence(ICollection<ISentenceItem> sent, Word word)
        {
            _word = word;
            _sententenceElements = sent;
        }
        public void AddElementToEnd(ISentenceItem element)
        {
            _sententenceElements.Add(element);
        }
        public int GetWordsCount()
        {
            return _sententenceElements.Count(x => x.SentenceItemType == SentenceItemType.Word);
        }
        public int GetElementsCount()
        {
            return _sententenceElements.Count;
        }
        public ISentenceItem GetElementByIndex(int index)
        {
            if (index < 0 || index >= _sententenceElements.Count) return null;
            return _sententenceElements.ElementAt(index);
        }
        public void DeleteWords(int wordLenght)
        {
            // сделать через LINQ
            for (int i = 0; i < _sententenceElements.Count; i++)
            {
                if (_sententenceElements.ElementAt(i).SentenceItemType != SentenceItemType.Word
                    || _word.GetWordLength(_sententenceElements.ElementAt(i)) != wordLenght
                    || !_word.FirstLetterIsConsonant(_sententenceElements.ElementAt(i))) continue;
                _sententenceElements.Remove(_sententenceElements.ElementAt(i));
                i--;
            }
        }
        public void ReplaceWords(int wordLenght, string newValue)
        {
            foreach (var currentSentence in _sententenceElements)
            {
                _word.ReplaceValue(wordLenght, currentSentence, newValue);
            }
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_sententenceElements.ElementAt(0).Value);

            for (int i = 1; i < _sententenceElements.Count; i++)
            {
                if (_sententenceElements.ElementAt(i).SentenceItemType == SentenceItemType.Word)
                {
                    builder.Append(" ");
                }
                builder.Append(_sententenceElements.ElementAt(i).Value);
            }
            return builder.ToString();
        }
    }
}





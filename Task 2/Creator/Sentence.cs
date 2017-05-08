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
        private readonly List<ISentenceItem> _sententenceElements;
        private readonly IWord _word;
        public Sentence()
        {
            _word = new Word();
            _sententenceElements = new List<ISentenceItem>();
        }

        public void AddElementToEnd(ISentenceItem element)
        {
            _sententenceElements.Add(element);
        }
        public int GetWordsCount()
        {
            //int count = 0;
            //foreach (var sentenceElement in _sententenceElements)
            //{
            //    if (sentenceElement.SentenceItemType == SentenceItemType.Word)
            //    {
            //        count++;
            //    }
            //}
            //return count;
            return _sententenceElements.Count(x => x.SentenceItemType == SentenceItemType.Word);
        }
        public int GetElementsCount()
        {
            return _sententenceElements.Count;
        }
        public ISentenceItem GetElementByIndex(int index)
        {
            if (index < 0 || index >= _sententenceElements.Count) return null;
            return _sententenceElements[index];
        }
        //Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
        public void DeleteWords(int wordLenght)
        {
            //делать удаление в копии списка предложений, а не в исх предложениях
            // сделать через LINQ
            var temp = _sententenceElements;
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].SentenceItemType != SentenceItemType.Word || _word.GetWordLength(temp[i]) != wordLenght ||
                    !_word.FirstLetterIsConsonant(temp[i])) continue;
                temp.Remove(temp[i]);
                i--;
            }
        }
            public void ReplaceWords(int wordLenght, string newValue)
            {
                // делать замену в копии списка предложений, а не в исх предложениях
                var sent = _sententenceElements;
                foreach (var currentSentence in sent)
                {
                    _word.ReplaceValue(wordLenght, currentSentence, newValue);
                }
            }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_sententenceElements[0].Value);

            for (int i = 1; i < _sententenceElements.Count; i++)
            {
                if (_sententenceElements[i].SentenceItemType == SentenceItemType.Word)
                {
                    builder.Append(" ");
                }
                builder.Append(_sententenceElements[i].Value);
            }
            return builder.ToString();
        }


    }

       
    
}

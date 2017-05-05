using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Classes
{
    class Sentence : ISentenceItem, ISentence
    {
        private string _value; // объявление закрытого поля
        public string Value // объявление свойства
        {
            get // аксессор чтения поля
            {
                return _value;
            }
            set // аксессор записи в поле
            {
                _value = value;
            }
        }
        private SentenceItemType _sentenceItemType;
        public SentenceItemType SentenceItemType
        {
            get
            {
                return _sentenceItemType;
            }
        }
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
            throw new NotImplementedException();
        }

        public int GetWordsCount()
        {
            throw new NotImplementedException();
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
            // сделать через LINQ
            for (int i = 0; i <= _sententenceElements.Count; i++)
            {
                if (_sententenceElements[i].SentenceItemType == SentenceItemType.Word
                    && _word.GetWordLength(_sententenceElements[i]) == wordLenght
                    && _word.FirstLetterIsConsonant(_sententenceElements[i]))
                {
                    _sententenceElements.Remove(_sententenceElements[i]);
                    i--;
                }
            }
        }
        public void ReplaceWords(int wordLenght, string newValue)
        {
            throw new NotImplementedException();
        }
    }
}

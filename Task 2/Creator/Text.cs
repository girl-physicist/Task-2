using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Task_2.Classes;
using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Creator
{
    public class Text
    {
        private readonly ICollection<ISentence> _sentences;
        private readonly IInterrogativeSentence _qustionMark;
        public Text(ICollection<ISentence> sent, InterrogativeSentence questionMark)
        {
            _sentences = sent;
            _qustionMark = questionMark;
        }
        public void AddSentence(ISentence sentence)
        {
            _sentences.Add(sentence);
        }
        public void RemoveSentence(ISentence sentence)
        {
            _sentences.Remove(sentence);
        }
        public IEnumerable<ISentence> SortSentencesByWordsCount()
        {
            return _sentences.OrderBy(x => x.GetWordsCount());
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _sentences);
        }
        public IEnumerable<ISentence> GetQuestionSentences()
        {
            return (from chosenSentence in _sentences
                    let count = chosenSentence.GetElementsCount()
                    let chosenElement = chosenSentence.GetElementByIndex(count - 1)
                    where chosenElement != null
                    where _qustionMark.IsQuestionMark(chosenElement)
                    select chosenSentence).ToList();
        }
        public void RemoveWords(int wordLenght)
        {
            foreach (var chosenSentence in _sentences)
            {
                chosenSentence.DeleteWords(wordLenght);
            }
        }
        public void ReplaceWords(int indexSentense, int wordLenght, string newValue)
        {
            var currentSentence = _sentences.ElementAt(indexSentense);
            currentSentence.ReplaceWords(wordLenght, newValue);
        }
        public IEnumerable<string> FindWordsOfPredeterminedLenght(int wordLenght)
        {
            IWord word = new Word();
            ICollection<ISentenceItem> buffer =new List<ISentenceItem>();
            foreach (var currentSentence in GetQuestionSentences())
            {
                for (int i = 0; i < currentSentence.GetWordsCount(); i++)
                {
                    var currentElement = currentSentence.GetElementByIndex(i);
                    buffer.Add(currentElement);
                }
            }
            return buffer.ToArray()
                .Where(x => x.SentenceItemType == SentenceItemType.Word && word.GetWordLength(x) == wordLenght)
                .Select(x => x.Value.ToUpper()).Distinct().ToArray();
        }
    }
}

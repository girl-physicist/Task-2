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
        private readonly IInterrogativeSentence _punctuationMark;
        public Text(ICollection<ISentence> sent, InterrogativeSentence questionMark)
        {
            _sentences = sent;
            _punctuationMark = questionMark;
        }
        public void AddSentence(ISentence sentence)
        {
            _sentences.Add(sentence);
        }
        public void RemoveSentence(ISentence sentence)
        {
            _sentences.Remove(sentence);
        }
        public IEnumerable<ISentence> SortSentences()
        {
            return _sentences.OrderBy(x => x.GetWordsCount());
        }
        //"Text.ToString()" скрывает наследуемый член "object.ToString()". Чтобы текущий член переопределял эту реализацию, исп.  override
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _sentences);
        }
        //Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
        public IEnumerable<ISentence> GetQuestionSentences()
        {
            return (from chosenSentence in _sentences
                    let count = chosenSentence.GetElementsCount()
                    let chosenElement = chosenSentence.GetElementByIndex(count - 1)
                    where chosenElement != null
                    where _punctuationMark.IsQuestionMark(chosenElement)
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
        public IEnumerable<string> FindWordsOfPredeterminedLenght(Text text, int wordLenght)
        {
            IWord word=new Word();
            ICollection<string> words = new List<string>();
            foreach (var currentSentence in text.GetQuestionSentences())
            {
                for (int i = 0; i < currentSentence.GetWordsCount(); i++)
                {
                    var currentElement = currentSentence.GetElementByIndex(i);
                    if (currentElement.SentenceItemType != SentenceItemType.Word ||
                        word.GetWordLength(currentElement) != wordLenght) continue;
                    var str = currentElement.Value.ToUpper();
                    if (!words.Contains(str))
                    {
                        words.Add(str);
                    }
                }
            }
            return words.ToArray();


            //return text.GetQuestionSentences()
            //    .OfType<Word>() .SelectMany(x=x.ofType<Word>)
            // .Where(y => y.GetWordLength(word) == wordLenght)
            //   .ToArray().Distinct();
        }
    }
}

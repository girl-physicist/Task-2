﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Classes
{
    public class Text
    {
        private readonly List<ISentence> _sentences;
        private readonly IWord _word;
        private readonly IInterrogativeSentence _punctuationMark;
        public Text()
        {
            _word = new Word();
            _sentences = new List<ISentence>();
            _punctuationMark = new InterrogativeSentence();
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
            // сепаратор Environment.NewLine равносилен  "\r\n" 
            return string.Join(Environment.NewLine, _sentences);
        }
        //Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
        public List<ISentence> GetQuestionSentences()
        {
            List<ISentence> questionSentences = new List<ISentence>();
            foreach (var chosenSentence in _sentences)
            {
                var count = chosenSentence.GetElementsCount();
                var chosenElement = chosenSentence.GetElementByIndex(count - 1);
                if (chosenElement == null) continue;
                if (_punctuationMark.IsQuestionMark(chosenElement))
                {
                    questionSentences.Add(chosenSentence);
                }
            }
            return questionSentences;
        }
        public List<ISentence> GetSentences()
        {
            return _sentences;
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
            var currentSentence = _sentences[indexSentense];
            if (currentSentence == null) return;
            currentSentence.ReplaceWords(wordLenght, newValue);
        }
        public IEnumerable<string> FindWordsOfPredeterminedLenght(Text text, int wordLenght)
        {
            List<string> words = new List<string>();
            foreach (var currentSentence in text.GetQuestionSentences())
            {
                for (int i = 0; i < currentSentence.GetWordsCount(); i++)
                {
                    var currentElement = currentSentence.GetElementByIndex(i);
                    if (currentElement.SentenceItemType == SentenceItemType.Word
                        && _word.GetWordLength(currentElement) == wordLenght)
                    {
                        var str = currentElement.Value.ToUpper();
                        if (!words.Contains(str))
                        {
                            words.Add(str);
                        }
                    }
                }
            }
            return words.ToArray();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Classes
{
    public class SentenceItem : ISentenceItem
    {
        private string _value;
        public string Value { get; set; }
        private SentenceItemType _sentenceItemType;
        public SentenceItemType SentenceItemType { get; private set; }

        public SentenceItem(string sentenceElementValue, SentenceItemType type)
        {
            _value = sentenceElementValue;
            _sentenceItemType = type;
        }
    }
}

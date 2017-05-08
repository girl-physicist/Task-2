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
        public SentenceItemType SentenceItemType { get; private set; }
        public string Value { get; set; }
        public SentenceItem(string sentenceElementValue, SentenceItemType type)
        {
            Value = sentenceElementValue;
           SentenceItemType = type;
        }
    }
}

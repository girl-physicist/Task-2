using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Enums;
using Task_2.Interfaces;

namespace Task_2.Classes
{
    class Sentence : Word,ISentenceItem
    {
        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SentenceItemType SentenceItemType => throw new NotImplementedException();

        //private readonly List<ISentenceItem> _sententenceElements;
        //private readonly IWord _word;
        //public Sentence()
        //{
        //    _word = new Word();
        //    _sententenceElements = new List<ISentenceItem>();
        //}



    }
}

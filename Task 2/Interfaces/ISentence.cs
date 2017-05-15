using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Interfaces
{
    public interface ISentence
    {
        void AddElementToEnd(ISentenceItem element);
        int GetWordsCount();
        int GetElementsCount();
        ISentenceItem GetElementByIndex(int index);
        void DeleteWordsOfGivenLength(int wordLenght);
        void ReplaceWords(int wordLenght, string newValue);
    }
}

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
        //Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
        //Выражение [^aAeEiIoOuU] соответствует всем символам, которые не являются гласными.
        void DeleteWords(int wordLenght);
        //В некотором предложении текста слова заданной длины заменить указанной подстрокой,
        //длина которой может не совпадать с длиной слова.
        void ReplaceWords(int wordLenght, string newValue);
        // заменять табуляции и последовательности пробелов одним пробелом.
        //Split по пробелу, в цикле Trim для каждрй строку, потом собирать текст обратно (вставляя пробелы),
    }
}

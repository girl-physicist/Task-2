using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Interfaces
{
    public interface IWord
    {
        int GetWordLength(ISentenceItem element);
        bool FirstLetterIsConsonant(ISentenceItem element);
        void ReplaceValue(int wordLenght, ISentenceItem element, string newValue);
    }
}
// // Split the sentence into an array of words
// and select those whose first letter is a Consonant.
// var earlyQuery =
//from sentence in _sententences
//let words = sentence.Split(' ')
//               from word in words
//               let w = word.ToLower()
//               where w[0] != 'a' || w[0] != 'e'
//                   || w[0] != 'i' || w[0] != 'o'
//                   || w[0] != 'u'
//               select word;

//            // Execute the query.
//            foreach (var v in earlyQuery)
//            {
//                return v;
//            }
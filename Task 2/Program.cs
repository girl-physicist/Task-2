using System;
using System.Collections.Generic;
using Task_2.Classes;
using Task_2.Reader;
using Task_2.part_2;
using Task_2.Parser;



namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "=============================================================";
            string line2 = String.Empty;
            string fileName = "input.txt";
            IReader r = new Reader.Reader(fileName);
            ISubjectIndex cl = new SubjectIndex();
            IParser<Text> parser = new TextParser();
            IEnumerable<string> listSentences = new List<string>();
            IEnumerable<string> listSentences1 = new List<string>();
            IEnumerable<string> listSentences2 = new List<string>();
            listSentences = r.Read(TypeOfRead.OriginalText);
            listSentences1 = r.Read(TypeOfRead.SpliText);
            listSentences2 = r.Read(TypeOfRead.TextToLower);
            IDictionary<char, string[]> word = cl.GetDictionary(listSentences2, 2);
            var text = parser.Parse(listSentences1);
            // 0 Вывод исходной версии
            Console.WriteLine("=====Original version=====");
            Console.WriteLine(line2);
            Console.WriteLine(parser.Parse(listSentences));
            Console.WriteLine(line);
            Console.WriteLine();
            // 1 Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
            Console.WriteLine("=====1 Output all sentences of the given text in ascending order of the number of words in each of them.=====");
            Console.WriteLine(line2);
            foreach (var item in text.SortSentencesByWordsCount())
            {
                Console.WriteLine("{0},  -- {1} -- words", item, item.GetWordsCount());
            }
            Console.WriteLine(line);
            // 2 Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
            Console.WriteLine("=====2 In all interrogative sentences of the text, find and print without repetition words of a given length.=====");
            Console.WriteLine(line2);
            Console.WriteLine("Enter the length of the word");
            var length = Convert.ToInt32(Console.ReadLine());
            var temp = text.FindWordsOfPredeterminedLenght(length);
            foreach (var i in temp)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(line);
            // 3 Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
            Console.WriteLine("=====3 Delete all words of a given length, starting with a consonant letter from the text.=====");
            Console.WriteLine(line2);
            Console.WriteLine("Enter the length of the word");
            var length2 = Convert.ToInt32(Console.ReadLine());
            text.RemoveWords(length2);
            Console.WriteLine(text);
            Console.WriteLine(line);
            // 4. В некотором предложении текста слова заданной длины заменить указанной подстрокой, 
            // длина которой может не совпадать с длиной слова.
            Console.WriteLine("=====4 In some sentence of the text of a word of a given length, " +
                              "replace the specified substring whose length may not coincide with the length of the word.=====");
            Console.WriteLine(line2);
            Console.WriteLine("Enter the sentence number");
            var sentence = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the length of the word");
            var length3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter replacement substring");
            var change = Convert.ToString(Console.ReadLine());
            text.ReplaceWords(sentence - 1, length3, change);
            Console.WriteLine(line2);
            Console.WriteLine(text);
            Console.WriteLine(line);
            // Часть 2. Предметный указатель
            Console.WriteLine(line2);
            Console.WriteLine("=====Dictionary=====");
            Console.WriteLine(line);
            foreach (var ch in word)
            {
                Console.WriteLine(ch.Key);
                foreach (var item in ch.Value)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey();
        }
    }
}

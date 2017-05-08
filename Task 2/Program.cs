using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Classes;
using Task_2.Classes.Opener_and_Reader;
using Task_2.Parser;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "=============================================================";
            IReader r = new Reader("input.txt");
            List<string> listSentences = new List<string>();
            IParser<Text> parser = new TextParser ();
            listSentences = r.Read();
            var text = parser.Parse(listSentences);

            //0 Вывести исходный вариант

            Console.WriteLine(text);
            Console.WriteLine(line);

            ///1 Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
            foreach (var item in text.SortSentences())
            {
                Console.WriteLine("{0},  -- {1} -- words", item, item.GetWordsCount());
            }
            Console.WriteLine(line);

            ///2 Во всех вопросительных предложениях текста найти и напечатать без повторений слова заданной длины.
            var temp = text.FindWordsOfPredeterminedLenght(text, 5);
            foreach (var i in temp)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(line);

            ///3 Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
            Console.WriteLine("3 Из текста удалить все слова заданной длины (7), начинающиеся на согласную букву.");
            text.RemoveWords(7);
            Console.WriteLine(text);
            Console.WriteLine(line);

            ///4 В некотором предложении текста слова заданной длины заменить указанной подстрокой, 
            ///длина которой может не совпадать с длиной слова.
            Console.WriteLine("4 В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова.");
            text.ReplaceWords(0, 3, "Change");
            Console.WriteLine(text);
            Console.WriteLine(line);

            Console.ReadKey();
        }
    }
}

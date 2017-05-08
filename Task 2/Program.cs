using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Classes;
using Task_2.Creator;
using Task_2.Opener_and_Reader;
using Task_2.Parser;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "=============================================================";
            string line2=String.Empty;
            IReader r = new Reader("input.txt");
            List<string> listSentences = new List<string>();
            IParser<Text> parser = new TextParser();
            listSentences = r.Read();
            var text = parser.Parse(listSentences);

            Console.WriteLine("Original version");
            Console.WriteLine(line2);
            Console.WriteLine(text);
            Console.WriteLine(line);

            Console.WriteLine("1 Output all sentences of the given text in ascending order of the number of words in each of them.");
            Console.WriteLine(line2);
            foreach (var item in text.SortSentences())
            {
                Console.WriteLine("{0},  -- {1} -- words", item, item.GetWordsCount());
            }
            Console.WriteLine(line);

            Console.WriteLine("2 In all interrogative sentences of the text, find and print without repetition words of a given length.");
            Console.WriteLine(line2);
            Console.WriteLine("Enter the length of the word");
            var length = Convert.ToInt32(Console.ReadLine());
            var temp = text.FindWordsOfPredeterminedLenght(text, length);
            foreach (var i in temp)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(line);

            Console.WriteLine("3 Delete all words of a given length, starting with a consonant letter from the text.");
            Console.WriteLine(line2);
            Console.WriteLine("Enter the length of the word");
            var length2 = Convert.ToInt32(Console.ReadLine());
            text.RemoveWords(length2);
            Console.WriteLine(text);
            Console.WriteLine(line);

            Console.WriteLine("4 In some sentence of the text of a word of a given length, replace the specified substring whose length may not coincide with the length of the word.");
            Console.WriteLine(line2);
            Console.WriteLine("Enter the sentence number");
            var sentence = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the length of the word");
            var length3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter replacement substring");
            var change = Convert.ToString(Console.ReadLine());
            text.ReplaceWords(sentence-1, length3, change);
            Console.WriteLine(text);
            Console.WriteLine(line);
            Console.ReadKey();
        }
    }
}

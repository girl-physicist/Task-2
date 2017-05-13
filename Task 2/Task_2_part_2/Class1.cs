using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Task_2.Creator;
using Task_2.Enums;
using Task_2.Opener_and_Reader;
using Task_2.Parser;

namespace Task_2.Task_2_part_2
{
    class Class1
    {
        private string _line = String.Empty;
        public string GetText(string fileName)
        {
            IEnumerable<string> listSentences = new List<string>();
            IReader r = new Reader(fileName);
            listSentences = r.Read(TypeOfRead.TexstToLower);
            var str = listSentences;
            string line1 = _line;
            foreach (var i in str)
            {
                line1 = line1 + i;
            }
            return String.Join(_line, line1);
        }
        public Tuple<string, int, string> Some(int lineNumberOnPage, string fileName)
        {
            string text = GetText(fileName);
            string result = Regex.Replace(text, @"(\s)|(\W)", " ");
            var allCountedWords = result
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select((line, index) => line
                    .Split(' ')
                    .Where(item => !string.IsNullOrEmpty(item))
                    .Select(s => new { Word = s, LineNumber = index }))
                .SelectMany(item => item)
                .OrderBy(item => item.Word)
                .GroupBy(item => item.Word)
                .Select(item =>
                {
                    var group = item.ToList();
                    return new
                    {
                        Word = item.Key,
                        CountEntries = group.Count,
                        Pages = group.Select(values => values.LineNumber / lineNumberOnPage + 1).ToArray()
                    };
                })
                .ToArray();
            string word = null;
            int countEntries = 0;
            string pages = null;
            foreach (var grouping in allCountedWords.GroupBy(item => item.Word[0]))
            {
                Console.WriteLine(char.ToUpper(grouping.Key));
                foreach (var w in grouping)
                {
                    word = w.Word;
                    countEntries = w.CountEntries;
                    pages = string.Join(",", w.Pages.Select(item => item.ToString()));
                    //DELETE!!!!!!!!!!!!!
                    //Console.WriteLine("{0}....Count: {1},Pages: {2}", word
                    //    , countEntries, string.Join(",", pages.Select(item => item.ToString())));
                }
            }
            return Tuple.Create(word, countEntries, pages);
        }
    }
}


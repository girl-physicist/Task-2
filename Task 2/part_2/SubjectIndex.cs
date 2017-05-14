using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_2.Task_2_part_2
{
   public class SubjectIndex:ISubjectIndex
    {
        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set => _fileName = value;
        }
        public SubjectIndex(string fName)
        {
            _fileName = fName;
        }
        private  string GetText()
        {
            return File.ReadAllText(_fileName, Encoding.Default);
        }
        public IDictionary<char, string[]> Some(int lineNumberOnPage)
        {
            string text = GetText();
            var allCountedWords = text
                .Replace("\"", "")
                .Replace("\t", "")
                .Replace("—", "")
                .Replace(".", "")
                .Replace(",", "")
                .Replace("!", "")
                .Replace("?", "")
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select((line, index) => line
                    .ToLower()
                    .Split(' ')
                    .Where(item => !string.IsNullOrEmpty(item))
                    .Select(item => new { Word = item, LineNumber = index }))
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
                        Pages = group
                        .Select(values => values.LineNumber / lineNumberOnPage + 1).ToList()
                    };
                })
                .ToList();
            IDictionary<char, string[]> dictionary = new Dictionary<char, string[]>();
            foreach (var grouping in allCountedWords.GroupBy(item => item.Word[0]))
            {
                var ch = char.ToUpper(grouping.Key);
                string[] result = new string[grouping.Count()];
                int i = 0;
                foreach (var word in grouping)
                {
                    result[i] = $"{word.Word}....Count: {word.CountEntries}" +
                                $",Pages: {string.Join(",", word.Pages.Distinct().Select(item => item.ToString()))}";
                    i += 1;
                }
                dictionary.Add(ch, result);
            }
            return dictionary;
        }
    }
}


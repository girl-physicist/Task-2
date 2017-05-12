using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_2.Opener_and_Reader
{
    public class Reader  : IReader
    {
        private string _fileName;

        public string FileName
        {
            get => _fileName;
            set => _fileName = value;
        }

        private string _line = string.Empty;

        public Reader(string fName)
        {
            _fileName = fName;
        }
        public  IEnumerable<string> Read()
        {
                FileStream stream = new FileStream(_fileName, FileMode.Open);
                StreamReader reader = new StreamReader(stream, Encoding.Default);
                List<string> result = new List<string>();
                string str = _line;
                while (!reader.EndOfStream)
                {
                    str = reader.ReadLine();
                    result.AddRange(_splitText(str, reader.EndOfStream));
                }
                reader.Close();
                return result;
        }
        public IEnumerable<string> Read1()
        {
            FileStream stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            ICollection<string> original = new List<string>();
            string str = _line;
            while (!reader.EndOfStream)
            {
                str = reader.ReadLine();
                original.Add(str);
            }
            reader.Close();
            return original;
        }

        //private readonly Dictionary<string, string> _endOfSentenceСharacters = new Dictionary<string, string>
        //{
        //    ["pointIndex"] = ".",
        //    ["exlamationIndex"] = "!",
        //    ["questionIndex"] = "?",
        //    ["ellipsisIndex"] = "...",
        //    ["interrogatoryExclamationIndex"] = "?!",
        //    ["hardExclamationIndex"] = "!!"
        //};
        private IEnumerable<string> _splitText(string line, bool isLastLine)
        {
            line = string.Join(" ", _line, line);
            List<string> sentences = new List<string>();
            string remained = line;
          
            while (remained.Length > 0)
            {
                int pointIndex = remained.IndexOf('.');
                int exlamationIndex = remained.IndexOf('!');
                int questionIndex = remained.IndexOf('?');
                int ellipsisIndex = remained.IndexOf("...", StringComparison.Ordinal);
                int interrogatoryExclamationIndex = remained.IndexOf("?!", StringComparison.Ordinal);
                int hardExclamationIndex = remained.IndexOf("!!", StringComparison.Ordinal);

                if (pointIndex < 0 && exlamationIndex < 0 && questionIndex < 0 && ellipsisIndex < 0 && interrogatoryExclamationIndex
                    < 0 && hardExclamationIndex < 0 )
                {
                    if (isLastLine)
                    {
                        sentences.Add(remained);
                    }
                    break;
                }
                int endOfSentence = pointIndex < 0 ? remained.Length : pointIndex;
                if (exlamationIndex > -1 && exlamationIndex < endOfSentence)
                    endOfSentence = exlamationIndex;
                if (questionIndex > -1 && questionIndex < endOfSentence)
                    endOfSentence = questionIndex;
                if (ellipsisIndex > -1 && ellipsisIndex < endOfSentence)
                    endOfSentence = ellipsisIndex;
                if (interrogatoryExclamationIndex > -1 && interrogatoryExclamationIndex < endOfSentence)
                    endOfSentence = interrogatoryExclamationIndex;
                if (hardExclamationIndex > -1 && hardExclamationIndex < endOfSentence)
                    endOfSentence = hardExclamationIndex;
                sentences.Add(remained.Substring(0, endOfSentence + 1));
                remained = remained.Substring(endOfSentence + 1);
                _line = remained;
            }
            return sentences;
        }
    }
}


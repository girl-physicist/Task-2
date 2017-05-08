using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_2.Opener_and_Reader
{
    public class Reader : IReader
    {
        private string _fileName;
        public string FileName { get => _fileName; set => _fileName = value; }
        private string _line = string.Empty;
        public Reader(string fName)
        {
            _fileName = fName;
        }
        public List<string> Read()
        {
            FileStream stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            List<string> result = new List<string>();
            string str = _line;
            while (!reader.EndOfStream)
            {
                str = reader.ReadLine();
                result.AddRange(SplitText(str, reader.EndOfStream));
            }
            reader.Close();
            return result;
        }
        private IEnumerable<string> SplitText(string line, bool isLastLine)
        {
            line = string.Join(" ", _line, line);
            int endOfSentence = 1;
            List<string> sentences = new List<string>();
            string remained = line;
            while (remained.Length > 0)
            {
                int pointIndex = remained.IndexOf('.');
                int exlamationIndex = remained.IndexOf('!');
                int questionIndex = remained.IndexOf('?');
                if (pointIndex < 0 && exlamationIndex < 0 && questionIndex < 0)
                {
                    if (isLastLine)
                    {
                        sentences.Add(remained);
                    }
                    break;
                }
                endOfSentence = (pointIndex < 0 ? remained.Length : pointIndex);
                if (exlamationIndex > -1 && exlamationIndex < endOfSentence)
                    endOfSentence = exlamationIndex;
                if (questionIndex > -1 && questionIndex < endOfSentence)
                    endOfSentence = questionIndex;
                sentences.Add(remained.Substring(0, endOfSentence + 1));
                remained = remained.Substring(endOfSentence + 1);
                _line = remained;
            }
            return sentences;
        }
    }
}


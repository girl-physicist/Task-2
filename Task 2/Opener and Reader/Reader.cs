using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2.Opener_and_Reader
{
    public class Reader : IReader
    {
        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set => _fileName = value;
        }
        private string _line = String.Empty;
        public Reader(string fName)
        {
            _fileName = fName;
        }
        public IEnumerable<string> Read(TypeOfRead mode)
        {
            FileStream stream = new FileStream(_fileName, FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            ICollection<string> result = new List<string>();
            ICollection<string> originalText = new List<string>();
            List<string> spliText = new List<string>();
            string str = _line;
            while (!reader.EndOfStream)
            {
                str = reader.ReadLine();
                originalText.Add(str);
                spliText.AddRange(SplitText(str, reader.EndOfStream));
            }
            reader.Close();
            if (mode == TypeOfRead.OriginalText)
            {
                result = originalText;
            }
            if (mode == TypeOfRead.SpliText)
            {
                result = spliText;
            }
            return result;
        }
        private IEnumerable<string> SplitText(string line, bool isLastLine)
        {
            line = String.Join(" ", _line, line);
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
                int endOfSentence = pointIndex < 0 ? remained.Length : pointIndex;
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


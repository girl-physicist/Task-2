using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        //void IReader.ReadAndDisplayFilesAsync()
        //{
        //    ReadAndDisplayFilesAsync(_fileName);
        //}
        //private static async void ReadAndDisplayFilesAsync(string fileName)
        //{
        //    String filename =  fileName;
        //    Char[] buffer;

        //    using (var sr = new StreamReader(filename))
        //    {
        //        buffer = new Char[(int)sr.BaseStream.Length];
        //        await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
        //    }
        //    Console.WriteLine(new String(buffer));
        //}





        

        public  IEnumerable<string> Read()
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
        private IEnumerable<string> SplitText(string line, bool isLastLine)
        {
            line = string.Join(" ", _line, line);
            List<string> sentences = new List<string>();
            string remained = line;
            while (remained.Length > 0)
            {
                // Добавить другие варианты окончания предложения (через Dictionary???)
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


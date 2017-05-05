using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_2.Classes.Opener_and_Reader
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
        private List<string> SplitText(string line, bool isLastLine)
        {
           // реализация
           
        }
    }
}

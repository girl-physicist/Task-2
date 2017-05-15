using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_2_Part_2.Subject_index
{
    public class Word
    {
        public string Value { get;}
        public int WordCount { get; private set; }
        public static int LineNo { get; set; }
        public int LastLineNo { get; private set; }
        public HashSet<int> Lines = new HashSet<int>();

        public Word(string value)
        {
           Value = value;
        }
        public Word()
        {
        }

        public string GetFirstLetter()
        {
            string s = Value;
            var sb = new StringBuilder(s);
            s = sb[0].ToString();
            return s.ToUpper();
        }

        public int GetRepetitionsCount(IEnumerable<string> line)
        {
            String t = line.ToString();
            String w = Value;
            int pos = line.Count();
            int count = 0;
            while (pos >= 0)
            {
                pos = t.IndexOf(w, pos, StringComparison.Ordinal);
                if (pos >= 0)
                {
                    count++;
                    pos += w.Length;
                }
            }
            return pos;
        }




        public void UpdateWordCount()
        {
            WordCount++;
            if (WordCount == 1 || LastLineNo != LineNo)
            {
                Lines.Add(LineNo);
                LastLineNo = LineNo;
            }

        }
        public void AddLine(int iLine)
        {
            Lines.Add(iLine);
            WordCount++;
        }
        public override string ToString()
        {
            return String.Format("{0}............. {1}:  {2}", Value, WordCount, String.Join(" ", Lines));
        }
    }
}

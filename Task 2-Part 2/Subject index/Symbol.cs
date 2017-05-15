using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Part_2.Subject_index
{
    public class Symbol
    {
        public string GetFirstLetter(Word word)
        {
            string s = word.Value;
            var sb = new StringBuilder(s);
            s = sb[0].ToString();
            return s.ToUpper();
        }
    }
}

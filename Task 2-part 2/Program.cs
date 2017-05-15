﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Reader;
using Task_2_Part_2.Parser;
using Task_2_Part_2.Subject_index;

namespace Task_2_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Symbol s=new Symbol();
      //      s.GetFirstLetter();
      Word q=new Word();
        
            IReader newReader = new Reader("input.txt");
            Tree<Word> tree = new Tree<Word>();
            IEnumerable<string> lines = new List<string>();
            lines = newReader.Read(TypeOfRead.TextToLower);
            IParser parser = new Parser.Parser();
            var words = parser.Parse(lines);

            q.GetRepetitionsCount(lines);

            foreach (var w in words.Values)
            {
                tree.Add(w);
            }

            Console.WriteLine(string.Join("\n", tree.Inorder()));
            Console.ReadKey();




           
           
            
        }
    }
}

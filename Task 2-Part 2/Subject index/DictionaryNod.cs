using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Part_2.Subject_index
{
   public class DictionaryNode<TValue>
   {
       public TValue Value { get; set; }
       public DictionaryNode<TValue> Left { get; set; }
       public DictionaryNode<TValue> Right { get; set; }

       public DictionaryNode(TValue value)
       {
           Value = value;
       }
    }
}

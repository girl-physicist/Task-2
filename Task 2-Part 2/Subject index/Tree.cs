using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Part_2.Subject_index
{
   public class Tree<T>
   {
       private DictionaryNode<T> _root;
//сравниваем текущий и следующий
        public int Compare(object x, object y)
       {
           Word wordX;
           Word wordY;
           if (x is Word)
           {
               wordX = (Word)x;
           }
           else { return 0; }
           if (y is Word)
           {
               wordY = (Word)y;
           }
           else { return 0; }
           return String.CompareOrdinal(wordX.Value, wordY.Value);
            // <0, wordX.Value< wordY.Value
            // >0, wordX.Value> wordY.Value
            // =0, wordX.Value= wordY.Value
       }

       //public void AddRow(IEnumerable<T> collection)
       //{
       //    foreach (var value in collection)
       //        Add(value);
       //}

       public int Count { get; protected set; }
       public void Add(T item)
       {
           var node = new DictionaryNode<T>(item);

           if (_root == null)
               _root = node;
           else
           {
               DictionaryNode<T> current = _root, parent = null;

               while (current != null)
               {
                   parent = current;
                   if (Compare(item, current.Value) < 0)
                       current = current.Left;
                   else
                       current = current.Right;
               }

               if (parent != null && Compare(item, parent.Value) < 0)
                   parent.Left = node;
               else if (parent != null) parent.Right = node;
           }
           ++Count;
       }

       public void Clear()
       {
           _root = null;
           Count = 0;
       }

       public bool Contains(T item)
       {
           var current = _root;
           while (current != null)
           {
               var result = Compare(item, current.Value);
               if (result == 0)
                   return true;
               if (result < 0)
                   current = current.Left;
               else
                   current = current.Right;
           }
           return false;
       }

       public DictionaryNode<T> FindItem(T item)
       {
           var current = _root;
           while (current != null)
           {
               var result = Compare(item, current.Value);
               if (result == 0)
               {
                   Console.WriteLine("Seeking element: {0}", current.Value);
                   return current;
               }
               if (result < 0) { current = current.Left; }
               else { current = current.Right; }
           }
           return null;
       }

       public IEnumerable<T> Inorder()
       {
           if (_root == null)
               yield break;

           var stack = new Stack<DictionaryNode<T>>();
           var node = _root;

           while (stack.Count > 0 || node != null)
           {
               if (node == null)
               {
                   node = stack.Pop();
                   yield return node.Value;
                   node = node.Right;
               }
               else
               {
                   stack.Push(node);
                   node = node.Left;
               }
           }
       }

       public IEnumerator<T> GetEnumerator()
       {
           return Inorder().GetEnumerator();
       }
    }
}

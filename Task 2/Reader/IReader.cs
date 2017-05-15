using System.Collections.Generic;

namespace Task_2.Reader
{
   public interface IReader
   {
       IEnumerable<string> Read(TypeOfRead mode);
   }
}

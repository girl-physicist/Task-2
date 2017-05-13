using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_2.Opener_and_Reader
{
   public interface IReader
   {
       IEnumerable<string> Read(TypeOfRead mode);
   }
}

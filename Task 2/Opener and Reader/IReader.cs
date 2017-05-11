using System.Collections.Generic;

namespace Task_2.Opener_and_Reader
{
   public interface IReader
   {

       IEnumerable<string> Read();
       IEnumerable<string> Read1();
        //void ReadAndDisplayFilesAsync();
    }
}

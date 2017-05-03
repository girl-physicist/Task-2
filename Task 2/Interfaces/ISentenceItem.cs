using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Enums;

namespace Task_2.Interfaces
{
  public  interface ISentenceItem
    {
        string Value { get; set; }
        SentenceItemType SentenceItemType { get; }
    }
}

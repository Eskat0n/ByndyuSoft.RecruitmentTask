using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc
{
    public interface IOperationProvider
    {
        bool IsOperation(string operation);

        int ComparePriority(string o1, string o2);

        IOperation GetOperation(string operation);
    }
}

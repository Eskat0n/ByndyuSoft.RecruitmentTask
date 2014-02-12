using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc
{
    public interface IOperation
    {
        int Execute(int x, int y);
        int Priority { get; }
    }
}

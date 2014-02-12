using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc
{
    public interface IPostfixConverter
    {
        string Convert(string infix);
    }
}

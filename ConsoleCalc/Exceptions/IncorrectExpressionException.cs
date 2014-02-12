using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc.Exceptions
{
    public class IncorrectExpressionException : Exception
    {
        public IncorrectExpressionException(Exception exception)
            : base(@"Неверный формат входного выражения", exception)
        {
        }
    }
}

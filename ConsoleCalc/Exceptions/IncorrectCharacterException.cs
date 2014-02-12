using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc.Exceptions
{
    public class IncorrectCharacterException : Exception
    {
        public IncorrectCharacterException(string message, Exception innerException)
            : base(@"Во входном выражении содержится недопустимый символ: " + message, innerException)
        {
        }
    }
}

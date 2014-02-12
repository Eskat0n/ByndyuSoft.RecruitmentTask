using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalc.Exceptions;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator.Register<IOperationProvider>(typeof(BasicOperationProvider));
            ServiceLocator.Register<IPostfixConverter>(typeof(PostfixConverterSortStation));
            ServiceLocator.Register<IPostfixExecutor>(typeof(PostfixExecutor));

            try
            {
                Calculator calculator = new Calculator();


                int result = calculator.Calculate(args[0]);

                Console.WriteLine(@"Ответ: {0}", result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine(@"Произошло деление на ноль");
            }
            catch (IncorrectCharacterException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IncorrectExpressionException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}

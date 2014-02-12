using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleCalc.Exceptions;

namespace ConsoleCalc
{
    public class PostfixConverterSortStation : IPostfixConverter
    {
        private readonly IOperationProvider _operationProvider;

        public PostfixConverterSortStation()
            : this(ServiceLocator.Resolve<IOperationProvider>())
        {
        }

        public PostfixConverterSortStation(IOperationProvider operationProvider)
        {
            _operationProvider = operationProvider;
        }

        #region IPostfixConverter Members

        public string Convert(string infix)
        {
            string postfix = String.Empty;
            Stack<string> operators = new Stack<string>();

            foreach (var c in infix.Split(' '))
            {
                if (_operationProvider.IsOperation(c))
                {
                    try
                    {
                        while ((operators.Count != 0) &&
                            (_operationProvider.ComparePriority(c, operators.Peek()) < 0))
                        {
                            postfix += operators.Pop() + ' ';
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new IncorrectExpressionException(ex);
                    }

                    operators.Push(c); 
                }
                else 
                {
                    try
                    {
                        int.Parse(c);
                    }
                    catch (Exception ex)
                    {
                        throw new IncorrectCharacterException(c, ex);
                    }

                    postfix += c + ' ';
                }
            }

            try
            {
                while (operators.Count != 0)
                {
                    postfix += operators.Pop() + ' ';
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new IncorrectExpressionException(ex);
            }

            return postfix.TrimEnd();
        }

        #endregion
    }
}

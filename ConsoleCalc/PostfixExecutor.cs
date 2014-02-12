using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalc.Exceptions;

namespace ConsoleCalc
{
    public class PostfixExecutor : IPostfixExecutor
    {        
        private Stack<int> _resultStack = new Stack<int>();
        private IOperationProvider _provider;

        public PostfixExecutor()
            : this(ServiceLocator.Resolve<IOperationProvider>())
        {
        }

        public PostfixExecutor(IOperationProvider provider)
        {
            _provider = provider;
        }

        #region IPostfixExecutor Members

        public int Execute(string postfix)
        {
            foreach (var c in postfix.Split(' '))
            {
                if (_provider.IsOperation(c))
                {
                    try
                    {
                        int y = _resultStack.Pop();
                        int x = _resultStack.Pop();

                        _resultStack.Push(_provider.GetOperation(c).Execute(x, y));
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new IncorrectExpressionException(ex);
                    }
                }
                else
                {
                    try
                    {
                        _resultStack.Push(int.Parse(c));
                    }
                    catch (Exception ex)
                    {
                        throw new IncorrectCharacterException(c, ex);
                    }
                }
            }

            try
            {
                return _resultStack.Peek();
            }
            catch (InvalidOperationException ex)
            {
                throw new IncorrectExpressionException(ex);
            }
        }

        #endregion
    }
}

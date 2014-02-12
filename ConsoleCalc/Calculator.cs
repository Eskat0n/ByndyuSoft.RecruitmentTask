using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc
{
    public class Calculator : ICalculator
    {
        private IPostfixConverter _converter;
        private IPostfixExecutor _executor;

        public Calculator()
            : this(ServiceLocator.Resolve<IPostfixConverter>(), ServiceLocator.Resolve<IPostfixExecutor>())
        {
        }

        public Calculator(IPostfixConverter converter, IPostfixExecutor executor)
        {
            _converter = converter;
            _executor = executor;
        }

        #region ICalculator Members

        public int Calculate(string input)
        {
            string postfix = _converter.Convert(input);

            return _executor.Execute(postfix);
        }

        #endregion
    }
}

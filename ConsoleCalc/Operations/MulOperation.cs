using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc
{
    public class MulOperation : IOperation
    {
        #region IOperation Members

        public int Execute(int x, int y)
        {
            return x * y;
        }

        public int Priority
        {
            get { return 2; }
        }

        #endregion
    }
}

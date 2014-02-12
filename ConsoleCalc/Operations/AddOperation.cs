using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc.Operations
{
    public class AddOperation : IOperation
    {
        #region IOperation Members

        public int Execute(int x, int y)
        {
            return x + y;
        }

        public int Priority
        {
            get { return 1; }
        }

        #endregion
    }
}

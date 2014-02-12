using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalc.Operations;

namespace ConsoleCalc
{
    public class BasicOperationProvider : IOperationProvider
    {
        private Dictionary<string, IOperation> _operations;

        public BasicOperationProvider()
        {
            _operations = new Dictionary<string, IOperation>();
            
            _operations[@"+"] = new AddOperation();
            _operations[@"-"] = new SubOperation();
            _operations[@"*"] = new MulOperation();
            _operations[@"/"] = new DivOperation();
        }

        #region IOperationProvider Members

        public bool IsOperation(string operation)
        {
            return _operations.Keys.Contains(operation);
        }

        public int ComparePriority(string o1, string o2)
        {
            return _operations[o1].Priority - _operations[o2].Priority;
        }

        public IOperation GetOperation(string operation)
        {
            return _operations[operation];
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ConsoleCalc.Operations;

namespace Tests
{
    public class AddOperationTests
    {
        [Fact]
        public void CorrectAddition()
        {
            var operation = new AddOperation();

            var result = operation.Execute(5, 3);

            Assert.Equal(8, result);
        }

        [Fact]
        public void CorrectPriority()
        {
            var operation = new AddOperation();

            Assert.Equal(1, operation.Priority);
        }
    }
}

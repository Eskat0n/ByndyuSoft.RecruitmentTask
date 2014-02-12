using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ConsoleCalc.Operations;

namespace Tests
{
    public class DivOperationTests
    {
        [Fact]
        public void CorrectDisivion()
        {
            var operation = new DivOperation();
            var result = operation.Execute(9, 3);

            Assert.Equal(3, result);
        }

        [Fact]
        public void CorrectPriority()
        {
            var operation = new DivOperation();

            Assert.Equal(2, operation.Priority);
        }

        [Fact]
        public void DivisionByZeroExceptionThrow()
        {
            var operation = new DivOperation();

            Assert.Throws(typeof(DivideByZeroException), () =>
                {
                    operation.Execute(13, 0);
                });
        }
    }
}

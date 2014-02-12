using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ConsoleCalc.Operations;

namespace Tests
{
    public class SubOperationTests
    {
        [Fact]
        public void CorrectSubtraction()
        {
            var operation = new SubOperation();

            var result = operation.Execute(10, 2);

            Assert.Equal(8, result);
        }

        [Fact]
        public void CorrectPriority()
        {
            var operation = new SubOperation();

            Assert.Equal(1, operation.Priority);
        }
    }
}

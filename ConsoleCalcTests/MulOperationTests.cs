using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ConsoleCalc;

namespace Tests
{
    public class MulOperationTests
    {
        [Fact]
        public void CorrectMultiplication()
        {
            var operation = new MulOperation();

            var result = operation.Execute(4, 9);

            Assert.Equal(36, result);
        }

        [Fact]
        public void CorrectPriority()
        {
            var operation = new MulOperation();

            Assert.Equal(2, operation.Priority);
        }
    }
}

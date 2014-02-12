using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Moq;
using ConsoleCalc;
using ConsoleCalc.Operations;

namespace Tests
{
    public class ExecutorTests
    {
        [Fact]
        public void TwoNumbersAdditionCorrectResult()
        {
            var postfix = @"2 2 +";

            var provider = new Mock<IOperationProvider>();
            provider.Setup(m => m.IsOperation(@"+")).Returns(true);
            provider.Setup(m => m.GetOperation(@"+")).Returns(new AddOperation());

            var executor = new PostfixExecutor(provider.Object);

            var result = executor.Execute(postfix);

            Assert.Equal(4, result);
        }

        [Fact]
        public void AdditionAndSubtractionCorrectResult()
        {
            var postfix = @"2 2 1 - +";

            var provider = new Mock<IOperationProvider>();
            provider.Setup(m => m.IsOperation(@"+")).Returns(true);
            provider.Setup(m => m.IsOperation(@"-")).Returns(true);
            provider.Setup(m => m.GetOperation(@"+")).Returns(new AddOperation());
            provider.Setup(m => m.GetOperation(@"-")).Returns(new SubOperation());

            var executor = new PostfixExecutor(provider.Object);

            var result = executor.Execute(postfix);

            Assert.Equal(3, result);
        }

        [Fact]
        public void ComplexExpressionCorrectResult()
        {
            var postfix = @"4 6 2 / +";

            var provider = new Mock<IOperationProvider>();
            provider.Setup(m => m.IsOperation(@"/")).Returns(true);
            provider.Setup(m => m.IsOperation(@"+")).Returns(true);
            provider.Setup(m => m.GetOperation(@"/")).Returns(new DivOperation());
            provider.Setup(m => m.GetOperation(@"+")).Returns(new AddOperation());

            var executor = new PostfixExecutor(provider.Object);

            var result = executor.Execute(postfix);

            Assert.Equal(7, result);
        }
    }
}

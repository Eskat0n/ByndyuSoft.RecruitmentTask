using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Moq;
using ConsoleCalc;
using ConsoleCalc.Exceptions;

namespace Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void TwoNumbersAdditionCorrectCalculation()
        {           
            var operationProvider = new Mock<IOperationProvider>();
            operationProvider.Setup(m => m.IsOperation(@"+")).Returns(true);

            var converter = new PostfixConverterSortStation(operationProvider.Object);

            var executor = new Mock<IPostfixExecutor>();
            executor.Setup(m => m.Execute(@"2 2 +")).Returns(4);

            var input = @"2 + 2";

            var calculator = new Calculator(converter, executor.Object);
            var result = calculator.Calculate(input);

            Assert.Equal(4, result);
        }

        [Fact]
        public void ComplexExpressionCorrectCalculation()
        {
            var operationProvider = new BasicOperationProvider();

            var converter = new PostfixConverterSortStation(operationProvider);
            var executor = new PostfixExecutor(operationProvider);

            var input = @"4 * 5 - 27 / 3";

            var calculator = new Calculator(converter, executor);
            var result = calculator.Calculate(input);

            Assert.Equal(11, result);
        }


        [Fact]
        public void MissingOperandExpressionExceptionThrow()
        {
            var operationProvider = new BasicOperationProvider();

            var converter = new PostfixConverterSortStation(operationProvider);
            var executor = new PostfixExecutor(operationProvider);

            var input = @"2 + + 7";

            var calculator = new Calculator(converter, executor);

            Assert.Throws(typeof(IncorrectExpressionException), () =>
            {
                calculator.Calculate(input);
            });
        }

        [Fact]
        public void DivisionByZeroExceptionThrow()
        {
            var operationProvider = new BasicOperationProvider();

            var converter = new PostfixConverterSortStation(operationProvider);
            var executor = new PostfixExecutor(operationProvider);

            var input = @"13 / 0";

            var calculator = new Calculator(converter, executor);

            Assert.Throws(typeof(DivideByZeroException), () =>
            {
                calculator.Calculate(input);
            });
        }
    }
}

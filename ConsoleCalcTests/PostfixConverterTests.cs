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
    public class PostfixConverterTests
    {
        [Fact]
        public void TwoNumbersAddtionCorrectCharCount()
        {
            var operationProvider = new Mock<IOperationProvider>();

            operationProvider.Setup(m => m.IsOperation(@"+")).Returns(true);

            var infix = @"2 + 2";

            var postfixConverter = new PostfixConverterSortStation(operationProvider.Object);
            var postfix = postfixConverter.Convert(infix);

            Assert.Equal(5, postfix.Length);
        }

        [Fact]
        public void TwoNumbersAdditionCorrectPostfixString()
        {
            var operationProvider = new Mock<IOperationProvider>();

            operationProvider.Setup(m => m.IsOperation(@"+")).Returns(true);

            var infix = @"2 + 2";

            var postfixConverter = new PostfixConverterSortStation(operationProvider.Object);
            var postfix = postfixConverter.Convert(infix);

            Assert.Equal(@"2 2 +", postfix);
        }

        [Fact]
        public void AdditionAndSubtractionCorrectPostfixString()
        {
            var operationProvider = new Mock<IOperationProvider>();

            operationProvider.Setup(m => m.IsOperation(@"+")).Returns(true);
            operationProvider.Setup(m => m.IsOperation(@"-")).Returns(true);
            operationProvider.Setup(m => m.ComparePriority(@"-", @"+")).Returns(0);

            var infix = @"2 + 2 - 1";

            var postfixConverter = new PostfixConverterSortStation(operationProvider.Object);
            var postfix = postfixConverter.Convert(infix);

            Assert.Equal(@"2 2 1 - +", postfix);
        }

        [Fact]
        public void TwoPriorityLevelOperationsCorrectPostfixString()
        {
            var operationProvider = new Mock<IOperationProvider>();

            operationProvider.Setup(m => m.IsOperation(@"-")).Returns(true);
            operationProvider.Setup(m => m.IsOperation(@"*")).Returns(true);
            operationProvider.Setup(m => m.ComparePriority(@"-", @"*")).Returns(-1);

            var infix = @"6 * 1 - 2";

            var postfixConverter = new PostfixConverterSortStation(operationProvider.Object);
            var postfix = postfixConverter.Convert(infix);

            Assert.Equal(@"6 1 * 2 -", postfix);
        }

        [Fact]
        public void DivisionOperationCorrectPostfixString()
        {
            var operationProvider = new Mock<IOperationProvider>();

            operationProvider.Setup(m => m.IsOperation(@"+")).Returns(true);
            operationProvider.Setup(m => m.IsOperation(@"/")).Returns(true);
            operationProvider.Setup(m => m.ComparePriority(@"/", @"+")).Returns(1);

            var infix = @"4 + 6 / 2";

            var postfixConverter = new PostfixConverterSortStation(operationProvider.Object);
            var postfix = postfixConverter.Convert(infix);

            Assert.Equal(@"4 6 2 / +", postfix);
        }

        [Fact]
        public void ComplexExpressionCorrectPostfixString()
        {
            var operationProvider = new BasicOperationProvider();

            var infix = @"3 * 10 - 26 / 13";

            var postfixConverter = new PostfixConverterSortStation(operationProvider);
            var postfix = postfixConverter.Convert(infix);

            Assert.Equal(@"3 10 * 26 13 / -", postfix);
        }

        [Fact]
        public void IncorrectCharactersInInputStringExceptionThrow()
        {
            var operationProvider = new BasicOperationProvider();

            var infix = @"2asb + 7";

            var postfixConverter = new PostfixConverterSortStation(operationProvider);

            Assert.Throws(typeof(IncorrectCharacterException), () =>
            {
                postfixConverter.Convert(infix);
            });
        }
    }
}

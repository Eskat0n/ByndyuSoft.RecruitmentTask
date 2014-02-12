using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ConsoleCalc;

namespace Tests
{
    public class BasicOperationProviderTests
    {
        [Fact]
        public void AddOperationRecognition()
        {
            var operation = @"+";

            var provider = new BasicOperationProvider();

            Assert.True(provider.IsOperation(operation));
        }

        [Fact]
        public void IncorrectOperationNoRecognition()
        {
            var incorrectOperation = @"#";

            var provider = new BasicOperationProvider();

            Assert.False(provider.IsOperation(incorrectOperation));
        }

        [Fact]
        public void AddAndSubCorrectComparsion()
        {
            var add = @"+";
            var sub = @"-";

            var provider = new BasicOperationProvider();

            Assert.True(provider.ComparePriority(add, sub) == 0);
        }

        [Fact]
        public void AddAndMulCorrectComparsion()
        {
            var add = @"+";
            var mul = @"*";

            var provider = new BasicOperationProvider();

            Assert.True(provider.ComparePriority(add, mul) < 0);
        }

        [Fact]
        public void DivAndSibCorrectComparsion()
        {
            var div = @"/";
            var sub = @"-";

            var provider = new BasicOperationProvider();

            Assert.True(provider.ComparePriority(div, sub) > 0);
        }
    }
}

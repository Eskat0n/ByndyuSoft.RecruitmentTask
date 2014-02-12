using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using ConsoleCalc;

namespace Tests
{
    public class ServiceLocatorTests
    {
        [Fact]
        public void ResolvingExistingServiceCorrect()
        {
            ServiceLocator.Register<IOperationProvider>(typeof(BasicOperationProvider));

            var provider = ServiceLocator.Resolve<IOperationProvider>();

            Assert.True(provider is BasicOperationProvider);
        }

        [Fact]
        public void ResolvingNonExistingServiceExceptionThrow()
        {
            Assert.Throws(typeof(KeyNotFoundException), () =>
            {
                ServiceLocator.Resolve<IOperation>();
            });
        }
    }
}

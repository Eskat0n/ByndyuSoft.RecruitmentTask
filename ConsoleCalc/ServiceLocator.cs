using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalc
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, Type> _services = new Dictionary<Type, Type>();

        public static void Register<T>(Type service)
        {
            _services[typeof(T)] = service;
        }

        public static T Resolve<T>()
        {
            return (T)Activator.CreateInstance(_services[typeof(T)]);
        }
    }
}

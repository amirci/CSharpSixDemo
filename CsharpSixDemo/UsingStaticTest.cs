using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace CsharpSixDemo
{
    public static class DSL
    {
        public static void Given(Action setup)
        {
            LogMessage("Given", setup.Method.Name);
            setup();
        }

        public static void When(Action doIt)
        {
            LogMessage("When", doIt.Method.Name);
            doIt();
        }

        public static void Then<T>(Func<T> postCondition, T expected)
        {
            LogMessage("Then", postCondition.Method.Name);
            Assert.That(postCondition(), Is.EqualTo(expected));
        }

        private static void LogMessage(string prefix, string methodName)
        {
            var action = Regex.Replace(methodName, "(\\B[A-Z])", " $1");
            var message = $"{prefix} {action}";
            Console.Out.WriteLine(message);
        }
    }

    namespace UsingStatic
    {
        using static DSL;

        public class UsingTheDsl 
        {
            [Test]
            public void Uses_the_static_methods_without_qualification()
            {
                Given(RemoveAllProducts);
                When(ListingAllProducts);
                Then(TheProductListIsEmpty, new int[] {});
            }

            private void RemoveAllProducts()
            {
                // empty body
            }

            private IEnumerable<int> TheProductListIsEmpty()
            {
                return Enumerable.Empty<int>();
            }

            private void ListingAllProducts()
            {
                // empty body
            }
        }

    }

}

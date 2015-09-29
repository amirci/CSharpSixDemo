using System;
using NUnit.Framework;

namespace CsharpSixDemo
{
    namespace ExpressionBodiesOnMethods
    {
        public class Wizard
        {
            public string First { get; } = "Harry";

            public string Last { get; } = "Potter";

            public string FullName() => First + " " + Last;

            public void Print() => Console.WriteLine(First + " " + Last);
        }


        public class FullNameMethod : IAmLazyTest<Wizard>
        {
            [Test]
            public void Combines_first_and_last()
            {
                Assert.That(_sut.FullName(), Is.EqualTo("Harry Potter"));
            }
        }

    }

}

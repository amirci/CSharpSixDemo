using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace CsharpSixDemo
{
    namespace IndexInitializer
    {
        public class Wizard
        {
            public Wizard() { }

            public Wizard(string first, string last)
            {
                this.First = first;
                this.Last = last;
            }

            public string First { get; } = "Harry";

            public string Last { get; } = "Potter";

        }

        public class Test
        {
            private readonly IDictionary<string, Wizard> _sut = 
                new Dictionary<string, Wizard>
            {
                ["Harry"] = new Wizard(),
                ["Hermione"] = new Wizard("Hermione", "Granger"),
            };


            [Test]
            public void The_keys_have_associated_values()
            {
                Assert.That(_sut["Harry"].First, Is.EqualTo("Harry"));
                Assert.That(_sut["Hermione"].First, Is.EqualTo("Hermione"));
            }
        }
    }
}

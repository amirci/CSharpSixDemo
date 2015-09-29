using System;
using NUnit.Framework;

namespace CsharpSixDemo
{
    namespace StringInterpolation
    {
        public class Wizard
        {
            public string First { get; } = "Harry";

            public string Last { get; } = "Potter";

        }

        public class Test: IAmLazyTest<Wizard>
        {
            [Test]
            public void Is_the_same_as_string_format()
            {
                var actual = $"The name is {_sut.First} {_sut.Last}";
                var expected = String.Format("The name is {0} {1}", _sut.First, _sut.Last);
                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void Format_modifiers_can_be_used_as_well()
            {
                var age = 13;
                var actual = $"Name: {_sut.First, 10} / Age: {age:C2}";
                var expected = String.Format("Name: {0, 10} / Age: {1:C2}", _sut.First, age);
                Assert.That(actual, Is.EqualTo(expected));
            }

            [Test]
            public void Any_expression_can_be_used()
            {
                var age = 13;
                var actual = $"{_sut.First} is {(age >= 11 ? "an adult" : "a child")}";
                Assert.That(actual, Is.EqualTo("Harry is an adult"));
            }
        }

    }

}

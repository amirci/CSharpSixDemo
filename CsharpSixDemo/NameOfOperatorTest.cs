using System;
using NUnit.Framework;

namespace CsharpSixDemo
{
    namespace NameOfOperator
    {
        public class Wizard
        {
            public string First { get; } = "Harry";

            public string Last { get; } = "Potter";

        }

        public class Test: IAmLazyTest<Wizard>
        {
            [Test]
            public void Gives_you_the_name_of_the_expression()
            {
                int? productPrice = null;

                var throwIt = new TestDelegate(() =>
                {
                   throw new Exception($"{nameof(productPrice)} is null!");
                });

                Assert.That(
                    throwIt,
                    Throws
                        .TypeOf<Exception>()
                        .With.Message.EqualTo("productPrice is null!"));
            }

            [Test]
            public void Can_be_used_with_chain_of_properties()
            {
                var actual = $"{nameof(_sut.First)}Name is {_sut.First}";
                var expected = "FirstName is Harry";
                Assert.That(actual, Is.EqualTo(expected));
            }

        }
    }
}

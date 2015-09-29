using System;
using NUnit.Framework;

namespace CsharpSixDemo
{
    namespace ExpressionBodiesOnProperties
    {
        public class Wizard
        {
            public string First { get; } = "Harry";

            public string Last { get; } = "Potter";

            public string FullName => First + " " + Last;

            public string this[string spell] => "Expelliarmus!";
        }


        public class FullNameProperty : IAmLazyTest<Wizard>
        {
            [Test]
            public void Combines_first_and_last()
            {
                Assert.That(_sut.FullName, Is.EqualTo("Harry Potter"));
            }
        }

        public class SpellIndex : IAmLazyTest<Wizard>
        {
            [Test]
            public void Harry_signature_spell_is_expelliarmus()
            {
                Assert.That(_sut["Destroy"], Is.EqualTo("Expelliarmus!"));
                Assert.That(_sut["Float"]  , Is.EqualTo("Expelliarmus!"));
            }
        }
    }

}

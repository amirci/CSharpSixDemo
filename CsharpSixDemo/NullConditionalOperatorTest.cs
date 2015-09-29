using NUnit.Framework;

namespace CsharpSixDemo
{
    namespace NullConditionalOperator
    {
        public class Wizard
        {
            public string First { get; set; } = "Harry";

            public string Last { get; } = "Potter";

            public void Expelliarmus() { }
        }

        public class WhenReferenceIsNull
        {
            private Wizard _wizard;

            [SetUp]
            public void BeforeEachTest() => _wizard = null;

            [Test]
            public void Calling_a_property_returns_null()
            {
                Assert.That(_wizard?.First, Is.Null);
            }

            [Test]
            public void Using_an_index_returns_null()
            {
                var wizards = CreateWizards();
                Assert.That(wizards?[3], Is.Null);
            }


            [Test]
            public void Using_coalescing_returns_the_other_value()
            {
                Assert.That(_wizard?.Last ?? "Ron", Is.EqualTo("Ron"));
            }

            [Test]
            public void Methods_are_not_invoked()
            {
                Assert.DoesNotThrow(() => _wizard?.Expelliarmus());
            }

            [Test]
            public void Chain_of_properties_will_be_guarded()
            {
                _wizard = new Wizard() {First = null};

                Assert.That(_wizard, Is.Not.Null);
                Assert.That(_wizard?.First?.Length, Is.Null);
            }

            private Wizard[] CreateWizards()
            {
                return null;
            }

        }

    }

}

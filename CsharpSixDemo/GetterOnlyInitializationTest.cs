using NUnit.Framework;

namespace CsharpSixDemo
{
    namespace GetterOnlyInitialization
    {
        public class Wizard
        {
            public string First { get; } = "Harry";

            public string Last { get; } = "Potter";

            public Wizard() { }

            public Wizard(string first, string last)
            {
                First = first;
                Last = last;
            }

            public void WontCompile(string first, string last)
            {
                //First = first;
                //Last = last;
            }
        }

        public class DefaultConstructor: IAmLazyTest<Wizard>
        {
            [Test]
            public void Sets_default_first_name_to_Harry()
            {
                Assert.That(_sut.First, Is.EqualTo("Harry"));
            }

            [Test]
            public void Sets_default_last_name_to_Potter()
            {
                Assert.That(_sut.Last, Is.EqualTo("Potter"));
            }
        }

        public class NonDefaultConstructor : IAmLazyTest<Wizard>
        {
            [SetUp]
            public new void BeforeEachTest()
            {
                _sut = new Wizard("Hermione", "Granger");
            }

            [Test]
            public void Initializes_first_name_to_Hermione()
            {
                Assert.That(_sut.First, Is.EqualTo("Hermione"));
            }

            [Test]
            public void Initializes_last_name_to_Granger()
            {
                Assert.That(_sut.Last, Is.EqualTo("Granger"));
            }
        }

        public class PropertiesAreReadonly : IAmLazyTest<Wizard>
        {
            [Test, Ignore("Uncomment to check it doesn't compile")]
            public void It_does_not_compile_assignment()
            {
                //_sut.WontCompile();
            }
        }

    }

}

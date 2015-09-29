using NUnit.Framework;

namespace CsharpSixDemo
{
    public class IAmLazyTest<T> where T: new()
    {
        protected T _sut;

        [SetUp]
        public void BeforeEachTest()
        {
            _sut = new T();
        }


    }
    namespace AutoPropertiesInitialization
    {
        public class Wizard
        {
            public string First { get; set; } = "Harry";

            public string Last { get; set; } = "Potter";

            public Wizard() { }

            public Wizard(string first, string last)
            {
                First = first;
                Last = last;
            }

            public void ChangeTo(string first, string last)
            {
                First = first;
                Last = last;
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
            public void Sets_first_name_to_Hermione()
            {
                Assert.That(_sut.First, Is.EqualTo("Hermione"));
            }

            [Test]
            public void Sets_last_name_to_Granger()
            {
                Assert.That(_sut.Last, Is.EqualTo("Granger"));
            }
        }

        public class ChangingTheName : IAmLazyTest<Wizard>
        {
            [Test]
            public void Changes_both_first_and_last()
            {
                _sut.ChangeTo("Hermione", "Granger");

                Assert.That(_sut.First, Is.EqualTo("Hermione"));
                Assert.That(_sut.Last, Is.EqualTo("Granger"));
            }
        }
    }
}

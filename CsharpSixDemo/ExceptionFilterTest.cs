using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using static System.Console;

namespace CsharpSixDemo
{
    namespace ExceptionFilters
    {
        public enum Spells
        {
            Expelliarmus,
            Lumos,
            WingardiumLeviosa,
            ExpectoPatronum
        }

        public class Wizard
        {
            public string First { get; } = "Harry";

            public string Last { get; } = "Potter";

            public string Cast(Spells spell)
            {
                var spellsIKnow = new[] {Spells.Expelliarmus, Spells.Lumos};

                if (!spellsIKnow.Contains(spell))
                {
                    throw new SpellNotKnownException(IFailed);
                }

                return IKnowIt;
            }

            public const string IFailed = "Wait... what?";
            public const string IKnowIt = "I'm a Wizard!";
        }

        public class SpellNotKnownException : Exception
        {
            public SpellNotKnownException(string message) : base(message)
            {
            }
        }

        public class Test: IAmLazyTest<Wizard>
        {
            [TestCase(Spells.Lumos)]
            [TestCase(Spells.Expelliarmus)]
            [TestCase(Spells.ExpectoPatronum)]
            public void Exception_does_not_throw(Spells spell)
            {
                Assert.That(() => Cast(spell), Throws.Nothing);
            }

            [TestCase(Spells.WingardiumLeviosa)]
            public void Exception_throws_because_does_not_know_basic_spell(Spells spell)
            {
                Assert.That(() => Cast(spell), Throws.TypeOf<SpellNotKnownException>());
            }

            private void Cast(Spells spell)
            {
                try
                {
                    _sut.Cast(spell);
                }
                catch (SpellNotKnownException) when (IsBasic(spell))
                {
                    WriteLine($"C'mon! I should know {spell}");
                    throw;
                }
                catch (SpellNotKnownException) when (!IsBasic(spell))
                {
                    WriteLine($"Phew! {spell} is really advanced");
                }
            }

            private bool IsBasic(Spells spell)
            {
                return spell != Spells.ExpectoPatronum;
            }
        }

    }

}

namespace CsharpSixDemo.ExceptionFilters
{
}

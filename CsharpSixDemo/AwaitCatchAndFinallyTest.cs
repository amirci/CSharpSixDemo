using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using static System.Console;

namespace CsharpSixDemo
{
    namespace AwaitCatchAndFinally
    {
        public class Wizard
        {
            public string First { get; } = "Harry";

            public string Last { get; } = "Potter";
        }

        public class MoM
        {
            public async static Task<Wizard> ApparateAsync()
            {
                using (var reader = new StreamReader("Wizards.txt"))
                {
                    var wizards = await reader.ReadToEndAsync();

                    return new Wizard();
                }
            }
        }

        public class Test
        {
            [Test]
            public void Calls_the_async_for_catch_and_finally()
            {
                var apparition = ApparateAsync();

                apparition.Wait();

                Assert.That(apparition.Result, Is.Not.Null);
            }

            private async Task<Wizard> ApparateAsync()
            {
                Wizard wizard = null;

                try
                {
                    wizard = await MoM.ApparateAsync();
                }
                catch (Exception e)
                {
                    await LogAsync(e);
                    wizard = new Wizard();
                }
                finally
                {
                    if (wizard != null) await CleanupAsync();
                }

                return wizard;
            }

            private Task CleanupAsync()
            {
                return Task.Run(() =>
                {
                    WriteLine("Cleaning up!");
                });
            }

            private Task LogAsync(Exception exception)
            {
                return Task.Run(() =>
                {
                    WriteLine($"{exception.GetType().Name} happened!");
                });
            }
        }
    }
}


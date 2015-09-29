[![Build status](https://ci.appveyor.com/api/projects/status/3vsjnx5dpqibhmhp/branch/master?svg=true)](https://ci.appveyor.com/project/amirci/csharpsixdemo/branch/master)

# CSharp 6 new features demo

The project illustrates the new features in C# 6.

Each file has the name of the feature and inside are tests to show how it works.

The format uses a `namespace` with the feature name, and the a test class with `[Test]` methods that describe how the new feature works.

For example for `String` interpolation you have:

``` csharp
   namespace StringInterpolation
   {
       public class Test
       {
           [Test]
           public void Is_the_same_as_string_format() { ... }

           [Test]
           public void Format_modifiers_can_be_used_as_well() { ... }

           [Test]
           public void Any_expression_can_be_used() { ... }
       }
   }
```

That would read something like:

* String Interpolation
  * Is the same as string format
  * Format modifiers can be used as well
  * Any expression can be used

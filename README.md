C# In Depth Chapter 7 Exploration for Book Club

# Talking Points

## Partial Classes & Methods

* Came in C# 2 and 3 (latter as partial methods)
* Flexible in many aspects (interfaces, number of files) but constraints encourage consistency

### Partial Classes

* Member & Static variable initialization order NOT guaranteed
  * **Another** reason not to rely on variable order in code (already brittle to do so)
* Further use cases for partial classes:
  * Webservice proxy code
  * ORM's (e.g. EF) -> multiple classes in one file, functionality expanded in individual partial class files
  * An aid to refactoring (i.e. a starting point for splitting up large types)
  * Organize functionality for unit testing

### Partial Methods

* Superior alternative to messy "partial implementation" techniques used previously for generated code extension:
  * Event hooks in generated code for manual code to subscribe
  * Expected methods in manual code (very brittle, bad design)
  * Empty virtual methods in generated code
* Declared like abstract methods
* Optional "hook" with zero overhead; does not get compiled in if no implementation
  * **Be careful of unintended side effect:** _any_ statement calling the partial method gets removed, including expressions in the argument
  * Argument behavior is only an issue if we are implementing the code generator; in general we would be implementing the partial method itself
* Must be private, can be static/generic

## Static classes

* A simple way to specify a _utility_ class (i.e. static methods only, no state, not meant for extension or instantiation)
* No abstract/sealed, no interfaces, no base type, no constructors (or other non-static members), no operators, no protected nor protected internal members
* In C#2, the static modifier prevents misuse as variable, array, argument, generic, or return types
* Instead of this (C#1):
  ```C#
  public sealed class MyUtilityClass
  {  
  	  private MyUtilityClass() { ; } // prevent instances
  	  public static string ReverseString(string input) { ... }
  }
  ```
  we can write this (C#2) (_static_ keyword required for every member):
  ```C#
  public static class MyUtilityClass
  {
  	  public static string ReverseString(string input) { ... }
  }
  ```

## Different access modifiers for getters vs. setters in properties

  * Allows for class implementer to specify logic/behavior specific to a property action (set/get) that they may not wish to expose
  * As opposed to the convention for other C# declarations, default matches the modifer for the property itself rather than the "most restrictive scope"

## Namespace Aliases

  * Hardly used outside of generated code, but have their uses
  * Use double-colon _namespace alias qualifier_ syntax to specify that an aliased type is being referenced (avoids collision with a future type/namespace)
  * Book example; instead of this (C#1):
  ```C#
    using System;
    using WinForms = System.Windows.Forms;
    using WebForms = System.Web.UI.WebControls;
    class Test
    {
      static void Main()
      {
        Console.WriteLine(typeof(WinForms.Button));
        Console.WriteLine(typeof(WebForms.Button));
      }
    }
  ```
  Use this (C#2), to avoid the possibility that someone might introduce an _actual_ (not alias) type or namespace called WinForms or WebForms:
  ```C#
  static void Main()
  {
    Console.WriteLine(typeof(WinForms::Button));
    Console.WriteLine(typeof(WebForms::Button));
  }    
  ```
  * Use `global::<Type>` to specify the root namespace (similar to above example, useful when types are defined _outside_ of a namespace)
  * Use extern aliases when fully-qualified types would result in a collision (i.e. each assembly gets its own alias)
    * very rare and unusal situation; can be addressed using VS references or compiler switch `/r`

## Pragma directives

  * Compiler-specific (Jon covers Microsoft compiler csc.exe)
  * line begins with `#pragma`
  * Can do anything outside the scope of the C# language specification
  * MS C# compiler recognizes `warning` and `checksum` pragmas  
  * **Warning** is used to disable warnings (by exact warning number)
	* Generally, warning should be fixed rather than ignored unless you have a very good reason for it
	* Use `disable` and `restore` keywords to limit scope of warning pragma as much as possible
  * **Checksum** is used to instruct compiler to use a *generated* checksum value instead of computing one
    * Checksum used to match with unique source code file for debugging information

## Fixed size buffers in unsafe code

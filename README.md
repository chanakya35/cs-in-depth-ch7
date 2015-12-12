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
* Optional hooks with zero overhead; do not get compiled in if no implementation

# .NET C# CLI: Notes Store
In this challenge, the task is to implement a class called Store.

The class will manage a collection of notes, with each note having a state and a name. Valid states for notes are 'completed', 'active', and
'others'. All other states are invalid.

The class must have the following methods:

    1. AddNote(state, name): adds a note with the given name (string) and state (string) to the collection. In addition to that:
        If the passed name is empty, then it throws an Exception with the message 'Name cannot be empty'.
        If the passed name is non-empty but the given state is not a valid state for a note, then it throws an Exception with the message 'Invalid state {state}'

    2. GetNotes(state): returns a list of note names with the given state (string) added so far. The names are returned in the order the corresponding notes were added. In addition to that:
        If the given state is not a valid note state, then it throws an Exception with the message 'Invalid state {state}.
        If no note is found in this state, it returns an empty list.

Note: The state names are case-sensitive.

Your implementation of the function will be tested by a stubbed code on several input files. Each input file contains parameters for the function calls. The functions will be called with those parameters, and the result of their executions will be printed to the standard output by the stubbed code. The stubbed code joins the strings returned by the GetNotes function with a comma and prints to the standard output. If GetNotes returns an empty list, the stubbed code prints 'No Notes'.

The stubbed code also prints messages of all the thrown errors.

#### Input Format For Custom Testing

In the first line, there is an integer, n, denoting the number of operations to be performed.

Each line / of the n subsequent lines (where 0 ≤ i < n) contains space-separated strings such that the first of them is a function name, and the remaining ones, if any, are parameters for that function.

#### Sample Case 0
Sample Input For Custom Testing

```
    AddNote active DrinkTea

    AddNote active DrinkCoffee

    AddNote completed Study

    GetNotes active

    GetNotes completed

    GetNotes foo
```

Sample Output

```
    DrinkTea, DrinkCoffee

    Study

    Error: Invalid state foo
```

Explanation

For all 3 AddNote operations, the AddNote function is called with a state and a name. Then, the GetNotes function Is called for
'active' state and 'completed' state respectively, and the result is printed. Then, the GetNotes function is called for 'foo' state, which throws an error since this state is invalid, and the error is printed.


#### Sample Case 1

Sample Input For Custom Testing

```
    AddNote active

    AddNote foo Study GetNotes completed
```

Sample Output

```
    Error: Name cannot be empty

    Error: Invalid state foo

    No Notes
```

Explanation

The AddNote function is called with 'active' state and an empty name, which throws an error since the name is empty. Then, AddNote is called with 'foo' state, which throws an error since the state is Invalid. Finally, the GetNotes function is called for
'completed' state, an empty list is returned since no note exists in this state, and 'No Notes' is printed by the stubbed code.
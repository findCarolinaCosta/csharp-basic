namespace StoreNotes.Test.Models;

using System;
using System.Collections.Generic;
using Moq;
using StoreNotes.Models;
using Helpers.Tests;

public class StoreTests
{
    [Fact(DisplayName = "Add And Retrieve Multiple Notes")]
    public void AddAndRetrieveMultipleNotes()
    {
        var notesStoreObj = new Store();
        List<string> statesValid = notesStoreObj.StatesValid;

        foreach (string state in statesValid)
        {
            string noteName = $"TestNoteForState_{state}";
            try
            {
                notesStoreObj.AddNote(state, noteName);

                List<string> notes = notesStoreObj.GetNotes(state);
                Assert.Contains(noteName, notes);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error adding note to state {state}: {e.Message}");
                Assert.True(false, $"Failed to add note to state {state}");
            }
        }
    }

    [Fact(DisplayName = "GetNotes Should Return No Notes")]
    public void GetNotes_ShouldReturnNoNotes()
    {
        var notesStoreObj = new Store();
        List<string> result = notesStoreObj.GetNotes("active");

        Assert.Empty(result);
    }

    [Fact(DisplayName = "AddNote Should Add Note To Valid State")]
    public void TestAddNoteWithValidState()
    {
        var store = new Store();
        store.AddNote("active", "DrinkTea");
        store.AddNote("active", "DrinkCoffee");
        store.AddNote("completed", "Study");

        var activeNotes = store.GetNotes("active");
        var completedNotes = store.GetNotes("completed");

        Assert.Equal(new List<string> { "DrinkTea", "DrinkCoffee" }, activeNotes);
        Assert.Equal(new List<string> { "Study" }, completedNotes);
    }

    [Fact(DisplayName = "AddNote Should Throw Exception If Name Is Empty")]
    public void TestAddNoteWithEmptyName()
    {
        var store = new Store();

        var ex = Assert.Throws<ArgumentException>(() => store.AddNote("active", ""));
        Assert.Equal("Name cannot be empty", ex.Message);
    }

    [Fact(DisplayName = "AddNote Should Throw Exception If State Is Invalid")]
    public void TestAddNoteWithInvalidState()
    {
        var store = new Store();

        var ex = Assert.Throws<ArgumentException>(() => store.AddNote("foo", "Study"));
        Assert.Equal("Invalid state foo", ex.Message);
    }

    [Fact(DisplayName = "GetNotes Should Throw Exception If State Is Invalid")]
    public void TestGetNotesWithInvalidState()
    {
        var store = new Store();

        var ex = Assert.Throws<ArgumentException>(() => store.GetNotes("foo"));
        Assert.Equal("Invalid state foo", ex.Message);
    }

    [Fact(DisplayName = "GetNotes Should Return Empty List For Empty State")]
    public void TestGetNotesWithEmptyState()
    {
        var store = new Store();
        Assert.Equal("No Notes", ConsoleOutput.Capture(() => store.GetNotes("completed")));
    }
}

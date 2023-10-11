namespace StoreNotes.Test.Models;

using System;
using System.Collections.Generic;
using Moq;
using StoreNotes.Models;

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
}

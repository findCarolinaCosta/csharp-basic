using System;
using System.Collections.Generic;
using System.IO;
using StoreNotes.Models;

Store notesStoreObj = new Store();

Console.WriteLine("Welcome to Notes Store!");

while (true)
{
    Console.WriteLine("____________________________");
    Console.WriteLine("Available operations:");
    Console.WriteLine("1 - AddNote");
    Console.WriteLine("2 - GetNotes");
    Console.WriteLine("3 - Exit");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    if (int.TryParse(choice, out int option))
    {
        string statesValid = string.Join("/", notesStoreObj.StatesValid);
        try
        {
            switch (option)
            {
                case 1:
                    Console.Write($"Enter the state ({statesValid}): ");
                    string state = Console.ReadLine();
                    Console.Write("Enter the note name: ");
                    string noteName = Console.ReadLine();
                    notesStoreObj.AddNote(state, noteName);
                    break;

                case 2:
                    Console.Write($"Enter the state ({statesValid}): ");
                    string getState = Console.ReadLine();
                    var result = notesStoreObj.GetNotes(getState);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("No Notes");
                    }
                    else
                    {
                        Console.WriteLine("Notes:");
                        Console.WriteLine(string.Join(", ", result));
                    }
                    break;

                case 3:
                    Console.WriteLine("Thank you for using Notes Store!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a numeric choice.");
    }
}


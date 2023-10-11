using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TeamInterface.Models;
using TeamInterface.Interfaces;

Console.WriteLine("Welcome to Team Management!");
Subteam teamObj = null;

while (true)
{
    Console.WriteLine("____________________________");
    Console.WriteLine("Options:");
    if (teamObj == null)
    {
        Console.WriteLine("1 - Create a new team");
    }
    else
    {
        Console.WriteLine("2 - Add players to the team");
        Console.WriteLine("3 - Remove players from the team");
        Console.WriteLine("4 - Change team name");
    }
    Console.WriteLine("5 - Exit");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    if (int.TryParse(choice, out int option))
    {
        switch (option)
        {
            case 1:
                Console.Write("Enter the initial team name and the number of players (e.g., TeamName 10): ");
                string input = Console.ReadLine();
                string[] inputArray = input.Split();

                if (inputArray.Length == 2 && int.TryParse(inputArray[1], out int count))
                {
                    teamObj = new Subteam(inputArray[0], count);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter team name and the number of players.");
                }
                break;

            case 2:
                if (teamObj != null)
                {
                    Console.Write("Enter the number of players to add: ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out int countToAdd))
                    {
                        teamObj.AddPlayer(countToAdd);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for the number of players to add.");
                    }
                }

                break;

            case 3:
                if (teamObj != null)
                {
                    Console.Write("Enter the number of players to remove: ");
                    input = Console.ReadLine();

                    if (int.TryParse(input, out int countToRemove))
                    {
                        teamObj.RemovePlayer(countToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for the number of players to remove.");
                    }
                }

                break;

            case 4:
                if (teamObj != null)
                {
                    Console.Write("Enter the new team name: ");
                    string newName = Console.ReadLine();

                    teamObj.ChangeTeamName(newName);
                }

                break;

            case 5:
                Console.WriteLine("Thank you for using Team Management!");
                return;

            default:
                Console.WriteLine("Invalid option. Please select a valid option.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a numeric choice.");
    }
}
using TeamInterface.Models;
using TeamInterface.Interfaces;
using Helpers.Tests;

namespace TeamInterface.Test.Models
{
    public class TeamTests
    {
        [Fact(DisplayName = "Subteam Should Be Subclass Of Team")]
        public void SubteamShouldBeSubclassOfTeam()
        {
            Type subteamType = typeof(Subteam);
            Type teamType = typeof(ITeam);

            Assert.True(teamType.IsAssignableFrom(subteamType));
        }

        [Fact(DisplayName = "Test Change Team Name")]
        public void TestChangeTeamName()
        {
            Subteam teamObj = new Subteam("InitialTeam", 10);

            string newTeamName = "NewTeamName";

            teamObj.ChangeTeamName(newTeamName);

            Assert.Equal(newTeamName, teamObj.TeamName);
        }

        [Fact(DisplayName = "Test Add Player")]
        public void TestAddPlayer()
        {
            Subteam teamObj = new Subteam("InitialTeam", 10);

            teamObj.AddPlayer(5);

            Assert.Equal(15, teamObj.NoOfPlayers);
        }

        [Fact(DisplayName = "Test Remove Player")]
        public void TestRemovePlayer()
        {
            Subteam teamObj = new Subteam("InitialTeam", 10);

            var result = teamObj.RemovePlayer(3);

            Assert.True(result);
            Assert.Equal(7, teamObj.NoOfPlayers);
        }

        [Fact(DisplayName = "Sample Case 0")]
        public void SampleCase0()
        {
            string originalName = "OldTeam";
            Subteam teamObj = new Subteam(originalName, 2);

            Assert.Equal($"Team {originalName} created", ConsoleOutput.Capture(() => new Subteam(originalName, 2)));
            Assert.Equal($"Current number of players in team {originalName} is 5", ConsoleOutput.Capture(() => teamObj.AddPlayer(3)));
            Assert.Equal($"Current number of players in team {originalName} is 1", ConsoleOutput.Capture(() => teamObj.RemovePlayer(4)));
            Assert.Equal($"Team name of team {originalName} changed to NewTeam", ConsoleOutput.Capture(() => teamObj.ChangeTeamName("NewTeam")));
        }

        [Fact(DisplayName = "Sample Case 1")]
        public void SampleCase1()
        {
            string originalName = "Champions";
            Subteam teamObj = new Subteam(originalName, 2);

            Assert.Equal($"Team {originalName} created", ConsoleOutput.Capture(() => new Subteam(originalName, 2)));
            Assert.Equal($"Current number of players in team {originalName} is 3", ConsoleOutput.Capture(() => teamObj.AddPlayer(1)));
            Assert.Equal($"Current number of players in team {originalName} is 1", ConsoleOutput.Capture(() => teamObj.RemovePlayer(2)));
            Assert.Equal($"Team name of team {originalName} changed to IPL", ConsoleOutput.Capture(() => teamObj.ChangeTeamName("IPL")));
        }
    }
}

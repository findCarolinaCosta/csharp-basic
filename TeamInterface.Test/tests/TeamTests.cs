using TeamInterface.Models;
using TeamInterface.Interfaces;

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
    }
}

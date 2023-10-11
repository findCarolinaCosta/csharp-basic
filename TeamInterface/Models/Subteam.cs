namespace TeamInterface.Models
{
    public class Subteam : Team
    {
        public Subteam(string teamName, int noOfPlayers) : base(teamName, noOfPlayers)
        { }

        public void ChangeTeamName(string name)
        {
            string oldTeamName = teamName;
            teamName = name;
            Console.WriteLine($"Team name of team {oldTeamName} changed to {teamName}");
        }
    }
}
using TeamInterface.Interfaces;

namespace TeamInterface.Models
{
    public class Team : ITeam
    {
        protected string teamName { get; set; }
        private int noOfPlayers { get; set; }

        public Team(string teamName, int noOfPlayers)
        {
            this.teamName = teamName;
            this.noOfPlayers = noOfPlayers;
            Console.WriteLine($"Team {teamName} created");
        }

        public void AddPlayer(int count)
        {
            noOfPlayers += count;
            Console.WriteLine($"Current number of players in team {teamName} is {noOfPlayers}");

        }

        public bool RemovePlayer(int count)
        {
            if (noOfPlayers - count < 0)
            {
                Console.WriteLine(
                    $"Current number of players in team {teamName} is {noOfPlayers}, cannot remove more players than currently in team"
                );

                return false;
            }
            noOfPlayers -= count;
            Console.WriteLine($"Current number of players in team {teamName} is {noOfPlayers}");

            return true;
        }

        public string TeamName { get { return teamName; } }

        public int NoOfPlayers { get { return noOfPlayers; } }

    }
}

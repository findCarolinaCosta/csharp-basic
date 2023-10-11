
namespace StoreNotes.Models
{
    public class Store
    {
        private List<string> activeNotes = new List<string>();
        private List<string> completedNotes = new List<string>();
        private List<string> othersNotes = new List<string>();
        private List<string> statesValid = new List<string> { "active", "completed", "others" };

        public void AddNote(string state, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            if (statesValid.Contains(state))
            {
                if (state == "active")
                {
                    activeNotes.Add(name);
                }
                else if (state == "completed")
                {
                    completedNotes.Add(name);
                }
                else if (state == "others")
                {
                    othersNotes.Add(name);
                }
            }
            else
            {
                throw new ArgumentException($"Invalid state {state}");
            }
        }

        public List<String> GetNotes(String state)
        {
            if (statesValid.Contains(state))
            {
                bool isCleanNotes = new List<List<string>> { activeNotes, completedNotes, othersNotes }.All(list => !list.Any());
                if (isCleanNotes)
                {
                    Console.WriteLine("No Notes");
                }
                else if (state == "active")
                {
                    return activeNotes;
                }
                else if (state == "completed")
                {
                    return completedNotes;
                }
                else if (state == "others")
                {
                    return othersNotes;
                }
            }
            else
            {
                throw new ArgumentException($"Invalid state {state}");
            }
            return new List<string>();
        }

        public List<string> StatesValid { get { return statesValid; } }
    }
}
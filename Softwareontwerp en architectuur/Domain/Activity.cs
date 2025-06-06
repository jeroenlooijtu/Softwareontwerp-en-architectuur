using Softwareontwerp_en_architectuur.Domain.State;

namespace Softwareontwerp_en_architectuur.Domain
{
    public class Activity : ICountable
    {
        public Activity(string name, string description, Developer developer, int storyPoints)
        {
            Name = name;
            Description = description;
            Developer = developer;
            StoryPoints = storyPoints;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; } = false;

        public Developer Developer { get; set; }

        public int StoryPoints { get; set; }



        public int CountStorypoints()
        {
            return StoryPoints;
        }

        public int CountFinishedStoryPoints()
        {
            throw new NotImplementedException();
        }
    }
}

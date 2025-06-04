namespace Softwareontwerp_en_architectuur.Domain
{
    public class Project
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Developer> developers = new List<Developer>();
        public DateOnly StartedOn { get; set; }
        public List<ISprint> DoneSprints = new List<ISprint>();
        public Developer LeadDeveloper { get; set; }

        public Project(string title, string description, DateOnly startedOn, ISprint currentSprint, Developer leadDeveloper)
        {
            Title = title;
            Description = description;
            StartedOn = startedOn;
            CurrentSprint = currentSprint;
            LeadDeveloper = leadDeveloper;
        }

        public ISprint CurrentSprint { get; set; }

        public void AddDeveloper(Developer developer)
        {
            this.developers.Add(developer);
        }
        public void AddFinishedSprint(ISprint sprint)
        {
            if (sprint.IsFinished())
            {
                this.DoneSprints.Add(sprint);
                return;
            }
            throw new InvalidOperationException("Can't add a not finished sprint to the finished sprint list");
        }
    }
}

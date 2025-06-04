namespace Softwareontwerp_en_architectuur.Domain
{
    public class Project
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Developer> developers = new List<Developer>();
        public DateOnly StartedOn { get; set; }
        public List<ISprint> DoneSprints = new List<ISprint>();
        public Developer? LeadDeveloper { get; set; }
        public List<Backlog_Item> backlog = new List<Backlog_Item>();

        public Project(string title, string description, DateOnly startedOn)
        {
            Title = title;
            Description = description;
            StartedOn = startedOn;
        }

        public ISprint? CurrentSprint { get; set; }

        public void AddDeveloper(Developer developer)
        {
            this.developers.Add(developer);
        }
        public void AddFinishedSprint()
        {
            if (this.CurrentSprint.IsFinished())
            {
                this.DoneSprints.Add(this.CurrentSprint);
                this.CurrentSprint = null;
                return;
            }
            throw new InvalidOperationException("Can't add a not finished sprint to the finished sprint list");
        }

        public bool DeveloperInvolved(Developer developer)
        {
            return this.developers.Contains(developer);
        }
        public void AddBacklogItem(Backlog_Item backlog_Item)
        {
            backlog_Item.Project = this;
            this.backlog.Add(backlog_Item);
        }
    }
}

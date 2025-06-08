using Softwareontwerp_en_architectuur.Domain.Notifier;
using Softwareontwerp_en_architectuur.Domain.State;

namespace Softwareontwerp_en_architectuur.Domain
{
    public class Backlog_Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefinitionOfDone { get; set; }
        public IState State { get; set; } = new TodoState();
        public Developer? Developer { get; private set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public List<INotifier> Notifiers { get; set; } = new List<INotifier>();
        public List<IBacklogitemObservable> Observers { get; set; } = new List<IBacklogitemObservable>();
        public DateOnly CompletedOn { get; set; }
        public Project? Project { get; set; }
        public Backlog_Item(string name, string description, string definitionOfDone)
        {
            Name = name;
            Description = description;
            DefinitionOfDone = definitionOfDone;
        }

       

        public void ChangeState(IState state)
        {
            this.State = state;
        }

        public int CountStorypoints()
        {
            int points = 0;
            foreach (ICountable a in this.Activities)
            {
                points += a.CountStorypoints();
            }
            return points;
        }

        public int CountFinishedStoryPoints()
        {
            throw new NotImplementedException();
        }

        public void AssignDeveloper(Developer developer)
        {
            if (Project.DeveloperInvolved(developer))
            {
                this.Developer = developer;
                return;
            }
            throw new InvalidOperationException("Developer not in the project");
        }


        public void Notify()
        {
            foreach (IBacklogitemObservable observer in this.Observers)
            {
                observer.SendNotification();
            }
        }

        public void Unsubscribe(IBacklogitemObservable observer)
        {
            this.Observers.Remove(observer);
        }

        public void Subscribe(IBacklogitemObservable observer)
        {
            this.Observers.Add(observer);
        }   
    }
}


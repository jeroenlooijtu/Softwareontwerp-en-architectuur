using System.Collections;

namespace Softwareontwerp_en_architectuur.Domain
{
    public interface ICountable
    {
        int CountStorypoints();

        int CountFinishedStoryPoints(); 
    }
    public interface ISprint
    {
        public List<Backlog_Item> Backlog { get; set; }
        public DateOnly BeginDate {  get; set; }
        public DateOnly EndDate { get; set;}

        public ISprintState State { get; set; }

    }
    public class ReviewSprint : ISprint, ICountable
    {
        public List<Backlog_Item> Backlog { get; set;  }
        public DateOnly BeginDate { get; set; }
        public DateOnly EndDate { get; set; }
        public ISprintState State { get; set; }

        public int CountFinishedStoryPoints()
        {
            throw new NotImplementedException();
        }

        public int CountStorypoints()
        {
            int points = 0;
            foreach (ICountable b in this.Backlog)
            {
                points += b.CountStorypoints();
            }
            return points;
        }
    }

    public class ReleaseSprint : ISprint
    {
        public List<Backlog_Item> Backlog { get; set; }
        public DateOnly BeginDate { get; set; }
        public DateOnly EndDate { get; set; }
        public ISprintState State { get; set; }

        public List<string> PipelineSteps { get; set; }
    }

    public class Backlog_Item : ICountable
    {
        

        public string Name { get; set; }
        public string Description { get; set; }
        public string DefinitionOfDone { get; set; }
        public IState State { get; set; } = new TodoState();
        public Developer Developer { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
        public List<INotifier> Notifiers { get; set; } = new List<INotifier>();
        public DateOnly CompletedOn { get; set; }

        public Backlog_Item(string name, string description, string definitionOfDone, IState state, Developer developer)
        {
            Name = name;
            Description = description;
            DefinitionOfDone = definitionOfDone;
            Developer = developer;
        }

        public void Notify()
        {

        }

        public int CountStorypoints()
        {
            int points = 0;
            foreach (ICountable a in this.Activities) {
                points += a.CountStorypoints();
            }
            return points;
        }

        public int CountFinishedStoryPoints()
        {
            throw new NotImplementedException();
        }
    }

    public class Activity : ICountable
    {
        public string Name { get; set;}
        public string Description { get; set; }
        public IState State { get; set; }

        public Developer Developer { get; set; }

        public int StoryPoints { get; set; }

        public Activity() { }

        public int CountStorypoints()
        {
            return StoryPoints;
        }

        public int CountFinishedStoryPoints()
        {
            throw new NotImplementedException();
        }
    }

    public class Developer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Developer() { }
    }

    

    public interface INotifier
    {
        public void SendNotification();
    }

    public class EmailNotifier : INotifier
    {
        public void SendNotification()
        {
           
        }
    }

    public class SlackNotifier : INotifier
    {
        public void SendNotification()
        {

        }
    }

    public interface IState
    {
        public void NextState(IState state);

    }

    public class TodoState : IState
    {

        public void NextState(IState state)
        {
            throw new NotImplementedException();
        }
    }

    public class DoingState : IState
    {
        public void NextState(IState state)
        {
            throw new NotImplementedException();
        }
    }
    public class ReadyForTestingState : IState
    {
        public void NextState(IState state)
        {
            throw new NotImplementedException();
        }
    }
    public class TestingState : IState
    {
        public void NextState(IState state)
        {
            throw new NotImplementedException();
        }
    }
    public class TestedState : IState
    {
        public void NextState(IState state)
        {
            throw new NotImplementedException();
        }
    }

    public class DoneState : IState
    {
        public void NextState(IState state)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISprintState
    {

    }

    public class CreatedSprintState : ISprintState
    {

    }

    public class DoingSprintState : ISprintState
    {

    }
    public class DoneSprintState : ISprintState
    {

    }

}

using Softwareontwerp_en_architectuur.Domain.State;
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
        public bool IsFinished();
    }

    public class Sprint : ISprint, ICountable
    {
        public Sprint(DateOnly beginDate, DateOnly endDate)
        {
            if (beginDate > endDate || beginDate < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Sprint date must be after todays date");
            }
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public List<BacklogItem> Backlog { get; set; } = new List<BacklogItem>();
        public DateOnly BeginDate { get; set; }
        public DateOnly EndDate { get; set; }
        public ISprintState State { get; set; } = new CreatedSprintState();


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

        public bool IsFinished()
        {
            return State.GetType() == typeof(DoneSprintState);
        }
    }

    public class ReleaseSprint : ISprint
    {
        public List<BacklogItem> Backlog { get; set; }
        public DateOnly BeginDate { get; set; }
        public DateOnly EndDate { get; set; }
        public ISprintState State { get; set; }

        public List<string> PipelineSteps { get; set; }

        public bool IsFinished()
        {
            return State.GetType() == typeof(DoneSprintState);
        }
    }
}
namespace Softwareontwerp_en_architectuur.Domain.State
{
    public class TodoState : BacklogState
    {
        public TodoState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            Backlog_item.State = new DoingState(Backlog_item);
        }

        public override void RegressState()
        {
            throw new InvalidOperationException("No earlier state exists");
        }
    }

    public class DoingState : BacklogState
    {
        public DoingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            if (!Backlog_item.AreActivitiesFinished())
            {
                throw new InvalidOperationException("Not all activities are finished");
            }
            
            Backlog_item.State = new ReadyForTestingState(Backlog_item);
        }

        public override void RegressState()
        {
            Backlog_item.State = new TodoState(Backlog_item);
        }
    }
    public class ReadyForTestingState : BacklogState
    {
        public ReadyForTestingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            Backlog_item.State = new TestingState(Backlog_item);
        }

        public override void RegressState()
        {
            Backlog_item.State = new TodoState(Backlog_item);
        }
    }
    public class TestingState : BacklogState
    {
        public TestingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            Backlog_item.State = new TestedState(Backlog_item);
        }

        public override void RegressState()
        {
            Backlog_item.CompletedOn = null;
            Backlog_item.State = new TodoState(Backlog_item);
        }
    }
    public class TestedState : BacklogState
    {
        public TestedState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            Backlog_item.CompletedOn = DateOnly.FromDateTime(DateTime.Now);
            Backlog_item.State = new DoneState(Backlog_item);
        }

        public override void RegressState()
        {
            Backlog_item.State = new ReadyForTestingState(Backlog_item);
        }
    }

    public class DoneState : BacklogState
    {
        public DoneState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            throw new InvalidOperationException("There is no next state");
        }

        public override void RegressState()
        {
            Backlog_item.CompletedOn = null;
            Backlog_item.State = new TodoState(Backlog_item);
        }
    }
}

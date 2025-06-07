namespace Softwareontwerp_en_architectuur.Domain.State
{
    public class TodoState : BacklogState
    {
        public TodoState(BacklogItem backlogItem) : base(backlogItem)
        {
        }

        public override void NextState()
        {
            BacklogItem.State = new DoingState(BacklogItem);
        }

        public override void RegressState()
        {
            throw new InvalidOperationException("No earlier state exists");
        }
    }

    public class DoingState : BacklogState
    {
        public DoingState(BacklogItem backlogItem) : base(backlogItem)
        {
        }

        public override void NextState()
        {
            if (!BacklogItem.AreActivitiesFinished())
            {
                throw new InvalidOperationException("Not all activities are finished");
            }
            
            BacklogItem.State = new ReadyForTestingState(BacklogItem);
        }

        public override void RegressState()
        {
            BacklogItem.State = new TodoState(BacklogItem);
        }
    }
    public class ReadyForTestingState : BacklogState
    {
        public ReadyForTestingState(BacklogItem backlogItem) : base(backlogItem)
        {
        }

        public override void NextState()
        {
            BacklogItem.State = new TestingState(BacklogItem);
        }

        public override void RegressState()
        {
            BacklogItem.State = new TodoState(BacklogItem);
        }
    }
    public class TestingState : BacklogState
    {
        public TestingState(BacklogItem backlogItem) : base(backlogItem)
        {
        }

        public override void NextState()
        {
            BacklogItem.State = new TestedState(BacklogItem);
        }

        public override void RegressState()
        {
            BacklogItem.CompletedOn = null;
            BacklogItem.State = new TodoState(BacklogItem);
        }
    }
    public class TestedState : BacklogState
    {
        public TestedState(BacklogItem backlogItem) : base(backlogItem)
        {
        }

        public override void NextState()
        {
            BacklogItem.CompletedOn = DateOnly.FromDateTime(DateTime.Now);
            BacklogItem.State = new DoneState(BacklogItem);
        }

        public override void RegressState()
        {
            BacklogItem.State = new ReadyForTestingState(BacklogItem);
        }
    }

    public class DoneState : BacklogState
    {
        public DoneState(BacklogItem backlogItem) : base(backlogItem)
        {
        }

        public override void NextState()
        {
            throw new InvalidOperationException("There is no next state");
        }

        public override void RegressState()
        {
            BacklogItem.CompletedOn = null;
            BacklogItem.State = new TodoState(BacklogItem);
        }
    }
}

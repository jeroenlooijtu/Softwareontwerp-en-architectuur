namespace Softwareontwerp_en_architectuur.Domain.State
{
    public class TodoState : BacklogState
    {
        public TodoState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            backlog_item.State = new DoingState(backlog_item);
        }

        public override void RegressState()
        {
            throw new NotImplementedException();
        }
    }

    public class DoingState : BacklogState
    {
        public DoingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            backlog_item.State = new ReadyForTestingState(backlog_item);
        }

        public override void RegressState()
        {
            throw new NotImplementedException();
        }
    }
    public class ReadyForTestingState : BacklogState
    {
        public ReadyForTestingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            backlog_item.State = new TestingState(backlog_item);
        }

        public override void RegressState()
        {
            throw new NotImplementedException();
        }
    }
    public class TestingState : BacklogState
    {
        public TestingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            backlog_item.State = new TestedState(backlog_item);
        }

        public override void RegressState()
        {
            backlog_item.State = new TodoState(backlog_item);
        }
    }
    public class TestedState : BacklogState
    {
        public TestedState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            backlog_item.State = new DoneState(backlog_item);
        }

        public override void RegressState()
        {
            backlog_item.State = new ReadyForTestingState(backlog_item);
        }
    }

    public class DoneState : BacklogState
    {
        public DoneState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

        public override void NextState()
        {
            throw new NotImplementedException();
        }

        public override void RegressState()
        {
            throw new NotImplementedException();
        }
    }
}

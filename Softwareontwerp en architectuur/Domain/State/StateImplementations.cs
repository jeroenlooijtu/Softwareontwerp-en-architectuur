namespace Softwareontwerp_en_architectuur.Domain.State
{
    public class TodoState : BacklogState
    {
        public TodoState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

    }

    public class DoingState : BacklogState
    {
        public DoingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

    }
    public class ReadyForTestingState : BacklogState
    {
        public ReadyForTestingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

    }
    public class TestingState : BacklogState
    {
        public TestingState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

    }
    public class TestedState : BacklogState
    {
        public TestedState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

    }

    public class DoneState : BacklogState
    {
        public DoneState(Backlog_Item backlog_item) : base(backlog_item)
        {
        }

    }
}

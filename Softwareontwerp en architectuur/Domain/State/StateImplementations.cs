namespace Softwareontwerp_en_architectuur.Domain.State
{
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
}

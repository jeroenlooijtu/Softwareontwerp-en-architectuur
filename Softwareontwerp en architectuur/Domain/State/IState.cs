namespace Softwareontwerp_en_architectuur.Domain.State
{
    public interface IState
    {
        public void NextState(IState state);

    }
}

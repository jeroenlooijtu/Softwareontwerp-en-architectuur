namespace Softwareontwerp_en_architectuur.Domain.State
{
    public abstract class BacklogState
    {
        public BacklogItem BacklogItem;

        public BacklogState(BacklogItem backlogItem)
        {
            this.BacklogItem = backlogItem;
        }

        public abstract void NextState();
        public abstract void RegressState();
    }
}
namespace Softwareontwerp_en_architectuur.Domain.State
{
    public abstract class BacklogState
    {
        public BacklogItem Backlog_item;

        public BacklogState(BacklogItem backlog_item)
        {
            this.Backlog_item = backlog_item;
        }

        public abstract void NextState();
        public abstract void RegressState();

    }
}

namespace Softwareontwerp_en_architectuur.Domain.State
{
    public abstract class BacklogState
    {
        public Backlog_Item Backlog_item;

        public BacklogState(Backlog_Item backlog_item)
        {
            this.Backlog_item = backlog_item;
        }

        public abstract void NextState();
        public abstract void RegressState();

    }
}

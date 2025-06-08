namespace Softwareontwerp_en_architectuur.Domain.Notifier
{
    public interface IBacklogitemObservable
    {
        public void Subscribe(INotifier notifier);
        public void UnSubscribe(INotifier notifier);
        public void SendNotification()
        {

        }
    }
}

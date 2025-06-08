namespace Softwareontwerp_en_architectuur.Domain.Notifier
{
    public interface IBacklogItemObservable
    {
        public void Subscribe(INotifier notifier);
        public void UnSubscribe(INotifier notifier);
        public void SendNotification();
        public void SendTesterNotification(string message);

    }
}

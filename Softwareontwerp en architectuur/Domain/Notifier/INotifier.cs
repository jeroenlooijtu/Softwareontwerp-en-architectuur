namespace Softwareontwerp_en_architectuur.Domain.Notifier
{
    public interface INotifier
    {
        public void SendNotification(string message);
    }
}
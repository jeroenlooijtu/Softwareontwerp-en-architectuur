namespace Softwareontwerp_en_architectuur.Domain.Notifier
{
    public class SlackNotifier : INotifier
    {
        public string SendNotification(string message)
        {
            return message;
        }
    }
}
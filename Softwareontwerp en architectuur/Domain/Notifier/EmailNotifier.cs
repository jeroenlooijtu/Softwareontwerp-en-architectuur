namespace Softwareontwerp_en_architectuur.Domain.Notifier
{
    public class EmailNotifier : INotifier
    {
        public List<String> receivedMessages = new List<String>();
        public string SendNotification(string message)
        {
            receivedMessages.Add(message);
            return message;
        }

       
    }
}
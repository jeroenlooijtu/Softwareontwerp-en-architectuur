namespace Softwareontwerp_en_architectuur.Domain.Notifier
{
    public class EmailNotifier
    {
        public void SendNotification(string message, Developer developer)
        {
            Console.Write(message + " " + developer.Name + " Adapted for email");
        }
    }
}
namespace Softwareontwerp_en_architectuur.Domain.Notifier
{
    public class SlackNotifier
    {
        public void SendNotification(string message, Developer developer)
        {
            Console.Write(message + " " + developer.Name + " Adapted for slack");
        }
    }
}
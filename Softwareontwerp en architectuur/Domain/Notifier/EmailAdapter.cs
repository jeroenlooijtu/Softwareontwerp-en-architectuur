namespace Softwareontwerp_en_architectuur.Domain.Notifier;

public class EmailAdapter : INotifier
{
    public EmailNotifier Notifier { get; set; }
    public Developer Developer { get; set; }

    public EmailAdapter(EmailNotifier notifier, Developer developer)
    {
        Notifier = notifier;
        Developer = developer;
    }

    public void SendNotification(string message)
    {
        Notifier.SendNotification(message, Developer);
    }
}
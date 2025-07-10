namespace Softwareontwerp_en_architectuur.Domain.Notifier;

public class SlackAdapter : INotifier
{
    public SlackNotifier SlackNotifier { get; set; }
    public Developer Developer { get; set; }

    public SlackAdapter(SlackNotifier slackNotifier, Developer developer)
    {
        SlackNotifier = slackNotifier;
        Developer = developer;
    }

    public void SendNotification(string message)
    {
        SlackNotifier.SendNotification(message, Developer);
    }
}
namespace Softwareontwerp_en_architectuur.Domain;

public class Discussion
{
    public string Topic {get; set;}
    public BacklogItem backlogItem {get; set;}
    public IPost IPost {get; set;}

    public Discussion(string topic, BacklogItem backlogItem, IPost post)
    {
        Topic = topic;
        this.backlogItem = backlogItem;
        IPost = post;
    }
}
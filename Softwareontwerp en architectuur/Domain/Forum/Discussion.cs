namespace Softwareontwerp_en_architectuur.Domain;

public class Discussion
{
    public string Topic {get; set;}
    public BacklogItem BacklogItem {get; set;}
    public Thread Thread {get; set;}
}
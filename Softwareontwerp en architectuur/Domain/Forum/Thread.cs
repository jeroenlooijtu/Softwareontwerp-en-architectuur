namespace Softwareontwerp_en_architectuur.Domain;

public class Thread : IPost
{
    public Developer MadeBy {get; set;}
    public string content {get; set;}
    public List<IPost> Posts {get; set;} = new List<IPost>();

    public Thread(string content, Developer madeBy)
    {
        MadeBy = madeBy;
        this.content = content;
    }
    public void AddComment(Comment post)
    {
        
        this.Posts.Add(post);
    }

    public void RemoveComment(IPost post)
    {
        this.Posts.Remove(post);
    }

    public void AddThread(Thread thread)
    {
        this.Posts.Add(thread);
    }
}
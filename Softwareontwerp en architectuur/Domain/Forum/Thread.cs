namespace Softwareontwerp_en_architectuur.Domain;

public class Thread : IPost
{
    public Developer MadeBy {get; set;}
    public string Content {get; set;}
    public List<IPost> Posts {get; set;} = new List<IPost>();

    public Thread( Developer madeBy, string content)
    {
        MadeBy = madeBy;
        this.Content = content;
    }

    public void AddComment(IPost post)
    {
        this.Posts.Add(post);
    }

    public void RemoveComment(IPost post)
    {
        this.Posts.Remove(post);
    }

}
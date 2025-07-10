namespace Softwareontwerp_en_architectuur.Domain;

public class Comment : IPost
{
    public Developer MadeBy {get; set;}
    public string Content { get; }
    public Thread? ThreadCommentedOn {get; set;}
    public bool Status {get; set;}

    public Comment(Developer madeBy, string content)
    {
        this.Content = content;
        MadeBy = madeBy;
        this.Status = true;
    }

    public void AddComment(IPost post)
    {
        throw new NotImplementedException();
    }

    public void RemoveComment(IPost post)
    {
        throw new NotImplementedException();
    }
}
namespace Softwareontwerp_en_architectuur.Domain;

public class Comment : IPost
{
    public string content { get; set; }
    public Developer MadeBy {get; set;}
    public Thread? ThreadCommentedOn {get; set;}

    public Comment(string content, Developer madeBy, Thread threadCommentedOn)
    {
        this.content = content;
        MadeBy = madeBy;
    }
    public void AddComment(Comment post)
    {
        Thread convertedComment = new Thread(this.content, this.MadeBy);
        this.ThreadCommentedOn.AddThread(convertedComment);
        this.ThreadCommentedOn.RemoveComment(this);
        convertedComment.AddComment(post);
    }

    public void RemoveComment(IPost post)
    {
        throw new NotImplementedException();
    }
}
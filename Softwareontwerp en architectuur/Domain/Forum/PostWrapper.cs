namespace Softwareontwerp_en_architectuur.Domain;

public class PostWrapper : IPost
{
    public IPost _inner;

    public Developer MadeBy => _inner.MadeBy;

    public string Content => _inner.Content;

    public PostWrapper(Developer madeBy, string content)
    {
        _inner = new Comment(madeBy, content);
    }
    public void AddComment(IPost post)
    {
        if (_inner is Comment)
        {
            var threaded = new Thread(_inner.MadeBy, _inner.Content);
            _inner = threaded;
        }
        _inner.AddComment(post);
    }

    public void RemoveComment(IPost post)
    {
        if (_inner is Comment)
        {
           throw new InvalidOperationException("Cannot remove comment from comment");
        }
        _inner.RemoveComment(post);
    }
}
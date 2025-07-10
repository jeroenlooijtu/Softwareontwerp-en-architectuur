namespace Softwareontwerp_en_architectuur.Domain;

public interface IPost
{
    public Developer MadeBy { get; }
    public string Content { get; }
    public void AddComment(IPost post);
    public void RemoveComment(IPost post);
}
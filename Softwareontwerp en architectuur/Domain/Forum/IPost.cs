namespace Softwareontwerp_en_architectuur.Domain;

public interface IPost
{
    public void AddComment(Comment post);
    public void RemoveComment(IPost post);
}
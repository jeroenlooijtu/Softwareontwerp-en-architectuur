using Softwareontwerp_en_architectuur.Domain;
using Thread = Softwareontwerp_en_architectuur.Domain.Thread;

namespace SOFATestsreal;

public class UnitTestPosts : StateTestBase
{
    [Fact]
    public void TestCommentToThread()
    {
        //Arrange
        Comment comment = new Comment(Dev, "I actualy think it does work");
        //Act
        postWrapper.AddComment(comment);
        //Assert
        Assert.IsType<Thread>(postWrapper._inner);
    }

    [Fact]
    public void TestCommentRemove()
    {
        //Arrange
        Comment comment = new Comment(Dev, "I actualy think it does work");
        postWrapper.AddComment(comment);
        //Act
        postWrapper.RemoveComment(comment);
        Softwareontwerp_en_architectuur.Domain.Thread thread = (Softwareontwerp_en_architectuur.Domain.Thread)postWrapper._inner;
        //Assert
        Assert.Empty(thread.Posts);
    }

    [Fact]
    public void CommentNotRemoveableFromComment()
    {
        //Act
        Action act = () => postWrapper.RemoveComment(postWrapper);
        //Assert
        Assert.Throws<InvalidOperationException>(act);
    }
}
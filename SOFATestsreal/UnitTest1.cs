using Softwareontwerp_en_architectuur.Domain;

namespace SOFATestsreal
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Developer dev = new Developer();
            Backlog_Item item = new Backlog_Item("Make work", "Make sure this method works", "It works", dev);

            //Act
            item.ChangeState(new DoingState());

            //Assert
            Assert.True(item.State.GetType() == typeof(DoingState));
        }
    }
}
using Softwareontwerp_en_architectuur.Domain;
using Softwareontwerp_en_architectuur.Domain.State;

namespace SOFATestsreal
{
    public class SonarTestsToMove : StateTestBase
    {
        [Fact]
        public void TestInitialStateType()
        {
            //Arrange
            Developer dev = new Developer("Dave", "Dave@gmail.com", "Yoooo", "Developer");
            BacklogItem item = new BacklogItem("Make work", "Make sure this method works", "It works");

            //Act
            item.ChangeState(new DoingState(item));

            //Assert
            Assert.True(item.State.GetType() == typeof(DoingState));
        }

        [Fact]
        public void TestCountStoryPointsWhichIsntBeingUsedAnymore()
        {
            //Arrange
            Sprint sprint = new Sprint(new DateOnly(2025, 12, 25), new DateOnly(2026, 1, 23));

            Developer dev = new Developer("Dave", "Dave@gmail.com", "Yoooo", "Developer");
            BacklogItem item = new BacklogItem("Make work", "Make sure this method works", "It works");
            BacklogItem item2 = new BacklogItem("Make work", "Make sure this method works", "It works");
            Activity act1 = new Activity("Make work", "Making it extra work", dev, 2);
            Activity act2 = new Activity("Make work", "Making it extra work", dev, 4);
            Activity act3 = new Activity("Make work", "Making it extra work", dev, 6);
            Activity act5 = new Activity("Make work", "Making it extra work", dev, 2);
            Activity act6 = new Activity("Make work", "Making it extra work", dev, 1);

            item.Activities.Add(act1);
            item.Activities.Add(act2);
            item.Activities.Add(act3);
            item2.Activities.Add(act5);
            item2.Activities.Add(act6);

            sprint.Backlog.Add(item);
            sprint.Backlog.Add(item2);

            //Act
            int x = sprint.CountStorypoints();

            //Assert
            Assert.Equal(15, x);
        }

        [Fact]
        public void TestSprintInThePast()
        {
            //Arrange 
            Action act = () => new Sprint(new DateOnly(2021, 12, 25), new DateOnly(2022, 1, 23));
            //Act
            Assert.Throws<ArgumentException>(act);
        }
    }
}
using Softwareontwerp_en_architectuur.Domain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFATestsreal
{
    public class UnitTestStat : StateTestBase
    {

        [Fact]
        public void StateChangeRegressToDoStateFail()
        {
            //Act
            Action act = () => Item.State.RegressState();
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(() => act());
            //Assert
            Assert.Equal("No earlier state exists", e.Message);
            Assert.True(Item.State.GetType() == typeof(TodoState));
        }
        [Fact]
        public void StateChangeOnDeveloperAssigning() {
            //Act
            Item.AssignDeveloper(Dev);

            //Assert
            Assert.Equal(Item.Developer, Dev);
            Assert.True(Item.State.GetType() == typeof(DoingState));
        }
        [Fact]
        public void StateChangeToReadyForTestingFail()
        {
            //Act
            Item.AssignDeveloper(Dev);
            Action act = () => Item.State.NextState();
            //Assert
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(() => act());
            Assert.Equal("Not all activities are finished", e.Message);

        }
        [Fact]
        public void StateChangeToReadyForTestingSucces()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            //Assert
            Assert.True(Item.State.GetType() == typeof(ReadyForTestingState));

        }
        [Fact]
        public void StateChangeRegressToToDo()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            Item.State.RegressState();
            //Assert
            Assert.True(Item.State.GetType() == typeof(TodoState));

        }
        [Fact]
        public void StateChangeDoingToToDo()
        {
            //Act
            Item.AssignDeveloper(Dev);
            Item.State.RegressState();

            //Assert
            Assert.Equal(Item.Developer, Dev);
            Assert.True(Item.State.GetType() == typeof(TodoState));
        }

        [Fact]
        public void StateChangeToReadyForTestingOnlySomeActivitiesFinished()
        {
            //Act
            Activites.First().IsFinished = true;
            Item.AssignDeveloper(Dev);
            Action act = () => Item.State.NextState();
            //Assert
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(() => act());
            Assert.Equal("Not all activities are finished", e.Message);

        }
        [Fact]
        public void StateChangeToTesting()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            Item.State.NextState();
            //Assert
            Assert.True(Item.State.GetType() == typeof(TestingState));
        }

        [Fact]
        public void StateChangeToTested()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            //Assert
            Assert.True(Item.State.GetType() == typeof(TestedState));
        }

        [Fact]
        public void StateChangeFromTestingToToDo()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            Item.State.NextState();
            Item.State.RegressState();
            //Assert
            Assert.True(Item.State.GetType() == typeof(TodoState));
        }
        [Fact]
        public void StateChangeToDone()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            //Assert
            Assert.Equal(Item.CompletedOn, DateOnly.FromDateTime(DateTime.Now));
            Assert.True(Item.State.GetType() == typeof(DoneState));
        }
        [Fact]
        public void StateChangeFromTestedToReadyForTesting()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.RegressState();
            //Assert
            Assert.True(Item.State.GetType() == typeof(ReadyForTestingState));
        }
        [Fact]
        public void StateChangeFromDoneToToDo()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.RegressState();
            //Assert
            Assert.Null(Item.CompletedOn);
            Assert.True(Item.State.GetType() == typeof(TodoState));
        }
        [Fact]
        public void StateChangeDoneNextStateFail()
        {
            //Act
            Item.AssignDeveloper(Dev);
            foreach (var a in Activites)
            {
                a.IsFinished = true;
            }
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            Action act = () => Item.State.NextState();
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(() => act());
            //Assert
            Assert.Equal(Item.CompletedOn, DateOnly.FromDateTime(DateTime.Now));
            Assert.Equal("There is no next state", e.Message);
        }
    }
}

using Softwareontwerp_en_architectuur.Domain.State;

namespace SOFATestsreal
{
    public class UnitTestState : StateTestBase
    {

        [Fact]
        public void StateChangeRegressToDoStateFail()
        {
            //Act
            Action act = () => Item.State.RegressState();
            //Assert
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("No earlier state exists", e.Message);
            Assert.IsType<TodoState>(Item.State);
        }
        [Fact]
        public void StateChangeOnDeveloperAssigning()
        {
            //Act
            Item.AssignDeveloper(Dev);
            //Assert
            Assert.Equal(Item.Developer, Dev);
            Assert.IsType<DoingState>(Item.State);
        }
        [Fact]
        public void StateChangeToReadyForTestingFail()
        {
            //Act
            Item.AssignDeveloper(Dev);
            Action act = () => Item.State.NextState();
            //Assert
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Not all activities are finished", e.Message);
        }
        [Fact]
        public void StateChangeToReadyForTestingSucces()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            //Act
            Item.State.NextState();
            //Assert
            Assert.IsType<ReadyForTestingState>(Item.State);
        }
        [Fact]
        public void StateChangeRegressToToDo()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            Item.State.NextState();
            //Act
            Item.State.RegressState();
            //Assert
            Assert.IsType<TodoState>(Item.State);
        }
        [Fact]
        public void StateChangeDoingToToDo()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            //Act
            Item.State.RegressState();
            //Assert
            Assert.Equal(Item.Developer, Dev);
            Assert.IsType<TodoState>(Item.State);
        }

        [Fact]
        public void StateChangeToReadyForTestingOnlySomeActivitiesFinished()
        {
            //Arrange
            Activites.First().IsFinished = true;
            Item.AssignDeveloper(Dev);
            //Act
            Action act = () => Item.State.NextState();
            //Assert
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Not all activities are finished", e.Message);
        }
        [Fact]
        public void StateChangeToTesting()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            Item.State.NextState();
            //Act
            Item.State.NextState();
            //Assert
            Assert.IsType<TestingState>(Item.State);
        }

        [Fact]
        public void StateChangeToTested()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            Item.State.NextState();
            Item.State.NextState();
            //Act
            Item.State.NextState();
            //Assert
            Assert.IsType<TestedState>(Item.State);
        }

        [Fact]
        public void StateChangeFromTestingToToDo()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            Item.State.NextState();
            Item.State.NextState();
            //Act
            Item.State.RegressState();
            //Assert
            Assert.IsType<TodoState>(Item.State);
        }
        [Fact]
        public void StateChangeToDone()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            //Act
            Item.State.NextState();
            //Assert
            Assert.Equal(Item.CompletedOn, DateOnly.FromDateTime(DateTime.Now));
            Assert.IsType<DoneState>(Item.State);
        }
        [Fact]
        public void StateChangeFromTestedToReadyForTesting()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            //Act
            Item.State.RegressState();
            //Assert
            Assert.IsType<ReadyForTestingState>(Item.State);
        }
        [Fact]
        public void StateChangeFromDoneToToDo()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            //Act
            Item.State.RegressState();
            //Assert
            Assert.Null(Item.CompletedOn);
            Assert.IsType<TodoState>(Item.State);
        }
        [Fact]
        public void StateChangeDoneNextStateFail()
        {
            //Arrange
            Item.AssignDeveloper(Dev);
            Activites.Select(a => { a.IsFinished = true; return a; }).ToList();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            Item.State.NextState();
            //Act
            Action act = () => Item.State.NextState();
            //Assert
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal(Item.CompletedOn, DateOnly.FromDateTime(DateTime.Now));
            Assert.Equal("There is no next state", e.Message);
        }
    }
}

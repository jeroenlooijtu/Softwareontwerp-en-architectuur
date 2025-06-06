using Softwareontwerp_en_architectuur.Domain;
using Softwareontwerp_en_architectuur.Domain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFATestsreal
{
    public class UnitTestProjects
    {
        [Fact]
        public void testAddFinishedSprintSucces()
        {
            //Arrange
            ReviewSprint sprint = new ReviewSprint(new DateOnly(2020, 12, 25), new DateOnly(2021, 1, 23));
            Project project = new Project("Main project", "The mainj project", new DateOnly(2021, 1, 10));

            project.CurrentSprint = sprint;
            sprint.State = new DoneSprintState();

            //Act
            project.AddFinishedSprint();

            //Assert
            Assert.True(project.DoneSprints.Contains(sprint));
            Assert.True(project.CurrentSprint == null);
        }

        [Fact]
        public void testAddFinishedSprintFail()
        {
            //Arrange
            ReviewSprint sprint = new ReviewSprint(new DateOnly(2020, 12, 25), new DateOnly(2021, 1, 23));
            Project project = new Project("Main project", "The mainj project", new DateOnly(2021, 1, 10));

            project.CurrentSprint = sprint;

            //Act
            Action act = () => project.AddFinishedSprint();

            //Assert
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Can't add a not finished sprint to the finished sprint list", e.Message);
        }
        [Fact]
        public void testAddBacklogItem()
        {
            //Arrange
            ReviewSprint sprint = new ReviewSprint(new DateOnly(2020, 12, 25), new DateOnly(2021, 1, 23));
            Project project = new Project("Main project", "The mainj project", new DateOnly(2021, 1, 10));
            Backlog_Item item = new Backlog_Item("Make work", "Make sure this method works", "It works");
            //Act
            project.AddBacklogItem(item);
            //Assert
            Assert.True(project.Backlog.Contains(item));
            Assert.Equal(item.Project, project);
        }
        [Fact]
        public void testAssignDeveloperSucces()
        {
            //Arrange
            ReviewSprint sprint = new ReviewSprint(new DateOnly(2020, 12, 25), new DateOnly(2021, 1, 23));
            Project project = new Project("Main project", "The mainj project", new DateOnly(2021, 1, 10));
            Backlog_Item item = new Backlog_Item("Make work", "Make sure this method works", "It works"); 
            Developer dev = new Developer();
            //Act
            project.AddBacklogItem(item);
            project.AddDeveloper(dev);
            item.AssignDeveloper(dev);
            //Assert
            Assert.Equal(item.Developer, dev);
        }
        [Fact]
        public void TestAssignDeveloperFail()
        {
            ReviewSprint sprint = new ReviewSprint(new DateOnly(2020, 12, 25), new DateOnly(2021, 1, 23));
            Project project = new Project("Main project", "The mainj project", new DateOnly(2021, 1, 10));
            Backlog_Item item = new Backlog_Item("Make work", "Make sure this method works", "It works");
            Developer dev = new Developer();
            //Act
            project.AddBacklogItem(item);

            Action act = () => item.AssignDeveloper(dev);
            InvalidOperationException e = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal("Developer not in the project", e.Message);
        }
    }
}

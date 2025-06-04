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
    }
}

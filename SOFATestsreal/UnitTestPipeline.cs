using Softwareontwerp_en_architectuur.Domain.SprintRelease;

namespace SOFATestsreal;

public class UnitTestPipeline : StateTestBase
{
    [Fact]
    public void TestPipelineAssignToDeploySprint()
    {
        //Arrange

        //Act
        DeploySprint dpSprint = new DeploySprint(pipeline);
        //Assert
        Assert.Equal(pipeline, dpSprint.pipeline);
    }

    [Fact]
    public void TestPipelineExecute()
    {
        //Arrange
        DeploySprint dpSprint = new DeploySprint(pipeline);
        using var sw = new StringWriter();
        Console.SetOut(sw);
        //Act
        dpSprint.Release();
        String x = sw.ToString().Replace("\r\n", "").Trim();
        //Assert
        Assert.Equal("BuildingAnalyzingDeployingPackagingSourcingTestingUtilizing", x);
    }
}
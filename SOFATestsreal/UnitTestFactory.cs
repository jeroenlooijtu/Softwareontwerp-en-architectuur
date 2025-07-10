using Softwareontwerp_en_architectuur.Domain;
using Softwareontwerp_en_architectuur.Domain.Factory;

namespace SOFATestsreal;

public class UnitTestFactory : StateTestBase
{
    [Fact]
    public void CreatePdfRapport()
    {
        //Arrange
        Sprint sprint = new Sprint(new DateOnly(2025, 12, 25), new DateOnly(2026, 1, 23));
        //Act
        PdfRapportage rapport = Factory.CreatePdfRapportage(sprint, "Company name", "Product name");
        Assert.NotNull(rapport);
        
    }

    [Fact]
    public void CreatePngRapport()
    {
        //Arrange
        Sprint sprint = new Sprint(new DateOnly(2025, 12, 25), new DateOnly(2026, 1, 23));
        //Act
        PngRapportage rapport = Factory.CreatePngRapportage(sprint, "Company name", "Product name");
        Assert.NotNull(rapport);
    }
}
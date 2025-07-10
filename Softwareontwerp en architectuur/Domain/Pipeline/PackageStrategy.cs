namespace Softwareontwerp_en_architectuur.Domain.Pipeline;

public class PackageStrategy : IPipelineStrategy
{
    public void Execute()
    {
        System.Console.WriteLine("Packaging");
    }
}
namespace Softwareontwerp_en_architectuur.Domain.Pipeline;

public class SourceStrategy : IPipelineStrategy
{
    public void Execute()
    {
        System.Console.WriteLine("Sourcing");
    }
}
namespace Softwareontwerp_en_architectuur.Domain.Pipeline;

public class TestStrategy : IPipelineStrategy
{
    public void Execute()
    {
        System.Console.WriteLine("Testing");
    }
}
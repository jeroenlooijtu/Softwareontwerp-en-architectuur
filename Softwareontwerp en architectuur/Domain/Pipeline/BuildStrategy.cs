using Softwareontwerp_en_architectuur.Domain.Pipeline;

public class BuildStrategy : IPipelineStrategy
{
    public void Execute()
    {
        System.Console.WriteLine("Building");
    }
}
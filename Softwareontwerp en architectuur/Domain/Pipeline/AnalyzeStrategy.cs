namespace Softwareontwerp_en_architectuur.Domain.Pipeline;

public class AnalyzeStrategy : IPipelineStrategy
{
    public void Execute()
    {
        System.Console.WriteLine("Analyzing");
    }
}
namespace Softwareontwerp_en_architectuur.Domain.Pipeline;

public class UtilityStrategy : IPipelineStrategy
{
    public void Execute()
    {
        System.Console.WriteLine("Utilizing");    }
}
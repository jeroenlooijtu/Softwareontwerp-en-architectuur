using Softwareontwerp_en_architectuur.Domain.Pipeline;

public class PipelineAction : IPipelineStep
{
    private string Name;
    private IPipelineStrategy Strategy;

    public PipelineAction(string name, IPipelineStrategy strategy)
    {
        this.Name = name;
        this.Strategy = strategy;
    }

    public void Execute()
    {
        Strategy.Execute();
    }
}
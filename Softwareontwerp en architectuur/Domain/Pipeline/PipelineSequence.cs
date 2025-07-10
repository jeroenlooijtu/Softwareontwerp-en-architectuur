namespace Softwareontwerp_en_architectuur.Domain.Pipeline;

public class PipelineSequence : IPipelineStep
{
    private List<IPipelineStep> Steps = new List<IPipelineStep>();

    public PipelineSequence()
    {
        
    }
    public void Execute()
    {
        foreach (var step in Steps)
        {
            step.Execute();
        }
    }

    public void Add(IPipelineStep step)
    {
        this.Steps.Add(step);
    }
}
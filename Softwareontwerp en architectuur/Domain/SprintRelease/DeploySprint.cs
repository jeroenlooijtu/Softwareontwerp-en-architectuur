using Softwareontwerp_en_architectuur.Domain.Pipeline;

namespace Softwareontwerp_en_architectuur.Domain.SprintRelease;

public class DeploySprint : ISprintRelease
{
    public PipelineSequence pipeline;

    public DeploySprint(PipelineSequence pipeline)
    {
        this.pipeline = pipeline;
    }
    public void Release()
    {
        pipeline.Execute();
    }

    public void addPipelineStep(IPipelineStep step)
    {
        pipeline.Add(step);
    }
}
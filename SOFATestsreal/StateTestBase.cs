using Softwareontwerp_en_architectuur.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softwareontwerp_en_architectuur.Domain.Factory;
using Softwareontwerp_en_architectuur.Domain.Pipeline;

namespace SOFATestsreal
{
    public abstract class StateTestBase : IDisposable
    {
        public Project Project { get; set; }
        public Developer Dev { get; set; }
        public BacklogItem Item { get; set; }
        public List<Activity> Activites { get; set; } = new List<Activity>();
        public PipelineSequence pipeline { get; set; }
        public PostWrapper postWrapper { get; set; }
        public IPost post { get; set; }
        public Softwareontwerp_en_architectuur.Domain.Thread Thread { get; set; }
        public Discussion Discussion { get; set; }
        
        public RapportageFactory Factory { get; set; }

        protected StateTestBase()
        {
            Project = new Project("Main project", "The main project", new DateOnly(2021, 1, 10));
            Dev = new Developer();
            Item = new BacklogItem("Make work", "Make sure this method works", "It works");
            Project.AddBacklogItem(Item);
            Project.AddDeveloper(Dev);
            Activity act1 = new Activity("Make workx", "Making it extra work", Dev, 2);
            Activity act2 = new Activity("Make workx", "Making it extra work", Dev, 4);
            Activity act3 = new Activity("Make workx", "Making it extra work", Dev, 6);
            Activites.Add(act1);
            Activites.Add(act2);
            Activites.Add(act3);
            Item.Activities.Add(act1);
            Item.Activities.Add(act2);
            Item.Activities.Add(act3);
            pipeline = new PipelineSequence();
            PipelineAction pipelineAction1 = new PipelineAction("Build", new BuildStrategy());
            PipelineAction pipelineAction2 = new PipelineAction("Analyze", new AnalyzeStrategy());
            PipelineAction pipelineAction3 = new PipelineAction("Deploy", new DeployStrategy());
            PipelineAction pipelineAction4 = new PipelineAction("Package", new PackageStrategy());
            PipelineAction pipelineAction5 = new PipelineAction("Source", new SourceStrategy());
            PipelineAction pipelineAction6 = new PipelineAction("Test", new TestStrategy());
            PipelineAction pipelineAction7 = new PipelineAction("Utility", new UtilityStrategy());
            pipeline.Add(pipelineAction1);
            pipeline.Add(pipelineAction2);
            pipeline.Add(pipelineAction3);
            pipeline.Add(pipelineAction4);
            pipeline.Add(pipelineAction5);
            pipeline.Add(pipelineAction6);
            pipeline.Add(pipelineAction7);
            postWrapper = new PostWrapper(Dev, "I think this is, wrong");
            Discussion = new Discussion("The item that wasn't good", Item, postWrapper);
            Factory = new RapportageFactory();
        }

        public void Dispose()
        {
            return;
        }
    }
}
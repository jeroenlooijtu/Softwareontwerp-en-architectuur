using Softwareontwerp_en_architectuur.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFATestsreal
{
    public abstract class StateTestBase : IDisposable
    {
        public Project Project { get; set; }
        public Developer Dev {  get; set; }
        public BacklogItem Item { get; set; }
        public List<Activity> Activites { get; set; } = new List<Activity>();
        protected StateTestBase()
        {
            Project =  new Project("Main project", "The main project", new DateOnly(2021, 1, 10));
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
        }
        public void Dispose()
        {
            return;
        }
    }
}

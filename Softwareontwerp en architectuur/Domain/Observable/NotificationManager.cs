using Softwareontwerp_en_architectuur.Domain.State;
using System;

namespace Softwareontwerp_en_architectuur.Domain.Observable
{
    public class NotificationManager
    {
        

        Dictionary<BacklogState, List<IObserver>> observers = new Dictionary<BacklogState, List<IObserver>>();

        public void Update(BacklogState state, string message)
        {

        }
        public void AddObserver(BacklogState state, IObserver observer)
        {
            observers[state].Add(observer);
        }
    }
}

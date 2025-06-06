namespace Softwareontwerp_en_architectuur.Domain.State
{
    public abstract class ActivityState
    {
        public Activity Activity { get; set; }
        public ActivityState(Activity activity)
        {
            this.Activity = activity;
        }

        public abstract void FinishActivity();
        public abstract void UndoActivityFinish();
    }
}

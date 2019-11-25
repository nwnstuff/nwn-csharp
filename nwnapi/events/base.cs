using System.Collections.Generic;

namespace NWN.Events
{
    public abstract class NWNXEvent
    {
        public virtual bool Skippable => false;   
        public bool Skipped {get; protected set;}
        public string EventType {get; protected set;}

        protected static uint GetEventObject(string eventDataTag) =>
            NWNX.Object.StringToObject(NWNX.Events.GetEventData(eventDataTag));
        
        public void Skip() 
        {
            if (!Skippable) return;
            NWNX.Events.SkipEvent();
            Skipped = true;
        }
    }

    public class Lazy<T>
    {
        public delegate object LazyFetchDelegate();
        private bool IsFetched = false;
        private T val;
        private LazyFetchDelegate fetcher;
        public T Value
        {
            get
            {
                if (!IsFetched){
                    val = (T)fetcher();
                    IsFetched = true;
                }
                return val;
            }
        }
        public Lazy(LazyFetchDelegate func) { fetcher = func; }
    }
}
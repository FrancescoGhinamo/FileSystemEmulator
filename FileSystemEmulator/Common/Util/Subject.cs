using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemEmulator.Common.Util
{
    /// <summary>
    /// Observable subject in a Observer Design Pattern implementation
    /// </summary>
    public abstract class Subject
    {
        /// <summary>
        /// Observers linked to this object
        /// </summary>
        private List<IObserver> Observers;

        /// <summary>
        /// True if the object has changed
        /// </summary>
        private bool Changed;

        /// <summary>
        /// Constructor
        /// </summary>
        public Subject()
        {
            Observers = new List<IObserver>();
        }


        /// <summary>
        /// Adds an observer to the object
        /// </summary>
        /// <param name="obs">Observer to link</param>
        public void AddObserver(IObserver obs)
        {
            Observers.Add(obs);
        }

        /// <summary>
        /// Removes the specified observer
        /// </summary>
        /// <param name="obs">Observer to remove</param>
        public void RemoveObserver(IObserver obs)
        {
            Observers.Remove(obs);
        }

        /// <summary>
        /// Sets the object has changed
        /// </summary>
        public void SetChanged()
        {
            Changed = true;
        }

        /// <summary>
        /// Notifies all the observers if the object has changed
        /// </summary>
        /// <param name="obj">Object to describe the changings</param>
        public void NotifyObserves(Object obj)
        {
            if(Changed)
            {
                foreach(IObserver i in Observers)
                {
                    i.Update(this, obj);
                }
                Changed = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Domain.Observers
{
    public interface IObserver
    {
        void Update();
    }

    public class PatientObserver : IObserver
    {
        public void Update()
        {
            // Perform actions when patient data changes
        }
    }

    public class PatientSubject
    {
        private List<IObserver> _observers = new();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Allows choosing different notifications at runtime.
namespace Healthcare.Application.Strategies
{
    public interface INotificationStrategy
    {
        void SendNotification(string message);
    }

    public class EmailNotification : INotificationStrategy
    {
        public void SendNotification(string message)
        {
            // Send email logic
        }
    }

    public class SmsNotification : INotificationStrategy
    {
        public void SendNotification(string message)
        {
            // Send SMS logic
        }
    }

    public class NotificationContext
    {
        private INotificationStrategy _strategy;

        public void SetStrategy(INotificationStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy(string message)
        {
            _strategy.SendNotification(message);
        }
    }
}

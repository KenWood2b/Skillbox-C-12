using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesWpfApp
{
    public abstract class Worker
    {
        public event Action<LogEntry> OnOperationPerformed;

        public abstract void EditClient(Client client, string field, string newValue);

        protected void LogAction(string action, string details)
        {
            OnOperationPerformed?.Invoke(new LogEntry
            {
                Timestamp = DateTime.Now,
                Action = action,
                PerformedBy = GetType().Name,
                Details = details
            });
        }
    }
}

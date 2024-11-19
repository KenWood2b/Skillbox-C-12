using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesWpfApp
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public string PerformedBy { get; set; }
        public string Details { get; set; }

        public override string ToString()
        {
            return $"[{Timestamp}] {PerformedBy}: {Action} — {Details}";
        }
    }
}

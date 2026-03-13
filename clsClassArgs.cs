using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraficLightProj
{
    public class clsClassArgs
    {
        public class StatusChangedEventArgs : EventArgs
        {
            public string NewStatus { get; private set; } = string.Empty;
            public byte Duration { get; private set; } = 10;

            public StatusChangedEventArgs(string newStatus, byte duration)
            {
                NewStatus = newStatus;
                Duration = duration;
            }
        }
    }
}

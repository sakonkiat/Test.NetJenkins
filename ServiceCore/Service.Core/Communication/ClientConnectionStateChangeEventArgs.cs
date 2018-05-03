using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Communication
{
    public class ClientConnectionStateChangeEventArgs : EventArgs
    {
        public ConnectionState  ConnectionSate { get; set; }
    }
}

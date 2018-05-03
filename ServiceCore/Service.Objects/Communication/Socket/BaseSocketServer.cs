using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service.Objects.Communication
{
    public abstract class BaseSocketServer
    {
        public abstract void Start();

        public abstract void StartAsync();

        protected abstract void ProcessAsync();

        protected abstract void Process();

        public abstract void Stop();
    }
}

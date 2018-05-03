using Service.Core;
using Service.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Factory.Communication.Sockets
{
    public class SocketBusinessLogic : ILogic
    {
        ISocketSender _sender;
        ISocketReceiver _receiver;
        string _s, _r;

        public SocketBusinessLogic(ISocketSender sender, ISocketReceiver receiver)
        {
            _sender = sender;
            _receiver = receiver;
        }

        public bool Process()
        {
            _s = "Business flow...";
            Console.WriteLine("Send : {0}", _s);
            _sender.Send(_s);
            Console.WriteLine("Receive : {0}", _receiver.Read());

            return false;
        }
    }
}

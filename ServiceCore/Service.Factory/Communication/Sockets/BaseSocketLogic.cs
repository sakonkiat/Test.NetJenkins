using Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service.Factory.Communication.Sockets
{
    public class BaseSocketLogic : ILogic
    {
        ILogic _logic;
        Socket _client;
        private bool isComplete = false;

        public BaseSocketLogic(ILogic logic, Socket client)
        {
            _client = client;
            _logic = logic;
        }

        public bool Process()
        {
            while (true)
            {
                if (_client != null && !_client.Connected)
                {
                    break;
                }
                else if (_client != null && _client.Connected)
                {
                    isComplete = _logic.Process();
                }

                if (isComplete) break;
            }

            return isComplete;
        }
    }
}

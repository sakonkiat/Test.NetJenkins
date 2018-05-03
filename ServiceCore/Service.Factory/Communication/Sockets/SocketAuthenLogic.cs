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
    public class SocketAuthenLogic : ILogic
    {
        ISocketSender _sender;
        ISocketReceiver _receiver;
        int _step = 1;
        bool result = false;

        public SocketAuthenLogic(ISocketSender sender, ISocketReceiver receiver)
        {
            _sender = sender;
            _receiver = receiver;
        }

        public bool Process()
        {

            switch (_step)
            {
                case 1:
                    _sender.Send("=== Authentication ===\r\nUsername : ");
                    Validate(_receiver.Read());
                    break;
                case 2:
                    _sender.Send("Password : ");
                    if (Validate(_receiver.Read()))
                    {
                        result = true;
                    }
                    break;
                default:
                    break;
            }


            return result;
        }

        private bool Validate(string input)
        {
            bool r = false;
            switch (_step)
            {
                case 1:
                    if (input.ToLower() == "ton")
                    {
                        r = true;
                        _step++;
                    }
                    break;
                case 2:
                    if (input.ToLower() == "1234")
                    {
                        r = true;
                    }
                    break;
                default:
                    break;
            }

            return r;
        }
    }
}

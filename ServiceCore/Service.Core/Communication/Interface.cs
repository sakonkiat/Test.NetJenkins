using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Communication
{
    public interface ISocketClientConnection : IDisposable
    {
        ConnectionState ConnectionState { get; }
        Socket Client { get; }
        void Connect();
        void Disconnect();
    }

    public interface ISocketReceiver
    {
        string Read();
        string Read(Encode endcode);      
    }

    public interface ISocketSender
    {
        int Send(string text);
        int Send(string text, Encode encode);
    }

    public interface ISocketServerConnection
    {
        bool ClientConnected { get; }
        ListenState ListenState { get; }
        ServerState ServerState { get; }

        void Initiallize();
        Socket StartListen();
        void Stop();

        event EventHandler<ClientConnectionStateChangeEventArgs> ClientConnectionStateChange;
    }
}

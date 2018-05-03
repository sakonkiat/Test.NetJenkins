using Service.Core;
using Service.Core.Communication;
using Service.Objects.Communication;
using Service.Objects.Communication.Socket;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Object.Communication
{
    public class SocketServer : BaseSocketServer, IInitializer
    {
        private ISocketServerConnection _con;
        //ISocketReceiver<string> _receiver;
        //ISocketSender<string> _sender;
        private Socket _client;
        private string _host;
        private int _port;

        public ISocketServerConnection Connection => _con;
        public ListenState ListenState => _con.ListenState;
        public ServerState ServerState => _con.ServerState;
        public bool ClientConnected => _con.ClientConnected;

        public SocketServer(string host, int port, int listenCount)
        {
            _host = host;
            _port = port;
            _con = new SocketServerConnection(
                host,
                port,
                listenCount);

            Initialize();
        }

        public void Initialize()
        {
            _con.ClientConnectionStateChange += _con_ClientConnectionStateChange;
        }

        public override void Start()
        {
            Process();
        }

        public override async void StartAsync()
        {
            await Task.Run(() =>
            {
                ProcessAsync();
            });
        }

        public override void Stop()
        {
            _con.Stop();
        }

        protected override async void ProcessAsync()
        {
            await Task.Run(() =>
            {
                _client = _con.StartListen();

                SendReceive(_client);
            });
        }

        protected override void Process()
        {
            _client = _con.StartListen();
            SendReceive(_client);
        }

        private void SendReceive(Socket client)
        {
            ISocketReceiver<string> _receiver = new SocketReceiver(_client, 1024, 128);
            ISocketSender<string> _sender = new SocketSender(_client);

            while (true)
            {
                if (client != null && !client.Connected)
                {
                    break;
                }
                else if (client != null && client.Connected)
                {
                    _sender.Send("", new ServerSenderAuthenticationLogic());
                    _receiver.Read(new ServerReceiverAuthenticationLogic());
                }

                Thread.Sleep(1000);
            }
        }

        #region Events

        private void _con_ClientConnectionStateChange(object sender, ClientConnectionStateChangeEventArgs e)
        {
            if (e.ConnectionSate == ConnectionState.Close && _con.ServerState == ServerState.Started) ProcessAsync();
        }

        #endregion
    }
}

using Service.Core;
using Service.Core.Communication;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Factory.Communication.Sockets
{
    public class SocketServer : BaseSocketServer, IInitializer
    {
        private ISocketServerConnection _con;
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
                SendReceive();
            });
        }

        protected override void Process()
        {
            _client = _con.StartListen();
            SendReceive();
        }

        protected override void SendReceive()
        {
            ISocketSender sender = new SocketSender(_client);
            ISocketReceiver receiver = new SocketReceiver(_client);
           
            ILogic authen = new BaseSocketLogic(new SocketAuthenLogic(sender, receiver), _client);
            ILogic biz = new BaseSocketLogic(new SocketBusinessLogic(sender, receiver), _client);
            LogicFlowModel[] logics =
                {
                    //new LogicFlowModel { Logic = authen, Seq = 3 },
                    new LogicFlowModel { Logic = biz, Seq = 5 }
                };

            BaseLogicFlow logicMgr = new SocketLogicFlow(logics);
            logicMgr.Execute();
        }

        #region Events

        private void _con_ClientConnectionStateChange(object sender, ClientConnectionStateChangeEventArgs e)
        {
            if (e.ConnectionSate == ConnectionState.Close && _con.ServerState == ServerState.Started) ProcessAsync();
        }

        #endregion
    }
}

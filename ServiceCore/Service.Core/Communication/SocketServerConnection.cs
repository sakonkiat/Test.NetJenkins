using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Core.Communication
{
    public class SocketServerConnection : ISocketServerConnection
    {
        private TcpListener _listener;
        private Socket _clientHandler;
        private IPEndPoint _ipEP;
        private IPAddress _ip;
        private ListenState _listenState;
        private ServerState _serverState;
        private CancellationTokenSource _cancelTask = new CancellationTokenSource();

        public event EventHandler<ClientConnectionStateChangeEventArgs> ClientConnectionStateChange;

        private int _port;
        private string _host;
        private int _listenCount;
        private bool _prevClientConnected = false;

        public bool ClientConnected => _clientHandler != null ? _clientHandler.Connected : false;

        public ListenState ListenState => _listenState;

        public ServerState ServerState => _serverState;

        #region "Constructor"

        public SocketServerConnection(IPEndPoint ipEP
                                , int listenCount = 0)
        {
            _listener = new TcpListener(ipEP);
            _listenCount = listenCount;

            Initiallize();
        }

        public SocketServerConnection(IPAddress ip
                                , int port
                                , int listenCount = 0)
        {
            _listener = new TcpListener(ip, port);
            _ip = ip;
            _port = port;
            _listenCount = listenCount;

            Initiallize();
        }

        public SocketServerConnection(string host
                                , int port
                                , int listenCount = 0)
        {
            _ipEP = new IPEndPoint(IPAddress.Parse(host), port);
            _listener = new TcpListener(_ipEP);
            _host = host;
            _port = port;
            _listenCount = listenCount;

            Initiallize();
        }


        #endregion

        public void Initiallize()
        {
            _listenState = ListenState.NoListen;
            _serverState = ServerState.Stopped;
        }

        public Socket StartListen()
        {
            try
            {
                _listener.Start(_listenCount);
                _serverState = ServerState.Started;
                _listenState = ListenState.Listen;
                _clientHandler = _listener.AcceptSocket();
                _listenState = ListenState.NoListen;
                _listener.Stop();

                OnClientConnectionStateChange(new ClientConnectionStateChangeEventArgs(), _cancelTask.Token);
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }

            finally
            {

            }

            return _clientHandler;
        }

        public void Stop()
        {
            if (_clientHandler != null)
            {
                _clientHandler.Shutdown(SocketShutdown.Both);
                _clientHandler.Disconnect(false);
                _clientHandler.Close();
                _clientHandler.Dispose();
            }

            if (_listener != null)
            {
                _listener.Stop();
            }

            _serverState = ServerState.Stopped;
            _cancelTask.Cancel();
        }

        #region "Events"        

        public async virtual void OnClientConnectionStateChange(ClientConnectionStateChangeEventArgs e, CancellationToken cancelToken)
        {
            await Task.Run(() =>
            {
                try
                {
                    while (true)
                    {                        
                        if (_clientHandler != null && (_clientHandler.Connected != _prevClientConnected))
                        {
                            _prevClientConnected = _clientHandler.Connected;
                            e.ConnectionSate = _clientHandler.Connected ? ConnectionState.Open : ConnectionState.Close;

                            if (ClientConnectionStateChange != null)
                            {
                                ClientConnectionStateChange(this, e);
                            }
                        }

                        cancelToken.ThrowIfCancellationRequested();
                        Thread.Sleep(1000);
                    }
                }
                catch (OperationCanceledException ex)
                {

                }
            }, cancelToken);
        }

        #endregion
    }
}

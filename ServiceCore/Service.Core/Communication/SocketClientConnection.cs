using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Communication
{
    public class SocketClientConnection : ISocketClientConnection
    {

        //private Socket _connection;
        private TcpClient _connection;
        private int _port;
        private string _host;
        private ConnectionState _conState;

        public ConnectionState ConnectionState
        {
            get
            {
                if (_connection != null && _connection.Client != null && _connection.Connected) _conState = ConnectionState.Open;
                else _conState = ConnectionState.Close;

                return _conState;
            }
        }

        public Socket Client => _connection != null && _connection.Client != null ? _connection.Client : null;

        //public Socket Socket { get { return _connection; } }

        public SocketClientConnection(string host, int port)
        {
            try
            {
                _host = host;
                _port = port;
                _connection = new TcpClient(host, port);                
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public virtual void Connect()
        {
            try
            {
                if (_host != "" || _port != 0)
                    _connection.Connect(_host, _port);
                else
                    throw new Exception("Must specify remote host.");
            }
            catch (SocketException ex)
            {

            }
            catch (ArgumentNullException ex)
            {

            }
            catch (ObjectDisposedException ex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        public virtual void Disconnect()
        {
            try
            {
                _connection.Close();
                //_connection.Dispose();
            }
            catch (PlatformNotSupportedException ex)
            {

            }
            catch (ObjectDisposedException ex)
            {


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

        }

        public void Dispose()
        {
            try
            {
                _connection.Close();
                //_connection.Dispose();
            }
            catch (PlatformNotSupportedException ex)
            {

            }
            catch (ObjectDisposedException ex)
            {


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
        }
    }
}

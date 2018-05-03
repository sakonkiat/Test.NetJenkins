using System;
using System.Net.Sockets;
using System.Text;

namespace Service.Core.Communication
{
    public class SocketSender : BaseSocketSender, ISocketSender
    {
        private IStringEncoder _stringEncoder;

        public SocketSender(Socket socket)
            : base(socket)
        {
            _stringEncoder = new StringEncoder();
        }

        /// <summary>
        /// Send string data to server
        /// </summary>
        /// <param name="text">String data</param>
        /// <returns>Return the data size send to server</returns>
        public int Send(string text)
        {
            byte[] _buffer;
            int _dataSize = 0;
            int availableDataSize = 0;

            //Encode input to byte array
            _buffer = Encoding.Default.GetBytes(text);
            _dataSize = _buffer.Length;

            //Send to server
            availableDataSize = base.Send(_buffer, _dataSize);

            return availableDataSize;
        }

        /// <summary>
        /// Send string data to server by specifc encode type
        /// </summary>
        /// <param name="text">String data</param>
        /// <param name="encode">Encode type</param>
        /// <returns>Return the data size send to server</returns>
        public int Send(string text, Encode encode)
        {
            byte[] _buffer;
            int _dataSize = 0;
            int availableDataSize = 0;

            //Encode input to byte array by specific encode type
            _buffer = _stringEncoder.GetBytes(text, encode);
            _dataSize = _buffer.Length;

            //Send to server
            availableDataSize = base.Send(_buffer, _dataSize);

            return availableDataSize;
        }
    }
}

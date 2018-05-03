using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Communication
{
    public class BaseSocketReceiver
    {        
        private Socket _reader;
        private byte[] _buffer;
        private int _receiveDataSize;

        public byte[] Buffer
        {
            get { return _buffer; }
            set { _buffer = value; }
        }

        public int ReceiveDataSize
        {
            get { return _receiveDataSize; }
            set { _receiveDataSize = value; }
        }

        public BaseSocketReceiver(Socket socket, int bufferSize = 1024, int receiveDataSize = 128)
        {
            _reader = socket;
            _buffer = new byte[bufferSize];
            _receiveDataSize = receiveDataSize;
        }

        /// <summary>
        /// Receive data of byte array from server
        /// </summary>
        /// <param name="buffer">Buffer size for read</param>
        /// <param name="dataSize">Data size read from server</param>
        /// <param name="socketFlags">Socket flags</param>
        /// <returns>Return the data read from server</returns>
        public virtual int Receive(byte[] buffer, int dataSize, SocketFlags socketFlags = SocketFlags.None)
        {
            int size = 0;

            try
            {
                if (dataSize > buffer.Length) dataSize = buffer.Length;
                size = _reader.Receive(buffer, dataSize, socketFlags);
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {

            }

            return size;
        }
    }
}

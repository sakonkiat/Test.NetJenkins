using System;
using System.Net.Sockets;
using System.Text;

namespace Service.Core.Communication
{
    public class SocketReceiver : BaseSocketReceiver, ISocketReceiver
    {
        private ILogger _log = Log4Net.CreateInstance("SocketLog");
        private IStringEncoder _stringEncoder;

        /// <summary>
        /// Initial object
        /// </summary>
        /// <param name="con">Socket Connection</param>
        /// <param name="bufferSize">Buffer size</param>
        /// <param name="receiveDataSize">Data size read from server</param>
        public SocketReceiver(Socket socket, int bufferSize = 1024, int receiveDataSize = 128)
            : base(socket, bufferSize, receiveDataSize)
        {
            _stringEncoder = new StringEncoder();

        }

        /// <summary>
        /// Read data from server
        /// </summary>
        /// <returns>Return the data read from server</returns>
        public string Read()
        {
            string text = "";

            try
            {
                //Receive data from server
                int availableDataSize = base.Receive(base.Buffer, base.ReceiveDataSize);

                //Get available data
                byte[] resizedBuffer = base.Buffer;
                Array.Resize(ref resizedBuffer, availableDataSize);

                //Encode text
                text = Encoding.Default.GetString(resizedBuffer);
            }
            catch (ArgumentOutOfRangeException ex)
            {

            }
            catch (Exception ex)
            {

            }           

            return text;
        }

        /// <summary>
        /// Read data from server by specific encode type
        /// </summary>
        /// <param name="encode">Encode type</param>
        /// <returns>Return the data read from server</returns>
        public string Read(Encode encode)
        {
            int availableDataSize = 0;

            //Receive data from server
            availableDataSize = base.Receive(base.Buffer, base.ReceiveDataSize);

            //Get available data
            byte[] resizedBuffer = base.Buffer;
            Array.Resize(ref resizedBuffer, availableDataSize);

            //Encode text by specific type
            string text = _stringEncoder.GetString(resizedBuffer, encode);

            return text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Communication
{
    public class BaseSocketSender
    {
        private Socket _sender;

        public BaseSocketSender(Socket socket)
        {
            _sender = socket;
        }

        /// <summary>
        /// Send data of byte array to server
        /// </summary>
        /// <param name="buffer">Buffer store data</param>
        /// <param name="dataSize">Send data size</param>
        /// <param name="socketFlags">Socket Flags</param>
        /// <returns>Return the data size send to server</returns>
        public virtual int Send(byte[] buffer, int dataSize, SocketFlags socketFlags = SocketFlags.None)
        {
            int size = 0;

            try
            {
                if (dataSize > buffer.Length) throw new Exception("Parameter 'dataSize' not over buffer size.");

                //If no data will set space, 32 is space in ascii
                if (buffer.Length == 0)
                {
                    buffer = new byte[1] { 32 };
                    dataSize = buffer.Length;
                }

                size = _sender.Send(buffer, dataSize, socketFlags);
            }
            catch (Exception ex)
            {

            }

            return size;
        }
    }
}

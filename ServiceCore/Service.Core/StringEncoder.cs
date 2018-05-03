using System.Text;

namespace Service.Core
{
    public class StringEncoder : IStringEncoder
    {
        public byte[] GetBytes(string text,Encode encode)
        {
            byte[] buffer;

            switch (encode)
            {
                case Encode.Default:
                    buffer = Encoding.Default.GetBytes(text);
                    break;
                case Encode.ASCII:
                    buffer = Encoding.ASCII.GetBytes(text);
                    break;
                case Encode.BigEndianUnicode:
                    buffer = Encoding.BigEndianUnicode.GetBytes(text);
                    break;
                case Encode.Unicode:
                    buffer = Encoding.Unicode.GetBytes(text);
                    break;
                case Encode.UTF7:
                    buffer = Encoding.UTF7.GetBytes(text);
                    break;
                case Encode.UTF8:
                    buffer = Encoding.UTF8.GetBytes(text);
                    break;
                case Encode.UTF32:
                    buffer = Encoding.UTF32.GetBytes(text);
                    break;
                default:
                    buffer = Encoding.Default.GetBytes(text);
                    break;
            }

            return buffer;
        }

        public string GetString(byte[] bufferData, Encode encode)
        {
            string result = "";

            switch (encode)
            {
                case Encode.Default:
                    result = Encoding.Default.GetString(bufferData);
                    break;
                case Encode.ASCII:
                    result = Encoding.ASCII.GetString(bufferData);
                    break;
                case Encode.BigEndianUnicode:
                    result = Encoding.BigEndianUnicode.GetString(bufferData);
                    break;
                case Encode.Unicode:
                    result = Encoding.Unicode.GetString(bufferData);
                    break;
                case Encode.UTF7:
                    result = Encoding.UTF7.GetString(bufferData);
                    break;
                case Encode.UTF8:
                    result = Encoding.UTF8.GetString(bufferData);
                    break;
                case Encode.UTF32:
                    result = Encoding.UTF32.GetString(bufferData);
                    break;
                default:
                    result = Encoding.Default.GetString(bufferData);
                    break;
            }

            return result;
        }
    }
}

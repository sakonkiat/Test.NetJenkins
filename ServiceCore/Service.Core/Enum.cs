using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{

    public enum ConnectionState
    {
        Open = 1,
        Close
    }

    public enum Encode
    {
        Default = 1,
        ASCII,
        BigEndianUnicode,
        Unicode,
        UTF7,
        UTF8,
        UTF32
    }

    public enum ListenState
    {
        Listen = 1,
        NoListen
    }

    public enum ServerState
    {
        Started = 1,
        Stopped
    }

    public enum LogType
    {
        Fatal = 1,
        Error,
        Warn,
        Info,
        Debug
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public interface ICondition
    {
        void PreConditionProcess();
        void PostConditionProcess();
    }

    public interface ICondition<T>
    {
        T PreConditionProcess(T input);
        T PostConditionProcess(T input);
    }

    public interface ILogic
    {
        bool Process();
    }

    public interface IConnection
    {
        void Connect();
        void Disconnect();
        ConnectionState ConnectionState { get; }
    }

    public interface IInitializer
    {
        void Initialize();
    }

    public interface IReader
    {
        string Read();
        string Read(Encode encode);
    }

    public interface IReceiver
    {
        int Receive();
    }

    public interface ISender
    {
        int Send();
    }

    public interface IStringEncoder
    {
        string GetString(byte[] bufferData, Encode encode);
        byte[] GetBytes(string text, Encode encode);
    }

    public interface IWriter
    {
        int Write(string text);
        int Write(string text, Encode encode);
    }

    public interface ILogger
    {
        void Debug(object message);
        void Debug(object message, Exception ex);
        void Info(object message);
        void Info(object message, Exception ex);
        void Warn(object message);
        void Warn(object message, Exception ex);
        void Error(object message);
        void Error(object message, Exception ex);
        void Fatal(object message);
        void Fatal(object message, Exception ex);
    }
}

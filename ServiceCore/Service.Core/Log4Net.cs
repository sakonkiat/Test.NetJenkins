using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Core
{
    public class Log4Net : ILogger
    {
        private static Log4Net _instance;
        private static ILog _log;

        public static Log4Net CreateInstance()
        {
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            if (_instance == null)
                _instance = new Log4Net();
            return _instance;
        }

        public static Log4Net CreateInstance(string logName)
        {
            _log = LogManager.GetLogger(logName);

            if (_instance == null)
                _instance = new Log4Net();
            return _instance;
        }

        public void Debug(object message)
        {
            _log.Debug(message);
        }

        public void Debug(object message, Exception ex)
        {
            _log.Debug(message, ex);
        }

        public void Error(object message)
        {
            _log.Error(message);
        }

        public void Error(object message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void Fatal(object message)
        {
            _log.Fatal(message);
        }

        public void Fatal(object message, Exception ex)
        {
            _log.Fatal(message, ex);
        }

        public void Info(object message)
        {
            _log.Info(message);
        }

        public void Info(object message, Exception ex)
        {
            _log.Info(message, ex);
        }

        public void Warn(object message)
        {
            _log.Warn(message);
        }

        public void Warn(object message, Exception ex)
        {
            _log.Warn(message, ex);
        }
    }
}

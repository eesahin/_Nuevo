using _Nuevo.Business.Interfaces;
using NLog;

namespace _Nuevo.Business.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        public NLogLogger()
        {
        }
        public void Information(string message)
        {
            Logger.Info(message);
        }
        public void Warning(string message)
        {
            Logger.Warn(message);
        }
        public void Debug(string message)
        {
            Logger.Debug(message);
        }
        public void Error(string message)
        {
            Logger.Error(message);
        }
    }
}

using System;

namespace ShootArena.Infrastructure.Modules.CustomLogger
{
    public interface ICustomLoggerModule
    {
        void Log(object message);
        void Log(string category, object message);
        void LogFormat(string format, params object[] args);
        void LogFormat(string category, string format, params object[] args);
        void LogWarning(object message);
        void LogWarning(string category, object message);
        void LogWarningFormat(string format, params object[] args);
        void LogWarningFormat(string category, string format, params object[] args);
        void LogError(object message);
        void LogError(string category, object message);
        void LogErrorFormat(string format, params object[] args);
        void LogErrorFormat(string category, string format, params object[] args);
        void LogException(Exception exception);
        void LogException(string category, Exception exception);
    }
}
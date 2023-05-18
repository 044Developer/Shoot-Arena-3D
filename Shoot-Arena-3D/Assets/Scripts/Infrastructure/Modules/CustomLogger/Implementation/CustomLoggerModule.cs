using System;
using UnityEngine;

namespace ShootArena.Infrastructure.Modules.CustomLogger.Implementation
{
    public class CustomLoggerModule : ICustomLoggerModule
    { 
        private const string INFO_COLOR = nameof(Color.white);
        private const string WARNING_COLOR = nameof(Color.yellow);
        private const string ERROR_COLOR = nameof(Color.red);

        private bool _isDebugBuild = false;

        public CustomLoggerModule()
        {
#if UNITY_EDITOR
            _isDebugBuild = true;
#else
            _isDebugBuild = false;  
#endif
        }

        public void Log(object message)
        {
            if (!_isDebugBuild)
                return;
            
            Debug.Log(FormatMessage(INFO_COLOR, message));
        }

        public void Log(string category, object message)
        {
            if (!_isDebugBuild)
                return;

            Debug.Log(FormatMessageWithCategory(INFO_COLOR, category, message));
        }

        public void LogFormat(string format, params object[] args)
        {
            if (!_isDebugBuild)
                return;

            Debug.Log(FormatMessage(INFO_COLOR, string.Format(format, args)));
        }

        public void LogFormat(string category, string format, params object[] args)
        {
            if (!_isDebugBuild)
                return;

            Debug.Log(FormatMessageWithCategory(INFO_COLOR, category, string.Format(format, args)));
        }

        public void LogWarning(object message)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogWarning(FormatMessage(WARNING_COLOR, message));
        }

        public void LogWarning(string category, object message)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogWarning(FormatMessageWithCategory(WARNING_COLOR, category, message));
        }

        public void LogWarningFormat(string format, params object[] args)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogWarningFormat(FormatMessage(WARNING_COLOR, string.Format(format, args)));
        }

        public void LogWarningFormat(string category, string format, params object[] args)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogWarningFormat(FormatMessageWithCategory(WARNING_COLOR, category, string.Format(format, args)));
        }

        public void LogError(object message)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogError(FormatMessage(ERROR_COLOR, message));
        }

        public void LogError(string category, object message)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogError(FormatMessageWithCategory(ERROR_COLOR, category, message));
        }

        public void LogErrorFormat(string format, params object[] args)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogErrorFormat(FormatMessage(ERROR_COLOR, string.Format(format, args)));
        }

        public void LogErrorFormat(string category, string format, params object[] args)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogErrorFormat(FormatMessageWithCategory(ERROR_COLOR, category, string.Format(format, args)));
        }

        public void LogException(Exception exception)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogError(FormatMessage(ERROR_COLOR, exception.Message));
        }

        public void LogException(string category, Exception exception)
        {
            if (!_isDebugBuild)
                return;

            Debug.LogError(FormatMessageWithCategory(ERROR_COLOR, category, exception.Message));
        }

        private string FormatMessage(string color, object message)
        {
            return $"<color={color}>{message}</color>";
        }

        private string FormatMessageWithCategory(string color, string category, object message)
        {
            return $"<color={color}><b>[{category}]</b> {message}</color>";
        }
    }
}
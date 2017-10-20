using WFS.Entities.Enumerations;
using WFS.Entities.Models;
using System;

namespace WFS.Entities.Interfaces
{
    public interface ILog
    {
        void Logger(LogType logtype, LogLevel loglevel, Exception ex, String message, CurrentUser currentUser);
        void Logger(LogType logtype, LogLevel loglevel, Exception ex, String message);
    }
}
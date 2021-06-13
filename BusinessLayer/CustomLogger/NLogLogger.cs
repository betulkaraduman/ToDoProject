using BusinessLayer.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string Message)
        {
           var logger= LogManager.GetLogger("fileLogger");
            logger.Log(LogLevel.Error, Message);
        }
    }
}

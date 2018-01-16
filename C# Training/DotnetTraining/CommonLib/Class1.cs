using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
namespace CommonLib
{
    
    public static class Logger
    {
      public static void LogMessage(string message, EventLogEntryType type)
      {
      EventLog log = new EventLog("Nichi-in", Environment.MachineName, Process.GetCurrentProcess().ProcessName);
      log.WriteEntry(message, type);
      }
    }
    public class InsertionFailedException : ApplicationException
    {
      public InsertionFailedException()
      {

      }

      public InsertionFailedException(string message) :base(message)
      {
      Logger.LogMessage(message, EventLogEntryType.Error);
      }
      public InsertionFailedException(string message, Exception innerException) :base(message, innerException)
      {
      var details = string.Format($"message\nThe Inner Exception:{innerException.Message}");
      Logger.LogMessage(details, EventLogEntryType.Error);
    }
    }
}

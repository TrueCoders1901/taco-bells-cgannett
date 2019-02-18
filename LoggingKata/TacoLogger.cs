using System;
using System.Collections.Generic;

namespace LoggingKata
{
    public class TacoLogger : ILog
    {
        public static List<string> AllLogs = new List<string>();
        public static bool isConsoleLog = true;

        public void LogFatal(string log, Exception exception = null)
        {
            log = ($"Fatal: {log}, Exception {exception}");

            if( isConsoleLog )
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(log);
                Console.ResetColor();
            }

            AllLogs.Add(log);
        }

        public void LogError(string log, Exception exception = null)
        {
            log = ($"ERROR: {log}, Exception {exception}");

            if( isConsoleLog )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(log);
                Console.ResetColor();
            }

            AllLogs.Add(log);
        }

        public void LogWarning(string log)
        {
            log = "Warning: " + log;

            if( isConsoleLog )
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(log);
                Console.ResetColor();
            }

            AllLogs.Add(log);
        }

        public void LogInfo(string log)
        {
            log = ($"INFO: {log}");

            if( isConsoleLog )
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(log);
                Console.ResetColor();
            }

            AllLogs.Add(log);
        }

        public void LogDebug(string log)
        {
            log = ($"Debug: {log}");

            if( isConsoleLog )
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(log);
                Console.ResetColor();
            }

            AllLogs.Add(log);
        }
    }
}
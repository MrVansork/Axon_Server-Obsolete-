using System;
using System.Collections.Generic;
using System.Text;

namespace Axon_Server
{
    public static class Log
    {
        private static int _info    = 0x0001;
        private static int _debug   = 0x0010;
        private static int _warn    = 0x0100;
        private static int _error   = 0x1000;

        private static int _flags   = 0x0000;

        public static void i(string tag, string message)
        {
            Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} I[{tag}] - {message}");
        }

        public static void d(string tag, string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} D[{tag}] - {message}");
            Console.ResetColor();
        }

        public static void w(string tag, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} W[{tag}] - {message}");
            Console.ResetColor();
        }

        public static void e(string tag, string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} E[{tag}] - {message}");
            Console.ResetColor();
        }

    }
}

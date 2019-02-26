using System;
using System.Collections.Generic;
using System.Text;

namespace Axon_Server
{
    public static class Log
    {

        #region Levels
        public const int Info    = 0x0001;
        public const int Debug   = 0x0010;
        public const int Warning = 0x0100;
        public const int Error   = 0x1000;

        private static int _flags   = 0x1101;
        #endregion

        #region Methods
        public static void add(int flag)
        {
            _flags += flag;
        }

        public static void remove(int flag)
        {
            _flags -= flag;
        }

        public static void set(int flags)
        {
            _flags = flags;
        }

        public static void i(string tag, string message)
        {
            if ((_flags & Info) == Info)
                Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} I[{tag}] - {message}");
        }

        public static void d(string tag, string message)
        {
            if ((_flags & Debug) == Debug)
            { 
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} D[{tag}] - {message}");
                Console.ResetColor();
            }
        }

        public static void w(string tag, string message)
        {
            if ((_flags & Warning) == Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} W[{tag}] - {message}");
                Console.ResetColor();
            }
        }

        public static void e(string tag, string message)
        {
            if ((_flags & Error) == Error)
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} E[{tag}] - {message}");
                Console.ResetColor();
            }
        }
        #endregion
    }
}

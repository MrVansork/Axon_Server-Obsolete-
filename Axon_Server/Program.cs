using System;

namespace Axon_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Constants.BigTitle);
            Console.WriteLine("  Server");
            Console.WriteLine("---------------------------------------------\n");

            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "debug":
                        Log.add(Log.Debug);
                        break;
                    default:
                        Log.w("Program", $"'{arg}' is not recognized as an argument");
                        break;
                }
            }

            Console.Write("\nPulse cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}

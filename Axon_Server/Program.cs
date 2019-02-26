using System;

namespace Axon_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Constants.BigTitle);
            Console.WriteLine("  Server");
            Console.WriteLine("---------------------------------------------");


            Console.Write("Pulse cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}

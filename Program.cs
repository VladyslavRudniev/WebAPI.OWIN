using System;
using Microsoft.Owin.Hosting;

namespace WebAPI.OWIN
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:9001"))
            {
                Console.WriteLine("Press key to exit...");
                Console.ReadKey();
            }
        }
    }
}
using Microsoft.Owin.Hosting;
using System;

namespace MLNotification.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:11111"))
            {
                Console.WriteLine("Hub on  http://localhost:11111");
                Console.ReadLine();
            }
        }
    }
}

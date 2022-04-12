using Microsoft.Extensions.DependencyInjection;
using Services;
using System;

namespace RT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            //setup dependecy injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFunctions, Functions>()
                .BuildServiceProvider();

            // service
            var functions = serviceProvider.GetService<IFunctions>();

            var app = new Application(functions);

            app.Run();
        }
    }
}

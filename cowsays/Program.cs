using System;
using CommandDotNet;

namespace cowsays
{
    class Program
    {
        static void Main(string[] args)
        {
            AppRunner<CowSays> appRunner = new AppRunner<CowSays>();

            appRunner.Run(args);
        }
    }
}

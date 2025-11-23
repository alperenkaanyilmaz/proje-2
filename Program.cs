using System;
using System.Threading.Tasks;

namespace AstroTestPort
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("AstroTest (C# Standalone) - Başlatılıyor...");
            var settings = Settings.Load("config.ini");
            var game = new GameManager(settings);
            await game.StartAsync();
        }
    }
}

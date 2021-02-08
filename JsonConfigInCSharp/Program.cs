using System;
using Microsoft.Extensions.Configuration;

namespace JsonConfigInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.configurationbuilder
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("settings.json", false, true) // add as content / copy-always
                .Build();

            Console.WriteLine(config["simple"]);
            Console.WriteLine(config["complex:but_very:simple"]);
        }
    }
}

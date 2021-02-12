using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace JsonConfigInCSharp
{
    public class MyConfig
    {
        public string Simple { get; set; }
    }

    public class MyDetailConfig
    {
        public string Simple { get; set; }
    }

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

            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/
            var myConfig = config.Get<MyConfig>();
            Console.WriteLine(myConfig.Simple);

            var myComplexConfig = config.GetSection("complex:but_very").Get<MyConfig> ();
            Console.WriteLine(myComplexConfig.Simple);

            // --------------------------------------------------------------------------


            Console.WriteLine("".PadLeft(60, '-'));
            Console.WriteLine("Configuration:");
            config
                .AsEnumerable()
                .OrderBy(x => x.Key)
                .ToList()
                .ForEach(x => Console.WriteLine("|" + x.Key + "|" + x.Value + "|")); // see that it is a key-value store and not a complex structured json (the json is a lie!)
            Console.WriteLine("".PadLeft(60, '-'));
            Console.WriteLine("Current directory:" + Environment.CurrentDirectory);
            Console.WriteLine("".PadLeft(60, '-'));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
